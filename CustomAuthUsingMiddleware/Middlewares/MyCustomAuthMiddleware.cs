using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker;
using System.Net;
using Microsoft.Extensions.Logging;

namespace CustomAuthUsingMiddleware.Middlewares
{
    public sealed class MyCustomAuthMiddleware : IFunctionsWorkerMiddleware
    {
        private ILogger<MyCustomAuthMiddleware> _logger;

        public MyCustomAuthMiddleware(ILogger<MyCustomAuthMiddleware> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            _logger.LogInformation("Executing MyCustomAuthMiddleware.");

            var httpRequestData = await context.GetHttpRequestDataAsync();

            string? myApiKey = null;
            if (httpRequestData!.Headers.TryGetValues("x-my-apikey", out var values))
            {
                myApiKey = values.First();
            }

            var isRequestValid = IsValidApiKey(myApiKey);

            if (!isRequestValid)
            {
                _logger.LogInformation("Invalid API key! Will return 401"); ;

                var httpResponseData = context.GetHttpResponseData()!;
                httpResponseData.StatusCode = HttpStatusCode.Unauthorized;

                return;
            }

            // Valid request. Continue to execute the function invocation pipeline.
            await next(context);
        }

        private static bool IsValidApiKey(string? apiKey)
        {
            // Dummy implementation to validate the key. You should implement your own logic here.
            if (string.Equals(apiKey , "foo"))
            {
                return true;
            }

            return false;
        }
    }
}
