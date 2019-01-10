using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLine.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TimeLine.Interface;
using TimeLine.Entity;
using System.Data;

namespace TimeLine.Server.Tests
{
    [TestClass()]
    public class MessageDAOTests
    {
        private Mock<IDatabase> mockdb;
        private IDatabase db;
        private IUserDAO userdao;
        private IMessageDAO messagedao;

        [TestInitialize]
        public void SetUp()
        {
            mockdb = new Mock<IDatabase>();
            db = mockdb.Object;
            userdao = new UserDAO(db);
            messagedao = new MessageDAO(db);
        }

        [TestMethod()]
        public void NormalInsertDataByUserAndMessageTest()
        {
            User user = new User("lkx","123");
            user.UserId = 1;
            Msg message = new Msg("1","2","3");
            string command = "insert into infos values('" + user.UserId + "','" + message.Content + "','" + message.ImagePath + "','" + message.Time + "')";
            mockdb.Setup(d => d.Execute(command)).Returns(2);
            Assert.AreEqual(2, messagedao.InsertDataByUserAndMessage(user, message));
        }

        [TestMethod()]
        public void ExceptionInsertDataByUserAndMessageTest()
        {
            User user = new User("lkx", "123");
            user.UserId = 1;
            Msg message = new Msg("1", "2", "3");
            string command = "insert into infos values('" + user.UserId + "','" + message.Content + "','" + message.ImagePath + "','" + message.Time + "')";
            mockdb.Setup(d => d.Execute(command)).Returns(-1);
            Assert.ThrowsException<Exception>(() => messagedao.InsertDataByUserAndMessage(user,message));
        }

        [TestMethod()]
        public void NormalGetnumTest()
        {
            string command = "select account,information,image,time from infos natural join users order by time desc";
            mockdb.Setup(d => d.Execute(command)).Returns(1);
            Assert.AreEqual(1, messagedao.GetNum());
        }

        [TestMethod()]
        public void ExceptionGetnumTest()
        {
            string command = "select account,information,image,time from infos natural join users order by time desc";
            mockdb.Setup(d => d.Execute(command)).Returns(-1);
            Assert.ThrowsException<Exception>(() => messagedao.GetNum());
        }

        [TestMethod()]
        public void GetDataTest()
        {
            var arrayList = new List<MixMsg>();
            MixMsg one = new MixMsg();
            MixMsg two = new MixMsg();
            MixMsg three = new MixMsg();
            arrayList.Add(one);
            arrayList.Add(two);
            arrayList.Add(three);
            int count = 0;
            var mockdb = new Mock<IDatabase>();
            var messagedao = new MessageDAO(mockdb.Object);
            var mockDatareader = new Mock<IDataReader>();
            mockDatareader.Setup(d => d.Read()).Returns(() => count < 3).Callback(() => count++);
            mockDatareader.Setup(r => r["user_id"]).Returns(()=> arrayList[count-1].Account);
            mockDatareader.Setup(r => r["information"]).Returns(() => arrayList[count - 1].Information);
            mockDatareader.Setup(r => r["image"]).Returns(() => arrayList[count - 1].Image);
            mockDatareader.Setup(r => r["time"]).Returns(() => arrayList[count - 1].Time);
            for(int i = 0; i < 3; i++)
            {
                Assert.AreEqual(arrayList[i].Account, messagedao.GetData(mockDatareader.Object)[i].Account);
            }
        }

    }
}