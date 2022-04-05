using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;


namespace UmbracoTest.Controllers
{
    public class ServicesController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/Services/";
        public ActionResult RenderServices()
        {
            return PartialView(string.Format("{0}ServicesMain.cshtml", Partial_Views_Path));
        }
    }
}