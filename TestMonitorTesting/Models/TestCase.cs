using Newtonsoft.Json;

namespace TestMonitorTesting.Models
{
    internal class TestCase
    {
        [JsonProperty("data")]
        public CaseData Data { get; set; }

        public override string ToString() =>
            Data.ToString();
    }
}