# Build phase
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj và restore
COPY *.csproj ./
RUN dotnet restore

# Copy source code và publish
COPY . ./
RUN dotnet publish -c Release -o /out

# Runtime phase
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "WebSocketServer.dll"]
