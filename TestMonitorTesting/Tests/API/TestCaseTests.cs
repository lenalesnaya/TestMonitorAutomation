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
    internal class TestCaseTests : APITest
    {
        private ProjectService _projectService;
        private TestSuiteService _testSuiteService;
        private TestCaseService _testCaseService;

        [SetUp]
        public void InitService()
        {
            _projectService = new ProjectService(ApiClient);
            _testSuiteService = new TestSuiteService(ApiClient);
            _testCaseService = new TestCaseService(ApiClient);
        }

        [Test, Category("Positive"), Description("Adding of a test case with random values.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Any user")]
        [AllureSuite("API")]
        [AllureSubSuite("TestCaseAPITests")]
        [SmokeTest]
        public void AddTestCase()
        {
            var newTestCase = new TestCase()
            { Data = TestCaseBuilder.RandomTestCaseData };

            var addedTestCase = HandleTestCaseAdding(newTestCase);

            Assert.Multiple(() =>
            {
                Assert.That(newTestCase.Data.Name, Is.EqualTo(addedTestCase!.Data.Name));
            });
        }

        [Test, Category("Positive"), Description("Getting of recently added test case.")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Any user")]
        [AllureSuite("API")]
        [AllureSubSuite("TestCaseAPITests")]
        [SmokeTest]
        public void GetTestCase()
        {
            var addedTestCase = HandleTestCaseAdding(
                new TestCase() { Data = TestCaseBuilder.StandartTestCaseData });

            var receivedTestCase = _testCaseService.GetTestCase<TestCase>(addedTestCase!.Data.Id);
            Logger.Info("Received object! " + receivedTestCase);

            Assert.Multiple(() =>
            {
                Assert.That(receivedTestCase.Data.Name, Is.EqualTo(addedTestCase.Data.Name));
            });
        }

        public TestCase? HandleTestCaseAdding(TestCase newTestCase)
        {
            var addedProject = _projectService.AddProject<Project>(
                new Project() { Data = ProjectBuilder.StandartProjectData });
            Logger.Info("New object! " + addedProject);

            var addedTestSuite =  _testSuiteService.AddTestSuite<TestSuite>(
                addedProject!.Data.Id,
                new TestSuite() { Data = TestSuiteBuilder.StandartTestSuiteData });

            return _testCaseService.AddTestCase<TestCase>(
                addedTestSuite!.Data.Id, newTestCase);
        }
    }
}