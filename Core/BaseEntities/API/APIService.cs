using Core.Clients;

namespace Core.BaseEntities.API
{
    internal class APIService
    {
        protected ApiClient _apiClient;

        public APIService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}