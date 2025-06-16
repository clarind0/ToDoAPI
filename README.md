# ✅ ToDoAPI

A simple yet robust RESTful API for managing tasks (to-dos), built with ASP.NET Core, Entity Framework Core and MySQL.

---

## 📦 Tech Stack

- **.NET 8 / ASP.NET Core**
- **Entity Framework Core (Code First)**
- **MySQL**
- **Swagger**

---

## 🚀 Features

- 🔐 JWT-based Authentication and Authorization
- 📄 CRUD operations for Assigment List, Tasks and Users
- 🧾 Soft-delete and Audit Fields
- 🔍 Filtering, Sorting and Pagination
- 📦 DTOs with AutoMapper
- 🧪 Unit and Integration Tests with xUnit

---

## 🛠️ Getting Started

### ✅ Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/)
- [MySQL Server](https://dev.mysql.com/)
- [Postman](https://www.postman.com/) or Swagger for testing

### 🔧 Setup

```bash
# Clone the repository
git clone https://github.com/your-username/ToDoAPI.git
cd ToDoAPI

# Restore dependencies
dotnet restore

# Apply migrations and seed database
dotnet ef database update
