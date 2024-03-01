using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;

namespace ReadQueueMessageInMiddleware.Middlewares
{
    public sealed class QueueMessageLoggingMiddleware : IFunctionsWorkerMiddleware
    {
        private readonly ILogger<QueueMessageLoggingMiddleware> _logger;

        public QueueMessageLoggingMiddleware(ILogger<QueueMessageLoggingMiddleware> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            _logger.LogInformation($"Executing {nameof(QueueMessageLoggingMiddleware)}");

            var queueTriggerBinding = context.FunctionDefinition.InputBindings.Values.FirstOrDefault(a => a.Type.Equals("queueTrigger"));

            if (queueTriggerBinding != null)
            {
                var queueMessage = await context.BindInputAsync<QueueMessage>(queueTriggerBinding);
                if (queueMessage.Value != null)
                {
                    _logger.LogInformation($"Received queue message. MessageId: {queueMessage.Value.MessageId}");
                }
            }

            await next(context);
        }
    }
}
