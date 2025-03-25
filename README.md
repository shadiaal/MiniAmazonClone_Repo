
# Mini Amazon Clone

This project is a simple e-commerce system developed using .NET Core. It simulates a mini version of Amazon, where users can view products, place orders, and manage products (admin). The project utilizes various modern technologies including Entity Framework Core, Dapper, JWT authentication, Role-based and Policy-based authorization, and unit testing with Moq & xUnit/NUnit.

## Project Overview

The goal of this project is to create a basic e-commerce platform where:
- **Admins** can add/manage products and view all orders.
- **Customers** can register, view products, and place orders.

Key functionalities of the project:
1. **User Authentication & Authorization:** 
   - JWT Authentication for secure access to the APIs.
   - Role-based and Claims-based Authorization for Admins and Customers.
   
2. **Database Management:** 
   - EF Core for relational database management and migrations.
   - Dapper for optimized performance in queries.

3. **Order Management:**
   - Customers can create and view orders.
   - Admins have access to manage products and all orders.

## Features
- User registration and login with JWT tokens.
- Admin functionality to add/update products.
- Customers can view products and place orders.
- Role-based and Claims-based authorization.
- Unit testing for the order repository logic.
- API endpoints for products and order management.


## Technologies Used

- **Backend:** 
  - .NET Core
  - Entity Framework Core
  - Dapper
  - JWT Authentication
  - Moq & xUnit/NUnit for unit testing
  
- **Database:** 
  - SQL Server (EF Core for ORM)
  
- **Authorization:**
  - Role-based access control (RBAC)
  - Claims-based and Policy-based Authorization

## Setup

### Prerequisites

1. .NET Core SDK (7.0 or later)
2. SQL Server or any supported database
3. Visual Studio or any other C# IDE

### Steps to Run the Project

1. **Clone the repository:**
   ```bash
   git clone https://github.com/shadiaal/MiniAmazonClone_Repo.git
   cd MiniAmazonClone_Repo
   ```

2. **Create and apply migrations for the database:**

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

3. **Run the project:**

   ```bash
   dotnet run
   ```

## API Endpoints

### Authentication
- **POST /register:** User registration
- **POST /login:** User login, returns JWT token
- **GET /user/profile:** Returns user profile information (requires JWT authentication)

### Products
- **GET /product:** Get a list of all available products
- **POST /product/addProduct:** Add a new product (Admin only)
- **PUT /product/updateProduct/{id}:** Update an existing product (Admin only)


### Orders
- **POST /orders/create:** Create a new order (Customer only)
- **GET /orders/{id}:** Get a specific order details
- **GET /orders/all:** Get all orders (Admin only)

## Unit Testing
This project includes unit tests for data access logic. Unit tests are written using Moq and xUnit/NUnit to mock dependencies and validate the correctness of the order repository.

Run the unit tests using:
```bash
dotnet test
```

## Conclusion

This project demonstrates the ability to integrate multiple functionalities into a simple e-commerce system using .NET Core. It utilizes modern practices such as JWT authentication, role-based access, and performance optimization techniques with Dapper. 

---
