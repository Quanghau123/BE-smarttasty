# ============================
# 1. Build stage
# ============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj và restore
COPY chatbot-service/ChatbotService/*.csproj ./ 
RUN dotnet restore

# copy toàn bộ source
COPY chatbot-service/ChatbotService/. ./
RUN dotnet publish -c Release -o /app

# ============================
# 2. Runtime stage
# ============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app ./
EXPOSE 8080

ENTRYPOINT ["dotnet", "ChatbotService.dll"]
