This is a repo of Asp.netcore .net backend application of "Quora"(a clone of Quora application).
Topic,Question,Answer are Entity objects of my application .
You can perfrom CRUD operation on each table.

# Quora-Like Backend Server

A scalable RESTful backend for a Topic,Question&Answer platform built using **ASP.NET Core**, **Entity Framework Core**, and **Azure SQL**. The application is containerized using **Docker** for easy local setup and deployment.

## 🚀 Tech Stack

- C#  
- ASP.NET Core Web API  
- Entity Framework Core  
- Azure SQL Server (Docker container)  
- Swagger / OpenAPI  
- Docker  
- Microsoft Azure (Deployment)

---

## 📦 Features

- REST APIs for Q&A content (CRUD operations)
- Proper validation and centralized error handling
- Normalized relational database schema
- Optimized read queries for better performance
- Swagger UI for API testing and documentation
- Fully containerized application
- Cloud deployment ready (Azure)

---

## 🛠️ Prerequisites

Make sure you have the following installed:

- .NET 8 SDK (or your project version)
- Docker Desktop
- Git

---

## ⚙️ How to Run the Application (Using Docker)

### 1️⃣ Clone the Repository

git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name

2️⃣ Start Azure SQL Server Container

Pull and run SQL Server container:

3️⃣ Update Connection String

Update appsettings.json:

4️⃣ Scaffold Database Entities

🧪 Running Without Docker (Optional)

Update connection string to your local SQL instance.

Run:

dotnet restore
dotnet build
dotnet run

7️⃣ Access the Application

http://localhost:5000/swagger
