using Allure.Commons;
using Core.BaseEntities.API;
using NUnit.Allure.Attributes;
using SaucedemoTests;
using TestMonitorTesting.Models;
using TestMonitorTesting.Models.Utilities;
using TestMonitorTesting.Services.API;

namespace TestMonitorTesting.Tests.API
{
    [TestFixture]
    internal class TestSuiteTests : APITest
    {
        private ProjectService _projectService;
        private TestSuiteService _testSuiteService;

        [SetUp]
        public void InitService()
        {
            _projectService = new ProjectService(ApiClient);
            _testSuiteService = new TestSuiteService(ApiClient);
        }

        [Test, Category("Positive"), Description("Adding of a test suite with random values.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Any user")]
        [AllureSuite("API")]
        [AllureSubSuite("TestSuiteAPITests")]
        [SmokeTest]
        public void AddTestSuite()
        {
            var newTestSuite = new TestSuite()
            { Data = TestSuiteBuilder.RandomTestSuiteData };

            var addedTestSuite = HandleTestSuiteAdding(newTestSuite);

            Assert.Multiple(() =>
            {
                Assert.That(newTestSuite.Data.Name, Is.EqualTo(addedTestSuite!.Data.Name));
            });
        }

        [Test, Category("Positive"), Description("Getting of recently added test suite.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Any user")]
        [AllureSuite("API")]
        [AllureSubSuite("TestSuiteAPITests")]
        [SmokeTest]
        public void GetTestSuite()
        {
            var addedTestSuite = HandleTestSuiteAdding(
                new TestSuite() { Data = TestSuiteBuilder.StandartTestSuiteData });

            var receivedTestSuite = _testSuiteService.GetTestSuite<TestSuite>(addedTestSuite!.Data.Id);
            Logger.Info("Received object! " + receivedTestSuite);

            Assert.Multiple(() =>
            {
                Assert.That(receivedTestSuite.Data.Name, Is.EqualTo(addedTestSuite.Data.Name));
            });
        }

        [Test, Category("Negative"), Description("Getting of an unexisted test suite.")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Any user")]
        [AllureSuite("API")]
        [AllureSubSuite("TestSuiteAPITests")]
        [Regression]
        public void GetUnexistedTestSuite()
        {
            var addedTestSuite = HandleTestSuiteAdding(
                new TestSuite() { Data = TestSuiteBuilder.StandartTestSuiteData });

            var response = _testSuiteService.GetTestSuite(addedTestSuite!.Data.Id * 1000);
            Logger.Info(response.StatusCode);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound));
        }

        public TestSuite? HandleTestSuiteAdding(TestSuite newTestSuite)
        {
            var addedProject = _projectService.AddProject<Project>(
                new Project() { Data = ProjectBuilder.StandartProjectData });
            Logger.Info("New object! " + addedProject);

            return _testSuiteService.AddTestSuite<TestSuite>(
                addedProject!.Data.Id, newTestSuite);
        }
    }
}