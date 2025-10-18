@echo off
echo Starting PC Protection System...
echo.
echo Starting API Server...
start "PC Protection API" cmd /k "cd /d %~dp0PCProtectionApi && dotnet run"
timeout /t 3 /nobreak >nul
echo.
echo Starting PC Protection Service...
start "PC Protection Service" cmd /k "cd /d %~dp0PcProtectionService && dotnet run"
echo.
echo Both services are starting...
echo API Dashboard: http://localhost:5104
echo API Docs: http://localhost:5104/swagger
echo.
pause
