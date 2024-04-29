using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MyCompany.Functions.Functions
{
    public sealed class HttpTriggerFunction
    {
        private readonly ILogger _logger;
        private readonly FooSettings _fooSettings;
        public HttpTriggerFunction(ILoggerFactory loggerFactory, IOptions<FooSettings> fooSettingsOption)
        {
            _logger = loggerFactory.CreateLogger<HttpTriggerFunction>();
            _fooSettings = fooSettingsOption.Value;
        }

        [Function("HelloHttp")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            await Task.Delay(100); // Simulate some async work

            var version = _fooSettings.ApiVersion;
            var url = _fooSettings.ApiUrl;
            _logger.LogInformation($"C# HTTP trigger function processed a request. version:{version}. ApiUrl:{url}");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString($"Welcome to Azure Functions! HelloHttpAsync. Version:{version}");

            return response;
        }
    }
}
