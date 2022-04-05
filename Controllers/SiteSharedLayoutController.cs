using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using UmbracoTest.Models;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;

namespace UmbracoTest.Controllers
{
    public class SiteSharedLayoutController : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/SharedLayout/";
        public ActionResult RenderHeader()
        {
            //return PartialView(string.Format("{0}Header.cshtml", Partial_Views_Path));
            List<NavList> nav = GetNavModel();
            return PartialView( Partial_Views_Path + "Header.cshtml",nav);
        }
        public ActionResult RenderFooter()
        {
            return PartialView(string.Format("{0}Footer.cshtml", Partial_Views_Path));
        }

        //create function to get navmodel from db
        //get subnav if any
        //update RenderHeader()

        public List<NavList> GetNavModel()
        {
            int pageId = int.Parse(CurrentPage.Path.Split(',')[1]); //page position
            IPublishedContent pageInfo = Umbraco.Content(pageId);
            var nav = new List<NavList>
            {
                new NavList ( new NavInfo(pageInfo.Url, pageInfo.Name) )
            };
            nav.AddRange(GetSubNavList(pageInfo));
            return nav;
        }

        public List<NavList> GetSubNavList(dynamic page)
        {
            List<NavList> navList = null;
            var subPages = page.Children;
            if(subPages != null)
            {
                navList = new List<NavList>();
                foreach(var subPage in subPages)
                {
                    var listItem = new NavList(new NavInfo(subPage.Url, subPage.Name))
                    {
                        NavItems = GetSubNavList(subPage)
                    };
                    navList.Add(listItem);
                }
            }
            return navList;
        }
    }
}