using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeLine.Entity;
using TimeLine.IO;
using TimeLine.Server;

namespace TimeLine
{
    public partial class Create : Form
    {
        private static Msg msg;

        public Create()
        {
            InitializeComponent();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxInput.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileOP fileOP = new FileOP();
            msg = fileOP.OpenPic();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string content = textBoxInput.Text.Trim();
            if (content == "")
            {
                MessageBox.Show("内容不能为空", "提示");
            }
            else
            {
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                msg.Content = content;
                msg.Time = time;
                MessageDAO messageDAO = new MessageDAO(new Database(Program.constr));
                if(messageDAO.InsertDataByUserAndMessage(Program.programUser, msg) == 1)
                {
                    MessageBox.Show("发表成功！", "提示");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("发表失败，请重新尝试！", "提示");
                }
            }
            
        }

        private void Create_Load(object sender, EventArgs e)
        {
            msg = new Msg();
        }
    }
}
