# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /FrameWorkTeste/Framework.Teste.Api
COPY . .
RUN dotnet restore "Framework.Teste.Api/Framework.Teste.Api.csproj"
WORKDIR /FrameWorkTeste/Framework.Teste.Api
RUN dotnet build "Framework.Teste.Api/Framework.Teste.Api.csproj" -c Release -o /app

FROM build AS publish
WORKDIR /FrameWorkTeste/Framework.Teste.Api
RUN dotnet publish "Framework.Teste.Api/Framework.Teste.Api.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Framework.Teste.Api.dll"]