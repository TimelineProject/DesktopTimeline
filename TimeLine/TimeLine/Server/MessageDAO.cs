using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeLine.Entity;
using TimeLine.Interface;

namespace TimeLine.Server
{
    public class MessageDAO:IMessageDAO
    {
        private IDatabase mydatabase;
        private MySqlDataReader reader;

        public MessageDAO(IDatabase db)
        {
            mydatabase = db;
            reader = null;
        }

        public int InsertDataByUserAndMessage(User user,Msg message)
        {
            string command = "insert into infos values('" + user.UserId + "','" + message.Content + "','" + message.ImagePath + "','" + message.Time + "')";
            int a = mydatabase.Execute(command);
            return a;
        }

        public List<MixMsg> GetData()
        {
            List<MixMsg> arrayList = new List<MixMsg>();
            string command = "select account,information,image,time from infos natural join users order by time desc";
            mydatabase.CreateCommand(command);
            reader = mydatabase.GetCommand().ExecuteReader();
            while (reader.Read())
            {
                MixMsg mixMsg = new MixMsg();
                mixMsg.Account = reader[0].ToString();
                mixMsg.Information = reader[1].ToString();
                if (reader[2].ToString() == "")
                {
                    mixMsg.Image =  Application.StartupPath + "\\image\\" + "nothing.png";
                }else
                {
                    mixMsg.Image = Application.StartupPath + "\\image\\" + reader[2].ToString();
                }
                string time = reader[3].ToString();
                DateTime date1 = Convert.ToDateTime(time);
                DateTime date2 = DateTime.Now;
                TimeSpan ts = date2.Subtract(date1);
                if (ts.TotalMinutes < 60)
                {
                    int a = (int)ts.TotalMinutes;
                    mixMsg.Time = a.ToString() + "分钟前";
                }
                else
                {
                    int a = (int)ts.TotalMinutes / 60;
                    mixMsg.Time = a.ToString() + "小时前";
                }
                arrayList.Add(mixMsg);
            }
            mydatabase.CloseDb();
            reader.Close();
            return arrayList;
        }

        public int GetNum()
        {
            string command = "select account,information,image,time from infos natural join users order by time desc";
            int a = mydatabase.Execute(command);
            return a;
        }

    }
}
