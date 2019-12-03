using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

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
            queryBoxComment.Click();
            queryBoxComment.SendKeys("Komentarz2");
            var queryBoxAuthot = browser.FindElement(By.Id("author"));
            queryBoxAuthot.SendKeys("Autor");
            var queryBoxEmail = browser.FindElement(By.Id("email"));
            queryBoxEmail.SendKeys("igarrazuxo-6741@yopmail.com");
            var PublishComment = browser.FindElement(By.Id("submit"));
            PublishComment.Click();
            var contentComment = browser.FindElement(By.CssSelector(".comment-content"));
            var y = contentComment.FindElement(By.TagName("p"));


            Assert.Equal("Komentarz2", y.Text );


        }

        public void Dispose()
        {
            browser.Quit();
        }

    }
}
