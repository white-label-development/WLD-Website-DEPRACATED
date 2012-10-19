using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WLD_Web.Controllers
{
    public class DocumentController : Controller
    {
        //
        // GET: /Document/CurriculumVitae

        public ActionResult CurriculumVitae()
        {
            string contentType = "application/pdf";
            string fileLocation = Server.MapPath("~/Documents/thompson_cv.pdf");
            return File(fileLocation, contentType, "thompson_cv.pdf");
        }

    }
}
