using Core.BaseEntities.GUI;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using TestMonitorTesting.Models;
using TestMonitorTesting.Models.Utilities;
using TestMonitorTesting.Pages;

namespace TestMonitorTesting.Steps
{
    internal class TestSuiteSteps : Step
    {
        public TestSuiteSteps(IWebDriver? driver) : base(driver) { }

        [AllureStep("Create standart test suite.")]
        public TestSuitesPage CreateStandartTestSuite() =>
            new ProjectSteps(Driver)
                .CreateSimpleStandartProject()
                .Header.ClickProjectsLink()
                .OpenLastAddedProject(ProjectBuilder.StandartProjectData.Name)
                .ClickTestSuitesLink()
                .ClickAddTestSuiteButton()
                .CreateTestSuite(TestSuiteBuilder.StandartTestSuiteData);

        [AllureStep("Create test suite.")]
        public TestSuitesPage CreateTestSuite(TestSuiteData testSuiteData) =>
            new ProjectSteps(Driver)
            .CreateSimpleStandartProject()
            .Header.ClickProjectsLink()
            .OpenLastAddedProject(ProjectBuilder.StandartProjectData.Name)
            .ClickTestSuitesLink()
            .ClickAddTestSuiteButton()
            .CreateTestSuite(testSuiteData);
    }
}