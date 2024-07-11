using Azure.Messaging.EventHubs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MyCompany.Functions
{
    public class EventHubTriggerFunction
    {
        private readonly ILogger<EventHubTriggerFunction> _logger;

        public EventHubTriggerFunction(ILogger<EventHubTriggerFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(EventHubTriggerFunction))]
        public void Run([EventHubTrigger("%WorkItemEventHubName%", Connection = "EventHubConnection")] EventData[] events)
        {
            _logger.LogInformation("C# Event Hub trigger function received {count} events", events.Length);
            foreach (EventData @event in events)
            {
                var eventBodyAsString = System.Text.Encoding.UTF8.GetString(@event.Body.Span);

                _logger.LogInformation("Event Body: {body}", eventBodyAsString);
            }
        }
    }
}
