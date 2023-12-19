##### A minimal function app with a middleware to execute custom authentication logic.

This app has a middleware called `MyCustomAuthMiddleware` which checks a special header value in the HTTP request (`x-my-apikey`). If it is present and the value is `foo`, then the function will be executed as normal, else a 401 response is sent back to the caller.

Feel free to update the token validation logic with your custom logic.



