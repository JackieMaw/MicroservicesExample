# Use the official .NET 8 SDK image to build the app.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies.
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the source code and publish the app.
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET 8 runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "StorageApi.dll"]