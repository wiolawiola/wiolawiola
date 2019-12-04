using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectExample
{
    internal partial class LoginPage
    {
        private const string MAIN_PAGE_BASE_URL = "http://automatyzacja.benedykt.net/wp-admin";
        private readonly IWebDriver _browser;

        private LoginPage(IWebDriver browser)
        {
            _browser = browser;
            browser.Navigate().GoToUrl(MAIN_PAGE_BASE_URL);
        }

        internal static LoginPage Open(IWebDriver webDriver)
        {
            return new LoginPage(webDriver);
        }

        internal blogPage EnterUserDataAndLogin()
        {
            WaitForClickable(By.Id("user_login"),5);
            var queryBox = _browser.FindElement(By.Id("user_login"));
            queryBox.SendKeys("automatyzacja");

            var queryBoxPassword = _browser.FindElement(By.Id("user_pass"));
            queryBoxPassword.SendKeys("auto@Zima2019");

            var buttonClick = _browser.FindElement(By.Id("wp-submit"));
            buttonClick.Click();
           

            return new blogPage(_browser);
        }

        internal void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

    }
}