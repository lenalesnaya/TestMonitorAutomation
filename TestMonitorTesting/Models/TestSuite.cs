using Newtonsoft.Json;

namespace TestMonitorTesting.Models
{
    internal class TestSuite
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

        public override string ToString() =>
                $"{nameof(Id)}: {Id} // " +
                $"{nameof(Name)}: {Name} // " +
                $"{nameof(Description)}: {Description}";

        protected bool Equals(TestSuite other) =>
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