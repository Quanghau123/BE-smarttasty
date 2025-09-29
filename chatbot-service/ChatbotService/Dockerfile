# ============================
# 1. Build stage
# ============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# copy csproj và restore
COPY *.csproj ./
RUN dotnet restore

# copy toàn bộ source
COPY . ./
RUN dotnet publish -c Release -o /out

# ============================
# 2. Runtime stage
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
EXPOSE 8080

ENTRYPOINT ["dotnet", "ChatbotService.dll"]
