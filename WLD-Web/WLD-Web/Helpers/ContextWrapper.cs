using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WLD_Web.Helpers
{
    public class ContextWrapper : WLD_Web.Helpers.IContextWrapper
    {

        public string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}