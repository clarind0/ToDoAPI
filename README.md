# ✅ ToDoAPI

A robust and clean RESTful API for managing Assigment Lists, built using ASP.NET Core, Entity Framework Core, and MySQL.

---

## 📦 Tech Stack

- **ASP.NET Core 8**
- **Entity Framework Core (Code First)**
- **MySQL**
- **Swagger / OpenAPI**

---

## 🚀 Features

- 🔐 JWT-based Authentication
- ✅ CRUD for Tasks and Users
- 📌 Pagination, Filtering and Sorting
- 🧾 DTO Mapping with AutoMapper
- 📂 Layered Architecture (Controller → Service → Repository)

---

## 🛠️ Getting Started

### ✅ Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/)
- [MySQL Server](https://dev.mysql.com/)
- [Postman](https://www.postman.com/) or your browser

---

### 🔧 Setup Instructions

```bash
# Clone the repository
git clone https://github.com/your-username/ToDoAPI.git
cd ToDoAPI

# Restore dependencies
dotnet restore

# Apply migrations and initialize the database
dotnet ef database update
```

---

## ▶️ Running the API

```bash
dotnet run
```

By default, the application runs at:  
📎 `https://localhost:5001`

---

## 🧭 Testing the API with Swagger

Once the API is running, open your browser and navigate to:

📎 `https://localhost:5001/swagger/index.html`

From there, you can explore all endpoints, test requests and inspect responses interactively.

---

## 🔐 Environment Configuration

Set up the following variables in `appsettings.json` or through secrets:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;user=root;password=yourpassword;database=ToDoDb;"
},
"Jwt": {
  "Key": "your-secret-key",
  "Issuer": "ToDoAPI",
  "Audience": "ToDoAPIClient"
}
```

---

## 🧠 What I Learned

- Effective use of ASP.NET Core layers (controllers, services, repositories)
- Building secure JWT authentication from scratch
- Applying clean architecture principles in a small-to-medium project
- Simplified API documentation using Swagger/OpenAPI
