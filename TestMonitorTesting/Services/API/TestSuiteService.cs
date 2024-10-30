using Core.BaseEntities.API;
using Core.Clients;
using RestSharp;
using TestMonitorTesting.Models;
using TestMonitorTesting.Services.API.Base;

namespace TestMonitorTesting.Services.API
{
    internal class TestSuiteService : TestmonitorApiService
    {
        public const string AddTestSuiteEndpoint = BaseEndpoint + "test-suites";
        public const string GetTestSuiteEndpoint = BaseEndpoint + "test-suites/{testSuiteId}";

        public TestSuiteService(ApiClient apiClient) : base(apiClient) { }

        public RestResponse AddTestSuite(int projectId, TestSuite newTestSuite)
        {
            newTestSuite.Data.ProjectId = projectId;
            var request = new RestRequest(AddTestSuiteEndpoint, Method.Post)
                .AddBody(newTestSuite.Data);

            return ApiClient.Execute(request);
        }

        public TestSuiteType AddTestSuite<TestSuiteType>(int projectId, TestSuiteType newTestSuite)
            where TestSuiteType : TestSuite, new()
        {
            newTestSuite.Data.ProjectId = projectId;
            var request = new RestRequest(AddTestSuiteEndpoint, Method.Post)
                .AddBody(newTestSuite.Data);

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