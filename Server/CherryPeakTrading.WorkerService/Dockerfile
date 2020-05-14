#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Server/CherryPeakTrading.WorkerService/CherryPeakTrading.WorkerService.csproj", "Server/CherryPeakTrading.WorkerService/"]
RUN dotnet restore "Server/CherryPeakTrading.WorkerService/CherryPeakTrading.WorkerService.csproj"
COPY . .
WORKDIR "/src/Server/CherryPeakTrading.WorkerService"
RUN dotnet build "CherryPeakTrading.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CherryPeakTrading.WorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CherryPeakTrading.WorkerService.dll"]