# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/GerenciadorDeTarefas.API.csproj", "src/"]
RUN dotnet restore "src/GerenciadorDeTarefas.API.csproj"

WORKDIR /src
COPY . .
RUN dotnet build "src/GerenciadorDeTarefas.API.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "src/GerenciadorDeTarefas.API.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY appsettings.Docker.json .  # Se houver configuração específica para o Docker
ENV ASPNETCORE_ENVIRONMENT=Docker
ENTRYPOINT ["dotnet", "GerenciadorDeTarefas.API.dll"]
