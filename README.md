# TP24TechnicalSol Project

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Usage](#usage)
- [Code Explained](#code-explained)
- [Further Possibilities](#Further-Possibilities)
- [License](#license)

## Overview

This project is built using the .NET framework and includes the following components:

- **Model**: Defines the data structures used in the application.
- **Services**: Provides services for managing receivables and fetching exchange rates.
- **Controllers**: Defines API endpoints for managing receivables.

## Features

- CRUD (Create, Read, Update, Delete) operations for receivables.
- Fetching and displaying exchange rates.
- Summarizing financial data.

To run this project, you'll need:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or another code editor.

Open the project in Visual Studio or your preferred code editor.
Configure your environment settings in appsettings.json. Set up the necessary API key.
Build and run the project. 
#### build:
You can use the `dotnet build .\TP24Technical.csproj` command to bulid the project 
#### Execute on local machine
`dotnet run .\TP24Technical.csproj` command to execute the project
#### Open in browser
open the web browser with https://localhost:7139/swagger/index.html or http://localhost:5133/swagger/index.html

## Code Explained
All code classes 
### Program:

The main program class where the application is configured and started. It registers services in the dependency injection container, including data seeding and database context. It sets up routing for controllers, Swagger documentation, and the main application pipeline.

### ReceivablesController:

A controller class responsible for handling HTTP requests related to receivables. Provides endpoints for retrieving all receivables, creating a new receivable, and getting details about a specific receivable.

### ReceivableDbContext:

A database context class for managing receivable entities.

### ExchangeRateSettings:

A configuration class for storing settings related to exchange rates.

### Receivable:

A model class representing receivable entities. It implements the IEntity interface.

### IRepository and Repository:

An interface and a generic class for defining and implementing common data access operations for entities.

### ExchangeRateapiService:

A service class for retrieving exchange rate data from an external API. It uses an HTTP client to make requests.

### IExchangeRatesService and IReceivableService:

Interfaces defining the contract for services related to exchange rates and receivables.

### ReceivableService:

A service class that implements the IReceivableService interface. It handles operations related to receivables, such as fetching, adding, updating, and deleting.

## Usage

1. Fetch all receivables: Send a GET request to `/Receivables/Index`.
2. Create a new receivable: Send a POST request to `/Receivables/Post` with a JSON body.
3. Fetch a specific receivable: Send a GET request to `/Receivables/{id}`.
4. Summarize financial data: Send a GET request to `/Receivables/Summary`.

## Further Possibilities
### GraphQL Implementation
The project has posibalites to include GraphQL support for flexible data queries. You can send GraphQL queries to retrieve data. Use the /Receivables/GraphQL endpoint to make GraphQL requests. Here's how you can use it:
#### Example GraphQL Query
``` QL
query {
  AllReceivables {
    Reference
    Amount
    CurrencyCode
  }
}
```

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/fahad1k/TP24TechnicalSol/blob/master/LICENSE.txt) file for details.
