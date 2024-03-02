### .NET Framework function app with class libraries.

This sample shows a .NET Framework isolated function application where functions are defined in 3 different projects, 

1. In the function app `NetFrameworkApp`
2. The `MyCompany.MyApp.FooLibrary` class library.
3. The `MyCompany.MyApp.BarLibrary` class library.

Both class libraries are referenced in the function app.

#### How to run
The function app has 1 queue trigger and 1 service bus trigger (in the FooLibrary). So update ``local.settings.json` file with your connection strings.

To run the function app, set `MyCompany.MyApp.Functions` project as the startup project in Visual studio and run.

