**Minimal .NET 8 Function App with Docker Support**

### How to Run

1. Download this directory.
2. Ensure Docker is running in your environment.
3. Navigate to the root directory and execute the following command to build the Docker image:
   ```bash
   docker build -t myapp:1 -f .\Dockerfile .
   ```
4. Wait for the image to be built.
5. Once the image is built, use the following command to list all images and note down the Image ID of the newly created one:
   ```bash
   docker images
   ```
6. Execute the Docker run command:
   ```bash
   docker run -p 8080:80 [IMAGE_ID]
   ```

7. The container will start, and you will begin seeing logs from the function app in the terminal. Now you are ready to access the HTTP trigger at `http://localhost:8080/api/hellohttp`.
