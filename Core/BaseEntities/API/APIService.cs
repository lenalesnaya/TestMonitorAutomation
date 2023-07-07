using Core.Clients;

namespace Core.BaseEntities.API
{
    public class APIService
    {
        protected ApiClient ApiClient;

        public APIService(ApiClient apiClient)
        {
            ApiClient = apiClient;
        }
    }
}