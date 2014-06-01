using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Libmpc;
using Microsoft.AspNet.SignalR.Client;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Address = "192.168.100.103";
            int Port = 6600;

            var hubConnection = new HubConnection("http://localhost:53731/");
            var msgrelay = hubConnection.CreateHubProxy("MsgHub");
            
            SoitinStateMachine kone = new SoitinStateMachine(Address, Port, msgrelay);

            msgrelay.On<string>("broadcastMessage", (state) =>
            {
                Console.WriteLine("Got stateupdate message");
                kone.QueueUpdate();
                //if (state.CompareTo("UPDATE_DATABASE") == 0)
                //{
                //    kone.QueueUpdate();
                //}
            });
            hubConnection.Start().Wait();
            //msgrelay.Invoke("Send", "Ugalabugala");
            
            while (true)
            {
                kone.run();
            }
            
            //string mpd_address = "192.168.100.103";

            //IPEndPoint server = new IPEndPoint(IPAddress.Parse(mpd_address), 6600);
            //MpcConnection juttu = new MpcConnection(server);
            //Mpc juttu_handler = new Mpc();
            //juttu_handler.Connection = juttu;
            
            //Console.WriteLine("Version: "+juttu.Version);
            //Console.ReadKey();
            //MpdStatus fug = juttu_handler.Status();
            //Console.WriteLine("Songid: " +fug.Volume);
            //string path = "\"/\"";
            //MpdDirectoryListing dirlist = juttu_handler.LsInfo();
            //List<MpdFile> lista = juttu_handler.ListAllInfo(path);

            //string youtubeurl = "\"yt:5ax1ui37qUI\"";


            //juttu_handler.Update();
            
            ////lista.ForEach(Console.WriteLine);

            //Console.ReadKey();
            //juttu.Disconnect();




        }
    }
}
