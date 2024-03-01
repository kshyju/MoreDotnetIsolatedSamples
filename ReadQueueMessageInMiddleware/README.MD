##### A minimal function app with a middleware to intercept the queue message.

This app has a middleware called `QueueMessageLoggingMiddleware` which intercepts the queue trigger messages during function invocations.

###### How to run the app

Update the `MyQueueCon` in `local.setting.json` with your storage account connection string.` and F5 to run the app.