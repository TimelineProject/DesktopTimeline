using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeLine.Entity;
using TimeLine.Server;

namespace TimeLine
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string name = textBoxUserName.Text.Trim();
            User user = new User(name);
            UserDAO userDAO = new UserDAO(new Database(Program.constr));
            if (userDAO.GetUserNumByAccount(user)!= 0)
            {
                MessageBox.Show("用户名已存在", "提示");
                textBoxUserName.Text = "";
                textBoxPassword.Text = "";
                textBoxPasswordCheck.Text = "";
            }else if(textBoxPassword.Text != textBoxPasswordCheck.Text)
            {
                MessageBox.Show("两次输入的密码不一致", "提示");
                textBoxPassword.Text = "";
                textBoxPasswordCheck.Text = "";
            }else if(textBoxUserName.Text ==""|| textBoxPassword.Text == "")
            {
                MessageBox.Show("用户名或密码不能为空！", "提示");
            }
            else
            {
                string password = textBoxPassword.Text.Trim();
                user.Password = password;
                if (userDAO.RegisterUser(user) == 1)
                {
                    MessageBox.Show("注册成功！", "提示");
                }
                else
                {
                    MessageBox.Show("注册失败，请重新注册！", "提示");
                }
                this.Close();
            }
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPasswordCheck.UseSystemPasswordChar = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
