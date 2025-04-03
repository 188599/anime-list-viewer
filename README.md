# AnimeListViewer

AnimeListViewer is a demo project designed to showcase a clean architecture implementation with a .NET backend and a Vue.js frontend. The project fetches anime data from a public API, stores it in an MSSQL database, and displays it in a filterable grid on the frontend.

---

## Features

- **Backend**:

  - Built with the latest .NET Framework version.
  - Implements Clean Architecture combined with Domain-Driven Design (DDD).
  - Uses Entity Framework Core (EF Core) with the Repository Pattern for data storage.
  - Includes a Hangfire job for hourly data upsert functionality.
  - MSSQL is used as the database.

- **Frontend**:
  - Built with Vue.js and TypeScript.
  - Displays anime data in a filterable grid.
  - Allows filtering of anime data via a dynamic filter component.

---

## Project Structure

The solution is divided into the following projects:

### Backend

1. **WebAPI**:

   - Exposes RESTful endpoints for the frontend.
   - Implements the Presentation layer of the Clean Architecture.

2. **WorkerService**:

   - Hosts the Hangfire job for data upsert functionality.
   - Runs background tasks like fetching and storing anime data.

3. **Class Libraries**:
   - **Domain**: Contains core business logic and entities.
   - **Application**: Contains use cases, commands, queries, and interfaces.
   - **Infrastructure**: Handles database access, repositories, and external API integrations.
   - **HangfireJobs**: Contains the implementation of Hangfire jobs.

### Frontend

- Built with Vue.js and TypeScript.
- Fetches data from the WebAPI and displays it in a responsive, filterable grid.

---

## Requirements

- Docker and Docker Compose installed on your system.

---

## Setup Instructions

### Running the Project with Docker

1. Clone the repository:

   ```bash
   git clone https://github.com/188599/anime-list-viewer.git
   cd anime-list-viewer/AnimeListViewer
   ```

2. Build and start the containers:

   ```bash
   cd docker && docker-compose up --build
   ```

3. Access the application:

   - **Frontend**: Open your browser and navigate to `http://localhost`.
   - **WebAPI**: The API is available at `http://localhost:5195`.

4. Hangfire is expose on port `5196`.

5. MSSQL is exposed on port `1433` for database management tools.

---

## Usage

1. The backend fetches anime data from the AniList API and stores it in the MSSQL database.
2. The Hangfire job runs every hour to upsert new anime data.
3. The frontend displays the anime data in a grid, allowing users to filter the list dynamically.

---

## Technologies Used

### Backend

- .NET 9
- Entity Framework Core
- Hangfire
- MSSQL
- Clean Architecture with DDD

### Frontend

- Vue.js 3
- TypeScript
- Axios

### Docker

- Docker Compose for container orchestration
- Nginx for serving the frontend
- MSSQL for database management

---

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
