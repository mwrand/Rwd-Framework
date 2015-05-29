using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rwd.Framework.Extensions;

namespace Rwd.FrameworkTests.ExtensionsTests
{
    /// <summary>
    /// Summary description for DateTimeExstensionTest
    /// </summary>
    [TestClass]
    public class DateTimeExstensionTest
    {
        public DateTimeExstensionTest()
        {
           
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DateTimeElapsed()
        {
            var now = DateTime.Now;
            var timeSpan = now.AddDays(1).Elapsed(now);
            if (timeSpan != new TimeSpan(1, 0, 0, 0))
            {
                Assert.Fail("Timespan was not properly calculated");
            }
        }

    }
}
