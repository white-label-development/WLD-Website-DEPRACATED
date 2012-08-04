using System;
using System.Web.Mvc;
using NUnit.Framework;
using WLD.Mvc.Helpers;
using WLD.Mvc.Tests.TestHelpers;

namespace WLD.Mvc.Tests.UnitTests.Helpers
{
    [TestFixture]
    public class HtmlHelpersTests
    {

        #region " CssLink "

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CssLink_should_throw_when_helper_argument_null()
        {           
            HtmlHelpers.CssLink(null, "some string");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CssLink_should_throw_when_cssFileName_argument_null()
        {
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();            
            var hh = new HtmlHelper(vc, new FakeViewDataContainer());

            HtmlHelpers.CssLink(hh, null);
        }

        [Test]       
        public void CssLink_returns_link_tag_string_for_valid_parameters()
        {
            var hh = SystemWeb.FakedHtmlHelper();
            string expected = "<link href=\"/Content/Css/test.css\" rel=\"stylesheet\" />";
            MvcHtmlString result = HtmlHelpers.CssLink(hh, "test.css");
            Assert.AreEqual(expected,result.ToString());
        }

        #endregion

        #region " JavascriptLink "

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JavascriptLink_should_throw_when_helper_argument_null()
        {
            HtmlHelpers.JavascriptLink(null, "some string");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void JavascriptLink_should_throw_when_javascriptName_argument_null()
        {
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();
            var hh = new HtmlHelper(vc, new FakeViewDataContainer());

            HtmlHelpers.JavascriptLink(hh, null);
        }

        [Test]
        public void JavascriptLink_returns_script_tag_string_for_valid_parameters()
        {
            var hh = SystemWeb.FakedHtmlHelper();
            string expected = "<script src=\"/Scripts/test.js\" type=\"text/javascript\"></script>";
            MvcHtmlString result = HtmlHelpers.JavascriptLink(hh, "test.js");
            Assert.AreEqual(expected, result.ToString());
        }

        #endregion

        #region " ImageLink "


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImageLink_should_throw_when_helper_argument_null()
        {
            HtmlHelpers.Image(null, "some string", "some string");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImageLink_should_throw_when_imageFileName_argument_null()
        {
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();
            var hh = new HtmlHelper(vc, new FakeViewDataContainer());

            HtmlHelpers.Image(hh, null, "somestring");
        }

        [Test]
        public void ImageLink_returns_image_tag_string_for_valid_src_parameter()
        {
            var hh = SystemWeb.FakedHtmlHelper();
            string expected = "<img src=\"/Images/test.png\" />";
            MvcHtmlString result = HtmlHelpers.Image(hh, "test.png" , null);
            Assert.AreEqual(expected, result.ToString());
        }

        [Test]
        public void ImageLink_returns_image_tag_string_for_valid_src_and_alt_parameters()
        {
            var hh = SystemWeb.FakedHtmlHelper();
            string expected = "<img alt=\"a test\" src=\"/Images/test.png\" title=\"a test\" />";
            MvcHtmlString result = HtmlHelpers.Image(hh, "test.png", "a test");
            Assert.AreEqual(expected, result.ToString());
        }

        #endregion

    }


    
}
