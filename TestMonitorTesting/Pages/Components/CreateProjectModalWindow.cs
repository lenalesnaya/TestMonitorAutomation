using OpenQA.Selenium;
using Core.BaseEntities.GUI;
using TestMonitorTesting.Wrappers;
using TestMonitorTesting.Models;

namespace TestMonitorTesting.Pages.Components
{
    internal class CreateProjectModalWindow : PageComponent
    {
        public static readonly By WindowBy = By.ClassName("modal-card");
        public static readonly By WindowTitleBy =
            By.XPath("//*[@class='modal-card-title' and text()='Add Project']");
        public static readonly By ProjectNameInputBy = By.CssSelector("input[name='name']");
        public static readonly By FeaturesButtonBy = By.XPath("//button//*[text()='Features']");
        public static readonly By TemplateButtonBy = By.XPath("//button//*[text()='Template']");
        public static readonly By CreateButtonBy = By.XPath("//button//*[text()='Create']");

        public UIElement Window => new(Driver, WindowBy);
        public UIElement WindowTitle => new(Driver, WindowTitleBy);
        public Input ProjectNameInput => new(Driver, Window.FindElement(ProjectNameInputBy));
        public Button FeaturesButton => new(Driver, Window.FindElement(FeaturesButtonBy));
        public Button TemplateButton => new(Driver, Window.FindElement(TemplateButtonBy));
        public Button CreateButton => new(Driver, Window.FindElement(CreateButtonBy));

        public CreateProjectModalWindow(IWebDriver driver) : base(driver) { }

        public override bool IsComponentExists()
        {
            return WindowTitle.Displayed;
        }

        public CreateProjectModalWindow SetProjectName(string projectName)
        {
            ProjectNameInput.Write(projectName);
            return this;
        }

        public CreateProjectModalWindow ClickFeaturesButton()
        {
            if (FeaturesButton.IsClickable)
            {
                FeaturesButton.Click();
            }

            return this;
        }

        public CreateProjectModalWindow ClickTemplateButton()
        {
            TemplateButton.Click();
            return this;
        }

        public ProjectsSettingsPage ClickCreateButton()
        {
            CreateButton.Click();
            Logger.Info($"Go to {nameof(ProjectsSettingsPage)}");
            return new ProjectsSettingsPage(Driver);
        }

        public ProjectsSettingsPage CreateProject(Project project) =>
            SetProjectName(project.Name)
            .ClickFeaturesButton()
            .ClickTemplateButton()
            .ClickCreateButton();
    }
}