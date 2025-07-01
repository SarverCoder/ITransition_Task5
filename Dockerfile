# See https://aka.ms/customizecontainer to learn how to customize your debug container.

# Base stage for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
# Railway uses dynamic port binding
ENV ASPNETCORE_URLS=http://*:$PORT
EXPOSE $PORT

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ITransition_Task5/ITransition_Task5.csproj", "ITransition_Task5/"]
RUN dotnet restore "./ITransition_Task5/ITransition_Task5.csproj"
COPY . .
WORKDIR "/src/ITransition_Task5"
RUN dotnet build "./ITransition_Task5.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ITransition_Task5.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# Add curl for healthchecks (optional but recommended)
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*
ENTRYPOINT ["dotnet", "ITransition_Task5.dll"]