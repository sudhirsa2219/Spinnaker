# Customer Management System

This project is a complete Customer Management System built with a microservice architecture. It includes a web API for customer CRUD operations, a frontend UI built with Blazor and React, and automation scripts for testing.

## Folder Structure

### 1. `Customer.Web`
The **Web API** microservice for customer management. It follows **Clean Architecture** design principles and supports CRUD operations. It includes built-in support for **Swagger**. It also uses **Carter** and **MediatR** packages and uses Command Query pattern and easy writing of routes.

The folder structure is as follows:
- **Core**: Contains common services that can be consumed by all microservices.
- **Customer.Web**: API implementation following Clean Architecture.
- **Customer.Unit.Test**: Contains unit tests for testing the core features of the customer management microservice.
- **ApiGateway**: Contains YARP (Yet Another Reverse Proxy) API Gateway, which is optional and not currently configured.

### 2. `Customer.UI`
Contains the frontend UI that consumes the Customer microservice.

This folder has two implementations:
- **CustomerWebApp**: A Blazor-based implementation that uses **MudBlazor** for a consistent look and feel.
- **customer-app**: A React-based implementation that also consumes the Customer microservice and has a similar look and feel.

### 3. `dockerfiles`
Contains the `docker-compose.yml` file for easily starting both the microservice and the frontend.

- **docker-compose.yml**: This file defines the services for both the frontend and the backend. It does not push pre-built images to any repository; instead, it uses the corresponding Dockerfile of each project to build the Docker images locally.
- **Note**: Make sure to run `docker-compose up --build` so that the images are built from the code before starting the containers.

### 4. `Automation`
Contains Python-based automation scripts for API testing.

- **Locust-based Load Testing**: It uses **Locust** for load testing the Customer microservice.

## Microservice Features

- The microservice automatically handles **database creation** and **initial data migration**.
- **Docker volumes** are not mapped, so any data is discarded when the container stops. However, it can be configured to point to a local database if persistent storage is needed.
- When running in **debug mode**, ensure that the `.env` file is configured correctly, especially for the microservice and frontend applications.

## Getting Started

### Prerequisites
- Docker and Docker Compose installed.
- Python 3.x (for automation scripts).
- Node.js (for React frontend).
- .NET SDK (for Blazor frontend and API).

### 1. Build and Run the Application

To build and run both the frontend and the microservice using Docker Compose, execute the following command:

```bash
docker-compose up --build
