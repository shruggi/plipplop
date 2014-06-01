using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data;
using System.IO;
using Libmpc;
using Microsoft.AspNet.SignalR.Client;
using Renci.SshNet;

namespace ConsoleApplication1
{
    class SoitinStateMachine
    {
        public enum SoitinStates
        {
            INIT,
            MONITOR,
            FILL,
            UPDATE,
            HALT
        }
        protected Queue<SoitinStates> StateQueue = new Queue<SoitinStates>();
        
        //  protected SoitinStates SoitinState;  
        protected MpcConnection MPConnection;
        protected Mpc MPClient;
        protected IHubProxy msgrelay = null;

        protected string Address;
        protected int Port;

        // used for triggering queue function
        protected int playlistsize = 0;

        public SoitinStateMachine(string Address, int Port, IHubProxy msgrelay)
        {
            StateQueue.Enqueue(SoitinStates.INIT);

            this.Address = Address;
            this.Port = Port;
            this.msgrelay = msgrelay;

        }

        public void QueueUpdate()
        {
            Console.Write("Queued UPDATE state.");
            StateQueue.Enqueue(SoitinStates.UPDATE);
        }

        public void connect()
        {
            IPEndPoint server = new IPEndPoint(IPAddress.Parse(Address), Port);
            while (true)
            {
                try
                {
                    MPConnection = new MpcConnection(server);
                    Console.WriteLine("Succesfully connected!");
                    break;
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Unable to connect (" + e.Message + "), Trying again in 3 seconds");
                    Thread.Sleep(3000);

                }
            }
            Console.WriteLine("Creating Mpc object");
            MPClient = new Mpc();
            MPClient.Connection = MPConnection;

            // If not coming from update loop (ie. queue is empty) -> queue default loop state.
            if (StateQueue.Count == 0)
            {
                StateQueue.Enqueue(SoitinStates.MONITOR);
            }
        }

        public void run()
        {
            //Console.WriteLine(SoitinState.ToString());
            // Pop next state from queue
            SoitinStates SoitinState = StateQueue.Dequeue();
            switch (SoitinState)
            {
                case SoitinStates.INIT:
                    Console.WriteLine("Connecting");
                    connect();
                    break;
                case SoitinStates.MONITOR:
                    try
                    {
                        MpdStatus status = MPClient.Status();
                        MpdFile currenttrack = MPClient.CurrentSong();

                        var playlist = MPClient.PlaylistInfo();
                        using (MopidyContext db = new MopidyContext()) 
                        {
                            var query = (from a in db.PlaylistSet join b in db.TrackSet on a.TrackId equals b.Id select b.weight).Sum();
                            Console.WriteLine(query);
                        }
                        

                        Console.WriteLine(status.Volume);
                        
                        if (currenttrack != null && status.State == MpdState.Play)
                        {
                            string trackname = currenttrack.Artist.ToString() + " - " + currenttrack.Title.ToString();
                            msgrelay.Invoke("StatusUpdate", trackname, status.TimeElapsed, status.TimeTotal);
                            Console.WriteLine(currenttrack.Title.ToString());
                        }
                        Thread.Sleep(1000);
                    }
                    catch
                    {
                        Console.WriteLine("Error reading socket, trying to reconnect.");
                        SoitinState = SoitinStates.INIT;
                    }
                    break;
                case SoitinStates.FILL:
                    break;
                case SoitinStates.UPDATE:
                    Console.WriteLine("Refreshing local database");

                    List<MpdFile> filelist = MPClient.ListAllInfo("\"/\"");
                    using (var db = new MopidyContext())
                    {

                        foreach (MpdFile file in filelist)
                        {
                            var jee = db.TrackSet.Where(a => a.album == file.Album && a.artist == file.Artist && a.title == file.Title).ToList();
                            if (jee.Count > 0)
                            {
                                continue;
                            }
                            var track = new Track();
                            track.album = file.Album;
                            track.title = file.Title;
                            track.track = file.Track;
                            track.artist = file.Artist;
                            track.genre = file.Genre;
                            track.filename = file.File;
                            track.runningtime = file.Time;
                            track.weight = 1;
                            if (file.HasDate)
                            {
                                track.date = DateTime.Parse(file.Date);
                            }
                            //track.CorePlaylistId = 0;
                            
                            db.TrackSet.Add(track);
                            
                        }
                        db.SaveChanges();
                    }

                    

                    //SqlParameter dbname = new SqlParameter("@dbname", "MopidyDatabaseWeightsSum");
                    //List<SqlParameter> parameterlist = new List<SqlParameter>();
                    //DataTable table = DBHandler.RunSelectQuery("SELECT * from MopidyDatabaseWeightsSum;", CommandType.Text, parameterlist);
                    //DBHandler.disconnect();                       
                    
                    //MPConnection.Disconnect();
                    //StateQueue.Enqueue(SoitinStates.INIT);
                    break;
                case SoitinStates.HALT:
                    break;
            }
            // If queue is empty, put default loop state in, otherwise just keep emptying the queue
            if (StateQueue.Count == 0)
            {
                StateQueue.Enqueue(SoitinStates.MONITOR);
            }
        }



    }
}