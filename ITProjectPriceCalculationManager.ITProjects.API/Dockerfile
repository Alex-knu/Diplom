FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ITProjectPriceCalculationManager.ITProjects.API/ITProjectPriceCalculationManager.ITProjects.API.csproj", "ITProjectPriceCalculationManager.ITProjects.API/"]
COPY ["ITProjectPriceCalculationManager.CoreModels/ITProjectPriceCalculationManager.CoreModels.csproj", "ITProjectPriceCalculationManager.CoreModels/"]
COPY ["ITProjectPriceCalculationManager.DTOModels/ITProjectPriceCalculationManager.DTOModels.csproj", "ITProjectPriceCalculationManager.DTOModels/"]
COPY ["ITProjectPriceCalculationManager.Core/ITProjectPriceCalculationManager.Core.csproj", "ITProjectPriceCalculationManager.Core/"]
RUN dotnet restore "ITProjectPriceCalculationManager.ITProjects.API/ITProjectPriceCalculationManager.ITProjects.API.csproj"
COPY . .
WORKDIR "/src/ITProjectPriceCalculationManager.ITProjects.API"
RUN dotnet build "ITProjectPriceCalculationManager.ITProjects.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITProjectPriceCalculationManager.ITProjects.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ITProjectPriceCalculationManager.ITProjects.API.dll"]