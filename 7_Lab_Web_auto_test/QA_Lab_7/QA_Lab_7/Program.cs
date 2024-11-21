using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace WebTest
{
    public class CastTests
    {
        private string _url = "https://amelia-flowers.ru";
        private IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void TestPageTitle()
        {
            driver.Navigate().GoToUrl("_url");
            Assert.Equals("Ожидаемый заголовок", driver.Title);
        }

        [Test]
        public void TestElementVisibility()
        {
            driver.Navigate().GoToUrl("_url");
            var element = driver.FindElement(By.Id("t-btn t-btn_md "));
            ClassicAssert.IsTrue(element.Displayed, "Элемент не виден на странице.");
        }

        [Test]
        public void TestLinkNavigation()
        {
            driver.Navigate().GoToUrl("_url");
            driver.FindElement(By.LinkText("Для клиента")).Click();
            ClassicAssert.Equals("Ожидаемый заголовок страницы", driver.Title);
        }

        [Test]
        public void TestTextFieldInput()
        {
            driver.Navigate().GoToUrl("https://amelia-flowers.ru/denmat");
            var textField = driver.FindElement(By.Id("t-store__filter__input js-store-filter-search"));
            textField.SendKeys("Тестовый ввод");
            Assert.Equals("Тестовый ввод", textField.GetAttribute("value"));
        }

        [Test]
        public void TestButtonClick()
        {
            driver.Navigate().GoToUrl("_url");
            driver.FindElement(By.Id("t-btn t-btn_md ")).Click();
            ClassicAssert.IsTrue(driver.FindElement(By.Id("_advp _aeam")).Displayed);}

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
