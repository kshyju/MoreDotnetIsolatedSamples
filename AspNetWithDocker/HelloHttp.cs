using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Net8SimpleHttpTrigger
{
    public sealed class HelloHttp
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        public HelloHttp(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = loggerFactory.CreateLogger<HelloHttp>();
        }

        [Function("HelloHttp")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation($"C# HTTP trigger function processed a request.");

            var myAppSettingValue = _configuration["MyAppSetting1"];
            _logger.LogInformation($"MyAppSetting1 value:{myAppSettingValue}");

            return new OkObjectResult($"MyAppSetting1 value is:{myAppSettingValue}");
        }
    }
}
