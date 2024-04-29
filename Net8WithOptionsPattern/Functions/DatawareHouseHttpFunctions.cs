using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MyCompany.Functions.Functions
{
    public sealed class DatawareHouseHttpFunctions
    {
        private readonly ILogger _logger;
        private readonly DataWarehouseServiceConfiguration _config;
        public DatawareHouseHttpFunctions(ILoggerFactory loggerFactory, IOptions<DataWarehouseServiceConfiguration> datawarehouseConfig)
        {
            _logger = loggerFactory.CreateLogger<HttpTriggerFunction>();
            _config = datawarehouseConfig.Value;
        }

        [Function("HelloData")]
        public async Task<HttpResponseData> HelloDataAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            await Task.Delay(100); // Simulate some async work

            var baseUrl = _config.DataWarehouseBaseUrl;
            _logger.LogInformation($"C# HTTP trigger function processed a request. DataWarehouseService DataWarehouseBaseUrl:{baseUrl}");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString($"Welcome to Azure Functions! HelloDataAsync. DataWarehouseService DataWarehouseBaseUrl:{baseUrl}");

            return response;
        }
    }
}
