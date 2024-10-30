using Core.BaseEntities.API;
using Core.Clients;

namespace TestMonitorTesting.Services.API.Base
{
    internal class TestmonitorApiService : APIService
    {
        public const string BaseEndpoint = "api/v1/";

        public TestmonitorApiService(ApiClient apiClient) : base(apiClient) { }
    }
}