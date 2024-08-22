#!/bin/sh

dotnet ef --version
dotnet ef database update --verbose --project $CSPROJ --context JobDbContext
dotnet ef database update --verbose --project $CSPROJ --context JobRangeContext --no-build

