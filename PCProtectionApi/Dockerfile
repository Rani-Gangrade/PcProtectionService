# Use the official .NET 8 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 8 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["PCProtectionApi/PCProtectionApi.csproj", "PCProtectionApi/"]
COPY ["PCProtectionShared/PCProtectionShared.csproj", "PCProtectionShared/"]

# Restore dependencies
RUN dotnet restore "PCProtectionApi/PCProtectionApi.csproj"

# Copy all source code
COPY . .

# Build the application
WORKDIR "/src/PCProtectionApi"
RUN dotnet build "PCProtectionApi.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "PCProtectionApi.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app

# Copy published application
COPY --from=publish /app/publish .

# Set environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80

# Expose port
EXPOSE 80

# Set entry point
ENTRYPOINT ["dotnet", "PCProtectionApi.dll"]
