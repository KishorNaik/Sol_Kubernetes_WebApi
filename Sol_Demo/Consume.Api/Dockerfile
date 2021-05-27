#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Consume.Api/Consume.Api.csproj", "Consume.Api/"]
RUN dotnet restore "Consume.Api/Consume.Api.csproj"
COPY . .
WORKDIR "/src/Consume.Api"
RUN dotnet build "Consume.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Consume.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consume.Api.dll"]