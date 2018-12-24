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

namespace TimeLine
{
    public partial class Create : Form
    {
        public static string mypath;

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
            string path = "";
            string filename = "";
            string time = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            OpenFileDialog openPic = new OpenFileDialog();
            openPic.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.png";
            openPic.FilterIndex = 1;
            if(openPic.ShowDialog()== DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openPic.FileName);
                if(fileInfo.Length > 2048000)
                {
                    MessageBox.Show("上传图片不能大于2000K");
                }
                else
                {
                    path = openPic.FileName;
                    int position = path.LastIndexOf("\\");
                    filename = path.Substring(position + 1);
                    if(System.IO.Directory.Exists(Application.StartupPath + "\\image"))
                    {
                       File.Copy(path, Application.StartupPath + "\\image\\" +time + filename );
                    }
                    else
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\image");
                        File.Copy(path, Application.StartupPath + "\\image\\" +time + filename);
                    }
                    mypath = time+filename;
                    MessageBox.Show("图片上传成功");
                }
            }
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
                string constr = "server=localhost;User Id=root;password=980817;Database=timeline;charset=utf8";
                string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
                MySqlConnection mycon = new MySqlConnection(constr);
                mycon.Open();
                MySqlCommand mycom = mycon.CreateCommand();
                string command = "insert into infos values('" + Program.user_id + "','" + content.ToString() + "','" + mypath + "','" + time + "')";
                mycom.CommandText = command;
                mycom.ExecuteNonQuery();
                command = null;
                MessageBox.Show("发表成功！", "提示");
                this.Close();
                mycon.Close();
            }
            
        }

        private void Create_Load(object sender, EventArgs e)
        {
            mypath = "";
        }
    }
}
