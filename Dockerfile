FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
WORKDIR /source

COPY *.sln .
COPY src/*.csproj./ ./src
RUN dotnet restore

COPY src/. /src
WORKDIR /source/src
RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Host.dll"]