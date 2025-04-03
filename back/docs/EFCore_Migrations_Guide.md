# 📦 Entity Framework Core Migrations Guide

This document explains how to run EF Core migrations in the **Animeland** project from inside the `Animeland.API` folder.

---

## 🛠️ Prerequisites

- Run these commands from the `Animeland.API` folder:
  ```
  cd back/src/Animeland.API/Animeland.API
  ```
- Ensure the following packages are installed:

### 🔹 In `Animeland.Infrastructure.csproj`
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design

### 🔹 In `Animeland.API.csproj`
- Microsoft.EntityFrameworkCore.Design

---

## 🚀 Create a Migration

```bash
dotnet ef migrations add InitialCreate \
  --project ../../Animeland.Infrastructure \
  --startup-project .
```

✅ This creates the `Migrations` folder inside `Animeland.Infrastructure`.

---

## 🛠️ Apply the Migration (Update Database)

```bash
dotnet ef database update \
  --project ../../Animeland.Infrastructure \
  --startup-project .
```

✅ This applies the migration and creates or updates the database.

---

## 🧼 Tips

- If you encounter errors about connection strings, ensure your `appsettings.json` contains:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=AnimelandDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

- If EF Core can't instantiate `ApplicationDbContext`, check your `ApplicationDbContextFactory` implementation.

---

Happy coding! 🚀