using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumTask.Pages;
using SeleniumTask.Utilities;

namespace SeleniumTask.Tests
{
    [TestClass]
    public class HomePageTest
    {
        private IWebDriver _driver;
        private HomePage _page;

        [DataTestMethod]
        [DataRow("Chrome")]
        [DataRow("Firefox")]
        [DataRow("Edge")]
        //[DataRow("Safari")]
        public void Verify_Page_Functionality_Across_Browsers(string browser)
        {
            _driver = Driver.CreateDriver(browser);
            _page = new HomePage(_driver);

            _page.NavigateToPage();
            Assert.AreEqual("Example Domain", _page.GetPageTitle());

            _page.ClickMoreInfoLink();
            Assert.AreEqual("Example Domains", _page.VerifyPageElement());
        }

        [TestCleanup]
        public void Teardown()
        {
            _driver?.Quit();
        }
    }
}