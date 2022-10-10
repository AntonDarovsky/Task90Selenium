using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using YandexSeleniumTests;
using Assert = NUnit.Framework.Assert;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace YandexTests
{
    [TestFixture(Description = "Yandex login check")]
    [AllureNUnit]
    public class YandexLoginTests
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void ClearResultsDir()
        {
            AllureLifecycle.Instance.CleanupResultDirectory();
        }
        [SetUp]
        public void Open()
        {
            driver = new ChromeDriver();

            driver.Url = "https://www.yandex.com/";

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void Close()
        {
            driver.Close();
        }
        [Test]
        [AllureStep("This method is login in Yandex email")]
        [AllureTag("NUnit", "Debug")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureFeature("Yandex")]
        [AllureOwner("Anton")]
        [AllureSubSuite("FirstSuite")]
        [AllureIssue("SM-143")]
        public void LoginYandexTest()
        {
            HomePageYandex homeYandex = new HomePageYandex(driver);

            homeYandex.ClickLoginButton();

            LoginPageYandex loginPageYandex = homeYandex.GoToLoginPage();

            loginPageYandex.Login("antonantonov972");

            loginPageYandex.Password("Antongekaleo97");

            loginPageYandex.LogOut();
   
            var element = driver.WaitForElement(By.CssSelector(".Button2-Text"), TimeSpan.FromMinutes(2));

            Assert.IsTrue(element.Displayed, "Wrong page!");
        }
    }
}
