using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVCProj.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace MVCProj.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET /home/index        
        public ActionResult Index()
        {
            return View();
        }

        // GET /home/emailStatus       
        public ActionResult EmailStatus()
        {
            return View();
        }

        public ActionResult Foo()
        {            
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            // return new HttpStatusCodeResult(403);
            // return Json(new { name = "serial number", value = "serial" }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("mvcproj@gazeta.pl"));
                message.From = new MailAddress("mvcproj@gazeta.pl");
                message.ReplyToList.Add(new MailAddress(model.FromEmail));
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                 {
                     var credential = new NetworkCredential
                     {
                         UserName = "mvcproj@gazeta.pl",
                         Password = "Bankstudencki7771" 
                     };
                     smtp.Credentials = credential;
                     smtp.Host = "smtp.gazeta.pl";
                     smtp.Port = 587;
                     smtp.EnableSsl = false;
                     await smtp.SendMailAsync(message);
                     return RedirectToAction("EmailStatus");
                 }
            }
            return View(model);
        }
    }
}