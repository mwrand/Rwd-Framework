using System;
using System.Runtime;
using System.Text;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rwd.Framework.Extensions;

namespace Rwd.FrameworkTests.ExtensionsTests
{
    /// <summary>
    /// Summary description for DataTableExtensionTest
    /// </summary>
    [TestClass]
    public class DataTableExtensionTest
    {
        public DataTableExtensionTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            SetEmployees();
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            _employees = null;
        }

        #endregion

        private class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }
            public string Phone { get; set; }
        }

        private List<Employee> _employees = null;

        private List<Employee> SetEmployees()
        {
            _employees = new List<Employee>
                {
                    new Employee {FirstName = "Ann", LastName = "Stevens", Title = "Manager", Phone = "6154543322"},
                    new Employee {FirstName = "Rick", LastName = "Adams", Title = "Developer", Phone = "6157443322"},
                    new Employee  {FirstName = "Jenn",LastName = "Lawerence",Title = "Sales Associate", Phone = "6158113322"}
                };
            return _employees;
        }

        [TestMethod]
        public void ToDataTableCanConvert()
        {
            try
            {
                var dt = _employees.ToDataTable();
            }
            catch (Exception ex)
            {
                Assert.Fail("Could not convert list to datatable");
            }
        }

        [TestMethod]
        public void HasRows()
        {
            var dt = _employees.ToDataTable();
            if (dt.Rows.Count == 0)
            {
                Assert.Fail("Has no rows");
            }
        }

        [TestMethod]
        public void HasColumns()
        {
            var dt = _employees.ToDataTable();
            if (dt.Columns.Count == 0)
            {
                Assert.Fail("Has no columns");
            }
        }

        [TestMethod]
        public void HasFirstNameColumn()
        {
            var dt = _employees.ToDataTable();
            if (dt.Columns[0].ColumnName != "FirstName")
            {
                Assert.Fail("The first column is not FirstName");
            }
        }

        [TestMethod]
        public void FirstRecordOfFirstColumnHasValue()
        {
            var dt = _employees.ToDataTable();
            var row = dt.Rows[0];
            if (row["FirstName"].ToString() != "Ann")
            {
                Assert.Fail("The first column of the first row, doesn't contain the explected value.");
            }
        }

    }
}
