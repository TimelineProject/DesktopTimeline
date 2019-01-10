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
    }
}