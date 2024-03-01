using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ReadQueueMessageInMiddleware.Functions
{
    public sealed class QueueTriggerFunction1
    {
        private readonly ILogger<QueueTriggerFunction1> _logger;

        public QueueTriggerFunction1(ILogger<QueueTriggerFunction1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(QueueTriggerFunction1))]
        public void Run([QueueTrigger("myqueue-items", Connection = "MyQueueCon")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
