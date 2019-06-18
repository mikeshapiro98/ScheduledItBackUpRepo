using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ScheduleIt2._0.Models;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ScheduleIt2._0.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailModel model)
        {
            if (ModelState.IsValid)
            {

                var email = model.FromEmail;
                var message = model.MessageBody;

                MailMessage msg = new MailMessage();

                msg.From = new MailAddress("scheduleitliveproject@gmail.com");
                msg.To.Add("seattledean@learncodinganywhere.com"); 
                msg.Subject = "ScheduleIT Live Project" ;
                msg.Body = model.MessageBody;
                msg.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential
                    ("scheduleitliveproject@gmail.com", "Techacademy1!");
                smtp.EnableSsl = true;

                
                smtp.Send(msg);
                

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

    }
}