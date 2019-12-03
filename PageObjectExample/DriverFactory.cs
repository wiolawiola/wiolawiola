using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectExample
{
    internal partial class MainPage
    {
        public class DriverFactory
        {
            internal static IWebDriver Get()
            {
                var driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                return driver;
            }
        }
    }
}