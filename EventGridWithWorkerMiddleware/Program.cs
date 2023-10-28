using EventGridWithWorkerMiddleware.Middlewares;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(b =>
    {
        b.UseWhen<CloudEventAttributeLoggingMiddleware>((context) =>
        {
            return context.FunctionDefinition.InputBindings.Values
                                             .Any(a => a.Type.Equals("eventGridTrigger", StringComparison.OrdinalIgnoreCase));
        });
    })
    .Build();

host.Run();
