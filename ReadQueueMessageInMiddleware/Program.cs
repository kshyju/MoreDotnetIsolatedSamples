using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReadQueueMessageInMiddleware.Middlewares;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(builder =>
    {

        builder.UseWhen<QueueMessageLoggingMiddleware>((context) =>
        {
            // We want to use this middleware only for queue trigger invocations.
            return context.FunctionDefinition.InputBindings.Values
                          .First(a => a.Type.EndsWith("Trigger")).Type == "queueTrigger";
        });
    })
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .Build();

host.Run();