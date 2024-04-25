### Sample app with custom input converter

This sample shows how to use a custom converter to extend the input binding pipeline.

#### Use case

We want to populate an enum based on the request data.

```csharp
[Function("HelloHttp")]
public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req, TypeEnum typeEnum)
{
    var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
    response.WriteString($"Hello, World!. TypeEnum:{typeEnum}");
    return response;
}

public enum TypeEnum
{
    Unknown,
    TypeA,
    TypeB
}
```

#### Converter

The custom converter `MyTypeEnumConverter` will read request query string and based on the value of "type" query parameter, it will populate the `typeEnum` parameter value of the function. 

The example uses request data to populate the value. But you are free to change it to any logic you want to implement.

See [Extending input binding pipeline in dotnet isolated Azure functions](https://techiesweb.net/2023/02/11/azure-functions-input-converters.html) for more details.

#### How to run

You can F5 in Visual studio. The function app has one http trigger. Try with different values for the "type" query parameter and see what value is being populated.

 - http://localhost:7071/api/hellohttp
 - http://localhost:7071/api/hellohttp?type=A
 - http://localhost:7071/api/hellohttp?type=B
 - http://localhost:7071/api/hellohttp?type=S
