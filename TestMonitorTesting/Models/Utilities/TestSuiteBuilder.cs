using Core.Utilites.Helpers;

namespace TestMonitorTesting.Models.Utilities
{
    internal class TestSuiteBuilder
    {
        private TestSuiteData _testSuiteData;

        public TestSuiteBuilder()
        {
            _testSuiteData = new TestSuiteData();
        }

        public static TestSuiteData StandartTestSuiteData =>
            TestDataHelper.GetTestEntity<TestSuiteData>("StandartTestSuite");

        public static TestSuiteData GenerateRandomTestSuiteData() => new()
        {
            Name = FakerHelper.Faker.Lorem.Word() + " test suite.",
            Description = FakerHelper.Faker.Lorem.Sentences(),
        };

        public TestSuiteBuilder SetName(string name)
        {
            _testSuiteData.Name = name;

            return this;
        }

        public TestSuiteBuilder SetDescription(string description)
        {
            _testSuiteData.Description = description;

            return this;
        }

        public TestSuiteBuilder SetProjectId(int projectId)
        {
            _testSuiteData.ProjectId = projectId;

            return this;
        }

        public TestSuite Build()
        {
            return new TestSuite() { Data = _testSuiteData };
        }
    }
}