# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["MyDotNetApp.csproj", "./"]
RUN dotnet restore

# Copy the rest of the code and publish
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port your app runs on
EXPOSE 8080
ENTRYPOINT ["dotnet", "MyDotNetApp.dll"]