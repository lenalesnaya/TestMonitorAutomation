using Core.BaseEntities.GUI;
using OpenQA.Selenium;
using TestMonitorTesting.Pages.Components;
using TestMonitorTesting.Wrappers;

namespace TestMonitorTesting.Pages
{
    internal class TestSuitesPage : Page
    {
        private static readonly string AddedTestSuiteTitleLocatorTemplate = "//td[@data-label='Name']//a[text()='{0}']";

        private static readonly By AddTestSuiteButtonBy = By.XPath("//button[contains(text(), 'Add Test Suite')]");
        private static readonly By PaginationNextButtonBy = By.CssSelector(".pagination-link.pagination-next");
        private static readonly By SuiteIsCreatedPopUpBy = By.XPath("//*[@role='alert']//a[contains(@href, 'test-suites/')]");

        public Button AddTestSuiteButton => new(Driver, AddTestSuiteButtonBy);
        public Button PaginationNextButton => new(Driver, PaginationNextButtonBy);
        public UIElement SuiteIsCreatedPopUp => new(Driver, WaitService!.GetVisibleElementByFluentWait(SuiteIsCreatedPopUpBy));

        public TestSuitesPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public TestSuitesPage(IWebDriver? driver) : base(driver, false) { }

        protected override string EndPoint => "/test-suites";

        public override bool IsPageOpened()
        {
            try
            {
                return AddTestSuiteButton.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public CreateTestSuiteModalWindow ClickAddTestSuiteButton()
        {
            AddTestSuiteButton.Click();
            Logger.Info($"Go to {nameof(CreateTestSuiteModalWindow)}");

            return new CreateTestSuiteModalWindow(Driver!);
        }

        public UIElement GetLastAddedTestSuiteLink(string testSuiteName)
        {
            try
            {
                while (!PaginationNextButton.IsDisabled())
                {
                    PaginationNextButton.Click();
                    Logger.Info($"Go to next suites list.");
                }
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message);
            }

            var locator = By.XPath(string.Format(AddedTestSuiteTitleLocatorTemplate, testSuiteName));
            return new UIElement(Driver, locator);
        }

        public OneTestSuitePage OpenTestSuitePage(string testSuiteName)
        {
            GetLastAddedTestSuiteLink(testSuiteName).Click();

            var oneTestSuitePage = new OneTestSuitePage(Driver);
            oneTestSuitePage.WaitForOpen();
            Logger.Info($"Go to {nameof(OneTestSuitePage)}");

            return oneTestSuitePage;
        }

        public bool CheckTestSuiteIsPresented(string testSuiteName) =>
            GetLastAddedTestSuiteLink(testSuiteName).Displayed;
    }
}