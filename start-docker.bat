@echo off
echo ==============================================
echo   PC Protection System - Docker Deployment
echo ==============================================
echo.

echo Building and starting all services...
echo.

echo [1/3] Building Docker images...
docker-compose build

echo.
echo [2/3] Starting services...
docker-compose up -d

echo.
echo [3/3] Checking service status...
docker-compose ps

echo.
echo ==============================================
echo   Services Started Successfully!
echo ==============================================
echo.
echo Dashboard: http://localhost:5104
echo API Docs:  http://localhost:5104/swagger
echo.
echo To view logs:
echo   docker-compose logs -f
echo.
echo To stop services:
echo   docker-compose down
echo.
pause
