FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

# restore and build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . /src/Navisite
RUN dotnet restore "Navisite/Navisite.csproj"
WORKDIR "/src/Navisite"
RUN dotnet build "Navisite.csproj" -c Release -o /app/build

# publish stage
FROM build AS publish
RUN dotnet publish "Navisite.csproj" -c Release -o /app/publish /p:UseAppHost=false

EXPOSE 5240
EXPOSE 5241

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Navisite.dll"]