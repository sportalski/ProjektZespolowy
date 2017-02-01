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
            driverGC.FindElement(By.Name("Email")).SendKeys("testowy11@testowy.pl");
            driverGC.FindElement(By.Name("FirstName")).SendKeys("Wojtek");
            driverGC.FindElement(By.Name("LastName")).SendKeys("Testowy");
            driverGC.FindElement(By.Name("Password")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.Name("ConfirmPassword")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.XPath("//input[contains(@class, 'btn btn-default')]")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Wojtek Testowy"));
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
            driverGC.FindElement(By.XPath("//input[contains(@class, 'btn btn-default')]")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Passwords must have at least one uppercase ('A'-'Z')."));
        }
        [TestMethod]
        public void TestKontoSrodki()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.LinkText("Logowanie")).Click();
            driverGC.FindElement(By.Name("Email")).SendKeys("logowanie@testowe.pl");
            driverGC.FindElement(By.Name("Password")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.XPath("//input[contains(@class, 'btn btn-default')]")).Click();
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
            driverGC.FindElement(By.XPath("//input[contains(@class, 'btn btn-default')]")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Wiadomość email została wysłana"));
        }
        [TestMethod]
        public void TestFormularzKontaktowyBlednyMail()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.Id("FromName")).SendKeys("Michał");
            driverGC.FindElement(By.Id("FromEmail")).SendKeys("testowy");
            driverGC.FindElement(By.Id("Message")).SendKeys("To jest testowa wiadomość");
            driverGC.FindElement(By.XPath("//input[contains(@class, 'btn btn-default')]")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Wartość w polu Twój adres email nie jest prawidłowym adresem e-mail."));
        }
        [TestMethod]
        public void TestLogowanieBlednyMail()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.LinkText("Logowanie")).Click();
            driverGC.FindElement(By.Name("Email")).SendKeys("logowanie");
            driverGC.FindElement(By.Name("Password")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.XPath("//input[contains(@class, 'btn btn-default')]")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Wartość w polu Email nie jest prawidłowym adresem e-mail."));
        }
        [TestMethod]
        public void TestPrzelewWalidacja()
        {
            driverGC.Navigate().GoToUrl("http://localhost:56431/");
            driverGC.FindElement(By.LinkText("Logowanie")).Click();
            driverGC.FindElement(By.Name("Email")).SendKeys("logowanie@testowe.pl");
            driverGC.FindElement(By.Name("Password")).SendKeys("1Q2w3e4r%");
            driverGC.FindElement(By.XPath("//input[contains(@class, 'btn btn-default')]")).Click();
            driverGC.FindElement(By.XPath("//a[contains(@class, 'btn home-section-button menu-section-button')]")).Click();
            driverGC.FindElement(By.XPath("//input[contains(@class, 'btn btn-default')]")).Click();
            Assert.IsTrue(driverGC.PageSource.Contains("Pole Rachunek odbiorcy jest wymagane."));
            Assert.IsTrue(driverGC.PageSource.Contains("Pole Tytuł przelewu jest wymagane."));
            Assert.IsTrue(driverGC.PageSource.Contains("Pole Imię i nazwisko odbiorcy jest wymagane."));
            Assert.IsTrue(driverGC.PageSource.Contains("Pole Kwota przelewu jest wymagane."));
        }
        }
}