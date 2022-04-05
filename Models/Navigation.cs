using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoTest.Models
{
    public class NavInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool NewWindow { get; set; }
        public string Target { get { return NewWindow ? "_blank" : null; } }
        public string Title { get; set; }

        public NavInfo() {}
        public NavInfo(string name=null, string url=null, bool newWindow=false, string title=null) 
        {
            Name = name;
            Url = url;
            NewWindow = newWindow;
            Title = title;
        }

    }

    public class NavList
    {
        public string Name { get; set; }

        public NavInfo Link { get; set; }
        public List<NavList> NavItems { get; set; }

        public bool HasSubNav { get { return NavItems != null && NavItems.Count > 0 && NavItems.Any(); } }

        public  NavList() { }

        public NavList(NavInfo link) { Link = link; }

    }
}