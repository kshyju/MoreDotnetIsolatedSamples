#### Function App with EventHub Trigger

This guide outlines how to set up a minimal .NET 8 Function App featuring an HTTP trigger that sends a message to an EventHub and an EventHub trigger that activates when new messages arrive.

##### Running the App locally
1. Update the `EventHubConnection` value in the `local.settings.json` file with your EventHub connection string. Additionally, set `WorkItemEventHubName` to your event hub name.
2. Open the project in Visual Studio and press F5 to run it.
3. The terminal will display the two functions. The URL for the HTTP trigger will appear in the terminal along with the function name.
4. Send one or more GET or POST requests to this endpoint to trigger the function, which will write a message to the configured EventHub (e.g., `samples-workeritems`).
5. You should see the `EventHubTriggerFunction` being invoked, which will read and log the message body.