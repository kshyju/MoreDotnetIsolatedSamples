using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Converters;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCompany.Functions.Converters;

namespace Net8SimpleHttpTrigger
{
    public enum TypeEnum
    {
        Unknown,
        TypeA,
        TypeB
    }

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
        public HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            // Explicitly specify the converter to use when binding this parameter.
            [InputConverter(typeof(MyTypeEnumConverter))] TypeEnum typeEnum)
        {
            _logger.LogInformation($"C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
            response.WriteString($"Hello, World!. TypeEnum:{typeEnum}");
            return response;
        }
    }
}
