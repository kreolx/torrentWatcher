#!/bin/sh

dotnet ef --version
dotnet ef database update --verbose --project src/Host/Host.csproj --context ApplicationDbContext

