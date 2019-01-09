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
            mockdb.Setup(d => d.DataNum(command)).Returns(-1);
            command = "insert into users (account,password) values('" + user.Username + "','" + user.Password + "')";
            mockdb.Setup(d => d.Execute(command)).Returns(0);
            Assert.AreEqual(0, userdao.RegisterUser(user));
        }
    }
}