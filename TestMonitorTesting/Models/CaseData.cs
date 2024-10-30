using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestMonitorTesting.Models
{
    internal class CaseData
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("test_suite_id")]
        [JsonPropertyName("test_suite_id")]
        public int TestSuiteId { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("duration")]
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonProperty("draft")]
        [JsonPropertyName("draft")]
        public bool Draft { get; set; }

        [JsonProperty("expected_result")]
        [JsonPropertyName("expected_result")]
        public string? ExpectedResult { get; set; }

        [JsonProperty("test_data")]
        [JsonPropertyName("test_data")]
        public string? TestData { get; set; }

        [JsonProperty("preconditions")]
        [JsonPropertyName("preconditions")]
        public string? Preconditions { get; set; }

        [JsonProperty("instructions")]
        [JsonPropertyName("instructions")]
        public List<string>? Instructions { get; set; }

        public override string ToString() =>
            $"{nameof(Id)}: {Id} // " +
            $"{nameof(TestSuiteId)}: {TestSuiteId} // " +
            $"{nameof(Name)}: {Name} // " +
            $"{nameof(Duration)}: {Duration} // " +
            $"{nameof(Preconditions)}: {Preconditions} // " +
            $"{nameof(ExpectedResult)}: {ExpectedResult} // " +
            $"{nameof(TestData)}: {TestData}";

        protected bool Equals(CaseData other) =>
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