FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ITProjectPriceCalculationManager.ITProjectsManager.API/", "ITProjectPriceCalculationManager.ITProjectsManager.API/"]
COPY ["ITProjectPriceCalculationManager.DTOModels/ITProjectPriceCalculationManager.DTOModels.csproj", "ITProjectPriceCalculationManager.DTOModels/"]
COPY ["ITProjectPriceCalculationManager.Extentions/ITProjectPriceCalculationManager.Extentions.csproj", "ITProjectPriceCalculationManager.Extentions/"]
COPY ["ITProjectPriceCalculationManager.Infrastructure/ITProjectPriceCalculationManager.Infrastructure.csproj", "ITProjectPriceCalculationManager.Infrastructure/"]
RUN dotnet restore "ITProjectPriceCalculationManager.ITProjectsManager.API/ITProjectPriceCalculationManager.ITProjectsManager.API.csproj"
COPY . .
WORKDIR "/src/ITProjectPriceCalculationManager.ITProjectsManager.API"
RUN dotnet build "ITProjectPriceCalculationManager.ITProjectsManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITProjectPriceCalculationManager.ITProjectsManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:80
ENTRYPOINT ["dotnet", "ITProjectPriceCalculationManager.ITProjectsManager.API.dll"]