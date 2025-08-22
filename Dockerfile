FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./src/EAMS.API/*.csproj ./EAMS.API/
COPY ./src/EAMS.Domain/*.csproj ./EAMS.Domain/
COPY ./src/EAMS.Infrastructure/*.csproj ./EAMS.Infrastructure/

RUN dotnet restore ./EAMS.API/EAMS.API.csproj

COPY ./src .
RUN dotnet publish EAMS.API/EAMS.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "EAMS.API.dll"]


