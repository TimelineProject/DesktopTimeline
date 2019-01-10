using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Interface;

namespace TimeLine.Server
{
    public class Database:IDatabase
    {
        private string mystr;
        private MySqlConnection mycon;
        private MySqlCommand mycom;
        private MySqlDataAdapter myDA;

        public Database(string con)
        {
            mycon = null;
            mycom = null;
            myDA = null;
            mystr = con;
        }
        public MySqlCommand GetCommand()
        {
            return mycom;
        }

        public void ConnectDb()
        {
            mycon = new MySqlConnection(mystr);
            mycon.Open();
        }

        public void CloseDb()
        {
            mycon.Close();
        }

        public void CreateCommand(string command)
        {
            this.ConnectDb();
            mycom = mycon.CreateCommand();
            mycom.CommandText = command;
        }

        public int DataNum(string command)
        {
            this.CreateCommand(command);
            myDA = new MySqlDataAdapter();
            myDA.SelectCommand = mycom;
            DataSet myDS = new DataSet();
            int n = myDA.Fill(myDS);
            mycom = null;
            this.CloseDb();
            return n;
        }

        public int Execute(string com)
        {
            this.CreateCommand(com);
            int n = mycom.ExecuteNonQuery();
            mycom = null;
            this.CloseDb();
            return n;
        } 
        public IDataReader GetReader(string command)
        {
            this.CreateCommand(command);
            MySqlDataReader reader = mycom.ExecuteReader();
            return reader;
        }
    }
}
