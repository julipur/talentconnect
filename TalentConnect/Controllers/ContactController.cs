using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TalentConnect.ViewModels;

namespace TalentConnect.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactViewModel viewModel)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    SendEmail(viewModel);
                    ViewBag.Message = "Thank you for your message, we will get back to you shortly.";
                }
                catch (Exception e)
                {
                    ViewBag.Message = "An error occurred while trying to send an email, please try again shortly.";
                }
            }

            return View(viewModel);
        }

        private void SendEmail(ContactViewModel viewModel)
        {
            var smtpClient = new SmtpClient("mail.talentconnect.co", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential("web@talentconnect.co", "xU1zbpb!");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mail = new MailMessage()
            {
                From = new MailAddress(viewModel.Email),
                Subject = "Email from website from " + viewModel.Email,
                Body = viewModel.Message
            };

            mail.To.Add(new MailAddress("web@talentconnect.co"));
            mail.To.Add(new MailAddress("jabbar@talentconnect.co"));

            smtpClient.Send(mail);
        }
    }
}