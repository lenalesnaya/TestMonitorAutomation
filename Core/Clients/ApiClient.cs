using NLog;
using RestSharp;
using RestSharp.Authenticators;
using Core.Utilites.Configuration;

namespace Core.Clients
{
    public class ApiClient
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly RestClient _restClient;

        public ApiClient()
        {
            var options = new RestClientOptions(Configurator.AppSettings.URL!)
            {
                Authenticator = new HttpBasicAuthenticator(
                    Configurator.Admin!.Username!, Configurator.Admin.Password!),
                ThrowOnAnyError = true,
                MaxTimeout = 10000,
            };

            _restClient = new RestClient(options);
            _restClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public RestResponse Execute(RestRequest request)
        {
            _logger.Info("Request: " + request.Resource);
            var response = _restClient.Execute(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response;
        }

        public ResponseData Execute<ResponseData>(RestRequest request)
            where ResponseData : new()
        {
            _logger.Info("Request: " + request.Resource);
            var response = _restClient.Execute<ResponseData>(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response.Data!;
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            _logger.Info("Request: " + request.Resource);
            var response = await _restClient.ExecuteAsync(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response;
        }

        public async Task<ResponseData> ExecuteAsync<ResponseData>(RestRequest request)
            where ResponseData : new()
        {
            _logger.Info("Request: " + request.Resource);
            var response = await _restClient.ExecuteAsync<ResponseData>(request);

            _logger.Info("Response Status: " + response.ResponseStatus);
            _logger.Info("Response Body: " + response.Content);

            return response.Data!;
        }
    }
}