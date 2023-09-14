FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS publish

COPY . /dotnet-app

RUN \
    cd /dotnet-app && \  
    dotnet restore "Sequence.Finder.Host/Sequence.Finder.Host.csproj" && \
    dotnet publish "Sequence.Finder.Host/Sequence.Finder.Host.csproj" --ignore-failed-sources --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sequence.Finder.Host.dll"]
ENV ENVIRONMENT=Development
CMD ["--environment=${ENVIRONMENT}"]