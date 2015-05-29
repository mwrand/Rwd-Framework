using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rwd.Framework.Extensions;

namespace Rwd.FrameworkTests.ExtensionsTests
{
    [TestClass]
    public class NumberExtensionTest
    {

        #region FromDecimalToInt

        [TestMethod]
        public void FromDecimalToInt()
        {
            const decimal dec = 5M;
            var actual = dec.ToInt();
            if (actual.GetType().FullName != "System.Int32")
            {
                Assert.Fail("Type is not int32");
            }
        }

        [TestMethod]
        public void FromDecimalToIntCorrect()
        {
            const decimal dec = 5M;
            var actual = dec.ToInt();
            Assert.AreEqual(5, actual);
        }

        #endregion

        #region IntTryParse

        [TestMethod]
        public void IntTryParse_ValidInput()
        {
            const int expected = 5;
            var input = expected.ToString();
            var value = input.IntTryParse();
            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void IntTryParse_InvalidInput()
        {
            const string input = "bad value";
            var value = input.IntTryParse();
            Assert.AreEqual(0, value);
        }

        [TestMethod]
        public void IntTryParse_NullInput()
        {
            const string input = null;
            var value = input.IntTryParse();
            Assert.AreEqual(0, value);
        }

        #endregion

        #region ToCardnial

        [TestMethod]
        public void ToCardinal_First()
        {
            const int input = 1;
            var value = input.ToCardinal();
            Assert.AreEqual("1st", value);
        }

        [TestMethod]
        public void ToCardinal_Second()
        {
            const int input = 2;
            var value = input.ToCardinal();
            Assert.AreEqual("2nd", value);
        }

        [TestMethod]
        public void ToCardinal_Third()
        {
            const int input = 3;
            var value = input.ToCardinal();
            Assert.AreEqual("3rd", value);
        }

        [TestMethod]
        public void ToCardinal_Fourth()
        {
            const int input = 4;
            var value = input.ToCardinal();
            Assert.AreEqual("4th", value);
        }

        [TestMethod]
        public void ToCardinal_Tenth()
        {
            const int input = 10;
            var value = input.ToCardinal();
            Assert.AreEqual("10th", value);
        }

        [TestMethod]
        public void ToCardinal_OneHundreth()
        {
            const int input = 100;
            var value = input.ToCardinal();
            Assert.AreEqual("100th", value);
        }


        #endregion

        #region ToMoney

        [TestMethod]
        public void ToMoney_Negative()
        {
            const decimal input = -1000;
            var value = input.ToMoney();
            Assert.AreEqual("($1,000.00)", value);
        }


        [TestMethod]
        public void ToMoney_Zero()
        {
            const decimal input = 0;
            var value = input.ToMoney();
            Assert.AreEqual("$0.00", value);
        }

        [TestMethod]
        public void ToMoney()
        {
            const decimal input = 1000;
            var value = input.ToMoney();
            Assert.AreEqual("$1,000.00", value);
        }

        #endregion
    }
}
