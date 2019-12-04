using System;
using System.Linq;
using OpenQA.Selenium;



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
    }
}