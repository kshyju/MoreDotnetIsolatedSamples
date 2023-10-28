using Azure.Messaging;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace EventGridWithWorkerMiddleware.Middlewares
{
    internal sealed class CloudEventAttributeLoggingMiddleware : IFunctionsWorkerMiddleware
    {
        private ILogger<CloudEventAttributeLoggingMiddleware> _logger;

        public CloudEventAttributeLoggingMiddleware(ILogger<CloudEventAttributeLoggingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            _logger.LogInformation("Inside CloudEventAttributeLoggingMiddleware");

            var eventGridBindingMetaData = context.FunctionDefinition
                                         .InputBindings.Values
                                         .FirstOrDefault(a => a.Type == "eventGridTrigger");

            if (eventGridBindingMetaData != null)
            {
                // Bind the event grid trigger payload to CloudEvent object.
                var bindingResult = await context.BindInputAsync<CloudEvent>(eventGridBindingMetaData);

                if (bindingResult.Value is not null)
                {
                    var cloudEvent = bindingResult.Value;
                    _logger.LogInformation("Event type: {type}, Event subject: {subject}", cloudEvent.Type, cloudEvent.Subject);

                    if (cloudEvent.ExtensionAttributes.TryGetValue("foo", out var foo))
                    {
                        _logger.LogInformation("Extension attribute foo: {foo}", foo);

                        // You can enahnce the cloudevent instance here if you wish.
                        // example- Add a new extension attribute to the CloudEvent object.
                        cloudEvent.ExtensionAttributes["cerified"] = "1";
                    }
                    else
                    {
                        _logger.LogInformation("Extension attribute foo is missing");
                    }
                }
            }

            await next(context);
        }
    }
}
