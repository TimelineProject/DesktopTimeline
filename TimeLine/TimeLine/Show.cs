using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeLine.Entity;
using TimeLine.IO;
using TimeLine.Server;

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
            Database database = new Database(Program.constr);
            ImageOP imageOP = new ImageOP();
            MessageDAO messageDAO = new MessageDAO(database);
            string command = "select account,information,image,time from infos natural join users order by time desc";
            IDataReader reader = database.GetReader(command);
            List<MixMsg> arrayList = messageDAO.GetData(reader);

            int i = 0;
            while (i < arrayList.Count)
            {
                int index = this.dataGridView1.Rows.Add();
                MixMsg mx  = arrayList[i];
                this.dataGridView1.Rows[index].Cells[0].Value = mx.Account;
                this.dataGridView1.Rows[index].Cells[1].Value = mx.Information;
                this.dataGridView1.Rows[index].Cells[2].Value = imageOP.GetImageByPath(mx.Image);
                this.dataGridView1.Rows[index].Cells[3].Value = mx.Time;
                i++;
            }
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}
