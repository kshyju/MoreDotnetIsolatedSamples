#### NET 8 Function App with EventHub Output Binding
This is a minimal .NET 8 Function App with an HTTP trigger that writes a message to an EventHub when executed.

##### Running the App
1.	Replace the `EventHubConnectionAppSetting` value in the `local.settings.json` file with your EventHub connection string.
2.	Open the project in Visual Studio and press F5 to run.
3.	The terminal will display the HTTP endpoint URL.
4.	Send a GET or POST request to this endpoint to trigger the function. This will write a message to the configured EventHub (`samples-workeritems` in this example).