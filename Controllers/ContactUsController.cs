using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;


namespace UmbracoTest.Controllers
{
    public class ContactUsController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/Contactus/";
        public ActionResult RenderContactUs()
        {
            return PartialView(string.Format("{0}ContactUsMain.cshtml", Partial_Views_Path));
        }
    }
}