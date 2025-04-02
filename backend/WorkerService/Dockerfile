FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5196

ENV ASPNETCORE_URLS=http://+:5196

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["backend/WorkerService/WorkerService.csproj", "backend/WorkerService/"]
RUN dotnet restore "backend/WorkerService/WorkerService.csproj"
COPY . .
WORKDIR "/src/backend/WorkerService"
RUN dotnet build "WorkerService.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "WorkerService.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerService.dll"]
