using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Azure.Messaging.ServiceBus;
using System.Threading.Tasks;

namespace MyCompany.MyApp.FooLibrary
{
    public sealed class FooServiceBusTriggers
    {
        private readonly ILogger<FooServiceBusTriggers> _logger;

        public FooServiceBusTriggers(ILogger<FooServiceBusTriggers> logger)
        {
            _logger = logger;
        }

        [Function("ServiceBusTrigger1FromFooClassLibrary")]
        public async Task Run(
            [ServiceBusTrigger("myqueue", Connection = "MyServiceBusCon")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
