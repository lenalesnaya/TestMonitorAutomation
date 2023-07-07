using Core.BaseEntities.API;
using Core.Clients;
using RestSharp;
using TestMonitorTesting.Models;

namespace TestMonitorTesting.Services.API
{
    internal class TestCaseService : APIService
    {
        public const string AddTestCaseEndpoint = "/api/v1/test-cases";
        public const string GetTestCaseEndpoint = "/api/v1/test-cases/{testCaseId}";

        public TestCaseService(ApiClient apiClient) : base(apiClient) { }

        public RestResponse AddTestCase(int testSuiteId, TestCase newTestCase)
        {
            newTestCase.Data.TestSuiteId = testSuiteId;
            var request = new RestRequest(AddTestCaseEndpoint, Method.Post)
                .AddBody(newTestCase.Data);

            return ApiClient.Execute(request);
        }

        public TestCaseType AddTestCase<TestCaseType>(int testSuiteId, TestCaseType newTestCase)
            where TestCaseType : TestCase, new()
        {
            newTestCase.Data.TestSuiteId = testSuiteId;
            var request = new RestRequest(AddTestCaseEndpoint, Method.Post)
                .AddBody(newTestCase.Data);

            return ApiClient.Execute<TestCaseType>(request);
        }

        public RestResponse GetTestCase(int testCaseId)
        {
            var request = new RestRequest(GetTestCaseEndpoint)
                .AddUrlSegment("testCaseId", testCaseId);
            return ApiClient.Execute(request);
        }

        public TestCaseType GetTestCase<TestCaseType>(int testCaseId)
            where TestCaseType : TestCase, new()
        {
            var request = new RestRequest(GetTestCaseEndpoint)
                .AddUrlSegment("testCaseId", testCaseId);

            return ApiClient.Execute<TestCaseType>(request);
        }
    }
}