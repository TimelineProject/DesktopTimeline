using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Entity;
using TimeLine.Interface;

namespace TimeLine.Server
{
    public class UserDAO:IUserDAO
    {
        private IDatabase mydatabase;
        private MySqlDataReader reader;
        
        public UserDAO(IDatabase db)
        {
            mydatabase = db;
            reader = null;
        }

        public int RegisterUser(User user)
        {
            if (GetUserNumByAccount(user) > 0)
            {
                throw new Exception();
            }
            string command = "insert into users (account,password) values('" + user.Username + "','" + user.Password + "')";
            int a = mydatabase.Execute(command);
            return a;
        }

        public int GetUserNumByAccountAndPassword(User user)
        {
            string command = "select account,password from users where account='" + user.Username + "' and password='" + user.Password + "'";
            int a = mydatabase.DataNum(command);
            return a;
        }

        public int GetUserNumByAccount(User user)
        {
            string command = "select account from users where account='" + user.Username + "'";
            int a = mydatabase.DataNum(command);
            return a;
        }

        public int getUserIdByUser(User user)
        {
            int a=0;
            string command = "select user_id from users where account ='" + user.Username + "' and password='" + user.Password + "'";
            mydatabase.CreateCommand(command);
            reader = mydatabase.GetCommand().ExecuteReader();
            while (reader.Read())
            {
                a = Convert.ToInt32(reader[0].ToString());
            }
            mydatabase.CloseDb();
            reader.Close();
            return a;
        }
    }
}
