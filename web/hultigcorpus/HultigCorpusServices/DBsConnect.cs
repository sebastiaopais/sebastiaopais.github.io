using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HultigCorpusServices
{
    class DBsConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBsConnect(string DBparam)
        {
            Initialize(DBparam);
        }

        //Initialize values
        private void Initialize(string DBparam)
        {
            server = "localhost";
            database = DBparam;
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Open DB");
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                Console.WriteLine("Close DB");
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Count statement
        public long TotalHosts(string domain)
        {
            string query = "";
            if (domain.ToString().Equals("all"))
                query = "SELECT Count(*) FROM hostlist";
            else
                query = "SELECT Count(*) FROM hostlist WHERE hostname LIKE \"%." + domain.ToString().ToLower() + "\"";

            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60000;

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Count statement
        public long TotalPages(string domain)
        {
            string query = "";
            if (domain.ToString().Equals("all"))
                query = "SELECT Count(*) FROM pages";
            else
                query = "SELECT Count(*) FROM pages WHERE hostname LIKE \"%." + domain.ToString().ToLower() + "\"";

            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60000;

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        public long TotalPagesWithTerm(string domain, string term)
        {
            string query = "";
            if (domain.ToString().Equals("all"))
                query = "SELECT Count(*) FROM pages WHERE text LIKE \"%." + term.ToString() + "\"";
            else
                query = "SELECT Count(*) FROM pages WHERE text LIKE \"%." + term.ToString() + "\" AND hostname LIKE \"%." + domain.ToString().ToLower() + "\"";

            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60000;

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        public List<string> HostsList()
        {
            string query = "SELECT hostname FROM hostlist;";

            List<string> list = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60000;

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                    list.Add(dataReader.GetString(0));

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public List<string> HostsListbyDomain(string domain)
        {
            string query = "SELECT hostname FROM hostlist WHERE hostname LIKE \"%." + domain.ToString() + "\"";

            List<string> list = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.CommandTimeout = 60000;

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();                

                //Read the data and store them in the list
                while (dataReader.Read())
                    list.Add(dataReader.GetString(0));

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

    }
}
