using System;
using System.Web.Mvc;
using System.Linq.Expressions;


namespace WLD.Mvc.Helpers
{
    public static class HtmlHelpers
    {
        //Html Helpers can also be set in the App_Code folder and called a bit easier - but
        //I like this technique as they are easier to test.

        //usage: @Html.CssLink("nivo-slider.css")
        public static MvcHtmlString CssLink(this HtmlHelper helper, string cssFileName)
        {
            if (helper == null) throw new ArgumentNullException("helper", "A HtmlHelper is required.");
            if (string.IsNullOrEmpty(cssFileName)) throw new ArgumentNullException("cssFileName", "cssFileName is required.");
            string fileLocation = string.Format("/Content/Css/{0}", cssFileName);
            TagBuilder tagBuilder = new TagBuilder("link");
            tagBuilder.Attributes.Add("href", fileLocation);
            tagBuilder.Attributes.Add("rel", "stylesheet");

            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));            
        }

        //<script src="@Url.Content("~/Scripts/modernizr-1.7.min.js")" type="text/javascript"></script>
        //usage: @Html.JavascriptLink("jquery.nivo.slider.pack.js")
        public static MvcHtmlString JavascriptLink(this HtmlHelper helper, string javascriptFileName)
        {
            if (helper == null) throw new ArgumentNullException("helper", "A HtmlHelper is required.");
            if (string.IsNullOrEmpty(javascriptFileName)) throw new ArgumentNullException("javascriptFileName", "javascriptFileName is required.");
            string fileLocation = string.Format("/Scripts/{0}", javascriptFileName);
            TagBuilder tagBuilder = new TagBuilder("script");
            tagBuilder.Attributes.Add("src", fileLocation);
            tagBuilder.Attributes.Add("type", "text/javascript");

           return new MvcHtmlString(tagBuilder.ToString());
        }

        //<img src="../../Images/ETC4.jpg" />
        public static MvcHtmlString Image(this HtmlHelper helper, string imageFileName, string altText)
        {
            if (helper == null) throw new ArgumentNullException("helper", "A HtmlHelper is required.");
            if (string.IsNullOrEmpty(imageFileName)) throw new ArgumentNullException("imageFileName", "imageFileName is required.");
            string fileLocation = string.Format("/Images/{0}", imageFileName);
            TagBuilder tagBuilder = new TagBuilder("img");
            tagBuilder.Attributes.Add("src", fileLocation);
            if(!string.IsNullOrEmpty(altText))
            {
                tagBuilder.Attributes.Add("alt", altText);
                tagBuilder.Attributes.Add("title", altText);
            }                            
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }

        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            return input.Substring(0, length) + "...";
        }

       
    }
}