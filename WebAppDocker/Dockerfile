FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./_.nuget.org.crt /etc/ssl/certs
COPY ./NuGet.Config ./
COPY . ./
RUN dotnet restore --interactive --configfile NuGet.Config
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish  -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppDocker.dll"]