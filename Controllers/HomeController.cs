using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;


namespace UmbracoTest.Controllers
{
    public class HomeController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/Home/";
        public ActionResult RenderCarousel()
        {
            return PartialView(string.Format("{0}Carousel.cshtml", Partial_Views_Path));
        }
        public ActionResult RenderFeatures()
        {
            return PartialView(string.Format("{0}SectionFeature.cshtml", Partial_Views_Path));
        }
        public ActionResult RenderRecentWorks()
        {
            return PartialView(string.Format("{0}SectionRecentWorks.cshtml", Partial_Views_Path));
        }
        public ActionResult RenderServices()
        {
            return PartialView(string.Format("{0}SectionServices.cshtml", Partial_Views_Path));
        }
    }
}