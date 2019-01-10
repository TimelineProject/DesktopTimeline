using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLine.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.ComponentModel;
using System.IO;
using TimeLine.Entity;
using TimeLine.Interface;
using System.Data;
using MySql.Data.MySqlClient;

namespace TimeLine.Server.Tests
{
    [TestClass()]
    public class UserDAOTests
    {
        private Mock<IDatabase> mockdb;
        private IDatabase db;
        private IUserDAO userdao;

        [TestInitialize]
        public void SetUp()
        {
            mockdb = new Mock<IDatabase>();
            db = mockdb.Object;
            userdao = new UserDAO(db);
        }

        [TestMethod()]
        public void RegisterNormalUserTest()
        {
            User user = new User("lkx","123");
            string command = "select account from users where account='" + user.Username + "'";
            mockdb.Setup(d => d.DataNum(command)).Returns(0);
            command = "insert into users (account,password) values('" + user.Username + "','" + user.Password + "')";
            mockdb.Setup(d => d.Execute(command)).Returns(1);
            Assert.AreEqual(1, userdao.RegisterUser(user));
        }

        [TestMethod()]
        public void RegisterExistUserTest()
        {
            User user = new User("lkx", "123");
            string command = "select account from users where account='" + user.Username + "'";
            mockdb.Setup(d => d.DataNum(command)).Returns(1);
            Assert.ThrowsException<Exception>(()=>userdao.RegisterUser(user));
        }

        [TestMethod()]
        public void RegisterNormalUserWithExceptionTest()
        {
            User user = new User("lkx", "123");
            string command = "select account from users where account='" + user.Username + "'";
            mockdb.Setup(d => d.DataNum(command)).Returns(-1);
            command = "insert into users (account,password) values('" + user.Username + "','" + user.Password + "')";
            mockdb.Setup(d => d.Execute(command)).Returns(2);
            Assert.ThrowsException<Exception>(() => userdao.RegisterUser(user));
        }

        [TestMethod()]
        public void GetNormalUserNumByAccountAndPasswordTest()
        {
            User user = new User("lkx", "123");
            string command = "select account,password from users where account='" + user.Username + "' and password='" + user.Password + "'";
            mockdb.Setup(d => d.DataNum(command)).Returns(1);
            Assert.AreEqual(1, userdao.GetUserNumByAccountAndPassword(user));
        }

        [TestMethod()]
        public void GetExceptionUserNumByAccountAndPasswordTest()
        {
            User user = new User("lkx", "123");
            string command = "select account,password from users where account='" + user.Username + "' and password='" + user.Password + "'";
            mockdb.Setup(d => d.DataNum(command)).Returns(-1);
            Assert.ThrowsException<Exception>(() => userdao.GetUserNumByAccountAndPassword(user));
        }

        [TestMethod()]
        public void GetNormalUserNumByAccountTest()
        {
            User user = new User("lkx", "123");
            string command = "select account from users where account='" + user.Username + "'";
            mockdb.Setup(d => d.DataNum(command)).Returns(1);
            Assert.AreEqual(1, userdao.GetUserNumByAccount(user));
        }

        [TestMethod()]
        public void GetExceptionUserNumByAccountTest()
        {
            User user = new User("lkx", "123");
            string command = "select account from users where account='" + user.Username + "'";
            mockdb.Setup(d => d.DataNum(command)).Returns(-1);
            Assert.ThrowsException<Exception>(() => userdao.GetUserNumByAccount(user));
        }

        [TestMethod()]
        public void GetUserIdByUserTest()
        {
            int count = 0;
            var mockdb = new Mock<IDatabase>();
            var userdao = new UserDAO(mockdb.Object);
            var mockDatareader = new Mock<IDataReader>();
            mockDatareader.Setup(d => d.Read()).Returns(() => count < 1).Callback(() => count++);
            mockDatareader.Setup(r => r["user_id"]).Returns("1");
            Assert.AreEqual(1, userdao.getUserIdByUser(mockDatareader.Object));
        }
    }
}