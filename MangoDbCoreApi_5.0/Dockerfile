#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MangoDbCoreApi_5.0/MangoDbCoreApi_5.csproj", "MangoDbCoreApi_5.0/"]
RUN dotnet restore "MangoDbCoreApi_5.0/MangoDbCoreApi_5.csproj"
COPY . .
WORKDIR "/src/MangoDbCoreApi_5.0"
RUN dotnet build "MangoDbCoreApi_5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MangoDbCoreApi_5.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MangoDbCoreApi_5.dll"]