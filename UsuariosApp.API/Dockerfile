FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UsuariosApp.API/UsuariosApp.API.csproj", "UsuariosApp.API/"]
COPY ["UsuariosApp.Domain/UsuariosApp.Domain.csproj", "UsuariosApp.Domain/"]
COPY ["UsuariosApp.Infra.Data/UsuariosApp.Infra.Data.csproj", "UsuariosApp.Infra.Data/"]
RUN dotnet restore "UsuariosApp.API/UsuariosApp.API.csproj"
COPY . .
WORKDIR "/src/UsuariosApp.API"
RUN dotnet build "./UsuariosApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UsuariosApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsuariosApp.API.dll"]
