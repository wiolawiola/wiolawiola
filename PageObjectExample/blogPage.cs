using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace PageObjectExample
{
    internal class blogPage
    {
        private IWebDriver _browser;
      
        

        public blogPage(IWebDriver browser)
        {
            _browser = browser;
        }

      

        public blogPage AddNote()
        {
            var MenuOptions = _browser.FindElements(By.CssSelector(".wp-menu-name"));
            var MenuOptionsWpisy = MenuOptions
               .Single(c => c.Text == "Wpisy");

            MenuOptionsWpisy.Click();

            return new blogPage(_browser);
        }

        public string AddWpis(ExampleWpis exampleWpis)
        {
            var AddNewWpis = _browser.FindElement(By.Id("title"));
            AddNewWpis.SendKeys(exampleWpis.Title);

            var AddNewWpisContent = _browser.FindElement(By.Id("content"));
            AddNewWpisContent.SendKeys(exampleWpis.ContentWpis);
                                               
            WaitForClickable(By.CssSelector(".edit-slug"), 5);

            var PublishWpisButton = _browser.FindElement(By.Id("publishing-action"));
            PublishWpisButton.Click();

            WaitForClickable(By.CssSelector("#sample-permalink > a"), 5);

            var link = _browser.FindElement(By.CssSelector("#sample-permalink > a"));
            var linktekst = link.GetAttribute("href");

            return linktekst;
        }

        public void LogOut()
        {
            //var PanelLogOut = _browser.FindElement(By.Id("wp-admin-bar-my-account"));
            //PanelLogOut.Click();

            MoveToElement(By.Id("wp-admin-bar-my-account"));

            WaitForClickable(By.Id("wp-admin-bar-logout"), 10);

            var ButtonLogOut = _browser.FindElement(By.Id("wp-admin-bar-logout"));
            ButtonLogOut.Click();

        }

        public blogPage PublishWpis()
        {
            var PublishWpisButton = _browser.FindElement(By.Id("publishing-action"));
            PublishWpisButton.Click();




            return new blogPage(_browser);
        }

        public blogPage AddNewNote()
        {
            var AddNewWpis = _browser.FindElement(By.CssSelector(".page-title-action"));

            AddNewWpis.Click();

            return new blogPage(_browser);
        }

        internal void WaitForClickable(By by, int seconds)
        {
            var wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
        internal void MoveToElement(By selector)
        {
            var element = _browser.FindElement(selector);
            MoveToElement(element);
        }
        internal void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();
        }
    }
}