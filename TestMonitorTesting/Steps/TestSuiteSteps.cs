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
                .OpenLastAddedProject(ProjectBuilder.StandartProject.Name)
                .ClickTestSuitesLink()
                .ClickAddTestSuiteButton()
                .CreateTestSuite(TestSuiteBuilder.StandartTestSuite);

        [AllureStep("Create test suite.")]
        public TestSuitesPage CreateTestSuite(TestSuite testSuite) =>
            new ProjectSteps(Driver)
            .CreateSimpleStandartProject()
            .Header.ClickProjectsLink()
            .OpenLastAddedProject(ProjectBuilder.StandartProject.Name)
            .ClickTestSuitesLink()
            .ClickAddTestSuiteButton()
            .CreateTestSuite(testSuite);
    }
}