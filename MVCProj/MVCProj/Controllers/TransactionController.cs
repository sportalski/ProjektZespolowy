﻿using MVCProj.Models;
using MVCProj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProj.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Deposit(int checkingAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();

                var service = new CheckingAccountService(db);
                service.UpdateBalance(transaction.CheckingAccountId);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

           public ActionResult Withdrawal(int checkingAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Withdrawal(Transaction transaction)
        {
            var checkingAccount = db.CheckingAccounts.Find(transaction.CheckingAccountId);
            if (checkingAccount.Balance < transaction.Amount)
            {
                ModelState.AddModelError("Amount", "Nie masz pieniedzy");
            }

            if (ModelState.IsValid)
            {
                transaction.Amount = -transaction.Amount;
                db.Transactions.Add(transaction);
                db.SaveChanges();

                var service = new CheckingAccountService(db);
                service.UpdateBalance(transaction.CheckingAccountId);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Transfer(int checkingAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Transfer(TransferViewModel transfer)
        {
            // check for available funds
            var sourceCheckingAccount = db.CheckingAccounts.Find(transfer.CheckingAccountId);
            if (sourceCheckingAccount.Balance < transfer.Amount)
            {
                ModelState.AddModelError("Amount", "Nie masz pieniedzy");
            }

            // check for a valid destination account
            var destinationCheckingAccount = db.CheckingAccounts.Where(c => c.AccountNumber == transfer.DestinationCheckingAccountNumber).FirstOrDefault();
            if (destinationCheckingAccount == null)
            {
                ModelState.AddModelError("DestinationCheckingAccountNumber", "Zly numer");
            }

            // add debit/credit transactions and update account balances
            if (ModelState.IsValid)
            {
                db.Transactions.Add(new Transaction { CheckingAccountId = transfer.CheckingAccountId, Amount = -transfer.Amount });
                db.Transactions.Add(new Transaction { CheckingAccountId = destinationCheckingAccount.Id, Amount = transfer.Amount });
                db.SaveChanges();

                var service = new CheckingAccountService(db);
                service.UpdateBalance(transfer.CheckingAccountId);
                service.UpdateBalance(destinationCheckingAccount.Id);

                return PartialView("_TransferSuccess", transfer);
            }
            return PartialView("_TransferForm");

        }

    }
}