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
    public class UserTests
    {
        private User user;

        [TestInitialize]
        public void SetUp()
        {
            user = new User();
        }

        [TestMethod()]
        public void UserTestPassword()
        {
            user.Password = "1";
            Assert.AreEqual("1", user.Password);
        }

        [TestMethod()]
        public void UserTestUserId()
        {
            user.UserId = 1;
            Assert.AreEqual(1, user.UserId);
        }

        [TestMethod()]
        public void UserTestUsername()
        {
            user.Username = "abc";
            Assert.AreEqual("abc", user.Username);
        }

        [TestMethod()]
        public void UserTestValiduser()
        {
            user.ValidUser = true;
            Assert.AreEqual(true, user.ValidUser);
        }

    }
}