# JobPost API
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Gagan-C_JobPortalApi&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Gagan-C_JobPortalApi)
## Overview
The JobPost API is a .NET 9-based application designed to manage job postings. It includes features such as user authentication, job post management, and onboarding services. The API leverages various .NET services and libraries to provide a robust and scalable solution.

## Features
- User Authentication and Authorization
- Job Post Management
- Onboarding Services
- Health Checks
- OpenTelemetry for logging and metrics
- Service Discovery and Resilience

## Getting Started

### Prerequisites
- .NET 9 SDK
- Docker

### Installation
1. Clone the repository:

	```bash
	   git clone https://github.com/Gagan-C/JobPortalApi.git
	```
2. Navigate to the project directory:
    ```bash
	   cd JobPortalApi/
	```
3. Restore the dependencies:
    ```bash
	   dotnet restore
	```


### Configuration

### Running the Application
1. Build the project:
	```bash
	   dotnet run --project JobPost.AppHost
	```

### API Documentation
The API documentation is available via Swagger. Once the application is running, navigate to `/swagger` to view the API documentation.

## Usage
### Authentication
The application uses cookie-based authentication and bearer tokens. Ensure you have the necessary authentication headers when making API requests.

### Health Checks
Health checks are available at the following endpoints:
- `/health` - Checks the overall health of the application.
- `/alive` - Checks if the application is alive.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License.
