using Moq;
using NUnit.Framework;
using System.Web.Mvc;
using WLD_Web.Helpers;

namespace WLD_Web.Tests.UnitTests
{
    [TestFixture]
    public class DocumentControllerTest
    {

        [Test]
        public void CurriculumVitae_FileRequest_ReturnsValidFilePathResult()
        {
            const string expectedContentType = "application/pdf";
            const string expectedFileName = "thompson_cv.pdf";
            var mock = new Mock<IContextWrapper>();
            mock.Setup(x => x.MapPath(It.IsAny<string>())).Returns(expectedFileName);
            var dc = new Controllers.DocumentController(mock.Object);
            
            ActionResult r = dc.CurriculumVitae();
            var fpr = ((FilePathResult) r);

            Assert.IsInstanceOf<FilePathResult>(r);
            Assert.AreEqual(expectedContentType, fpr.ContentType);
            Assert.AreEqual(expectedFileName, fpr.FileName);
        }
    }
}
