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
        private TestSuiteService _testSuiteService;

        [SetUp]
        public void InitService()
        {
            _testSuiteService = new TestSuiteService(ApiClient);
        }

        [Test, Category("Positive"), Description("Adding of a test suite with random values.")]
        [SmokeTest]
        public void AddTestSuite()
        {
            var newTestSuite = TestSuiteBuilder.RandomTestSuite;
            var addedTestSuite = HandleTestSuiteAdding(newTestSuite);

            Assert.Multiple(() =>
            {
                Assert.That(newTestSuite.Name, Is.EqualTo(addedTestSuite!.Name));
            });
        }

        [Test, Category("Positive"), Description("Getting of recently added test suite.")]
        [SmokeTest]
        public void GetTestSuite()
        {
            var addedTestSuite = HandleTestSuiteAdding(TestSuiteBuilder.StandartTestSuite);
            var receivedTestSuite = _testSuiteService.GetTestSuite<TestSuite>(addedTestSuite!.Id);
            Logger.Info("Received object! " + receivedTestSuite);

            Assert.Multiple(() =>
            {
                Assert.That(receivedTestSuite.Name, Is.EqualTo(addedTestSuite.Name));
            });
        }

        [Test, Category("Negative"), Description("Getting of an unexisted test suite.")]
        [Regression]
        public void GetUnexistedTestSuite()
        {
            var addedTestSuite = HandleTestSuiteAdding(TestSuiteBuilder.StandartTestSuite);
            try
            {
                _testSuiteService.GetTestSuite(addedTestSuite!.Id + 1000);
                Assert.Fail();
            }
            catch (HttpRequestException ex)
            {
                Logger.Info(ex.Message);
                Assert.Pass();
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message);
                Assert.Fail();
            }
        }

        public TestSuite? HandleTestSuiteAdding(TestSuite newTestSuite)
        {
            //var addedProject = new ProjectTests().HandleProjectAdding(
            //    ProjectBuilder.StandartProject);

            return _testSuiteService.AddTestSuite<TestSuite>(
                41, newTestSuite);
        }
    }
}