FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./src/AMS.API/*.csproj ./AMS.API/
COPY ./src/AMS.Core/*.csproj ./AMS.Core/
COPY ./src/AMS.Infrastructure/*.csproj ./AMS.Infrastructure/

RUN dotnet restore ./AMS.API/AMS.API.csproj

COPY ./src .
RUN dotnet publish AMS.API/AMS.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "AMS.API.dll"]

