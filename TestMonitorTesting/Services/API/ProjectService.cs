using Core.BaseEntities.API;
using Core.Clients;
using RestSharp;
using TestMonitorTesting.Models;

namespace TestMonitorTesting.Services.API
{
    internal class ProjectService : APIService
    {
        public const string AddProjectEndpoint = "api/v1/projects";
        public const string GetProjectEndpoint = "api/v1/projects/{projectId}";

        public ProjectService(ApiClient apiClient) : base(apiClient) { }

        public RestResponse AddProject(Project newProject)
        {
            var request = new RestRequest(AddProjectEndpoint, Method.Post)
                .AddBody(newProject.Data);// AddJsonBody

            return ApiClient.Execute(request);
        }

        public ProjectType AddProject<ProjectType>(ProjectType newProject)
            where ProjectType : Project, new()
        {
            var request = new RestRequest(AddProjectEndpoint, Method.Post)
                .AddBody(newProject.Data);// AddJsonBody

            return ApiClient.Execute<ProjectType>(request);
        }

        public RestResponse GetProject(int projectId)
        {
            var request = new RestRequest(GetProjectEndpoint)
                .AddUrlSegment("projectId", projectId);
            return ApiClient.Execute(request);
        }

        public ProjectType GetProject<ProjectType>(int projectId)
            where ProjectType : Project, new()
        {
            var request = new RestRequest(GetProjectEndpoint)
                .AddUrlSegment("projectId", projectId);

            return ApiClient.Execute<ProjectType>(request);
        }
    }
}