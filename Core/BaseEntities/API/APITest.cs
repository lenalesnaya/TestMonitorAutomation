using NLog;
using Core.Clients;

namespace Core.BaseEntities.API
{
    public class APITest
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        protected ApiClient ApiClient;

        [SetUp]
        public void InitApiClient()
        {
            ApiClient = new ApiClient();
        }
    }
}