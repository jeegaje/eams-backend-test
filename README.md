# 🏠 EAMS-BFF (Emergency Accommodation Management System - Backend for Frontend)

The EAMS-BFF is a .NET Core-based intermediate API layer designed to serve the Emergency Accommodation Management System (EAMS) Single Page Application (SPA). It aggregates and transforms data from the Core API, manages authentication flows, and optimizes communication between the frontend and backend services.

## 🚀 Purpose

- Serve UI-specific data to the SPA with minimal network chattiness.
- Handle authentication and token management via Azure Entra ID (B2C).
- Provide a modular, scalable, and cloud-native backend aligned with Microsoft Azure best practices.

---

## 🧱 Architecture Overview

| Layer         | Technology        | Hosting                |
|--------------|-------------------|------------------------|
| SPA          | Vue.js or React   | Azure Static Web Apps  |
| BFF and Core API (this project) | .NET Core         | Azure Container Apps   |
| Data Layer   | Azure SQL Database| Azure SQL              |
| Identity     | Azure Entra ID B2C| Azure Entra            |

---

## 🔐 Authentication & Security

- **Identity Provider**: Azure Entra External ID (B2C)
- **Token Management**: JWTs issued by Entra ID, managed by BFF
- **Secrets Management**: Azure Key Vault
- **Network Security**: Azure VNet integration and private endpoints (recommended)

---

## 📦 Features

- 🔄 **API Aggregation**: Combines multiple Core API calls into optimized endpoints
- 🎯 **UI-Specific Transformation**: Tailors backend data for SPA consumption (DTOs)
- 📊 **Monitoring**: Integrated with Azure Application Insights
- 🔧 **CI/CD**: Automated pipelines via Azure DevOps or GitHub Actions 

---

## 🛠️ Technologies Used

- [.NET Core](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
- [Azure Container Apps](https://learn.microsoft.com/en-us/azure/container-apps/)
- [Azure Entra ID (B2C)](https://learn.microsoft.com/en-us/azure/active-directory-b2c/)
- [Azure Key Vault](https://learn.microsoft.com/en-us/azure/key-vault/)
- [Azure Application Insights](https://learn.microsoft.com/en-us/azure/azure-monitor/app/app-insights-overview)

---

## 📁 Project Structure

EAMS.API/                          # Main Web API project (BFF + Core API)
├── Controllers/                   # API endpoints
├── Middleware/                    # Custom middleware (e.g., error handling, logging)
├── Extensions/                    # Service registration, configuration extensions
├── DTOs/                          # Data Transfer Objects for API communication
├── Program.cs                     # Entry point
├── appsettings.json               # Configuration
├── EAMS.API.csproj

EAMS.Domain/                       # Business rules and domain logic
├── Entities/                      # Core domain entities (e.g., Booking, Property, Organisation)
├── Interfaces/                    # Domain service interfaces
├── Services/                      # Business logic implementations
├── ValueObjects/                  # Domain-specific value types
├── Exceptions/                    # Domain-specific exceptions
├── EAMS.Domain.csproj

EAMS.Infrastructure/              # Data access and external integrations
├── Repositories/                 # EF Core repositories
├── DataContext/                  # EF DbContext
├── Identity/                     # Azure Entra ID integration
├── KeyVault/                     # Secure secret retrieval
├── Migrations/					  # EF Core migrations
├── EAMS.Infrastructure.csproj

EAMS.Tests/                       # Unit and integration tests
├── EAMS.Domain.Tests/            # Domain layer tests
├── EAMS.Tests.csproj

README.md                         # Project documentation

# 📦 EF Core Components


## 🧱 DbContext Configuration

Located in `EAMS.Infrastructure/DataContext/EamsDbContext.cs`:

## 🧱 Migrations

```
# To add a migration
dotnet ef migrations add [MigrationName] --project src\EAMS.Infrastructure --startup-project src\EAMS.API

# To update database
dotnet ef database update --project src\EAMS.Infrastructure --startup-project src\EAMS.API
```


