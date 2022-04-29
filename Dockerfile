#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
EXPOSE 8086
WORKDIR /app

COPY MangoDbCoreApi_5.0.csproj .
RUN dotnet restore MangoDbCoreApi_5.0.csproj

COPY . . 
RUN dotnet publish  "MangoDbCoreApi_5.0.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "MangoDbCoreApi_5.0.dll"]