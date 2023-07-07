using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestMonitorTesting.Models
{
    public class ProjectData
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonProperty("symbol_id")]
        [JsonPropertyName("symbol_id")]
        public int SymbolId { get; set; }

        [JsonProperty("description")]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonProperty("starts_at")]
        [JsonPropertyName("starts_at")]
        public string? StartsAt { get; set; }

        [JsonProperty("ends_at")]
        [JsonPropertyName("ends_at")]
        public string? EndsAt { get; set; }

        [JsonProperty("uses_applications")]
        [JsonPropertyName("uses_applications")]
        public bool UsesApplications { get; set; }

        [JsonProperty("uses_requirements")]
        [JsonPropertyName("uses_requirements")]
        public bool UsesRequirements { get; set; }

        [JsonProperty("uses_risks")]
        [JsonPropertyName("uses_risks")]
        public bool UsesRisks { get; set; }

        [JsonProperty("uses_issues")]
        [JsonPropertyName("uses_issues")]
        public bool UsesIssues { get; set; }

        [JsonProperty("uses_messages")]
        [JsonPropertyName("uses_messages")]
        public bool UsesMessages { get; set; }

        [JsonProperty("completed")]
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        //public string? AdditionalProperty { get; set; }

        public override string ToString() =>
                $"{nameof(Id)}: {Id} // " +
                $"{nameof(Name)}: {Name} // " +
                $"{nameof(StartsAt)}: {StartsAt} // " +
                $"{nameof(EndsAt)}: {EndsAt} // " +
                $"{nameof(Completed)}: {Completed}";

        protected bool Equals(ProjectData other) =>
                Id == other.Id &&
                Name == other.Name &&
                SymbolId == other.SymbolId;

        public override int GetHashCode() =>
            HashCode.Combine(
                Id,
                Name,
                SymbolId,
                StartsAt,
                EndsAt);

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((ProjectData)obj);
        }
    }
}