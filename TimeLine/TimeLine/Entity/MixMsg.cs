using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.Entity
{
    public class MixMsg
    {
        public string Account { get; set; }
        public string Image { get; set; }
        public string Information { get; set; }
        public string Time { get; set; }

        public MixMsg()
        {
            this.Account = "";
            this.Image = "";
            this.Information = "";
            this.Time = "";
        }

        public MixMsg(string acc,string image,string info,string time)
        {
            this.Account = acc;
            this.Image = image;
            this.Information = info;
            this.Time = time;
        }

    }
}
