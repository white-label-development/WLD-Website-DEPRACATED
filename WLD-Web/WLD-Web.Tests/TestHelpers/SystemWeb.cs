using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Moq;


namespace WLD.Mvc.Tests.TestHelpers
{
    class SystemWeb
    {
       
        public static HtmlHelper FakedHtmlHelper()
        {
            var vc = new ViewContext();
            vc.HttpContext = new FakeHttpContext();
            var hh = new HtmlHelper(vc, new FakeViewDataContainer());
            return hh;
        }
    }

    public class FakeAuthorizationContext : AuthorizationContext
    {
        public override HttpContextBase HttpContext
        {
            get
            {
                return base.HttpContext;
            }
            set
            {
                base.HttpContext = value;
            }
        }



    }

    public class FakeHttpContext : HttpContextBase
    {
        private Dictionary<object, object> _items = new Dictionary<object, object>();
        public override IDictionary Items { get { return _items; } }

        public override HttpRequestBase Request
        {
            get
            {
                return GetRequestBase();
            }
        }


        public bool IsAjaxRequest { get; set; }
        public bool IsAuthenticated { get; set; }

        public HttpRequestBase GetRequestBase()
        {
            var request = new Mock<HttpRequestBase>();
            // Not working - IsAjaxRequest() is static extension method and cannot be mocked
            // request.Setup(x => x.IsAjaxRequest()).Returns(true /* or false */);
            // use this

           
            request.SetupGet(x => x.IsAuthenticated).Returns(IsAuthenticated);

            if(IsAjaxRequest)
                request.SetupGet(x => x.Headers).Returns(new System.Net.WebHeaderCollection {{"X-Requested-With", "XMLHttpRequest"}});
            
            return request.Object;

            //var context = new Mock<HttpContextBase>();            
            //context.SetupGet(x => x.Request).Returns(request.Object);
            //HttpContextBase httpContextBase = context.Object;
        }
    }

    public class FakeViewDataContainer : IViewDataContainer
    {
        private ViewDataDictionary _viewData = new ViewDataDictionary();
        public ViewDataDictionary ViewData { get { return _viewData; } set { _viewData = value; } }
    }


}
