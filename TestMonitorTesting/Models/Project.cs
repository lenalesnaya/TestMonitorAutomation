using Newtonsoft.Json;

namespace TestMonitorTesting.Models
{
    internal class Project
    {
        [JsonProperty("data")]
        public ProjectData Data { get; set; }

        public override string ToString() =>
            Data.ToString();
    }
}