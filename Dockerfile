#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["BasketApp.ServiceHost.Api/BasketApp.ServiceHost.Api.csproj", "BasketApp.ServiceHost.Api/"]
COPY ["BasketApp.Data/BasketApp.Data.csproj", "BasketApp.Data/"]
COPY ["BasketApp.Core/BasketApp.Core.csproj", "BasketApp.Core/"]
COPY ["BasketApp.Service/BasketApp.Service.csproj", "BasketApp.Service/"]
RUN dotnet restore "BasketApp.ServiceHost.Api/BasketApp.ServiceHost.Api.csproj"
COPY . .
WORKDIR "/src/BasketApp.ServiceHost.Api"
RUN dotnet build "BasketApp.ServiceHost.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasketApp.ServiceHost.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasketApp.ServiceHost.Api.dll"]