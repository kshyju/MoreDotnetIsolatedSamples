using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;

namespace CustomAuthUsingMiddleware.Middlewares
{
    public sealed class MyCustomAuthMiddleware : IFunctionsWorkerMiddleware
    {
        private const string TokenHeaderName = "x-my-apikey";
        private readonly ILogger<MyCustomAuthMiddleware> _logger;

        public MyCustomAuthMiddleware(ILogger<MyCustomAuthMiddleware> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            _logger.LogInformation("Executing MyCustomAuthMiddleware.");

            var httpRequestData = (await context.GetHttpRequestDataAsync())!;

            var isRequestValid = IsValidApiKey(httpRequestData);

            if (!isRequestValid)
            {
                _logger.LogInformation($"The API key present in the '{TokenHeaderName}' request header is not valid."); ;

                // Overwrite the response with our 401 response and some useful message.
                HttpResponseData newHttpResponse = httpRequestData.CreateResponse();
                await newHttpResponse.WriteAsJsonAsync(new { Message = $"The API key present in the '{TokenHeaderName}' request header is not valid." }, HttpStatusCode.Unauthorized);
                context.GetInvocationResult().Value = newHttpResponse;

                return;
            }

            // Valid request. Continue to execute the function invocation pipeline.
            await next(context);
        }

        private static bool IsValidApiKey(HttpRequestData httpRequestData)
        {
            if (!httpRequestData.Headers.TryGetValues(TokenHeaderName, out var values))
            {
                return false;

            }

            var apiKey = values.First();

            // Dummy implementation to validate the key. You should implement your own logic here.
            return string.Equals(apiKey, "foo");
        }
    }
}
