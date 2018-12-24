using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace TimeLine
{
    public partial class FormLogin : Form
    {
        public static bool isValidUser;
        private int errorTime = 3;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxUserName.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            errorTime -= 1;
            string username = textBoxUserName.Text.Trim();
            string passw = textBoxPassword.Text.Trim();
            MySqlConnection mycon = new MySqlConnection(Program.constr);
            mycon.Open();
            MySqlCommand mycom = mycon.CreateCommand();
            string command = "select account,password from users where account='" + username + "' and password='"+passw+"'";
            mycom.CommandText = command;
            MySqlDataAdapter myDA = new MySqlDataAdapter();
            myDA.SelectCommand = mycom;
            DataSet myDS = new DataSet();
            int n = myDA.Fill(myDS, "users");
            if(n != 0)
            {
                MessageBox.Show("登陆成功!");
                Program.isValidUser = true;
                command = "select user_id from users where account ='" + username + "' and password='" + passw + "'";
                mycom.CommandText = command;
                MySqlDataReader reader = null;
                reader = mycom.ExecuteReader();
                while (reader.Read())
                {
                    Program.user_id =Convert.ToInt32(reader[0].ToString());
                }
                reader.Close();
                Program.user = username;
                this.Close();
            }
            else
            {
                if (errorTime > 0)
                {
                    MessageBox.Show("用户名或密码输入错误。请重新输入！还有" + errorTime.ToString() + "次机会");
                    textBoxUserName.Text = "";
                    textBoxPassword.Text = "";
                    textBoxUserName.Focus();
                }
                else
                {
                    MessageBox.Show("你输入的用户名或密码已达到上限，将退出程序，请稍后再试");
                    this.Close();
                }
            }
            mycon.Close();
           
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Program.isValidUser = false;
            this.Close();
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister register = new FormRegister();
            register.ShowDialog();
        }
    }
}
