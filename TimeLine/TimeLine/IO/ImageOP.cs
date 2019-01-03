using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.IO
{
    public class ImageOP
    {
        public ImageOP() { } 

        public Image GetImageByPath(string path)
        {
            return Image.FromFile(path);
        }
    }
}
