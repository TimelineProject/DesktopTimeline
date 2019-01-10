using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLine.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.IO.Tests
{
    [TestClass()]
    public class ImageOPTests
    {
        private ImageOP image;
        [TestInitialize]
        public void SetUp()
        {
            image = new ImageOP();
        }
        [TestMethod()]
        public void GetImageByPathTest()
        {
            string path = "1";
            Assert.AreEqual(null, image.GetImageByPath(path));
        }
    }
}