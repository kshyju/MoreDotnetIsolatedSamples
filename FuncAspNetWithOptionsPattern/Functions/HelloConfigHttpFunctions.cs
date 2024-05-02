using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyCompany.Functions.Functions
{
    public sealed class HelloConfigHttpFunctions
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public HelloConfigHttpFunctions(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<HttpTriggerFunction>();
            _configuration = configuration;
        }

        [Function("HelloConfig")]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            await Task.Delay(100); // Simulate some async work

            var fooId = _configuration["FooId"];
            var barIdFromNestedConfig = _configuration["Bar:Id"];

            _logger.LogInformation($"C# HTTP trigger function processed a request. FooId:{fooId}. BarId:{barIdFromNestedConfig}");

            return new OkObjectResult(new { FooId = fooId, BarId = barIdFromNestedConfig, CurrentTime = DateTime.Now });
        }
    }
}
