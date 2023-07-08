using Core.BaseEntities.GUI;
using OpenQA.Selenium;
using TestMonitorTesting.Models;
using TestMonitorTesting.Wrappers;

namespace TestMonitorTesting.Pages.Components
{
    internal class CreateTestSuiteModalWindow : PageComponent
    {
        public const int MinLimitSuiteNameValue = 1;
        public const int MaxLimitSuiteNameValue = 100;

        public static readonly By WindowBy = By.ClassName("modal-card");
        public static readonly By WindowTitleBy =
            By.XPath("//*[@class='modal-card-title' and text()='Add Test Suite']");
        public static readonly By TestSuiteNameInputBy = By.Name("name");
        public static readonly By TestSuiteDescriptionInputBy = By.Name("description");
        public static readonly By AddButtonBy = By.CssSelector(".button.is-success");
        public static readonly By CancelButtonBy = By.CssSelector(".button.is-white");
        public static readonly By DangerMessageBy = By.CssSelector(".help.is-danger");

        public UIElement Window => new(Driver, WindowBy);
        public UIElement WindowTitle => new(Driver, WindowTitleBy);
        public Input TestSuiteNameInput => new(Driver, Window.FindElement(TestSuiteNameInputBy));
        public Input TestSuiteDescriptionInput => new(Driver, Window.FindElement(TestSuiteDescriptionInputBy));
        public Button AddButton => new(Driver, Window.FindElement(AddButtonBy));
        public Button CancelButton => new(Driver, Window.FindElement(CancelButtonBy));
        public UIElement DangerMessage => new(Driver, DangerMessageBy);

        public CreateTestSuiteModalWindow(IWebDriver driver) : base(driver) { }

        public override bool IsComponentExists()
        {
            return WindowTitle.Displayed;
        }

        public CreateTestSuiteModalWindow SetSuiteName(string name)
        {
            TestSuiteNameInput.Write(name);
            return this;
        }

        public CreateTestSuiteModalWindow SetSuiteDescription(string? description = null)
        {
            TestSuiteDescriptionInput.Write(description ?? string.Empty);
            return this;
        }

        public TestSuitesPage ClickAddButton()
        {
            if (!AddButton.IsDisabled())
            {
                AddButton.Click();
                Logger.Info($"Go to {nameof(TestSuitesPage)}");
            }

            return new TestSuitesPage(Driver);
        }

        public TestSuitesPage ClickCancelButton()
        {
            CancelButton.Click();
            Logger.Info($"Go to {nameof(TestSuitesPage)}");

            return new TestSuitesPage(Driver);
        }

        public TestSuitesPage CreateTestSuite(TestSuiteData testSuiteData) =>
            SetSuiteName(testSuiteData.Name)
            .SetSuiteDescription(testSuiteData.Description!)
            .ClickAddButton();
    }
}