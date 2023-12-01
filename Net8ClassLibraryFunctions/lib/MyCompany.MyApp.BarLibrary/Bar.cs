using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace MyCompany.MyApp.BarLibrary
{
    public sealed class Bar
    {
        private readonly ILogger _logger;

        public Bar(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Bar>();
        }

        [Function("BarAsync")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            await Task.Delay(100); // Simulate some async work

            _logger.LogInformation("C# HTTP trigger function processed a request for BarAsync");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString("Welcome to BarAsync from Bar Class library");

            return response;
        }
    }
}
