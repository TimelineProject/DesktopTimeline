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
    public partial class Show : Form
    {
        public Show()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Show_Load(object sender, EventArgs e)
        {
            DataGridViewImageColumn status = new DataGridViewImageColumn();
            status.Name = "image";
            status.HeaderText = "图片";
            status.Width = 150;
            dataGridView1.Columns.Insert(2, status);
            MySqlConnection mycon = new MySqlConnection(Program.constr);
            mycon.Open();
            MySqlDataReader reader = null;
            MySqlCommand mycom = mycon.CreateCommand();
            string command = "select account,information,image,time from infos natural join users order by time desc";
            mycom.CommandText = command;
            reader = mycom.ExecuteReader();
            while (reader.Read())
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
                    int a = (int)ts.TotalMinutes / 60;
                    this.dataGridView1.Rows[index].Cells[3].Value = a.ToString() + "小时前";
                }
            }
            dataGridView1.AllowUserToAddRows = false;
            reader.Close();
            mycon.Close();
        }
    }
}
