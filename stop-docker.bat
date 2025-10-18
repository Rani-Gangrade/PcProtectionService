@echo off
echo ==============================================
echo   Stopping PC Protection System
echo ==============================================
echo.

echo Stopping all services...
docker-compose down

echo.
echo Cleaning up unused images (optional)...
docker system prune -f

echo.
echo All services stopped successfully!
echo.
pause
