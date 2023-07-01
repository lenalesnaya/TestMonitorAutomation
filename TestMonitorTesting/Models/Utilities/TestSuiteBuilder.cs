using Core.Utilites.Helpers;

namespace TestMonitorTesting.Models.Utilities
{
    internal class TestSuiteBuilder
    {
        public static TestSuite GetStandartTestSuite(int projectId)
        {
            var suite = TestDataHelper.GetTestEntity<TestSuite>("StandartTestSuite");
            suite.ProjectId = projectId;

            return suite;
        }

        public static TestSuite GetRandomTestSuite(int projectId) => new()
        {
            Name = FakerHelper.Faker.Lorem.Word() + " test suite.",
            Description = FakerHelper.Faker.Lorem.Sentences(),
            ProjectId = projectId
        };
    }
}