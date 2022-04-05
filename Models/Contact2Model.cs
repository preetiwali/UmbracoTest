using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmbracoTest.Models
{
    public class Contact2Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public string Subject { get; set; }

        public string Message { get; set; }

        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
    }
}