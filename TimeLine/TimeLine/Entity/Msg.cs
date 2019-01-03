using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.Entity
{
    public class Msg
    {
        public string ImagePath { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }

        public Msg()
        {
            this.ImagePath = "";
            this.Content = "";
            this.Time = "";
        }

        public Msg(string mycontent,string myimage,string time)
        {
            this.Content = mycontent;
            this.ImagePath = myimage;
            this.Time = time;
        }
    }
}
