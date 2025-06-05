## 🐳 Docker Requirement

> ⚠️ **Note:**  
> To run this project successfully, you must have **[Docker Desktop](https://www.docker.com/products/docker-desktop/)** installed and running on your machine.

### Running the Application

Navigate to the root directory of the project where the `docker-compose.yml` and other Docker-related files are located (this is usually the folder where you cloned the repo).

Then, run the following command to build and start all required Docker containers:

```bash
docker-compose up --build

In addition, you should have a **basic understanding of Docker** and be familiar with common Docker commands such as:

- `docker build`
- `docker run`
- `docker ps`
- `docker stop`
- `docker-compose up`
- `docker-compose down`

> 💡 If you're new to Docker, check out the [Docker Docs](https://docs.docker.com/get-started/) to get started.

---

## 📚 API Documentation

Access the Swagger UI for each microservice below:

- **Product Service:** [http://localhost:8081/productapi/swagger/index.html](http://localhost:8081/productapi/swagger/index.html)
- **Order Service:** [http://localhost:8081/orderapi/swagger/index.html](http://localhost:8081/orderapi/swagger/index.html)
