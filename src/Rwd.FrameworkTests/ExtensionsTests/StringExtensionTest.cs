using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rwd.Framework.Extensions;
using Rwd.Framework;

namespace Rwd.FrameworkTests.ExtensionsTests
{
    [TestClass]
    public class StringExtensionTest
    {

        #region IsDateTime

        [TestMethod]
        public void IsDateTime_NullInput()
        {
            const string input = null;
            var actual = input.IsDateTime();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsDateTime_ValidInput()
        {
            const string input = "5/24/2014";
            var actual = input.IsDateTime();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsDateTime_InvalidInput()
        {
            const string input = "M5/24/2014";
            var actual = input.IsDateTime();
            Assert.IsFalse(actual);
        }

        #endregion

        #region IsDateTime

        [TestMethod]
        public void IsNumber_NullInput()
        {
            const string input = null;
            var actual = input.IsNumber();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsNumber_ValidInput()
        {
            const string input = "25";
            var actual = input.IsNumber();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsNumber_ValidDecimalInput()
        {
            const string input = "25.3";
            var actual = input.IsNumber();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsNumber_ValidNegativeInput()
        {
            const string input = "-25,000";
            var actual = input.IsNumber();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsNumber_InvalidInput()
        {
            const string input = "26t";
            var actual = input.IsNumber();
            Assert.IsFalse(actual);
        }

        #endregion
    }
}
