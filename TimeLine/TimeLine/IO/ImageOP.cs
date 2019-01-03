using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            try{
              return Image.FromFile(path);
            }
            catch (FileNotFoundException e) {
                return null;
            }
            catch (OutOfMemoryException e)
            {
                return null;
            }
        }
    }
}
