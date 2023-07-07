using Allure.Commons;
using Core.BaseEntities.GUI;
using Core.Utilites.Helpers;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SaucedemoTests;
using TestMonitorTesting.Models;
using TestMonitorTesting.Models.Utilities;
using TestMonitorTesting.Pages.Components;
using TestMonitorTesting.Steps;

namespace TestMonitorTesting.Tests.GUI
{
    [TestFixture]
    internal class TestSuiteTests : GUITest
    {
        [Test, Category("Positive"), Description("Adding of the standart test suite.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("TestSuitesGUITests")]
        [SmokeTest]
        public void CreateTestSuite_WithStandartData()
        {
            var testSuitesPage =
                new TestSuiteSteps(Browser!.Driver).CreateStandartTestSuite();

                Assert.That(testSuitesPage.CheckTestSuiteIsPresented(
                    TestSuiteBuilder.StandartTestSuiteData.Name),
                    Is.True);
        }

        [Test, Category("Positive"), Description("Deleting of just added test suite.")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("TestSuitesGUITests")]
        [SmokeTest]
        public void DeleteTestSuite()
        {
            var randomTestSuiteData = TestSuiteBuilder.RandomTestSuiteData;
            var testSuitesPage =
                new TestSuiteSteps(Browser!.Driver).CreateTestSuite(randomTestSuiteData);

            testSuitesPage.OpenTestSuitePage(randomTestSuiteData.Name)
                .DeleteTestSuite();

            try
            {
                testSuitesPage.GetLastAddedTestSuiteLink(randomTestSuiteData.Name);
                Assert.That(false);
            }
            catch (NoSuchElementException ex)
            {
                Logger.Info(ex.Message);
                Assert.That(true);
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message);
                Assert.That(false);
            }
        }

        [Test, Category("Positive"), Description(
            "Adding of a test suite with positive low limit values of test suite name field.")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("TestSuitesGUITests")]
        [Regression]
        public void CreateTestSuite_WithNameFieldPositiveLowLimitValue()
        {
            var fakeName = FakerHelper.GetAlphabeticStringRandomValue(
                CreateTestSuiteModalWindow.MinLimitSuiteNameValue);
            var newTestSuiteData = new TestSuiteData { Name = fakeName };

            var testSuitesPage =
                new TestSuiteSteps(Browser!.Driver).CreateTestSuite(newTestSuiteData);

            Assert.That(testSuitesPage.CheckTestSuiteIsPresented(
                fakeName),
                Is.True);
        }

        [Test, Category("Positive"), Description(
            "Adding of a test suite with positive high limit values of test suite name field.")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("TestSuitesGUITests")]
        [Regression]
        public void CreateTestSuite_WithNameFieldPositiveHighLimitValue()
        {
            var fakeName = FakerHelper.GetAlphabeticStringRandomValue(
                CreateTestSuiteModalWindow.MaxLimitSuiteNameValue);
            var newTestSuiteData = new TestSuiteData { Name = fakeName };

            var testSuitesPage =
                new TestSuiteSteps(Browser!.Driver).CreateTestSuite(newTestSuiteData);

            Assert.That(testSuitesPage.CheckTestSuiteIsPresented(
                fakeName),
                Is.True);
        }

        [Test, Category("Positive"), Description(
            "Check of the popup message 'Test suite <test suite name> created'.")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("TestSuitesGUITests")]
        [Regression]
        public void CreateTestSuite_CheckPopUpMessage()
        {
            var testSuitesPage =
                new TestSuiteSteps(Browser!.Driver).CreateStandartTestSuite();

            Assert.That(testSuitesPage.SuiteIsCreatedPopUp.IsClickable,
                Is.True);
        }

        [Test, Category("Positive"), Description(
            "Check of the dialog window 'Add test suite' closing.")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("TestSuitesGUITests")]
        [Regression]
        public void CreateTestSuite_CheckDialogWindow()
        {
            var createTestSuiteModalWindow = new ProjectSteps(Browser!.Driver)
                 .CreateSimpleStandartProject()
                 .Header.ClickProjectsLink()
                 .OpenLastAddedProject(ProjectBuilder.StandartProjectData.Name)
                 .ClickTestSuitesLink()
                 .ClickAddTestSuiteButton();

            new Actions(Browser.Driver).SendKeys(Keys.Escape).Build().Perform();

            Assert.That(createTestSuiteModalWindow.CancelButton.Displayed,
                Is.False);
        }

        [Test, Category("Negative"), Description(
            "Adding of a test suite with negative value (spaces) of test suite name field.")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("TestSuitesGUITests")]
        [Regression]
        public void CreateTestSuite_WithNameFieldNegativeValue()
        {
            var fakeSpaceName = FakerHelper.GetSymbolsSpecifiedRangeStringRandomValue(
                new Random().Next(1, 100), ' ', ' ');

            var createTestSuiteModalWindow = new ProjectSteps(Browser!.Driver)
                 .CreateSimpleStandartProject()
                 .Header.ClickProjectsLink()
                 .OpenLastAddedProject(ProjectBuilder.StandartProjectData.Name)
                 .ClickTestSuitesLink()
                 .ClickAddTestSuiteButton();

            createTestSuiteModalWindow.SetSuiteName(fakeSpaceName);
            createTestSuiteModalWindow.AddButton.Click();

            Assert.Multiple(() =>
            {
                Assert.That(createTestSuiteModalWindow.AddButton.IsDisabled(), Is.True);
                Assert.That(createTestSuiteModalWindow.DangerMessage.Displayed, Is.True);
            });
        }

        [Test, Category("Negative"), Description("Check of overlimit test suite name field value input.")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("TestSuitesGUITests")]
        [Regression]
        public void CreateTestSuite_WithNameFieldOverLimitValue()
        {
            var fakeOverLimitName = FakerHelper.GetAlphabeticStringRandomValue(
                CreateTestSuiteModalWindow.MaxLimitSuiteNameValue + 1);

            var createTestSuiteModalWindow = new ProjectSteps(Browser!.Driver)
                 .CreateSimpleStandartProject()
                 .Header.ClickProjectsLink()
                 .OpenLastAddedProject(ProjectBuilder.StandartProjectData.Name)
                 .ClickTestSuitesLink()
                 .ClickAddTestSuiteButton();

            createTestSuiteModalWindow.SetSuiteName(fakeOverLimitName);
            var inputText = createTestSuiteModalWindow.TestSuiteNameInput.GetAttribute("value");

            Assert.That(inputText.Length == CreateTestSuiteModalWindow.MaxLimitSuiteNameValue,
                Is.True);
        }

        [Test, Category("Negative"), Description(
            "(crash test) Adding of a test suite with negative space value of test suite name field.")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Any user")]
        [AllureSuite("GUI")]
        [AllureSubSuite("TestSuitesGUITests")]
        [Regression]
        public void CrashTest_WithNameFieldNegativeValue()
        {
            var fakeName = FakerHelper.GetSymbolsSpecifiedRangeStringRandomValue(
                new Random().Next(1, 100), ' ', ' ');

            var newTestSuiteData = new TestSuiteData { Name = fakeName };
            var testSuitesPage =
                new TestSuiteSteps(Browser!.Driver).CreateTestSuite(newTestSuiteData);

            Assert.That(testSuitesPage.CheckTestSuiteIsPresented(
                fakeName),
                Is.True);
        }
    }
}