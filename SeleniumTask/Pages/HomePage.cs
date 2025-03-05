using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTask.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private const string Url = "https://example.com/";
        private readonly TimeSpan _timeout = TimeSpan.FromSeconds(10);

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToPage()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }

        public void ClickMoreInfoLink()
        {
            var wait = new WebDriverWait(_driver, _timeout);
            var link = wait.Until(_driver => _driver.FindElement(By.LinkText("More information...")));
            link.Click();
        }

        public string VerifyPageElement()
        {
            var wait = new WebDriverWait(_driver, _timeout);
            var ElementText = wait.Until(_driver => _driver.FindElement(By.XPath("//h1[text()='Example Domains']")));
            return ElementText.Text;
        }
    }
}