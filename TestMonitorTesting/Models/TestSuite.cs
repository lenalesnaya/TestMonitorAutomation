using Newtonsoft.Json;

namespace TestMonitorTesting.Models
{
    internal class TestSuite
    {
        [JsonProperty("data")]
        public TestSuiteData Data { get; set; }

        public override string ToString() =>
            Data.ToString();
    }
}