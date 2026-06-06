FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/NttApp.Api/NttApp.Api.csproj", "src/NttApp.Api/"]
COPY ["src/NttApp.Domain/NttApp.Domain.csproj", "src/NttApp.Domain/"]
COPY ["src/NttApp.InMemoryDb/NttApp.InMemoryDb.csproj", "src/NttApp.InMemoryDb/"]
RUN dotnet restore "src/NttApp.Api/NttApp.Api.csproj"
COPY . .
WORKDIR "/src/src/NttApp.Api"
RUN dotnet build "./NttApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./NttApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NttApp.Api.dll"]
