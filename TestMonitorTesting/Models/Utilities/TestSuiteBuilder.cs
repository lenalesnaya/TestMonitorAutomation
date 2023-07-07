using Core.Utilites.Helpers;

namespace TestMonitorTesting.Models.Utilities
{
    internal class TestSuiteBuilder
    {
        private TestSuite _testSuite;

        public TestSuiteBuilder()
        {
            _testSuite = new TestSuite();
        }

        public static TestSuite StandartTestSuite =>
            TestDataHelper.GetTestEntity<TestSuite>("StandartTestSuite");


        public static TestSuite GetStandartTestSuite(int projectId)
        {
            var suite = StandartTestSuite;
            suite.ProjectId = projectId;

            return suite;
        }

        public static TestSuite RandomTestSuite => new()
        {
            Name = FakerHelper.Faker.Lorem.Word() + " test suite.",
            Description = FakerHelper.Faker.Lorem.Sentences(),
        };

        public static TestSuite GetRandomTestSuite(int projectId)
        {
            var testSuite = RandomTestSuite;
            testSuite.ProjectId = projectId;

            return testSuite;
        }

        public TestSuiteBuilder SetName(string name)
        {
            _testSuite.Name = name;

            return this;
        }

        public TestSuiteBuilder SetDescription(string description)
        {
            _testSuite.Description = description;

            return this;
        }

        public TestSuiteBuilder SetProjectId(int projectId)
        {
            _testSuite.ProjectId = projectId;

            return this;
        }

        public TestSuite Build()
        {
            return _testSuite;
        }
    }
}