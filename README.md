# Inventory-Management
1)A brief description of the project.
Project Name:Inventory Management System API
Language : C#
Technology : ASP.Net Core Version 8.0, Entity Framework.
Database: MS-SQL

Description:-
	This is inventory Management System API Project, written in ASP.NET core8.0. 
API Layer: Exposes RESTful endpoints for product management (create, read, update, delete, and stock adjustments).
Business Logic Layer: Implements core business rules through interfaces like IProductBusinessLogic.
Data Access Layer: Manages database operations using Entity Framework Core and the Repository Pattern via interfaces such as IProductRepository.

Handled Exceptions using Global Exception Handler.
Used Dependency Injection for decoupled architecture.
Utilized Data Transfer Objects (DTO) to expose only necessary data on the client-facing side.
Used AutoMapper for mapping between entities and DTOs.

Database management handled via Entity Framework Core Migrations and SQL Server.
Used Code-First Approach for database migration.

API IN Project:
1)/api/Product/GetProduct/{productId}
2)/api/Product/GetAllProducts
3)/api/Product/AddProduct
4)/api/Product/UpdateProduct/{productId}
5)/api/Product/DeleteProduct/{productId}
6)/api/Product/DeleteProduct/{productId}
7)/api/Product/ReduceStock/{productId}/{stock}
8)/api/Product/LowStockProducts


2)Instructions to run this project locally.
Software Requirements:
	IDE: Visual Studio 2022 (or later)
	Framework: .NET 8.0 / ASP.NET Core 8.0
	Database: Microsoft SQL Server (MSSQL)
	ORM: Entity Framework Core 8
	Language: C#
	
Steps To Run:
-Inventory_Management_System_API project there is appsettinfs.json file. Change 'ConnectionStrings' to your database connection string.
-In nuget package manager console,Set 'Inventory_Management_System.DbConntext' as Default Project.
-Execute These two commands in sequence.
	Add-Migration InitialCreate -StartupProject Inventory-Management-System-API
	Update-Database -StartupProject Inventory-Management-System-API
-Start the Project.

3)How to run Test Cases:
Postamn Collection is added in this repository to run test cases.
Import collection in Postman. Or,Test Using Swagger UI.

Postman Collection Name = Inventory-Management-Collection.postman_collection
