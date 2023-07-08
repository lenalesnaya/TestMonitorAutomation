using Core.BaseEntities.GUI;
using OpenQA.Selenium;

namespace TestMonitorTesting.Pages
{
    internal class OneProjectPage : Page
    {
        protected override string EndPoint => "/test-p";

        private static readonly By TestSuitesLinkBy = By.CssSelector("a[href$='design/test-suites']");

        public UIElement TestSuitesLink => new(Driver, TestSuitesLinkBy);

        public OneProjectPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public OneProjectPage(IWebDriver? driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            try
            {
                return TestSuitesLink.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public TestSuitesPage ClickTestSuitesLink()
        {
            TestSuitesLink.Click();

            var testSuitesPage = new TestSuitesPage(Driver);
            testSuitesPage.WaitForOpen();
            Logger.Info($"Go to {nameof(TestSuitesPage)}");

            return testSuitesPage;
        }
    }
}
