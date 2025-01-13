# MenuManager API

This repository contains the API for the **MenuManager** project, a university project aimed at performing CRUD operations using a database hosted on Azure. The project is developed using **C#** and targets **.NET 8**. 
The project is also hosted on Azure at the following link (until February 2025): [menumanager20250109143504.azurewebsites.net](https://menumanager20250109143504.azurewebsites.net).

## Project Structure

### MenuManager
This folder contains the business logic and services of the application. The main subfolders and files are:

- **Controllers**: Contains the controllers that handle HTTP requests and responses.
- **DTOs**: Contains Data Transfer Objects used for transferring data between layers.
- **Requests**: Contains the requests used to interact with the services.
- **Services**: Contains the services that handle business logic. For example, `DishServices` manages operations related to dishes.
- **Program.cs**: The entry point of the application, where the application is configured and started.

### MenuManager.Models
This folder contains the entities and repositories used by the application. The main subfolders and files are:

- **Configuration**: Contains configuration classes for the entities.
- **Context**: Contains the database context class, `MyDbContext`.
- **Entities**: Contains the domain entities, such as `Dish` and `DishType`.
- **Repositories**: Contains the repositories that manage data access. For example, `DishRepository` and `DishTypeRepository`.

## CRUD Operations

The project supports the following CRUD operations. These operations are exposed through the controllers as HTTP requests, which call corresponding methods in the services. The services then interact with the repositories to perform the actual data manipulation.

### Dish Operations

1. **Create**: Adding a new dish to the database.
   - Exposed in the controller through the `Dish/AddDish` HTTP POST request.
   - The `Dish/AddDish` method in the controller calls the `AddDish` method in `DishServices`, which in turn calls `AddDish` in `DishRepository`.

2. **Read**: Retrieving dishes from the database.
   - Exposed in the controller through the `Dish/GetAll` HTTP GET request.
   - The `Dish/GetAll` method in the controller calls the `GetAllDishes` method in `DishServices`, which then calls `GetAll` in `DishRepository`.

3. **Update**: Modifying an existing dish in the database.
   - Exposed in the controller through the `Dish/UpdateDish` HTTP PUT request.
   - The `Dish/UpdateDish` method in the controller calls the `UpdateDish` method in `DishServices`, which in turn calls `UpdateDish` in `DishRepository`.

4. **Delete**: Removing a dish from the database.
   - Exposed in the controller through the `Dish/DeleteDish` HTTP DELETE request.
   - The `Dish/DeleteDish` method in the controller calls the `DeleteDish` method in `DishServices`, which then calls `Delete` in `DishRepository`.

### DishType Operations

1. **Create**: Adding a new dish type to the database.
   - Exposed in the controller through the `DishType/AddDishType` HTTP POST request.
   - The `DishType/AddDishType` method in the controller calls the `AddDishType` method in `DishTypeServices`, which in turn calls `AddDishType` in `DishTypeRepository`.

2. **Read**: Retrieving dish types from the database.
   - Exposed in the controller through the `DishType/GetAll` HTTP GET request.
   - The `DishType/GetAll` method in the controller calls the `GetAllDishTypes` method in `DishTypeServices`, which then calls `GetAll` in `DishTypeRepository`.

3. **Update**: Modifying an existing dish type in the database.
   - Exposed in the controller through the `DishType/UpdateDishType` HTTP PUT request.
   - The `DishType/UpdateDishType` method in the controller calls the `UpdateDishType` method in `DishTypeServices`, which in turn calls `UpdateDishType` in `DishTypeRepository`.

4. **Delete**: Removing a dish type from the database.
   - Exposed in the controller through the `DishType/DeleteDishType` HTTP DELETE request.
   - The `DishType/DeleteDishType` method in the controller calls the `DeleteDishType` method in `DishTypeServices`, which then calls `Delete` in `DishTypeRepository`.

## Main Entities

- **Dish**: Represents a dish in the system. It has properties such as `Id`, `Name`, `Price`, `TypeId`, and a relationship with `DishType`.
- **DishType**: Represents the type of a dish. It has properties such as `Id` and `Type`, and a relationship with a collection of `Dish`.

## Database Configuration

### MyDbContext
Manages the configuration of the database context, including defining the `DbSet` for `Dish` and `DishType`, and overriding the `OnModelCreating` and `OnConfiguring` methods.

## Dependencies

The project relies on the following dependencies:

- **Entity Framework Core**: For data access and database management.
- **Microsoft.Extensions.DependencyInjection**: For dependency injection and service management.
- **Microsoft.Extensions.Logging**: For logging operations.
- **System.Threading.Tasks**: For managing asynchronous operations.
- **Swashbuckle.AspNetCore**: For integrating Swagger to generate API documentation.

## Requirements

- **.NET 8**
- **Visual Studio 2022** or later

## Installation

To get started with the project, follow these steps:

1. Clone the repository.
   ```bash
   git clone https://github.com/SenseiBonsai2K/MenuManager.git
2. Open the project in Visual Studio.
3. Configure the database connection string in the appsettings.json file.
4. Run the database migrations:
  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update
  ```

## License
This project is licensed under the terms of the **MIT license**. See the [LICENSE](LICENSE) file for more details.

