# Use .NET SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything from the build context (your whole repo) into the container
COPY . .

# Restore dependencies using the solution file
# This assumes DBConnectorSolution.sln is in the root of your repo
RUN dotnet restore "DBConnectorSolution.sln"

# Publish the console app
RUN dotnet publish "DBConnector.ConsoleApp/DBConnector.ConsoleApp.csproj" -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "DBConnector.ConsoleApp.dll"]
