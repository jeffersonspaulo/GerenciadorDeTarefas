# Use a imagem base do .NET SDK
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use a imagem base do .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY ["KDSOrderManagement.csproj", "KDSOrderManagement/"]
RUN dotnet restore "KDSOrderManagement/KDSOrderManagement.csproj"

WORKDIR "/src/KDSOrderManagement"
COPY . .

RUN dotnet build "KDSOrderManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KDSOrderManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY appsettings.Docker.json .
ENV ASPNETCORE_ENVIRONMENT=Docker
ENTRYPOINT ["dotnet", "KDSOrderManagement.dll"]
