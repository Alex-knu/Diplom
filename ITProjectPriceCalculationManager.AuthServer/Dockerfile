FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ITProjectPriceCalculationManager.AuthServer/ITProjectPriceCalculationManager.AuthServer.csproj", "ITProjectPriceCalculationManager.AuthServer/"]
COPY ["ITProjectPriceCalculationManager.Extentions/ITProjectPriceCalculationManager.Extentions.csproj", "ITProjectPriceCalculationManager.Extentions/"]
RUN dotnet restore "ITProjectPriceCalculationManager.AuthServer/ITProjectPriceCalculationManager.AuthServer.csproj"
COPY . .
WORKDIR "/src/ITProjectPriceCalculationManager.AuthServer"
RUN dotnet build "ITProjectPriceCalculationManager.AuthServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ITProjectPriceCalculationManager.AuthServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ITProjectPriceCalculationManager.AuthServer.dll"]