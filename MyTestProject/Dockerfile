FROM mcr.microsoft.com/playwright/dotnet:v1.59.0-jammy
WORKDIR /test
# This copies the code Jenkins just pulled from GitHub
COPY . . 
RUN dotnet build
ENTRYPOINT ["dotnet", "test"]