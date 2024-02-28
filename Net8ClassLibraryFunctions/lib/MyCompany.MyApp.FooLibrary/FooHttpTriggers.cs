using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MyCompany.MyApp.FooLibrary
{
    public sealed class FooHttpTriggers
    {
        private readonly ILogger _logger;

        public FooHttpTriggers(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FooHttpTriggers>();
        }

        [Function("HttpTrigger1FromFooLibrary")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request for FooHttpTrigger1 from Foo Class library");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Hello world from Foo Class library.");

            return response;
        }
    }
}
