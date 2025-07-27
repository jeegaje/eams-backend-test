# Accommodation Management System

A comprehensive accommodation management system built with .NET 8.0, featuring a multi-layered architecture with a web frontend, backend-for-frontend (BFF) layer, and core API services.

## 🏗️ Architecture Overview

The system follows a clean architecture pattern with clear separation of concerns:

```
┌─────────────────────────────────────────────────────────────┐
│                    Web Frontend (MVC)                      │
│                   Port: 5000/7000                          │
└─────────────────────┬───────────────────────────────────────┘
                      │
┌─────────────────────▼───────────────────────────────────────┐
│              Backend-for-Frontend (BFF)                    │
│                   Port: 5001/7001                          │
└─────────────────────┬───────────────────────────────────────┘
                      │
┌─────────────────────▼───────────────────────────────────────┐
│                  Core API                                  │
│                Port: 5002/7002                             │
└─────────────────────┬───────────────────────────────────────┘
                      │
┌─────────────────────▼───────────────────────────────────────┐
│              Infrastructure Layer                          │
│            (Entity Framework + SQL Server)                 │
└─────────────────────────────────────────────────────────────┘
```

## 📁 Project Structure

### Core Projects

- **EAMS.Domain** - Contains business entities, interfaces, DTOs, and domain logic
- **EAMS.Infrastructure** - Data access layer with Entity Framework, repositories, and services
- **EAMS.CoreAPI** - RESTful API with Swagger documentation
- **EAMS.BFF** - Backend-for-Frontend layer that aggregates and transforms API responses
- **EAMS.Web** - MVC web application with user interface

### Key Domain Models

#### User Model

- **Properties**: FirstName, LastName, Role, Jti, InvitationToken, etc.
- **Roles**: User, Manager, RestrictedAdmin, SuperAdmin, LeadAdmin
- **Features**: Password expiry tracking, role-based permissions

#### Accommodation Model

- **Properties**: Name, Address details, Region, Phone, Email, Website
- **Types**: Motel, Hotel, Backpacker, Caravan, Other
- **Classifications**: Density (Low/Medium/High), Duration (Short/Medium/Long/Permanent)
- **Regions**: Metropolitan, Regional, Remote

## 🚀 Getting Started

### Prerequisites

- **.NET 8.0 SDK** - [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** (LocalDB, Express, or full version)
- **Visual Studio 2022** or **Visual Studio Code** (optional but recommended)
- **Git** for version control

### Database Setup

The application uses SQL Server with the following default connection string:

```
Server=127.0.0.1,1433;Database=AccommodationDb;User Id=sa;Password=Masuklah#1;Trusted_Connection=false;TrustServerCertificate=true;
```

**Note**: Update the connection string in `src/EAMS.CoreAPI/appsettings.json` to match your SQL Server configuration.

### Installation & Setup

1. **Clone the repository**

   ```bash
   git clone <repository-url>
   cd EAMS
   ```

2. **Restore NuGet packages**

   ```bash
   dotnet restore
   ```

3. **Build the solution**

   ```bash
   dotnet build
   ```

4. **Update database (if needed)**
   ```bash
   cd src/EAMS.CoreAPI
   dotnet ef database update
   ```

## 🏃‍♂️ Running the Application

The system requires all three services to be running simultaneously. You can run them in separate terminal windows:

### Option 1: Run Individual Services

**Terminal 1 - Core API:**

```bash
cd src/EAMS.CoreAPI
dotnet run
```

- API will be available at: `http://localhost:5002`
- Swagger UI: `http://localhost:5002/swagger`

**Terminal 2 - Backend-for-Frontend (BFF):**

```bash
cd src/EAMS.BFF
dotnet run
```

- BFF will be available at: `http://localhost:5001`
- Swagger UI: `http://localhost:5001/swagger`

**Terminal 3 - Web Frontend:**

```bash
cd src/EAMS.Web
dotnet run
```

- Web application will be available at: `http://localhost:5000`

### Option 2: Using Visual Studio

1. Set multiple startup projects:

   - Right-click solution → Properties
   - Select "Multiple startup projects"
   - Set all three projects (CoreAPI, BFF, Web) to "Start"

2. Press F5 or click Start

## 🌐 Application URLs

| Service      | HTTP                  | HTTPS                  | Description          |
| ------------ | --------------------- | ---------------------- | -------------------- |
| Web Frontend | http://localhost:5000 | https://localhost:7000 | Main user interface  |
| BFF API      | http://localhost:5001 | https://localhost:7001 | Backend-for-Frontend |
| Core API     | http://localhost:5002 | https://localhost:7002 | Core business API    |

## 🔧 Development

### Available Endpoints

#### Core API (`/api/users`)

- `GET /api/users` - Retrieve all users

#### BFF API (`/bff/users`)

- `GET /bff/users` - Retrieve users with frontend-optimized response format

#### Web Frontend

- `/` - Home page
- `/Home/Users` - Users listing page
- `/Home/Privacy` - Privacy page

### Database Migrations

To create a new migration:

```bash
cd src/EAMS.CoreAPI
dotnet ef migrations add MigrationName
```

To update the database:

```bash
dotnet ef database update
```

### Project Dependencies

#### Web Project

- Microsoft.Extensions.Http (8.0.0)
- Microsoft.AspNetCore.Authentication.JwtBearer (8.0.0)

#### Core API Project

- Microsoft.AspNetCore.OpenApi (8.0.17)
- Swashbuckle.AspNetCore (6.6.2)
- Microsoft.EntityFrameworkCore.SqlServer (8.0.0)
- AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.1)
- FluentValidation.AspNetCore (11.3.0)
- Serilog.AspNetCore (8.0.0)

#### Infrastructure Project

- Microsoft.EntityFrameworkCore (8.0.17)
- Microsoft.EntityFrameworkCore.SqlServer (8.0.0)
- Microsoft.EntityFrameworkCore.Tools (8.0.0)

## 🔒 Security Features

- JWT Bearer authentication support (configured but not fully implemented)
- Role-based authorization with hierarchical user roles
- Password expiry tracking
- CORS policies configured between services

## 📝 API Documentation

When running in development mode, Swagger UI is available for both APIs:

- Core API: `http://localhost:5002/swagger`
- BFF API: `http://localhost:5001/swagger`

## 🛠️ Technology Stack

- **Framework**: .NET 8.0
- **Web Framework**: ASP.NET Core MVC
- **API Framework**: ASP.NET Core Web API
- **ORM**: Entity Framework Core
- **Database**: SQL Server
- **Documentation**: Swagger/OpenAPI
- **Logging**: Serilog
- **Validation**: FluentValidation
- **Mapping**: AutoMapper

## 📂 Configuration Files

- `appsettings.json` - Application configuration
- `appsettings.Development.json` - Development environment settings
- `launchSettings.json` - Development server configuration

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Run tests (when available)
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🐛 Troubleshooting

### Common Issues

1. **Database Connection Issues**

   - Verify SQL Server is running
   - Check connection string in `appsettings.json`
   - Ensure database exists or run migrations

2. **Port Conflicts**

   - Check if ports 5000, 5001, 5002 are available
   - Modify port numbers in `launchSettings.json` if needed

3. **CORS Issues**

   - Ensure all services are running on correct ports
   - Check CORS policies in Program.cs files

4. **Build Errors**
   - Run `dotnet restore` to ensure all packages are installed
   - Check .NET 8.0 SDK is installed

### Support

For support and questions, please create an issue in the repository.
