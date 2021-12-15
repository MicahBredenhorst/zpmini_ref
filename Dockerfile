FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ZPMini/ZPMini.API.csproj", "ZPMini/"]
COPY ["ZPMini.Data/ZPMini.Data.csproj", "ZPMini.Data/"]
COPY ["ZPMini.Logic/ZPMini.Logic.csproj", "ZPMini.Logic/"]
COPY ["ZPMini.Factory/ZPMini.Factory.csproj", "ZPMini.Factory/"]
RUN dotnet restore "ZPMini/ZPMini.API.csproj"
COPY . .
WORKDIR "/src/ZPMini"
RUN dotnet build "ZPMini.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZPMini.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZPMini.API.dll"]