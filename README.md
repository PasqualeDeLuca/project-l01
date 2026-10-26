# Project_l01

Full-stack inventory and order management application built as an educational and portfolio project.

The project simulates a small business system for managing **categories, products, customers and orders**, with a REST API developed in **ASP.NET Core** and a web frontend developed with **Angular**.

The main goal is to practice the development of a modern full-stack application using the .NET ecosystem, relational databases, Entity Framework Core and Angular.

---

## 🚀 Tech Stack

### Backend

- **C#**
- **.NET 10**
- **ASP.NET Core**
- **Entity Framework Core**
- **PostgreSQL**
- **Docker / Docker Compose**
- **OpenAPI**
- **Swagger UI**

### Frontend

- **Angular**
- **TypeScript**
- **HTML**
- **CSS**

### Development tools

- **Git**
- **GitHub**
- **Visual Studio Code**
- **Docker Desktop**
- **.NET CLI**
- **EF Core CLI**

---

## 📚 Project Status

The application currently provides a basic full-stack management system for products, categories, customers, and orders.

### Available features

- **Product management** — Create, view, update, and delete products.
- **Category management** — Manage product categories with relational constraints.
- **Order management** — View orders, customers, order items, quantities, prices, and totals.
- **REST API** — ASP.NET Core API organized into Controllers, Services, Repositories, DTOs, and Entity Framework Core.
- **Database** — PostgreSQL database running in Docker, with migrations, relational constraints, and seed data.
- **Angular frontend** — Web interface for browsing products and orders, including product CRUD and order details.
- **API documentation** — Interactive API testing through OpenAPI and Swagger UI.
- **SQL** — Direct database inspection and verification through PostgreSQL.

---

## 📌 Project Overview

Project_l01 represents a simplified business management application.

The application is centered around four main domain concepts:

```text
Category
   │
   └── Product
          │
          └── Order Item
                    │
Customer ───────── Order
```

The system will allow users to:

- manage product categories
- manage products
- manage customers
- create and manage orders
- associate products with orders
- calculate order totals
- retrieve data through a REST API
- interact with the backend through an Angular frontend

The project is intentionally developed incrementally, following a learning-oriented roadmap.

---

## 🏗️ Architecture

The application follows a classic full-stack architecture:

```text
┌──────────────────────┐
│       Angular        │
│      Frontend        │
└──────────┬───────────┘
           │ HTTP / JSON
           ▼
┌──────────────────────┐
│    ASP.NET Core      │
│       REST API       │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│ Entity Framework Core│
│         ORM          │
└──────────┬───────────┘
           │
           ▼
┌──────────────────────┐
│      PostgreSQL      │
│      Database        │
└──────────────────────┘
```

### Backend

The backend is implemented as an ASP.NET Core Web API.

Its responsibilities include:

- exposing REST endpoints
- validating incoming requests
- implementing application logic
- communicating with the database
- mapping database entities to API responses
- handling errors
- documenting the API through OpenAPI/Swagger

### Data access

**Entity Framework Core** is used as the ORM.

It provides the connection between C# objects and relational database tables.

The project uses:

- entities
- `DbContext`
- relationships
- migrations
- LINQ queries
- seed data

### Database

**PostgreSQL** is used as the relational database.

The database runs inside a Docker container, making the development environment reproducible and isolated from the host machine.

---

## 📁 Project Structure

The current repository structure is:

```text
project-l01/
│
├── .gitignore
├── docker-compose.yml
├── project-l01.slnx
│
└── project-l01.api/
    │
    ├── Data/
    │
    ├── Properties/
    │
    ├── project-l01.api.csproj
    ├── Program.cs
    ├── project-l01.api.http
    ├── appsettings.json
    └── appsettings.Development.json
```

The repository root represents the overall solution, while `project-l01.api` contains the ASP.NET Core API project.

As the application grows, additional folders will be introduced to separate responsibilities such as:

```text
project-l01.api/
│
├── Controllers/
├── Data/
├── Entities/
├── DTOs/
├── Services/
└── ...
```

---

## 🗄️ Domain Model

The initial domain is composed of four main entities.

### Category

Represents a category to which products belong.

```text
Category
---------
Id
Name
```

A category can contain multiple products.

```text
Category 1 ──────── * Product
```

### Product

Represents an item available in the inventory.

```text
Product
-------
Id
Name
Description
Price
Stock
CategoryId
```

Each product belongs to one category.

### Customer

Represents a customer who can place orders.

```text
Customer
--------
Id
FirstName
LastName
Email
```

### Order

Represents an order created by a customer.

```text
Order
-----
Id
CustomerId
OrderDate
Status
```

An order can contain multiple products through order items.

```text
Customer 1 ──────── * Order

Order 1 ──────── * OrderItem

Product 1 ──────── * OrderItem
```

---

## 🔗 Database Relationships

The relational model uses foreign keys to connect entities.

Conceptually:

```text
Categories
    │
    │ 1:N
    ▼
Products
    │
    │ 1:N
    ▼
OrderItems
    ▲
    │ N:1
    │
Orders
    ▲
    │ N:1
    │
Customers
```

This structure allows the application to represent real-world business relationships while maintaining database integrity.

---

## 🔄 Entity Framework Core

Entity Framework Core is responsible for mapping the C# domain model to PostgreSQL.

The development workflow is based on migrations:

```text
C# Entity
    ↓
EF Core Model
    ↓
Migration
    ↓
PostgreSQL Schema
```

For example, when a new property is added to an entity, a migration can be generated and applied to update the database schema.

This keeps the database structure synchronized with the application's model.

---

## 🐳 Docker

PostgreSQL runs through Docker Compose.

This allows the database environment to be created without installing PostgreSQL directly on the host machine.

The basic architecture is:

```text
Docker Compose
      │
      ▼
PostgreSQL Container
      │
      ▼
Project_l01 Database
```

Docker also makes it easier to reproduce the development environment on another machine.

---

## 📖 API Documentation

The backend exposes a REST API.

During development, the API is documented using **OpenAPI** and can be explored through **Swagger UI**.

This makes it possible to:

- inspect available endpoints
- understand request/response models
- send test requests
- inspect HTTP status codes
- experiment with the API without requiring the Angular frontend

---

## 🔍 API

The API will expose resources corresponding to the application's domain.

Examples include:

```text
GET    /api/categories
GET    /api/categories/{id}
POST   /api/categories
PUT    /api/categories/{id}
DELETE /api/categories/{id}
```

and similarly for:

```text
/api/products
/api/customers
/api/orders
```

The exact endpoints will evolve as development progresses.

---

## 🖥️ Angular Frontend

The Angular application will provide the user interface for interacting with the API.

The frontend will communicate with the backend through HTTP requests:

```text
Angular Component
       ↓
Angular Service
       ↓
HttpClient
       ↓
ASP.NET Core API
       ↓
Entity Framework Core
       ↓
PostgreSQL
```

The frontend will progressively implement interfaces for:

- products
- categories
- customers
- orders

---

## 🛠️ Development Goals

This project is primarily a learning and portfolio project.

The main objectives are to gain practical experience with:

### .NET

- C#
- ASP.NET Core
- REST APIs
- Dependency Injection
- configuration
- middleware
- error handling
- OpenAPI
- Swagger

### Entity Framework Core

- entities
- `DbContext`
- relationships
- foreign keys
- migrations
- seed data
- LINQ
- database queries

### PostgreSQL

- relational database design
- primary keys
- foreign keys
- constraints
- joins
- filtering
- aggregation
- SQL queries

### Angular

- components
- templates
- services
- dependency injection
- routing
- forms
- HTTP communication
- reactive programming

### Development practices

- Git
- GitHub
- semantic commits
- project organization
- separation of concerns
- incremental development

---

## ▶️ Running the Project

### Requirements

Make sure the following tools are installed:

- [.NET 10 SDK](https://dotnet.microsoft.com/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- Node.js
- npm
- Angular CLI

### 1. Clone the repository

```bash
git clone <repository-url>
cd project-l01
```

### 2. Start PostgreSQL

```bash
docker compose up -d
```

### 3. Restore .NET dependencies

```bash
dotnet restore
```

### 4. Apply database migrations

```bash
dotnet ef database update --project project-l01.api
```

### 5. Start the API

```bash
dotnet run --project project-l01.api
```

The API will be available on the development URL displayed by ASP.NET Core.

### 6. Start the Angular application

Once the frontend is available:

```bash
cd <angular-project-folder>
npm install
ng serve
```

The Angular development server will then provide the frontend application.

---

## 🧪 Development Workflow

The project is developed incrementally.

A typical workflow is:

```text
1. Define domain requirement
          ↓
2. Create / update Entity
          ↓
3. Configure EF Core
          ↓
4. Create Migration
          ↓
5. Update PostgreSQL
          ↓
6. Implement API endpoint
          ↓
7. Test API with Swagger
          ↓
8. Implement Angular UI
          ↓
9. Test complete flow
```

This approach makes it possible to understand each layer before connecting it to the next one.

---

## 🎯 Why this project?

Project_l01 is designed to demonstrate the complete development flow of a small full-stack application.

Rather than focusing only on the final interface, the project covers the entire chain:

```text
Database
   ↕
Entity Framework Core
   ↕
ASP.NET Core API
   ↕
HTTP / JSON
   ↕
Angular
   ↕
User Interface
```

The project therefore serves both as a practical learning environment and as a portfolio project demonstrating familiarity with the **.NET + Angular full-stack ecosystem**.

---

## 👤 Author

**Pasquale De Luca**

Software Developer focused on full-stack development, .NET, Angular and modern application architecture.
