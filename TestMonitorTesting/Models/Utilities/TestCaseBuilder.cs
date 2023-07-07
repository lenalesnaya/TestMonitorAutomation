using Core.Utilites.Helpers;

namespace TestMonitorTesting.Models.Utilities
{
    internal class TestCaseBuilder
    {
        private CaseData _testCaseData;

        public TestCaseBuilder()
        {
            _testCaseData = new CaseData();
        }

        public static CaseData StandartTestCaseData =>
            TestDataHelper.GetTestEntity<CaseData>("StandartTestCase");


        public static CaseData GetStandartTestCaseData(int testSuiteId)
        {
            var testCase = StandartTestCaseData;
            testCase.TestSuiteId = testSuiteId;

            return testCase;
        }

        public static CaseData RandomTestCaseData => new()
        {
            Name = FakerHelper.Faker.Lorem.Word() + " test suite.",
            Duration = new Random().Next(1, 60),
            ExpectedResult = FakerHelper.Faker.Lorem.Sentences(),
            TestData = FakerHelper.Faker.Lorem.Sentences(),
            Preconditions = FakerHelper.Faker.Lorem.Sentences(),
            Instructions = GetInstructions()
        };

        public static CaseData GetRandomTestCase(int testSuiteId)
        {
            var testCase = RandomTestCaseData;
            testCase.TestSuiteId = testSuiteId;

            return testCase;
        }

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
            _testCaseData.TestSuiteId = testSuiteId;

            return this;
        }

        public TestCaseBuilder SetName(string name)
        {
            _testCaseData.Name = name;

            return this;
        }

        public TestCaseBuilder SetDuration(int duration)
        {
            _testCaseData.Duration = duration;

            return this;
        }

        public TestCaseBuilder SetDraft(bool draft)
        {
            _testCaseData.Draft = draft;

            return this;
        }

        public TestCaseBuilder SetExpectedResult(string expectedResult)
        {
            _testCaseData.ExpectedResult = expectedResult;

            return this;
        }

        public TestCaseBuilder SetTestData(string testData)
        {
            _testCaseData.TestData = testData;

            return this;
        }

        public TestCaseBuilder SetPreconditions(string preconditions)
        {
            _testCaseData.Preconditions = preconditions;

            return this;
        }

        public TestCaseBuilder SetInstructions(List<string> instructions)
        {
            _testCaseData.Instructions = instructions;

            return this;
        }

        public TestCase Build()
        {
            return new TestCase() { Data = _testCaseData };
        }
    }
}