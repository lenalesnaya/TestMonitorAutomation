using System.Text.Json.Serialization;

namespace TestMonitorTesting.Models
{
    internal class TestSuiteData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("project_id")]
        public int ProjectId { get; set; }

        public override string ToString() =>
                $"{nameof(Id)}: {Id} // " +
                $"{nameof(Name)}: {Name} // " +
                $"{nameof(Description)}: {Description}";

        protected bool Equals(TestSuiteData other) =>
                Id == other.Id &&
                Name == other.Name &&
                ProjectId == other.ProjectId;

        public override int GetHashCode() =>
            HashCode.Combine(
                Id,
                Name,
                ProjectId);

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((TestSuite)obj);
        }
    }
}