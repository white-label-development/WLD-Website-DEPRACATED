using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WLD_Web.Helpers;


namespace WLD_Web.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IContextWrapper _contextWrapper;
        public DocumentController(IContextWrapper contextWrapper)
        {
            _contextWrapper = contextWrapper;
        }

        
        // GET: /Document/CurriculumVitae
        public ActionResult CurriculumVitae()
        {
            const string contentType = "application/pdf";
            string fileLocation = _contextWrapper.MapPath("~/Documents/thompson_cv.pdf");
            return File(fileLocation, contentType, "thompson_cv.pdf");
        }

    }
}
