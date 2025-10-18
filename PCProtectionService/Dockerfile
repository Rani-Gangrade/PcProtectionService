# Use the official .NET 8 runtime as base image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

# Use the official .NET 8 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["PcProtectionService/PcProtectionService.csproj", "PcProtectionService/"]
COPY ["PCProtectionShared/PCProtectionShared.csproj", "PCProtectionShared/"]

# Restore dependencies
RUN dotnet restore "PcProtectionService/PcProtectionService.csproj"

# Copy all source code
COPY . .

# Build the application
WORKDIR "/src/PcProtectionService"
RUN dotnet build "PcProtectionService.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "PcProtectionService.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app

# Install required packages for Windows performance counters
RUN apt-get update && apt-get install -y \
    procps \
    && rm -rf /var/lib/apt/lists/*

# Copy published application
COPY --from=publish /app/publish .

# Set environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Expose port (if needed for health checks)
EXPOSE 80

# Set entry point
ENTRYPOINT ["dotnet", "PcProtectionService.dll"]
