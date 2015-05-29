using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rwd.Framework.Extensions;
using System.Web;

namespace Rwd.FrameworkTests.ExtensionsTests
{
    [TestClass]
    public class CollectionExtentsionTest
    {
        private IEnumerable<string> GetStringList()
        {
            return new List<string> { "1", "2", "3", "4" };
        }

        [TestMethod]
        public void ToIntsNoException()
        {
            try
            {
                var list = GetStringList().ToInts();
            }
            catch (Exception)
            {
                Assert.Fail("List of strings was was not convert converted to list of ints");
            }
            
        }

        [TestMethod]
        public void ToIntTestConversion()
        {
            try
            {
                var list = GetStringList().ToInts();
                foreach (var item in list.Where(item => item.GetType().ToString() != "System.Int32"))
                {
                    Assert.Fail("One or more items weren't converted to int");
                }
            }
            catch (Exception)
            {
                Assert.Fail("List of strings was was not convert converted to list of ints");
            }

        }
    }
}
