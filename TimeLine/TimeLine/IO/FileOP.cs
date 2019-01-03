using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeLine.Entity;

namespace TimeLine.IO
{
    public class FileOP
    {
        public FileOP() { }

        public Msg OpenPic()
        {
            Msg msg = new Msg();
            string time = DateTime.Now.ToString("yyyyMMddHHmmss", DateTimeFormatInfo.InvariantInfo);
            OpenFileDialog openPic = new OpenFileDialog();
            openPic.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.png";
            openPic.FilterIndex = 1;
            if (openPic.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(openPic.FileName);
                if (fileInfo.Length > 204800)
                {
                    MessageBox.Show("上传图片不能大于200K");
                }
                else
                {
                    string path = openPic.FileName;
                    int position = path.LastIndexOf("\\");
                    string filename = path.Substring(position + 1);
                    if (System.IO.Directory.Exists(Application.StartupPath + "\\image"))
                    {
                        File.Copy(path, Application.StartupPath + "\\image\\" + time + filename);
                    }
                    else
                    {
                        Directory.CreateDirectory(Application.StartupPath + "\\image");
                        File.Copy(path, Application.StartupPath + "\\image\\" + time + filename);
                    }
                    msg.ImagePath = time + filename;
                    MessageBox.Show("图片上传成功");
                }
            }
            return msg;
        }
    }
}
