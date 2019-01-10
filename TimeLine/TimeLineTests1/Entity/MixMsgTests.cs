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
    public class MixMsgTests
    {
        private MixMsg mixMsg;

        [TestInitialize()]
        public void SetUp()
        {
            mixMsg = new MixMsg();
        }

        [TestMethod()]
        public void MixMsgTestAccount()
        {
            mixMsg.Account = "1";
            Assert.AreEqual("1", mixMsg.Account);
        }

        [TestMethod()]
        public void MixMsgTestTime()
        {
            mixMsg.Time = "1";
            Assert.AreEqual("1", mixMsg.Time);
        }

        [TestMethod()]
        public void MixMsgTestInfo()
        {
            mixMsg.Information = "1";
            Assert.AreEqual("1", mixMsg.Information);
        }

        [TestMethod()]
        public void MixMsgTestImage()
        {
            mixMsg.Image = "1";
            Assert.AreEqual("1", mixMsg.Image);
        }
    }
}