using Core.BaseEntities.API;
using Core.Clients;
using RestSharp;
using TestMonitorTesting.Models;

namespace TestMonitorTesting.Services.API
{
    internal class TestSuiteService : APIService
    {
        public const string AddTestSuiteEndpoint = "/api/v1/test-suites";
        public const string GetTestSuiteEndpoint = "/api/v1/test-suites/{testSuiteId}";

        public TestSuiteService(ApiClient apiClient) : base(apiClient) { }

        public RestResponse AddTestSuite(int projectId, TestSuite newTestSuite)
        {
            newTestSuite.ProjectId = projectId;
            var request = new RestRequest(AddTestSuiteEndpoint, Method.Post)
                .AddBody(newTestSuite);

            return ApiClient.Execute(request);
        }

        public TestSuiteType AddTestSuite<TestSuiteType>(int projectId, TestSuiteType newTestSuite)
            where TestSuiteType : TestSuite, new()
        {
            newTestSuite.ProjectId = projectId;
            var request = new RestRequest(AddTestSuiteEndpoint, Method.Post)
                .AddBody(newTestSuite);

            return ApiClient.Execute<TestSuiteType>(request);
        }

        public RestResponse GetTestSuite(int testSuiteId)
        {
            var request = new RestRequest(GetTestSuiteEndpoint)
                .AddUrlSegment("testSuiteId", testSuiteId);
            return ApiClient.Execute(request);
        }

        public TestSuiteType GetTestSuite<TestSuiteType>(int testSuiteId)
            where TestSuiteType : TestSuite, new()
        {
            var request = new RestRequest(GetTestSuiteEndpoint)
                .AddUrlSegment("testSuiteId", testSuiteId);

            return ApiClient.Execute<TestSuiteType>(request);
        }
    }
}