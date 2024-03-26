using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Net8SimpleHttpTrigger
{
    public sealed class EventHubWriterFunctions(ILoggerFactory loggerFactory)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<EventHubWriterFunctions>();

        [Function("WriteToEventHub")]
        public HelloHttpResponse WriteToEventHub([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation($"C# HTTP trigger function processed a request.");

            var message = $"WI-{Guid.NewGuid().ToString()[..8]}";

            var httpResponse = req.CreateResponse(System.Net.HttpStatusCode.OK);
            httpResponse.WriteStringAsync($"Message '{message}' written to Event Hub.");

            return new HelloHttpResponse
            {
                HttpResponse = httpResponse,
                Message = message
            };
        }
    }

    public sealed class HelloHttpResponse
    {
        public required HttpResponseData HttpResponse { get; set; }

        [EventHubOutput("samples-workitems", Connection = "EventHubConnectionAppSetting")]
        public string? Message { get; set; }
    }
}
