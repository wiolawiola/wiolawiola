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

        public void Dispose()
        {
            browser.Quit();
        }

    }
}
