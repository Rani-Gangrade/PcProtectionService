@echo off
echo Starting PC Protection Service...
cd /d "%~dp0PcProtectionService"
dotnet run
pause
