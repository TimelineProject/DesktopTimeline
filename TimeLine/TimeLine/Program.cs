using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeLine.Entity;

namespace TimeLine
{
    static class Program
    {
        public static User programUser;
        public static int user_id;
        public static string user;
        //各位使用数据库的时候自行更改
        public static string constr = "server=localhost;User Id=root;password=;Database=software;charset=utf8";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            programUser = new User();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
            if(programUser.ValidUser)
            {
                Application.Run(new TimeLine());
            }
        }
    }
}
