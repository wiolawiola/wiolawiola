using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using Xunit;
using System.Linq;

namespace Project1
{
    public class GoogleTest : IDisposable
    {
        IWebDriver browser;

        public GoogleTest()
        {
            browser = new ChromeDriver();
        }

        [Fact]
        public void CanGoogleWeatherForWarsaw()
        {
            browser.Navigate().GoToUrl("https://google.com");

            var queryBox = browser.FindElement(By.CssSelector(".gLFyf"));
            queryBox.Click();
            queryBox.SendKeys("Pogoda Wawa");
            queryBox.Submit();

            var result = browser.FindElement(By.Id("wob_tm"));
            Assert.Equal("3", result.Text);

        }

        [Fact]

        public void Can_add_new_comment()
        {
            browser.Navigate().GoToUrl("http://automatyzacja.benedykt.net/");

            var queryBox = browser.FindElement(By.CssSelector(".entry-title"));
            var link = queryBox.FindElement(By.TagName("a"));
            link.Click();

            var queryBoxComment = browser.FindElement(By.Id("comment"));
            var exampleText = Faker.Lorem.Paragraph();
            queryBoxComment.SendKeys(exampleText);

            var queryBoxAuthot = browser.FindElement(By.Id("author"));
            var exampleAuthor = Faker.Lorem.Paragraph();
            queryBoxAuthot.SendKeys(exampleAuthor);

            var queryBoxEmail = browser.FindElement(By.Id("email"));
            var exampleEmail = Faker.Internet.Email();
            queryBoxEmail.SendKeys(exampleEmail);

            MoveToElement(browser.FindElement(By.CssSelector("div.nav-links")));
            var PublishComment = browser.FindElement(By.Id("submit"));
            PublishComment.Click();
            
            var comments = browser.FindElements(By.CssSelector("article.comment-body"));
            var myComments = comments
                .Where(c => c.FindElement(By.CssSelector(".fn")).Text == exampleAuthor)
                .Where(c => c.FindElement(By.CssSelector(".comment-content > p")).Text == exampleText);


            Assert.Single(myComments);


        }
        private void MoveToElement(IWebElement element)
        {
            Actions builder = new Actions(browser);
            Actions moveTo = builder.MoveToElement(element);
            moveTo.Build().Perform();

        }


        public void Dispose()
        {
            browser.Quit();
        }

       
    }
}
