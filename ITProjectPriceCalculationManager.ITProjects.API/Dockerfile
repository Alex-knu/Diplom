FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ITProjectPriceCalculationManager.ITProjects.API.csproj", "ITProjectPriceCalculationManager.ITProjects.API/"]
#COPY ["ITProjectPriceCalculationManager.Infrastructure/ITProjectPriceCalculationManager.Infrastructure.csproj", "ITProjectPriceCalculationManager.Infrastructure/"]
#COPY ["ITProjectPriceCalculationManager.Core/ITProjectPriceCalculationManager.Core.csproj", "ITProjectPriceCalculationManager.Core/"]
RUN dotnet restore "ITProjectPriceCalculationManager.ITProjects.API/ITProjectPriceCalculationManager.ITProjects.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ITProjectPriceCalculationManager.ITProjects.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITProjectPriceCalculationManager.ITProjects.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ITProjectPriceCalculationManager.ITProjects.API.dll"]