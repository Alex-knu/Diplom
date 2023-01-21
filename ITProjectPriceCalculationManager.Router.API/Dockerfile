FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ITProjectPriceCalculationManager.Router.API/ITProjectPriceCalculationManager.Router.API.csproj", "ITProjectPriceCalculationManager.Router.API/"]
COPY ["ITProjectPriceCalculationManager.DTOModels/ITProjectPriceCalculationManager.DTOModels.csproj", "ITProjectPriceCalculationManager.DTOModels/"]
RUN dotnet restore "ITProjectPriceCalculationManager.Router.API/ITProjectPriceCalculationManager.Router.API.csproj"
COPY . .
WORKDIR "/src/ITProjectPriceCalculationManager.Router.API"
RUN dotnet build "ITProjectPriceCalculationManager.Router.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITProjectPriceCalculationManager.Router.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ITProjectPriceCalculationManager.Router.API.dll"]