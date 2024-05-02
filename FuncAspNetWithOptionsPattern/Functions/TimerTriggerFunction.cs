using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MyCompany.Functions.Functions
{
    public sealed class TimerTriggerFunction
    {
        private readonly ILogger _logger;
        private readonly BarSettings _barSettings;
        private readonly FooSettings _fooSettings;
        public TimerTriggerFunction(ILoggerFactory loggerFactory, BarSettings barSettings, IOptions<FooSettings> fooSettingsOption)
        {
            _logger = loggerFactory.CreateLogger<TimerTriggerFunction>();
            _barSettings = barSettings;
            _fooSettings = fooSettingsOption.Value;
        }

        [Function("TimerTriggerFunction1")]
        public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}. {_barSettings.ServiceUrl}");

            _logger.LogInformation($"ServiceUrl:{_barSettings.ServiceUrl}. ApiCallTimeoutInSecondsTimeout:{_barSettings.ApiCallTimeoutInSecondsTimeout}");
            _logger.LogInformation($"Foo ApiVersion:{_fooSettings.ApiVersion}. ApiUrl:{_fooSettings.ApiUrl}");
        }
    }
}
