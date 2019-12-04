using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace PageObjectExample
{
    internal class NotePage
    {
        private IWebDriver _browser;

        public NotePage(IWebDriver browser)
        {
            _browser = browser;
        }

        internal NotePage AddComent(ExampleComment exampleComment)
        {
            var queryBoxComment = _browser.FindElement(By.Id("comment"));
            
            queryBoxComment.SendKeys(exampleComment.Content);

            var queryBoxAuthot = _browser.FindElement(By.Id("author"));
            
            queryBoxAuthot.SendKeys(exampleComment.Author);

            var queryBoxEmail = _browser.FindElement(By.Id("email"));
          
            queryBoxEmail.SendKeys(exampleComment.Email);

            MoveToElement(_browser.FindElement(By.CssSelector("div.nav-links")));
            var PublishComment = _browser.FindElement(By.Id("submit"));
            PublishComment.Click();


            return new NotePage(_browser);
        }

        internal bool Has(ExampleComment exampleComment)
        {
            var comments = _browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
                .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleComment.Author)
                .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == exampleComment.Content);



            return myComments.Count() ==1 ;
        }

        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(_browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();

        }
    }
}