#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HealthMed-Agenda.Api/HealthMed-Agenda.Api.csproj", "HealthMed-Agenda.Api/"]
COPY ["HealthMed-Agenda.Application/HealthMed-Agenda.Application.csproj", "HealthMed-Agenda.Application/"]
COPY ["HealthMed-Agenda.Domain/HealthMed-Agenda.Domain.csproj", "HealthMed-Agenda.Domain/"]
COPY ["HealthMed-Agenda.Infra.Gateway/HealthMed-Agenda.Infra.Gateway.csproj", "HealthMed-Agenda.Infra.Gateway/"]
COPY ["HealthMed-Agenda.Infra.MQ/HealthMed-Agenda.Infra.MQ.csproj", "HealthMed-Agenda.Infra.MQ/"]
COPY ["HealthMed-Agenda.Ioc/HealthMed-Agenda.Ioc.csproj", "HealthMed-Agenda.Ioc/"]
COPY ["HealthMed-Agenda.Tests/HealthMed-Agenda.Tests.csproj", "HealthMed-Agenda.Tests/"]

RUN dotnet restore "./HealthMed-Agenda.Api/HealthMed-Agenda.Api.csproj"
COPY . .
WORKDIR "/src/HealthMed_Agenda.Api"
RUN dotnet build "./HealthMed-Agenda.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HealthMed-Agenda.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthMed-Agenda.Api.dll"]