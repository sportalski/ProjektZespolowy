using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVCProj.Controllers;
using MVCProj.Models;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVCProj.Controllers.Tests
{
    [PexClass(typeof(HomeController))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class HomeControllerTest
    {
        [PexMethod]
        public HomeController ConstructorTest()
        {
            HomeController target = new HomeController();
            return target;
        }

        [PexMethod]
        public ActionResult EmailStatusTest([PexAssumeUnderTest]HomeController target)
        {
            ActionResult result = target.EmailStatus();
            return result;
        }

        [PexMethod]
        public ActionResult FooTest([PexAssumeUnderTest]HomeController target)
        {
            ActionResult result = target.Foo();
            return result;
        }
        [PexMethod]
        public ActionResult IndexTest([PexAssumeUnderTest]HomeController target)
        {
            ActionResult result = target.Index();
            return result;
        }

        [PexMethod]
        public Task<ActionResult> IndexTest01([PexAssumeUnderTest]HomeController target, EmailFormModel model)
        {
            Task<ActionResult> result = target.Index(model);
            return result;
        }
        [PexMethod]
        public ActionResult SerialTest([PexAssumeUnderTest]HomeController target, string letterCase)
        {
            ActionResult result = target.Serial(letterCase);
            return result;
        }
    }
}
