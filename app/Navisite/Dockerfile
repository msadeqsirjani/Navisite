FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Navisite/Navisite.csproj", "Navisite/"]
RUN dotnet restore "Navisite/Navisite.csproj"
COPY . .
WORKDIR "/src/Navisite"
RUN dotnet build "Navisite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Navisite.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final 
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Navisite.dll"]