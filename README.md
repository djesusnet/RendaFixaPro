# RendaFixaPro - Clean Architecture Solution

Welcome to the RendaFixaPro solution, a .NET project structured around the principles of Clean Architecture. This solution is designed for calculating CDB financial applications and it's comprised of a .NET API backend and an Angular 12 frontend.

## Getting Started

### Prerequisites

Before you run the projects, ensure you have the following installed:

- Node Version Manager (NVM) for Windows
- Node.js v14
- .NET 8 Framework
- Visual Studio 2022

### Installing NVM and Node.js on Windows

1. Download and install NVM for Windows from the official repository.
2. Open a command prompt and run nvm install 14.0.0 to install Node.js v14.
3. Set Node.js v14 as the default version by running nvm use 14.0.0.


### Running the Frontend (RendaFixaPro.Presentation)

The frontend is developed with Angular 12.


1. Navigate to src/RendaFixaPro.Presentation.
2. Run npm install to install the necessary packages.
3. Start the project with ng serve.
4. Access the application at http://localhost:4200.


### Running the Backend (.NET API)

The backend is a .NET API structured into four layers:

- RendaFixaPro.Api - The entry point for the application, handling HTTP requests.
- RendaFixaPro.Application - Contains business logic and application services.
- RendaFixaPro.Domain - Houses the domain entities and business rules.
- RendaFixaPro.Infrastructure - Implements persistence and infrastructure concerns.

### To run the backend:

1. Open RendaFixaPro.sln in Visual Studio 2022.
2. Set RendaFixaPro.Api as the startup project.
3. Press F5 to build and run the solution.

Ensure the API and the frontend are running simultaneously to allow for full integration.


## Unit Testing

The unit tests for the application reside in the tests folder.

- RendaFixaPro.Tests - Contains unit tests for the application.

### To run the tests:

1. Open the solution in Visual Studio 2022.
2. Navigate to the Test Explorer.
3. Run all tests or individual tests as needed.

