using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rwd.Framework.Web;

namespace Rwd.FrameworkTests.WebTests
{
    [TestClass]
    public class HtmlTagsTest
    {
        [TestMethod]
        public void Bold_NullInput()
        {
            var actual = HtmlTags.B(null);
            const string expected = "<b></b>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Bold_ValidInput()
        {
            var actual = HtmlTags.B("Some Text");
            const string expected = "<b>Some Text</b>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Div_NullInput()
        {
            var actual = HtmlTags.Div(null);
            const string expected = "<div>&nbsp;</div>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Div_ValidInput()
        {
            var actual = HtmlTags.Div("Some Text");
            const string expected = "<div>Some Text</div>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Div_NullInputWithNullClass()
        {
            var actual = HtmlTags.Div(null, null);
            const string expected = "<div>&nbsp;</div>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Div_ValidInputWithClass()
        {
            var actual = HtmlTags.Div("myClass", "Some Text");
            const string expected = @"<div class=""myClass"">Some Text</div>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Span_NullInput()
        {
            var actual = HtmlTags.Span(null);
            const string expected = "<span></span>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Span_ValidInput()
        {
            var actual = HtmlTags.Span("Some Text");
            const string expected = "<span>Some Text</span>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Span_NullInputWithNullClass()
        {
            var actual = HtmlTags.Span(null, null);
            const string expected = "<span></span>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Span_ValidInputWithClass()
        {
            var actual = HtmlTags.Span("myClass", "Some Text");
            const string expected = @"<span class=""myClass"">Some Text</span>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Generic_NullTagInput()
        {
            var actual = HtmlTags.Generic(null, "Some Text");
            var expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Generic_ValidInput()
        {
            var actual = HtmlTags.Generic("newTag", "Some Text");
            const string expected = "<newTag>Some Text</newTag>";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Generic_ValidInputWithClass()
        {
            var actual = HtmlTags.Generic("newTag", "myClass", "Some Text");
            const string expected = @"<newTag class=""myClass"">Some Text</newTag>";
            Assert.AreEqual(expected, actual);
        }
    }
}
