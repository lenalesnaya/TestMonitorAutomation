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
        private TestCaseService _testCaseService;

        [SetUp]
        public void InitService()
        {
            _testCaseService = new TestCaseService(ApiClient);
        }

        [Test, Category("Positive"), Description("Adding of a test case with random values.")]
        [SmokeTest]
        public void AddTestCase()
        {
            var newTestCase = TestCaseBuilder.RandomTestCase;
            var addedTestCase = HandleTestCaseAdding(newTestCase);

            Assert.Multiple(() =>
            {
                Assert.That(newTestCase.Name, Is.EqualTo(addedTestCase!.Name));
            });
        }

        [Test, Category("Positive"), Description("Getting of recently added test case.")]
        [SmokeTest]
        public void GetTestCase()
        {
            var addedTestCase = HandleTestCaseAdding(TestCaseBuilder.StandartTestCase);
            var receivedTestCase = _testCaseService.GetTestCase<TestCase>(addedTestCase!.Id);
            Logger.Info("Received object! " + receivedTestCase);

            Assert.Multiple(() =>
            {
                Assert.That(receivedTestCase.Name, Is.EqualTo(addedTestCase.Name));
            });
        }

        public TestCase? HandleTestCaseAdding(TestCase newTestCase)
        {
            var addedTestSuite = new TestSuiteTests().HandleTestSuiteAdding(
                TestSuiteBuilder.StandartTestSuite);

            return _testCaseService.AddTestCase<TestCase>(
                addedTestSuite!.Id, newTestCase);
        }
    }
}