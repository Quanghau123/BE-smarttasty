# Build phase
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj và restore
COPY *.csproj ./
RUN dotnet restore

# Copy toàn bộ source code và publish
COPY . ./
RUN dotnet publish -c Release -o /out

# Runtime phase
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy từ build
COPY --from=build /out ./

# Expose port (nếu cần, ví dụ 5000)
EXPOSE 5000

# Chạy DLL chính của NotificationService
ENTRYPOINT ["dotnet", "NotificationService.dll"]
