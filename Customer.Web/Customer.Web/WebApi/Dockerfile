#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 6200
EXPOSE 6210

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Customer.Web/WebApi/WebApi.csproj", "Customer.Web/WebApi/"]
COPY ["Customer.Web/Application/Application.csproj", "Customer.Web/Application/"]
COPY ["Core/Core.Messaging/Core.Messaging.csproj", "Core/Core.Messaging/"]
COPY ["Core/Core/Core.csproj", "Core/Core/"]
COPY ["Customer.Web/Domain/Domain.csproj", "Customer.Web/Domain/"]
COPY ["Customer.Web/Infrastructure/Infrastructure.csproj", "Customer.Web/Infrastructure/"]
RUN dotnet restore "./Customer.Web/WebApi/./WebApi.csproj"
COPY . .
WORKDIR "/src/Customer.Web/WebApi"
RUN dotnet build "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]