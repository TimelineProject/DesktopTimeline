using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLine.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLine.Server.Tests
{
    [TestClass()]
    public class DatabaseTests
    {
        private Database database;

        [TestInitialize]
        public void Setup()
        {
            string a = "123";
            database = new Database(a);
        }

        [TestMethod()]
        public void GetCommandTest()
        {
            Assert.AreEqual(null, database.GetCommand());
        }

    }
}