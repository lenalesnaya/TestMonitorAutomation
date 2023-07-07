using Core.BaseEntities.GUI;
using OpenQA.Selenium;
using TestMonitorTesting.Wrappers;

namespace TestMonitorTesting.Pages
{
    internal class OneTestSuitePage : Page
    {
        private static readonly By DropdownButtonBy = By.ClassName("dropdown-trigger");
        private static readonly By DeleteTestSuiteItemBy = By.XPath(
            "//a[@class='dropdown-item']//*[contains(text(), 'Delete')]");
        private static readonly By DeleteCheckboxBy = By.XPath("//*[@class='modal-card']//input[@type='checkbox']");
        public static readonly By DeleteButtonBy = By.XPath("//button[text()='Delete']");

        public Button DropdownButton => new(Driver, DropdownButtonBy);
        public UIElement DeleteTestSuiteItem => new(Driver, DeleteTestSuiteItemBy);
        public Checkbox DeleteCheckbox => new(Driver, Driver!.FindElement(DeleteCheckboxBy));
        public Button DeleteButton => new(Driver, DeleteButtonBy);

        protected override string EndPoint => throw new NotImplementedException();

        public OneTestSuitePage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl) { }

        public OneTestSuitePage(IWebDriver? driver) : base(driver, false) { }

        public override bool IsPageOpened()
        {
            try
            {
                return DropdownButton.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public OneTestSuitePage ClickDropdownButton()
        {
            DropdownButton.Click();
            return this;
        }

        public OneTestSuitePage ClickDeleteTestSuiteItem()
        {
            DeleteTestSuiteItem.Click();
            return this;
        }

        public OneTestSuitePage SelectDeleteCheckbox()
        {
            DeleteCheckbox.Select();
            return this;
        }

        public TestSuitesPage ClickDeleteButton()
        {
            if (DeleteButton.IsClickable)
            {
                DeleteButton.Click();
            }

            var testSuitesPage = new TestSuitesPage(Driver);
            testSuitesPage.WaitForOpen();
            Logger.Info($"Go to {nameof(TestSuitesPage)}");

            return testSuitesPage;
        }

        public TestSuitesPage DeleteTestSuite() =>
            ClickDropdownButton()
            .ClickDeleteTestSuiteItem()
            .SelectDeleteCheckbox()
            .ClickDeleteButton();
    }
}