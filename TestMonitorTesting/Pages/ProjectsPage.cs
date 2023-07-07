using Core.BaseEntities.GUI;
using OpenQA.Selenium;
using TestMonitorTesting.Pages.Components;
using TestMonitorTesting.Wrappers;

namespace TestMonitorTesting.Pages
{
    internal class ProjectsPage : Page
    {
        public readonly Header Header;
        public readonly ProjectCard ProjectCard;
        private static readonly By PaginationNextButtonBy = By.CssSelector(".pagination-link.pagination-next");
        private static readonly By ProjectsTitleBy = By.XPath("//*[@class='title' and text()='Projects']");
        private static readonly By ProjectsSettingsButtonBy = By.CssSelector("a[href$='settings/projects']");

        public UIElement ProjectsTitle => new(Driver, ProjectsTitleBy);
        public Button PaginationNextButton => new(Driver, PaginationNextButtonBy);
        public Button ProjectsSettingsButton => new(Driver, ProjectsSettingsButtonBy);

        protected override string EndPoint => "/my-projects";

        public ProjectsPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            ProjectCard = new ProjectCard(driver!);
            Header = new Header(driver!);
        }

        public ProjectsPage(IWebDriver? driver) : base(driver, false)
        {
            ProjectCard = new ProjectCard(driver!);
            Header = new Header(driver!);
        }

        public override bool IsPageOpened()
        {
            try
            {
                if (ProjectsTitle.Displayed && ProjectsSettingsButton.Displayed)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        public ProjectsSettingsPage ClickProjectsSettingsButton()
        {
            ProjectsSettingsButton.Click();

            var projectsSettingsPage = new ProjectsSettingsPage(Driver);
            projectsSettingsPage.WaitForOpen();
            Logger.Info($"Go to {nameof(ProjectsSettingsPage)}");

            return projectsSettingsPage;
        }

        public OneProjectPage OpenLastAddedProject(string projectName)
        {
            try
            {
                while (!PaginationNextButton.IsDisabled())
                {
                    PaginationNextButton.Click();
                    Logger.Info($"Go to next projects list.");
                }
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message);
            }

            ProjectCard.LastProjectCard.ExecuteScript("arguments[0].click();");

            var oneProjectPage = new OneProjectPage(Driver);
            oneProjectPage.WaitForOpen();
            Logger.Info($"Go to {nameof(OneProjectPage)}");

            return oneProjectPage;
        }
    }
}