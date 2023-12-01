using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace MyCompany.MyApp.FooLibrary
{
    public sealed class Foo
    {
        private readonly ILogger _logger;

        public Foo(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Foo>();
        }

        [Function("Foo")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request for Foo");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Welcome to Foo  from Foo Class library.");

            return response;
        }
    }
}
