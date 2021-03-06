using MVCProj.Models;
using System.Web.Mvc;
using System;
using MVCProj.Controllers;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVCProj.Controllers.Tests
{
    
    [TestClass]
    [PexClass(typeof(TransactionController))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TransactionControllerTest
    {
        [PexMethod]
        public TransactionController ConstructorTest()
        {
            TransactionController target = new TransactionController();
            return target;
           
        }

        [PexMethod]
        public ActionResult DepositTest([PexAssumeUnderTest]TransactionController target, int checkingAccountId)
        {
            ActionResult result = target.Deposit(checkingAccountId);
            return result;
        }

        [PexMethod]
        public ActionResult DepositTest01([PexAssumeUnderTest]TransactionController target, Transaction transaction)
        {
            ActionResult result = target.Deposit(transaction);
            return result;
        }
    }
}
