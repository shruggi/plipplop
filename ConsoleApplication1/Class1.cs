using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApplication1
{
    class DatabaseHandler
    {
        protected string DbConnString;
        protected SqlConnection DbConn;

        public void DatabaseHandler(string DbConnString) {
            // Properties.Settings.Default.MopidyDatabaseConnectionString;
             this.DbConnString = DbConnString;
             DbConn = new SqlConnection();
             DbConn.ConnectionString = DbConnString;
        }

        public void connect() 
        {
            if (DbConn.State != System.Data.ConnectionState.Open)
            {
                try { DbConn.Open(); }
                catch (Exception e) { Console.WriteLine("Error opening database connection: {0}", e); }
                
                Console.WriteLine("Database connection opened.");
            }
            else
            {
                Console.WriteLine("Database connection opened.");
            }
        }
        public void disconnect()
        {
            if (DbConn.State == System.Data.ConnectionState.Open)
            {
                DbConn.Close();
                Console.WriteLine("Database connection closed.");
            }
            else
            {
                Console.WriteLine("Database connection already closed/broken/whatever.");
            }
        }
    }
}
