using Newtonsoft.Json;

namespace TestMonitorTesting.Models
{
    internal class TestCase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("test_suite_id")]
        public int TestSuiteId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("draft")]
        public bool Draft { get; set; }

        [JsonProperty("expected_result")]
        public string? ExpectedResult { get; set; }

        [JsonProperty("test_data")]
        public string? TestData { get; set; }

        [JsonProperty("preconditions")]
        public string? Preconditions { get; set; }

        [JsonProperty("instructions")]
        public List<string>? Instructions { get; set; }

        public override string ToString() =>
            $"{nameof(Id)}: {Id} // " +
            $"{nameof(TestSuiteId)}: {TestSuiteId} // " +
            $"{nameof(Name)}: {Name} // " +
            $"{nameof(Duration)}: {Duration} // " +
            $"{nameof(Preconditions)}: {Preconditions} // " +
            $"{nameof(ExpectedResult)}: {ExpectedResult} // " +
            $"{nameof(TestData)}: {TestData}";

        protected bool Equals(TestCase other) =>
                Id == other.Id &&
                TestSuiteId == other.TestSuiteId &&
                Name == other.Name;

        public override int GetHashCode() =>
            HashCode.Combine(
                Id,
                TestSuiteId,
                Name);

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((TestSuite)obj);
        }
    }
}