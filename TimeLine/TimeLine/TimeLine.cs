using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeLine
{
    public partial class TimeLine : Form
    {
 
        public TimeLine()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
        private void TimeLine_Load(object sender, EventArgs e)
        {
            DataGridViewImageColumn status = new DataGridViewImageColumn();
            status.Name = "image";
            status.HeaderText = "图片";
            status.Width = 150;
            dataGridView1.Columns.Insert(2, status);
            int i = 0;
            string constr = "server=localhost;User Id=root;password=980817;Database=timeline";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlDataReader reader = null;
            MySqlCommand mycom = mycon.CreateCommand();
            string command = "select account,information,image,time from infos natural join users order by time desc";
            mycom.CommandText = command;
            reader = mycom.ExecuteReader();
            while (reader.Read() && i<5)
            {
                int index = this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[index].Cells[0].Value = reader[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = reader[1].ToString();
                string path = reader[2].ToString();
                if (path != "")
                {
                   path = Application.StartupPath + "\\image\\" + path;
                   this.dataGridView1.Rows[index].Cells[2].Value = Image.FromFile(path);
                }
                else
                {
                    path = Application.StartupPath + "\\image\\" + "nothing.png";
                    this.dataGridView1.Rows[index].Cells[2].Value = Image.FromFile(path);
                }
                
                string time = reader[3].ToString();
                DateTime date1 = Convert.ToDateTime(time);
                DateTime date2 = DateTime.Now;
                TimeSpan ts = date2.Subtract(date1);
                if (ts.TotalMinutes < 60)
                {
                    int a = (int)ts.TotalMinutes;
                    this.dataGridView1.Rows[index].Cells[3].Value = a.ToString() + "分钟前";
                }
                else
                {
                    int a = (int )ts.TotalMinutes / 60;
                    this.dataGridView1.Rows[index].Cells[3].Value = a.ToString() + "小时前";
                }
                i++;
            }

            dataGridView1.AllowUserToAddRows = false;
            reader.Close();
            mycon.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Create create = new Create();
            create.ShowDialog();
        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int index = 0;
            int i = 0;
            string constr = "server=localhost;User Id=root;password=980817;Database=timeline";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlDataReader reader = null;
            MySqlCommand mycom = mycon.CreateCommand();
            string command = "select account,information,image,time from users natural join infos order by time desc";
            mycom.CommandText = command;
            reader = mycom.ExecuteReader();
            if(i<5)this.dataGridView1.Rows.Add();
            while (reader.Read() && i < 5 )
            {
                this.dataGridView1.Rows[index].Cells[0].Value = reader[0].ToString();
                this.dataGridView1.Rows[index].Cells[1].Value = reader[1].ToString();
                string path = reader[2].ToString();
                if (path != "") {
                   path = Application.StartupPath + "\\image\\" + path;
                   this.dataGridView1.Rows[index].Cells[2].Value = Image.FromFile(path);
                }
                else
                {
                    path = Application.StartupPath + "\\image\\" + "nothing.png";
                    this.dataGridView1.Rows[index].Cells[2].Value = Image.FromFile(path);
                }
                string time = reader[3].ToString();
                DateTime date1 = Convert.ToDateTime(time);
                DateTime date2 = DateTime.Now;
                TimeSpan ts = date2.Subtract(date1);
                if (ts.TotalMinutes < 60)
                {
                    int a = (int)ts.TotalMinutes;
                    this.dataGridView1.Rows[index].Cells[3].Value = a.ToString() + "分钟前";
                }
                else
                {
                    int a = (int)ts.TotalMinutes / 60;
                    this.dataGridView1.Rows[index].Cells[3].Value = a.ToString() + "小时前";
                }
                index++;
                i++;
            }
            reader.Close();
            mycon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show show = new Show();
            show.ShowDialog();
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
