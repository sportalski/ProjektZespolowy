using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVCProj.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace MVCProj.Controllers
{
    public class UserAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET /home/index        
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingAccountId = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.CheckingAccountId = checkingAccountId;

            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(userId);
            ViewBag.Pin = user.Pin;

            var checkingAccount = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First();
            return View(checkingAccount);
        }

       
        [Authorize]
        public ActionResult Transfer()
        {
            TransferModel model = new TransferModel();
            var userId = User.Identity.GetUserId();
            var checkingAccount = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First();
            model.UserName = checkingAccount.Name;
            model.AccountNumber = checkingAccount.AccountNumber;
            model.Balance = checkingAccount.Balance;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Transfer(TransferModel model)
        {
            var userId = User.Identity.GetUserId();
            var checkingAccount = db.CheckingAccounts.Where(c => c.ApplicationUserId == userId).First();
            model.UserName = checkingAccount.Name;
            model.AccountNumber = checkingAccount.AccountNumber;
            model.Balance = checkingAccount.Balance;
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
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
    }
}