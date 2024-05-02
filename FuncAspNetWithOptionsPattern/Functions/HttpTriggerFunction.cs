using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
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
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            await Task.Delay(100); // Simulate some async work

            var version = _fooSettings.ApiVersion;
            var url = _fooSettings.ApiUrl;
            _logger.LogInformation($"C# HTTP trigger function processed a request. version:{version}. ApiUrl:{url}");

            return new OkObjectResult(new { ApiURL = url, Version = version, CurrentTime = DateTime.Now });
        }
    }
}
