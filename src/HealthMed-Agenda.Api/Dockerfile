#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HealthMed_Agenda.Api/HealthMed_Agenda.Api.csproj", "HealthMed_Agenda.Api/"]
COPY ["HealthMed_Agenda.Application/HealthMed_Agenda.Application.csproj", "HealthMed_Agenda.Application/"]
COPY ["HealthMed_Agenda.Domain/HealthMed_Agenda.Domain.csproj", "HealthMed_Agenda.Domain/"]
COPY ["HealthMed_Agenda.Infra.Gateway/HealthMed_Agenda.Infra.Gateway.csproj", "HealthMed_Agenda.Infra.Gateway/"]
COPY ["HealthMed_AgendaInfra.MQ/HealthMed_Agenda.Infra.MQ.csproj", "HealthMed_Agenda.Infra.MQ/"]
COPY ["HealthMed_Agenda.Ioc/HealthMed_Agenda.Ioc.csproj", "HealthMed_Agenda.Ioc/"]
COPY ["HealthMed_Agenda.Tests/HealthMed_Agenda.Tests.csproj", "HealthMed_Agenda.Tests/"]

RUN dotnet restore "./HealthMed_Agenda.Api/HealthMed_Agenda.Api.csproj"
COPY . .
WORKDIR "/src/HealthMed_Agenda.Api"
RUN dotnet build "./HealthMed_Agenda.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HealthMed_Agenda.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HealthMed_Agenda.Api.dll"]