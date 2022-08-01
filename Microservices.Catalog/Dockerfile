FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ENV ASPNETCORE_ENVIRONMENT=Production
WORKDIR "/src" 
COPY "Microservices.Catalog" "Catalog/"
COPY "Core" "Core/"
RUN dotnet restore "Catalog/Microservices.Catalog.csproj" 
RUN dotnet publish "Catalog/Microservices.Catalog.csproj" -c Release -o "publish"
  
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR "/app"                      
COPY --from=build "src/publish" .
ENTRYPOINT ["dotnet", "Microservices.Catalog.dll"]
