# 🛡️ PC Protection MVP - System Health Monitoring

A comprehensive real-time system health monitoring solution built with .NET 8, PostgreSQL, and modern web technologies.

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Requirements](#requirements)
- [Quick Start](#quick-start)
- [Project Structure](#project-structure)
- [API Documentation](#api-documentation)
- [Deployment](#deployment)
- [Configuration](#configuration)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)

## 🎯 Overview

PC Protection MVP is a real-time system health monitoring solution that collects, stores, and visualizes system metrics including CPU utilization, memory usage, and security events. The system consists of a background service that continuously monitors system health and a web dashboard that provides real-time visualization of the collected data.

## ✨ Features

### 🔧 Core Functionality
- **Real-time System Monitoring**: Collects metrics every 15 seconds
- **CPU Utilization Tracking**: Monitors processor usage with Windows Performance Counters
- **Memory Usage Monitoring**: Tracks RAM consumption and availability
- **Security Event Detection**: Monitors Windows Security Event Log (with graceful fallback)
- **Data Persistence**: Stores all metrics in PostgreSQL database
- **RESTful API**: Provides data access via REST endpoints
- **Modern Dashboard**: Beautiful, responsive web interface with real-time updates

### 🚀 Technical Features
- **Entity Framework Core**: Modern ORM with automatic migrations
- **PostgreSQL Database**: Robust, scalable data storage
- **CORS Support**: Cross-origin requests enabled
- **Swagger Documentation**: Interactive API documentation
- **Docker Support**: Containerized deployment ready
- **Error Handling**: Comprehensive error management and logging
- **Performance Optimized**: Efficient data collection and storage

## 🏗️ Architecture

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   PC Protection │    │   PostgreSQL    │    │   Web Dashboard │
│     Service     │───▶│    Database     │◀───│   & API Server  │
│  (Background)   │    │                 │    │                 │
└─────────────────┘    └─────────────────┘    └─────────────────┘
         │                       │                       │
         ▼                       ▼                       ▼
   System Metrics          Data Storage            User Interface
   - CPU Usage            - SystemMetrics         - Real-time Charts
   - Memory Usage         - Automatic Migrations  - Historical Data
   - Security Events      - Data Persistence      - API Documentation
```

### Components

1. **PC Protection Service**: Background service that collects system metrics
2. **PC Protection API**: Web API server that serves data and dashboard
3. **PC Protection Shared**: Shared libraries and data models
4. **PostgreSQL Database**: Data storage with Entity Framework migrations
5. **Web Dashboard**: Modern, responsive user interface

## 📋 Requirements

### System Requirements
- **Operating System**: Windows 10/11 or Windows Server 2019+
- **.NET Runtime**: .NET 8.0 or later
- **Database**: PostgreSQL 12+ (or use Docker)
- **Memory**: Minimum 2GB RAM
- **Disk Space**: 500MB for application and data

### Development Requirements
- **Visual Studio 2022** or **Visual Studio Code**
- **.NET 8 SDK**
- **PostgreSQL** (or Docker Desktop)
- **Git** (for version control)

## 🚀 Quick Start

### Option 1: Docker Deployment (Recommended)

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd PcProtectionService
   ```

2. **Start all services**
   ```bash
   # Windows
   start-docker.bat
   
   # Linux/Mac
   docker-compose up -d --build
   ```

3. **Access the dashboard**
   - Open browser: http://localhost:5104
   - API Documentation: http://localhost:5104/swagger

### Option 2: Manual Setup

1. **Setup PostgreSQL Database**
   ```bash
   # Create database
   psql -U postgres -c "CREATE DATABASE pcprotection;"
   ```

2. **Run Entity Framework Migrations**
   ```bash
   cd PCProtectionShared
   dotnet ef database update
   ```

3. **Start the PC Protection Service**
   ```bash
   cd PcProtectionService
   dotnet run
   ```

4. **Start the API Server** (in new terminal)
   ```bash
   cd PCProtectionApi
   dotnet run
   ```

5. **Access the dashboard**
   - Open browser: http://localhost:5104

## 📁 Project Structure

```
PcProtectionService/
├── 📁 PcProtectionService/          # Background monitoring service
│   ├── Program.cs                   # Main service entry point
│   ├── PcProtectionService.csproj   # Service project file
│   └── Dockerfile                   # Service container config
├── 📁 PCProtectionApi/              # Web API and dashboard
│   ├── Controllers/
│   │   └── AnalyticsController.cs   # API endpoints
│   ├── wwwroot/
│   │   └── index.html              # Web dashboard
│   ├── Program.cs                   # API server entry point
│   ├── appsettings.json            # Configuration
│   ├── PCProtectionApi.csproj      # API project file
│   └── Dockerfile                   # API container config
├── 📁 PCProtectionShared/           # Shared libraries
│   ├── Data/
│   │   ├── AppDbContext.cs         # Entity Framework context
│   │   └── AppDbContextFactory.cs  # Design-time factory
│   ├── SystemMetrics.cs            # Data models
│   ├── Migrations/                  # Database migrations
│   └── PCProtectionShared.csproj   # Shared project file
├── 📄 docker-compose.yml            # Docker orchestration
├── 📄 start-docker.bat              # Docker startup script
├── 📄 stop-docker.bat               # Docker shutdown script
├── 📄 start-all.bat                 # Manual startup script
└── 📄 README.md                     # This file
```

## 📚 API Documentation

### Base URL
```
http://localhost:5104/api
```

### Endpoints

#### Get Latest Metrics
```http
GET /api/analytics
```

**Response:**
```json
[
  {
    "id": 1,
    "cpuUtilization": 15.2,
    "memoryUsedMb": 11711,
    "memoryTotalMb": 13624,
    "memoryUtilization": 85.96,
    "securityEventType": "SystemCheck",
    "securityEventMessage": "System security check completed",
    "hostname": "LAPTOP-ABC123",
    "collectedAt": "2025-01-18T10:30:00Z",
    "createdAt": "2025-01-18T10:30:00Z"
  }
]
```

### Interactive Documentation
Visit http://localhost:5104/swagger for interactive API documentation.

## 🚀 Deployment

### Docker Deployment

1. **Build and start services**
   ```bash
   docker-compose up -d --build
   ```

2. **Check service status**
   ```bash
   docker-compose ps
   ```

3. **View logs**
   ```bash
   docker-compose logs -f
   ```

4. **Stop services**
   ```bash
   docker-compose down
   ```

### Cloud Deployment

#### Azure
```bash
# Deploy to Azure Container Instances
az container create --resource-group myResourceGroup \
  --name pcprotection --image your-registry/pcprotection-api \
  --dns-name-label pcprotection-demo --ports 80
```

#### AWS
```bash
# Deploy to AWS ECS
aws ecs create-service --cluster my-cluster \
  --service-name pcprotection --task-definition pcprotection:1 \
  --desired-count 1
```

#### Google Cloud
```bash
# Deploy to Cloud Run
gcloud run deploy pcprotection --source . \
  --platform managed --region us-central1
```

## ⚙️ Configuration

### Database Connection
Update connection strings in:
- `PCProtectionApi/appsettings.json`
- `PCProtectionApi/appsettings.Production.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=pcprotection;Username=postgres;Password=yourpassword;"
  }
}
```

### Service Configuration
Modify collection interval in `PcProtectionService/Program.cs`:
```csharp
Thread.Sleep(15000); // 15 seconds
```

### Dashboard Configuration
Update API URL in `PCProtectionApi/wwwroot/index.html`:
```javascript
const API_BASE_URL = 'http://localhost:5104/api';
```

## 🔧 Troubleshooting

### Common Issues

#### 1. Database Connection Failed
```bash
# Check PostgreSQL is running
pg_ctl status

# Test connection
psql -U postgres -d pcprotection -c "SELECT 1;"
```

#### 2. Port Already in Use
```bash
# Find process using port 5104
netstat -ano | findstr :5104

# Stop the process
taskkill /PID <process_id> /F
```

#### 3. File Lock Errors
```bash
# Stop all dotnet processes
Get-Process -Name "dotnet" | Stop-Process -Force

# Clean and rebuild
dotnet clean
dotnet build
```

#### 4. Security Event Access Denied
The system automatically falls back to simulated security events when running without administrator privileges. This is normal behavior and doesn't affect functionality.

### Logs and Debugging

#### View Service Logs
```bash
# Docker
docker-compose logs -f pcprotection-service

# Manual
# Check console output of the service
```

#### View API Logs
```bash
# Docker
docker-compose logs -f pcprotection-api

# Manual
# Check console output of the API server
```

#### Database Logs
```bash
# PostgreSQL logs
tail -f /var/log/postgresql/postgresql-*.log
```

## 📊 Performance

### System Requirements
- **CPU**: Minimal impact (< 1% average)
- **Memory**: ~50MB for service, ~100MB for API
- **Disk**: ~10MB/hour for metrics storage
- **Network**: Minimal (local API calls only)

### Optimization Tips
1. **Database Indexing**: Automatic with Entity Framework
2. **Connection Pooling**: Enabled by default
3. **Caching**: Dashboard caches data for 30 seconds
4. **Compression**: API responses are compressed

## 🔒 Security

### Data Protection
- **Local Storage**: All data stored locally
- **No External Calls**: System operates offline
- **Encrypted Connections**: HTTPS in production
- **Access Control**: CORS configured for local access

### Best Practices
1. **Change Default Passwords**: Update PostgreSQL credentials
2. **Use HTTPS**: Enable SSL in production
3. **Network Security**: Restrict access to monitoring ports
4. **Regular Updates**: Keep .NET and PostgreSQL updated

## 🤝 Contributing

### Development Setup
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

### Code Style
- Follow C# naming conventions
- Use meaningful variable names
- Add XML documentation for public methods
- Keep methods focused and small

### Testing
```bash
# Run tests
dotnet test

# Build solution
dotnet build

# Run linting
dotnet format
```

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🙏 Acknowledgments

- **.NET Team** for the excellent framework
- **PostgreSQL** for the robust database
- **Entity Framework** for the ORM capabilities
- **Docker** for containerization support

## 📞 Support

For support and questions:
- **Issues**: Create an issue in the repository
- **Documentation**: Check this README and inline code comments
- **API Docs**: Visit http://localhost:5104/swagger when running

---

**PC Protection MVP** - Professional system health monitoring made simple! 🛡️✨
