using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        private IDataReader reader;

        public MessageDAO(IDatabase db)
        {
            mydatabase = db;
            reader = null;
        }

        public int InsertDataByUserAndMessage(User user,Msg message)
        {
            string command = "insert into infos values('" + user.UserId + "','" + message.Content + "','" + message.ImagePath + "','" + message.Time + "')";
            int a = mydatabase.Execute(command);
            if (a < 1)
            {
                throw new Exception();
            }
            return a;
        }

        public List<MixMsg> GetData(IDataReader reader)
        {
            List<MixMsg> arrayList = new List<MixMsg>();
            //string command = "select account,information,image,time from infos natural join users order by time desc";
            //reader = mydatabase.GetReader(command);
            while (reader.Read())
            {
                MixMsg mixMsg = new MixMsg();
                mixMsg.Account = Convert.ToString(reader["user_id"]);
                mixMsg.Information = Convert.ToString(reader["information"]);
                if (Convert.ToString(reader["image"]) == "")
                {
                    mixMsg.Image =  Application.StartupPath + "\\image\\" + "nothing.png";
                }else
                {
                    mixMsg.Image = Application.StartupPath + "\\image\\" + Convert.ToString(reader[2]);
                }
                string time = Convert.ToString(reader["time"]);
                DateTime date1 = DateTime.Parse(time);
                //DateTime date1 = DateTime.Now;
                DateTime date2 = DateTime.Now;
                TimeSpan ts = date2.Subtract(date1);
                if (ts.TotalMinutes < 60)
                {
                    int a = Convert.ToInt32(ts.TotalMinutes);
                    mixMsg.Time = Convert.ToString(a) + "分钟前";
                }
                else
                {
                    int a = (int)ts.TotalMinutes / 60;
                    mixMsg.Time = Convert.ToString(a) + "小时前";
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
            if (a < 0)
            {
                throw new Exception();
            }
            return a;
        }

    }
}
