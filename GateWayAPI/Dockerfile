﻿FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY GateWayAPI.csproj ./
RUN dotnet restore GateWayAPI.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "GateWayAPI.dll"]
