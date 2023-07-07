using Core.BaseEntities.GUI;
using Core.Utilites.Configuration;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestMonitorTesting.Models.Utilities;
using TestMonitorTesting.Pages;

namespace TestMonitorTesting.Steps
{
    internal class ProjectSteps : Step
    {
        public ProjectSteps(IWebDriver? driver) : base(driver) { }

        [AllureStep("Create simple standart project (with only project name entering).")]
        public ProjectsSettingsPage CreateSimpleStandartProject() =>
            new LoginPage(Driver, true)
                .Login(Configurator.Admin!)
                .ClickProjectsSettingsButton()
                .ClickCreateProjectButton()
                .CreateProject(ProjectBuilder.StandartProject);
    }
}