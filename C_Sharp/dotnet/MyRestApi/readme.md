# Quickstart .NET API for Library Management

This repository provides a step-by-step guide to building a REST API using .NET with vertical slicing architecture, focusing on managing user accounts and a books library.

## Table of Contents

1. [Overview](#overview)
2. [Set Up Project](#set-up-project)
3. [Define Features](#define-features)
4. [Set Up Database](#set-up-database)
5. [Implement Features](#implement-features)
6. [Configure Swagger](#configure-swagger)
7. [Test API](#test-api)
8. [Deploy Application](#deploy-application)

## Overview

### What is Vertical Slicing?

Vertical slicing is an architectural approach that divides an application into vertical slices, each representing a complete feature or use case. This includes all necessary layers for a feature within a single slice.

### Benefits of Vertical Slicing

- **Modularity**: Each feature is self-contained and independent.
- **Maintainability**: Easier to understand and modify individual features.
- **Scalability**: Simplifies scaling specific parts of the application.

### Project Structure

```plaintext
MyLibraryApi/
├── Features/
│   ├── UserAccounts/
│   │   ├── Controllers/
│   │   ├── Data/
│   │   ├── DTOs/
│   │   ├── Models/
│   │   ├── Services/
│   ├── BooksLibrary/
│   │   ├── Controllers/
│   │   ├── Data/
│   │   ├── DTOs/
│   │   ├── Models/
│   │   ├── Services/
├── Data/
├── Startup.cs
├── Program.cs
├── appsettings.json
```

## Set Up Project

1. Install .NET SDK from the [official .NET website](https://dotnet.microsoft.com/download).
2. Create a new Web API project:
    ```bash
    dotnet new webapi -n MyLibraryApi
    cd MyLibraryApi
    dotnet run
    ```

## Define Features

1. Create a `Features` directory:
    ```bash
    mkdir -p Features/UserAccounts/{Controllers,Data,DTOs,Models,Services} Features/BooksLibrary/{Controllers,Data,DTOs,Models,Services}
    ```

## Set Up Database

1. Choose a database (MySQL or SQLite).
2. Install required EF Core providers:
    ```bash
    dotnet add package Pomelo.EntityFrameworkCore.MySql
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```
3. Create a `Data` directory and add a database context class.
4. Configure the database context in `Startup.cs`.
5. Add connection strings in `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=librarydb;User=root;Password=yourpassword;",
        "SQLiteConnection": "Data Source=library.db"
      }
    }
    ```
6. Create migrations and update the database:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

## Implement Features

### User Accounts Feature

1. Define the `User` model in the `Models` directory.
2. Create `UserDto` in the `DTOs` directory.
3. Implement `IUserRepository` interface and `UserRepository` class in the `Data` directory.
4. Create `UserAccountsController` in the `Controllers` directory.
5. Implement `UserService` in the `Services` directory (if needed).

### Books Library Feature

1. Define the `Book` model in the `Models` directory.
2. Create `BookDto` in the `DTOs` directory.
3. Implement `IBookRepository` interface and `BookRepository` class in the `Data` directory.
4. Create `BooksLibraryController` in the `Controllers` directory.
5. Implement `BookService` in the `Services` directory (if needed).

## Configure Swagger

1. Install Swagger:
    ```bash
    dotnet add package Swashbuckle.AspNetCore
    ```
2. Configure Swagger in `Startup.cs` to enable API documentation.

## Test API

1. Write unit and integration tests.
2. Test endpoints using tools like Postman or Swagger UI.

## Deploy Application

1. Configure the application for deployment.
2. Choose a hosting environment (e.g., Azure, AWS, Docker).

---

This guide provides a structured approach to building a REST API for managing user accounts and a books library in .NET using vertical slicing architecture. Follow each section step-by-step to set up and develop your API.
```
