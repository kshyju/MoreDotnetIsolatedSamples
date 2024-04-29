using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCompany.Functions;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureAppConfiguration((hostBuilderContext, configBuilder) =>
            {
                // Add appsettings json files as configuration sources.
                configBuilder
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true);

                // Add env variables as a configuration source.
                configBuilder.AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                IConfiguration configuration = context.Configuration;

                // Configure strongly typed settings objects using options pattern.
                services.Configure<FooSettings>(configuration.GetSection("FooSettings"));

                // Add a singleton BarSettings instance which can be DI injected to any classes later
                var barConfigSection = context.Configuration.GetSection("BarSettings");
                var barSettings = new BarSettings();
                barConfigSection.Bind(barSettings);
                services.AddSingleton(barSettings);

                // AddOptions example
                services.AddOptions<DataWarehouseServiceConfiguration>()
                    .Configure<IConfiguration>((settings, configuration) =>
                    {
                        configuration.GetSection("DataWarehouseServiceConfiguration").Bind(settings);
                    });
            })
            .Build();

        host.Run();
    }
}