#  Employee Management System

##  Description

The Employee Management System is a web-based application built using **ASP.NET Core MVC** and **SQL Server** that allows organizations to manage employee data efficiently. It supports role-based access for Admin, HR, Manager, and Engineer, with secure authentication and CRUD operations for employee records.

---

##  Features

-  User authentication and role-based authorization (Admin, HR, Manager, Engineer)
-  Add, view, edit, and delete employee records
-  Search and filter employee data
-  Pagination for large datasets
-  Server-side and client-side validation
-  Data caching using IMemoryCache
-  Layered architecture with Repository and Service pattern
-  Followed SOLID principles for clean code
-  Logging and exception handling

---

##  Tech Stack

- **Frontend**: Razor Pages, Bootstrap
- **Backend**: ASP.NET Core MVC (.NET 9 or latest)
- **Database**: SQL Server
- **ORM**: Entity Framework Core & Dapper
- **Authentication**: ASP.NET Core Identity (individual accounts)
- **Tools**: Visual Studio, Git, GitHub

---

##  Architecture

- `Controllers/` – Handles routing and user requests  
- `Models/` – Contains the data models (Employee, User, etc.)  
- `Views/` – Razor views for UI rendering  
- `Services/` – Business logic implementation  
- `Repositories/` – Interacts with the database (EF Core & Dapper)

---

##  Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/EmployeeManagement.git
   cd EmployeeManagement
