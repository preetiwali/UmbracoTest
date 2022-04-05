using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;


namespace UmbracoTest.Controllers
{
    public class AboutUsController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/Aboutus/";
        public ActionResult RenderAboutus()
        {
            return PartialView(string.Format("{0}AboutUsMain.cshtml", Partial_Views_Path));
        }
    }
}