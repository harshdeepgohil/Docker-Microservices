FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY Product.Services.ProductAPI.csproj ./
RUN dotnet restore Product.Services.ProductAPI.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80 

ENTRYPOINT ["dotnet", "Product.Services.ProductAPI.dll"]

