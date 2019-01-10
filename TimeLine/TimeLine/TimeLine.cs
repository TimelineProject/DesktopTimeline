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
using TimeLine.Entity;
using TimeLine.IO;
using TimeLine.Server;

namespace TimeLine
{
    public partial class TimeLine : Form
    {
        private int row = 0;
        private int lastn = 0;

        public TimeLine()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void TimeLine_Load(object sender, EventArgs e)
        {
            int index = 0;
            DataGridViewImageColumn status = new DataGridViewImageColumn();
            status.Name = "image";
            status.HeaderText = "图片";
            status.Width = 150;
            dataGridView1.Columns.Insert(2, status);

            int a = 0;
            ImageOP imageOP = new ImageOP();
            Database database = new Database(Program.constr);
            MessageDAO messageDAO = new MessageDAO(database);
            string command = "select account,information,image,time from infos natural join users order by time desc";
            IDataReader reader = database.GetReader(command);
            List<MixMsg> arrayList = messageDAO.GetData(reader);

            int i = 0;
            while (i < arrayList.Count && a < 5)
            {
                index = this.dataGridView1.Rows.Add();
                MixMsg mx = arrayList[i];
                this.dataGridView1.Rows[index].Cells[0].Value = mx.Account;
                this.dataGridView1.Rows[index].Cells[1].Value = mx.Information;
                this.dataGridView1.Rows[index].Cells[2].Value = imageOP.GetImageByPath(mx.Image);
                this.dataGridView1.Rows[index].Cells[3].Value = mx.Time;
                i++;
                a++;
            }
            row = a;
            lastn = a;
            dataGridView1.AllowUserToAddRows = false;

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
            ImageOP imageOP = new ImageOP();
            Database database = new Database(Program.constr);
            MessageDAO messageDAO = new MessageDAO(database);
            string command = "select account,information,image,time from infos natural join users order by time desc";
            IDataReader reader = database.GetReader(command);
            List<MixMsg> arrayList = messageDAO.GetData(reader);

            int n = arrayList.Count();
            if (n == row)
            {
                return;
            }
            else if (n == lastn)
            {
                return;
            }
            else if (n > lastn && n <= 5)
            {
                for (int a = lastn; a < n; a++)
                {
                    this.dataGridView1.Rows.Add();
                }
                int i = 0;
                while (i < arrayList.Count)
                {
                    MixMsg mx = arrayList[i];
                    this.dataGridView1.Rows[i].Cells[0].Value = mx.Account;
                    this.dataGridView1.Rows[i].Cells[1].Value = mx.Information;
                    this.dataGridView1.Rows[i].Cells[2].Value = imageOP.GetImageByPath(mx.Image);
                    this.dataGridView1.Rows[i].Cells[3].Value = mx.Time;
                    i++;
                }
                lastn = n;
            }
            else if(n > 5 && lastn < 5)
            {
                for (int a = lastn; a < 5; a++)
                {
                    this.dataGridView1.Rows.Add();
                }
                int i = 0;

                while (i < arrayList.Count && i < 5)
                {
                    MixMsg mx = arrayList[i];
                    this.dataGridView1.Rows[i].Cells[0].Value = mx.Account;
                    this.dataGridView1.Rows[i].Cells[1].Value = mx.Information;
                    this.dataGridView1.Rows[i].Cells[2].Value = imageOP.GetImageByPath(mx.Image);
                    this.dataGridView1.Rows[i].Cells[3].Value = mx.Time;
                    i++;
                }
                lastn = n;
            }
            else 
            {
                int i = 0;
                int a = 0;
                while (i < arrayList.Count && a < 5)
                {
                    MixMsg mx = arrayList[i];
                    this.dataGridView1.Rows[i].Cells[0].Value = mx.Account;
                    this.dataGridView1.Rows[i].Cells[1].Value = mx.Information;
                    this.dataGridView1.Rows[i].Cells[2].Value = imageOP.GetImageByPath(mx.Image);
                    this.dataGridView1.Rows[i].Cells[3].Value = mx.Time;
                    i++;
                    a++;
                }
            }
            dataGridView1.AllowUserToAddRows = false;
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