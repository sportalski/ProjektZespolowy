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
            driverGC.FindElement(By.LinkText("zarejestruj")).Click();
            driverGC.FindElement(By.Name("Email")).SendKeys("testowy1@testowy.pl");
            driverGC.FindElement(By.Name("FirstName")).SendKeys("Wojtek");
            driverGC.FindElement(By.Name("LastName")).SendKeys("Testowy");
            driverGC.FindElement(By.Name("Password")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.Name("ConfirmPassword")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.XPath("/html[@class=' js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths']/body/div[@class='container body-content']/div[@class='row'][3]/div[@class='register-form-section col-md-12 text-center']/form[@class='form-horizontal']/div[@class='form-group'][6]/div[@class='col-md-12 margin-top']/input[@class='btn btn-default']")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Witaj Wojtek!"));
        }
        [TestMethod]
        public void TestHasloTworzenieKonta()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.LinkText("zarejestruj")).Click();
            driverGC.FindElement(By.Name("Email")).SendKeys("testowy11@testowy1.pl");
            driverGC.FindElement(By.Name("FirstName")).SendKeys("Wojtekk");
            driverGC.FindElement(By.Name("LastName")).SendKeys("Testowyt");
            driverGC.FindElement(By.Name("Password")).SendKeys("1q2w3e4r%");
            driverGC.FindElement(By.Name("ConfirmPassword")).SendKeys("1q2w3e4r%");
            driverGC.FindElement(By.XPath("/html[@class=' js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths']/body/div[@class='container body-content']/div[@class='row'][3]/div[@class='register-form-section col-md-12 text-center']/form[@class='form-horizontal']/div[@class='form-group'][6]/div[@class='col-md-12 margin-top']/input[@class='btn btn-default']")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Passwords must have at least one uppercase ('A'-'Z')."));
        }
        [TestMethod]
        public void TestKontoSrodki()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.LinkText("Logowanie")).Click();
            driverGC.FindElement(By.Name("Email")).SendKeys("logowanie@testowe.pl");
            driverGC.FindElement(By.Name("Password")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.XPath("/html[@class=' js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths']/body/div[@class='container body-content']/div[@class='row'][3]/section[@id='loginForm']/form[@class='form-horizontal']/div[@class='form-group'][4]/div[@class='col-md-12']/input[@class='btn btn-default']")).Click();
            driverGC.FindElement(By.XPath("/html[@class=' js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths']/body/div[@class='container body-content']/div[@class='row']/div[@class='col-md-6 margin-top-20'][1]/a[@class='btn btn-primary btn-large btn-block'][3]")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("logowanie testowe"));
            Assert.IsTrue(driverGC.PageSource.Contains("0,00 zł"));
        }
        [TestMethod]
        public void TestFormularzKontaktowy()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.Id("FromName")).SendKeys("Michał");
            driverGC.FindElement(By.Id("FromEmail")).SendKeys("testowy@mail.pl");
            driverGC.FindElement(By.Id("Message")).SendKeys("To jest testowa wiadomość");
            driverGC.FindElement(By.XPath("/html[@class=' js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths']/body/div[@class='container body-content']/div[@id='contact']/div[@class='col-md-12 third-section']/div[@class='row'][5]/div[@class='form-section']/form/div[@class='form-group text-center']/div[@class='col-md-12']/input[@class='btn btn-default']")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Wiadomość email została wysłana"));
        }
        [TestMethod]
        public void TestFormularzKontaktowyBlednyMail()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.Id("FromName")).SendKeys("Michał");
            driverGC.FindElement(By.Id("FromEmail")).SendKeys("testowy");
            driverGC.FindElement(By.Id("Message")).SendKeys("To jest testowa wiadomość");
            driverGC.FindElement(By.XPath("/html[@class=' js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths']/body/div[@class='container body-content']/div[@id='contact']/div[@class='col-md-12 third-section']/div[@class='row'][5]/div[@class='form-section']/form/div[@class='form-group text-center']/div[@class='col-md-12']/input[@class='btn btn-default']")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Wartość w polu Twój adres email nie jest prawidłowym adresem e-mail."));
        }
        [TestMethod]
        public void TestLogowanieBlednyMail()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.LinkText("Logowanie")).Click();
            driverGC.FindElement(By.Name("Email")).SendKeys("logowanie");
            driverGC.FindElement(By.Name("Password")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.XPath("/html[@class=' js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths js flexbox flexboxlegacy canvas canvastext webgl no-touch geolocation postmessage websqldatabase indexeddb hashchange history draganddrop websockets rgba hsla multiplebgs backgroundsize borderimage borderradius boxshadow textshadow opacity cssanimations csscolumns cssgradients cssreflections csstransforms csstransforms3d csstransitions fontface generatedcontent video audio localstorage sessionstorage webworkers applicationcache svg inlinesvg smil svgclippaths']/body/div[@class='container body-content']/div[@class='row'][3]/section[@id='loginForm']/form[@class='form-horizontal']/div[@class='form-group'][4]/div[@class='col-md-12']/input[@class='btn btn-default']")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Wartość w polu Email nie jest prawidłowym adresem e-mail."));
        }
    }
}
