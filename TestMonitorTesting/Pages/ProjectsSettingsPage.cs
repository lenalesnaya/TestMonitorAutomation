using Core.BaseEntities.GUI;
using OpenQA.Selenium;
using TestMonitorTesting.Pages.Components;
using TestMonitorTesting.Wrappers;

namespace TestMonitorTesting.Pages
{
    internal class ProjectsSettingsPage : Page
    {
        protected override string EndPoint => "/settings/projects";

        public readonly Header Header;

        private static readonly By SettingsTitleBy = By.XPath("//*[@class='title' and text()='Settings']");
        private static readonly By CreateProjectButtonBy = By.XPath("//button[contains(text(), 'Create project')]");

        public UIElement SettingsTitle => new(Driver, SettingsTitleBy);
        public Button CreateProjectButton => new(Driver, CreateProjectButtonBy);

        public ProjectsSettingsPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            Header = new Header(driver!);
        }

        public ProjectsSettingsPage(IWebDriver? driver) : base(driver, false)
        {
            Header = new Header(driver!);
        }

        public override bool IsPageOpened()
        {
            try
            {
                if (SettingsTitle.Displayed && CreateProjectButton.Displayed)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        public CreateProjectModalWindow ClickCreateProjectButton()
        {
            CreateProjectButton.Click();
            Logger.Info($"Go to {nameof(CreateProjectModalWindow)}");

            return new CreateProjectModalWindow(Driver!);
        }
    }
}