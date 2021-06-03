using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using testumbraco.Models;
using Umbraco.Web.Mvc;

namespace testumbraco.Controllers
{
    public class ContactController : SurfaceController
    {

        [HttpGet]
        public ActionResult RenderForm()
        {
            return PartialView("~/Views/Contact.cshtml");
        }

        [HttpPost]
        public ActionResult RenderForm(ContactModel model)
        {

            if (ModelState.IsValid)
            {

                ViewBag.Check = Task.Run(() => SendEmail(model)).Result;
            }
            return CurrentUmbracoPage();
        }


       

        public async Task<bool> SendEmail(ContactModel model)

        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(model.Email, model.Name);
            mail.To.Add(model.Email);
            mail.Subject = "Umbraco";
            mail.IsBodyHtml = true;
            mail.Body = model.Message;


            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {

                    await smtp.SendMailAsync(mail);

                }
                return true;
            }
            catch (Exception ex)
            {
                ViewBag.Exeption = ex.Message;
                return false;
            }
        }

    }




}
