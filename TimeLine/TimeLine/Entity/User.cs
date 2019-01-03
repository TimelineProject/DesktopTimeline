using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.Entity
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public bool ValidUser { get; set; }
        public User()
        {
            Username = "";
            Password = "";
        }
        public User(string name)
        {
            Username = name;
        }
        public User(string name,string pw)
        {
            Username = name;
            Password = pw;
        }
        
    }
}
