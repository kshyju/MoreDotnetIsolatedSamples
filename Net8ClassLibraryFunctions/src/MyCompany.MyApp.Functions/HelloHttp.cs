using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace MyCompany.MyApp.Functions
{
    public sealed class HelloHttp
    {
        private readonly ILogger _logger;

        public HelloHttp(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HelloHttp>();
        }

        [Function("HelloHttp")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request for HelloHttp.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions! This function is defined in the entry assembly.");

            return response;
        }
    }
}
