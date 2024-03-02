using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Azure.Storage.Queues.Models;

namespace MyCompany.MyApp.FooLibrary
{
    public class FooQueueTriggers
    {
        private readonly ILogger<FooQueueTriggers> _logger;

        public FooQueueTriggers(ILogger<FooQueueTriggers> logger)
        {
            _logger = logger;
        }

        [Function("QueueTrigger1FromFooClassLibrary")]
        public void Run([QueueTrigger("foo-queue", Connection = "MyQueueCon")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function from Foo class library processed: {message.MessageText}");
        }
    }
}
