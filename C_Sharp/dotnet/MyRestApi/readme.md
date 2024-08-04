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
MyRestApi/
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
├── Infrastructure/
│   ├── AppDbContext.cs
├── Startup.cs
├── Program.cs
├── appsettings.json
```

## Set Up Project

1. Install .NET SDK from the [official .NET website](https://dotnet.microsoft.com/download).
2. Create a new Web API project:
    ```bash
    dotnet new webapi -n MyRestApi
    cd MyRestApi
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
3. Create a `Infrastructure` directory and add a database context class.
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
6. Set up a local tool manifest and install `dotnet-ef`:
    ```bash
    dotnet new tool-manifest
    dotnet tool install dotnet-ef
    ```

7. Create migrations and update the database:
    ```bash
    dotnet tool run dotnet-ef migrations add InitialCreate
    dotnet tool run dotnet-ef database update
    ```

## Implement Features

### User Accounts Feature

1. **Define the `User` model** in the `Models` directory.
2. **Create Input and Output DTOs** in the `DTOs` directory for password security:
    - `UserInputDto` for receiving user data (including password).
    - `UserOutputDto` for sending user data without sensitive information.
3. **Implement `IUserRepository` interface and `UserRepository` class** in the `Data` directory.
4. **Create `UserAccountsController`** in the `Controllers` directory.
5. **Implement `PasswordService`** in the `Services` directory to handle password hashing and verification.

### Books Library Feature

1. **Define the `Book` model** in the `Models` directory.
2. **Create `BookDto`** in the `DTOs` directory.
3. **Implement `IBookRepository` interface and `BookRepository` class** in the `Data` directory.
4. **Create `BooksLibraryController`** in the `Controllers` directory.
5. **Implement `BookService`** in the `Services` directory.

### Why Use Services?

Services are used for sub-features within the feature that allow for operations like:
- **Password Encryption**: Securely handling passwords.
- **Email Notifications**: Sending notifications to users.
- **File Uploads**: Managing file uploads and storage.

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

## API Endpoints

### UserAccounts Endpoints

```python
# Get All Users
# Endpoint: GET /api/UserAccounts
# Description: Retrieves a list of all users.

# Get User By ID
# Endpoint: GET /api/UserAccounts/{id}
# Description: Retrieves a specific user by their ID.
# Parameters:
#   - {id}: The ID of the user.

# Add New User
# Endpoint: POST /api/UserAccounts
# Description: Adds a new user.
# Body: UserInputDto with user details.

# Update User
# Endpoint: PUT /api/UserAccounts/{id}
# Description: Updates an existing user.
# Parameters:
#   - {id}: The ID of the user.
# Body: UserInputDto with updated user details.

# Delete User
# Endpoint: DELETE /api/UserAccounts/{id}
# Description: Deletes a user by their ID.
# Parameters:
#   - {id}: The ID of the user.
```

### BooksLibrary Endpoints

```python
# Get All Books
# Endpoint: GET /api/BooksLibrary
# Description: Retrieves a list of all books.

# Get Book By ID
# Endpoint: GET /api/BooksLibrary/{id}
# Description: Retrieves a specific book by its ID.
# Parameters:
#   - {id}: The ID of the book.

# Add New Book
# Endpoint: POST /api/BooksLibrary
# Description: Adds a new book.
# Body: BookInputDto with book details.

# Update Book
# Endpoint: PUT /api/BooksLibrary/{id}
# Description: Updates an existing book.
# Parameters:
#   - {id}: The ID of the book.
# Body: BookInputDto with updated book details.

# Delete Book
# Endpoint: DELETE /api/BooksLibrary/{id}
# Description: Deletes a book by its ID.
# Parameters:
#   - {id}: The ID of the book.
```

---
<b>
This guide provides a structured approach to building a REST API for managing user accounts and a books library in .NET using vertical slicing architecture. Follow each section step-by-step to set up and develop your API.
</b>