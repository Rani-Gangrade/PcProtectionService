# PC Protection System - Docker Deployment

## 🐳 Docker Setup Complete!

Your PC Protection MVP is now ready for Docker deployment with full hosting capabilities.

## 🚀 Quick Start

### Option 1: Use Batch Files (Easiest)
```bash
# Start all services
start-docker.bat

# Stop all services  
stop-docker.bat
```

### Option 2: Manual Docker Commands
```bash
# Build and start all services
docker-compose up -d --build

# View logs
docker-compose logs -f

# Stop services
docker-compose down
```

## 📊 Services Included

### 1. **PostgreSQL Database**
- **Container**: `pcprotection-postgres`
- **Port**: 5432
- **Database**: `pcprotection`
- **Credentials**: postgres / Rani@123

### 2. **PC Protection Service**
- **Container**: `pcprotection-service`
- **Function**: Collects system metrics every 15 seconds
- **Data**: CPU, Memory, Security events

### 3. **PC Protection API & Dashboard**
- **Container**: `pcprotection-api`
- **Port**: 5104
- **Dashboard**: http://localhost:5104
- **API Docs**: http://localhost:5104/swagger

## 🌐 Access Points

Once running, access your system at:
- **Dashboard**: http://localhost:5104
- **API Endpoint**: http://localhost:5104/api/analytics
- **Swagger Docs**: http://localhost:5104/swagger

## 🔧 Docker Commands

### View Service Status
```bash
docker-compose ps
```

### View Logs
```bash
# All services
docker-compose logs -f

# Specific service
docker-compose logs -f pcprotection-service
docker-compose logs -f pcprotection-api
```

### Restart Services
```bash
# Restart all
docker-compose restart

# Restart specific service
docker-compose restart pcprotection-service
```

### Update Services
```bash
# Rebuild and restart
docker-compose up -d --build
```

## 📁 File Structure
```
PcProtectionService/
├── docker-compose.yml          # Main orchestration file
├── .dockerignore              # Docker ignore rules
├── start-docker.bat           # Easy start script
├── stop-docker.bat            # Easy stop script
├── PcProtectionService/
│   └── Dockerfile             # Service container config
├── PCProtectionApi/
│   ├── Dockerfile             # API container config
│   └── appsettings.Production.json
└── PCProtectionShared/
    └── (shared libraries)
```

## 🎯 Features

- ✅ **Automatic Database Setup**: PostgreSQL with migrations
- ✅ **Health Checks**: Services wait for database to be ready
- ✅ **Persistent Data**: Database data survives container restarts
- ✅ **Production Ready**: Optimized for hosting
- ✅ **Easy Management**: Simple start/stop scripts
- ✅ **Network Isolation**: Services communicate securely
- ✅ **Auto Restart**: Services restart automatically if they fail

## 🚀 Deployment Ready!

Your PC Protection MVP is now ready for:
- **Local Development**: Run with `start-docker.bat`
- **Production Hosting**: Deploy to any Docker host
- **Cloud Deployment**: Ready for AWS, Azure, Google Cloud
- **CI/CD Integration**: Docker images ready for pipelines

## 📈 Monitoring

The system automatically:
- Collects real-time system metrics
- Stores data in PostgreSQL
- Serves data via REST API
- Displays beautiful dashboard
- Handles errors gracefully
- Restarts on failure

**Your PC Protection MVP is now production-ready with Docker! 🎉**
