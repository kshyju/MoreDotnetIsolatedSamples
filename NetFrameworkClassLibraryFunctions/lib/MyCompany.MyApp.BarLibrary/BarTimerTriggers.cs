using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace MyCompany.MyApp.BarLibrary
{
    public class BarTimerTriggers
    {
        private readonly ILogger _logger;

        public BarTimerTriggers(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BarTimerTriggers>();
        }

        [Function("TimerTrigger1FromBarLibrary")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
