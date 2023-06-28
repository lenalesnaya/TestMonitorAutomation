using Core.Clients;

namespace Core.BaseEntities.API
{
    internal class APIService
    {
        protected ApiClient ApiClient;

        public APIService(ApiClient apiClient)
        {
            ApiClient = apiClient;
        }
    }
}