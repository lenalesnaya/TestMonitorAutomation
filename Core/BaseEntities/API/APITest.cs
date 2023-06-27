using NLog;
using Core.Clients;

namespace Core.BaseEntities.API
{
    internal class APITest
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();
        }
    }
}