using Core.Utilites.Helpers;

namespace TestMonitorTesting.Models.Utilities
{
    internal class TestCaseBuilder
    {
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
    }
}