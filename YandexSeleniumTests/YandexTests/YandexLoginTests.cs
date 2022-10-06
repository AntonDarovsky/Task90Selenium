using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using YandexSeleniumTests;

namespace YandexTests
{
    [TestClass]
    public class YandexLoginTests
    {
        [TestMethod]
        public void LoginYandexTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Url = "https://www.yandex.com/";

            driver.Manage().Window.Maximize();

            HomePageYandex homeYandex = new HomePageYandex(driver);

            homeYandex.ClickLoginButton();

            homeYandex.TakeScreenshot(driver, "../Test.png");

            LoginPageYandex loginPageYandex = homeYandex.GoToLoginPage();

            loginPageYandex.Login("antonantonov972");

            loginPageYandex.Password("Antongekaleo97");

            loginPageYandex.LogOut();
   
            var element = driver.WaitForElement(By.CssSelector(".Button2-Text"), TimeSpan.FromMinutes(2));

            Assert.IsTrue(element.Displayed, "Wrong page!");

            driver.Close();
        }
    }
}
