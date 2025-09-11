# Build phase
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj và restore sớm để cache
COPY *.csproj ./
RUN dotnet restore

# Copy toàn bộ source và publish
COPY . ./
RUN dotnet publish -c Release -o /out

# Runtime phase
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "backend.dll"]
