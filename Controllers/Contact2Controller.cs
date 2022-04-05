using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using UmbracoTest.Models;
using Umbraco.Core.Services;
using Umbraco.Core;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.IO;
using System.Text;

namespace UmbracoTest.Controllers
{
    public class Contact2Controller : SurfaceController
    {
        private const string Partial_Views_Path = "~/Views/Partials/SharedLayout/";
        public ActionResult RenderContact2()
        {
            return PartialView(string.Format("{0}Contact2Partial.cshtml", Partial_Views_Path));
        }

        public ActionResult HandleSubmitForm(Contact2Model model)
        {
            Umbraco.Core.GuidUdi currentPageUdi = new GuidUdi(CurrentPage.ContentType.ItemType.ToString(), CurrentPage.Key);
            if (ModelState.IsValid)
            {
                var message = Services.ContentService
                    .CreateContent(String.Format("{0} - {1}", model.Name, DateTime.Now.ToString()),
                    currentPageUdi, "contactContent2");
                message.SetValue("userName", model.Name);
                message.SetValue("email", model.Email);
                message.SetValue("subject", model.Subject);
                message.SetValue("message", model.Message);
                message.SetValue("phone", model.Phone);
                message.SetValue("companyName", model.CompanyName);
                TempData["ContactUsSuccess"] = true;
                Services.ContentService.SaveAndPublish(message);
                SendMail(model);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();
        }

        private void SendMail(Contact2Model model)
        {


            //Fetching Email Body Text from EmailTemplate File.  
            string FilePath = "C:\\Users\\preet\\Pictures\\Test_Umbraco\\UmbracoTest\\EmailTemplates\\Template.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();

            //Replace dynamic data
            Random rnd = new Random();
            string token = rnd.Next(1000, 99999).ToString();
            MailText = MailText.Replace("[username]", model.Name.Trim());
            MailText = MailText.Replace("[token]", token);
            MailText = MailText.Replace("[subject]", model.Subject);
            MailText = MailText.Replace("[message_details]", model.Message);
            MailText = MailText.Replace("[company]", model.CompanyName);
            MailText = MailText.Replace("[phone]", model.Phone);
           
            var fromEmail = new MailAddress(ConfigurationManager.AppSettings["SendEmailFrom"]);
            var fromPassword = ConfigurationManager.AppSettings["SendEmailPassword"];
            var toAddress = new MailAddress(model.Email);
            string subject = ConfigurationManager.AppSettings["SendEmailSubject"]; 
            string body = MailText;


            var smtp = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromEmail.Address, fromPassword)
            };

            var message = new MailMessage(fromEmail, toAddress);
            message.Subject = subject;
            message.Body = MailText;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}