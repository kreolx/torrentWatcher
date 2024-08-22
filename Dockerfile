FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build
WORKDIR /source

COPY ./publish .

ENTRYPOINT ["dotnet", "Host.dll"]