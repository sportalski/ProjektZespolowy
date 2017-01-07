using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driverGC;
        private int i;

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            driverGC = new ChromeDriver();
        }
        [TestMethod]
        public void TestTworzeniaKonta()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.LinkText("Zarejestruj")).Click();
            driverGC.FindElement(By.Name("Email")).SendKeys("testowy1@testowy.pl");
            driverGC.FindElement(By.Name("FirstName")).SendKeys("Wojtek");
            driverGC.FindElement(By.Name("LastName")).SendKeys("Testowy");
            driverGC.FindElement(By.Name("Password")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.Name("ConfirmPassword")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.XPath("/html[@class=' js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths']/body/div[@class='container body-content']/form[@class='form-horizontal']/div[@class='form-group'][6]/div[@class='col-md-offset-2 col-md-10']/input[@class='btn btn-default']")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Witaj Wojtek!"));
        }
        [TestMethod]
        public void TestHasloTworzenieKonta()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.LinkText("Zarejestruj")).Click();
            driverGC.FindElement(By.Name("Email")).SendKeys("testowy11@testowy1.pl");
            driverGC.FindElement(By.Name("FirstName")).SendKeys("Wojtekk");
            driverGC.FindElement(By.Name("LastName")).SendKeys("Testowyt");
            driverGC.FindElement(By.Name("Password")).SendKeys("1q2w3e4r%");
            driverGC.FindElement(By.Name("ConfirmPassword")).SendKeys("1q2w3e4r%");
            driverGC.FindElement(By.XPath("/html[@class=' js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths']/body/div[@class='container body-content']/form[@class='form-horizontal']/div[@class='form-group'][6]/div[@class='col-md-offset-2 col-md-10']/input[@class='btn btn-default']")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Passwords must have at least one uppercase ('A'-'Z')."));
        }
    }
}
