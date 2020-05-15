#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
COPY ./ /app/
RUN dotnet restore "CherryPeakTrading.WorkerService"
RUN dotnet publish "CherryPeakTrading.WorkerService" -c Release -o publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CherryPeakTrading.WorkerService.dll"]
