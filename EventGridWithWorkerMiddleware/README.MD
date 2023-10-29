Dotnet isolated function app with event grid trigger and middleware which inspects the CloudEvent payload.

To test locally, F5 and use POSTMAN/Fiddler to send a POST request to http://localhost:7071/runtime/webhooks/EventGrid?functionName=EventGridTrigger
with below JSON as the request body.

```json
{
    "specversion": "1.0",
    "type": "MyApp.NewOrderReceived",  
    "source": "/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.Storage/storageAccounts/{storage-account}",
    "id": "9aeb0fdf-c01e-0131-0922-9eb54906e209",
    "time": "2019-11-18T15:13:39.4589254Z",
    "subject": "NewOrder",
    "dataschema": "#",
    "data": {
        "requestId": "9aeb0fdf-c01e-0131-0922-9eb549000000",        
        "quantity": 12,
        "productId": 345,
        "customerId": 678,
        "promocode":"black friday deals"
    },
    "foo":"bar"
}
```
and also include the below 2 request headers.

1. Content-Type : application/json
2. aeg-event-type : Notification

