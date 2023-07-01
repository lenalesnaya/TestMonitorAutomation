using Core.Utilites.Helpers;

namespace TestMonitorTesting.Models.Utilities
{
    internal class TestCaseBuilder
    {
        private TestCase _testCase;

        public TestCaseBuilder()
        {
            _testCase = new TestCase();
        }

        public static TestCase GetStandartTestCase(int testSuiteId)
        {
            var testCase = TestDataHelper.GetTestEntity<TestCase>("StandartTestCase");
            testCase.TestSuiteId = testSuiteId;

            return testCase;
        }

        public static TestCase GetRandomTestCase(int testSuiteId) => new()
        {
            Name = FakerHelper.Faker.Lorem.Word() + " test suite.",
            TestSuiteId = testSuiteId,
            Duration = new Random().Next(1, 60),
            ExpectedResult = FakerHelper.Faker.Lorem.Sentences(),
            TestData = FakerHelper.Faker.Lorem.Sentences(),
            Preconditions = FakerHelper.Faker.Lorem.Sentences(),
            Instructions = GetInstructions()
        };

        private static List<string> GetInstructions()
        {
            var instructions = new List<string>();
            var listCount = new Random().Next(1, 15);

            for (int i = 0; i < listCount; i++)
            {
                instructions.Add(FakerHelper.Faker.Lorem.Sentence());
            }

            return instructions;
        }

        public TestCaseBuilder SetTestSuiteId(int testSuiteId)
        {
            _testCase.TestSuiteId = testSuiteId;

            return this;
        }

        public TestCaseBuilder SetName(string name)
        {
            _testCase.Name = name;

            return this;
        }

        public TestCaseBuilder SetDuration(int duration)
        {
            _testCase.Duration = duration;

            return this;
        }

        public TestCaseBuilder SetDraft(bool draft)
        {
            _testCase.Draft = draft;

            return this;
        }

        public TestCaseBuilder SetExpectedResult(string expectedResult)
        {
            _testCase.ExpectedResult = expectedResult;

            return this;
        }

        public TestCaseBuilder SetTestData(string testData)
        {
            _testCase.TestData = testData;

            return this;
        }

        public TestCaseBuilder SetPreconditions(string preconditions)
        {
            _testCase.Preconditions = preconditions;

            return this;
        }

        public TestCaseBuilder SetInstructions(List<string> instructions)
        {
            _testCase.Instructions = instructions;

            return this;
        }

        public TestCase Build()
        {
            return _testCase;
        }
    }
}