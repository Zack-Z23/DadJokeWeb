FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY DadJokeWeb/*.csproj ./DadJokeWeb/
RUN dotnet restore ./DadJokeWeb/DadJokeWeb.csproj

COPY . .
RUN dotnet publish DadJokeWeb/DadJokeWeb.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "DadJokeWeb.dll"]
