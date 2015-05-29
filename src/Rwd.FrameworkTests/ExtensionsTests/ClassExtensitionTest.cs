using System;
using System.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rwd.Framework.Extensions;

namespace Rwd.FrameworkTests.ExtensionsTests
{
    [TestClass]
    public class ClassExtensionTest
    {
        [TestMethod]
        public void ErrorIsThrownIfObjectIsNull()
        {
            Object obj =null;
            try
            {
                obj.ThrowIfArgumentIsNull(string.Empty);
                Assert.Fail("No exception thrown");
            }
            catch (ArgumentNullException ex)
            {
                // do nothing, test passed
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void NoErrorIfObjectIsNotNull()
        {
            var obj = new Object();
            try
            {
                obj.ThrowIfArgumentIsNull(string.Empty);
                Assert.IsNotNull(obj, "No error thrown");
            }
            catch (ArgumentNullException ex)
            {
                Assert.Fail("An execption was thrown");
            }
        }
    }
}
