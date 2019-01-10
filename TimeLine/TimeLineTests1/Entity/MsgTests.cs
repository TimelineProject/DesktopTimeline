using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.Entity.Tests
{
    [TestClass()]
    public class MsgTests
    {
        private Msg message;

        [TestInitialize]
        public void SetUp()
        {
            message = new Msg();
        }

        [TestMethod()]
        public void MsgTestTime()
        {
            message.Time = "1";
            Assert.AreEqual("1", message.Time);
        }

        [TestMethod()]
        public void MsgTestContent()
        {
            message.Content = "1";
            Assert.AreEqual("1", message.Content);
        }

        [TestMethod()]
        public void MsgTestTimeImagePath()
        {
            message.ImagePath = "1";
            Assert.AreEqual("1", message.ImagePath);
        }
    }
}