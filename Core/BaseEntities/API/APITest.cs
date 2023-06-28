using NLog;
using Core.Clients;

namespace Core.BaseEntities.API
{
    internal class APITest
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        protected ApiClient ApiClient;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            ApiClient = new ApiClient();
        }
    }
}