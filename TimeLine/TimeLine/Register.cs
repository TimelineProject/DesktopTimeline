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
            string constr = "server=localhost;User Id=root;password=980817;Database=timeline";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycom = mycon.CreateCommand();
            string command = "select account from users where account='" + name + "'";
            mycom.CommandText = command;
            MySqlDataAdapter myDA = new MySqlDataAdapter();
            myDA.SelectCommand = mycom;
            DataSet myDS = new DataSet();
            int n = myDA.Fill(myDS, "users");
            if (n != 0)
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
                command = "insert into users (account,password) values('" + textBoxUserName.Text+ "','"+textBoxPassword.Text+"')";
                mycom.CommandText = command;
                mycom.ExecuteNonQuery();
                command = null;
                MessageBox.Show("注册成功！", "提示");
                this.Close();
            }
            mycon.Close();
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
