**Minimal .NET 8 Function App which uses Options pattern**

This function app uses [.NET options pattern](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-8.0) to bind settings to strongly typed classes which can be accessed in function classes using dependency injection.

### How to run locally

1. Download this directory.
2. Open the project in Visual studio and F5 / Select "Debug->Start debugging" menu.

The values used to populate `FooSettings` and `BarSettings` are defined in the `appsettings.json` file, and we are adding that file as a configuration source. The file is one of the many configuration sources. See [Configuration in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration) for details 


### When deployed to Azure

When deployed to Azure, the values in `appsettings.json` are overridden by the values in the Azure Function App settings. The Azure Function App settings can be set in the Azure portal or using the Azure CLI.

##### Defining nested JSON app settings.

You can define the app setting entry as either of the below:

1. `DataWarehouseServiceConfiguration:DataWarehouseBaseUrl`
2. `DataWarehouseServiceConfiguration__DataWarehouseBaseUrl`

The `:` separator works only for windows operating system while `__` works for both windows and linux operating systems.`

![Azure App settings in portal](/assets/images/azure_app_settings.png)

