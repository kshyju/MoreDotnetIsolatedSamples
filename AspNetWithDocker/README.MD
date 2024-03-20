**Minimal .NET 8 Function App with ASP.NET integration**

This function app uses aspnet core integration and uses appsettings.json as configuration source.

### How to build and run the docker image

1. Download this directory.
2. Ensure Docker is running in your environment.
3. Navigate to the root directory (where Dockerfile is present) and execute the following command to build the Docker image:
   ```bash
   docker build -t aspnet_function_app:1 -f .\Dockerfile .
   ```
4. Wait for the image to be built.
5. Once the image is built, use the following command to list all images. Ensure the newly built image is listed there.
   ```bash
   docker images
   ```
6. Execute the Docker run command:
   ```bash
   docker run -p 8080:80 aspnet_function_app:1
   ```

7. The container will start, and you will begin seeing logs from the function app in the terminal. Now you are ready to access the HTTP trigger at `http://localhost:8080/api/hellohttp`. The hello http function will read the "MyAppSetting1" app setting value and include that in the response.
