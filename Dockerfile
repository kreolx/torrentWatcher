FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build

RUN apt-get update && apt-get -f install && apt-get -y install wget gnupg2 apt-utils
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list' \
    && apt-get update \
    && apt-get install -y google-chrome-unstable --no-install-recommends \
    && rm -rf /var/lib/apt/lists/*
#####################
#END PUPPETEER RECIPE
#####################
ENV PUPPETEER_EXECUTABLE_PATH "/usr/bin/google-chrome-unstable"

WORKDIR /source

COPY ./publish .

ENTRYPOINT ["dotnet", "Host.dll"]