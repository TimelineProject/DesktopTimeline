using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeLine
{
    static class Program
    {
        public static bool isValidUser;
        public static int user_id;
        public static string user;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
            if (isValidUser == true)
            {
                Application.Run(new TimeLine());
            }
        }
    }
}
