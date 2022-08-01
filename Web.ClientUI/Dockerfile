#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#
# Промежуточный образ для сборки Angular-приложения
#
# В результате получим папку 'ClientApp/dist' со всеми нужными файлами Angular
FROM node as build-node
# Создать в образе папку 'ClientApp' и перейти в неё
WORKDIR "/ClientApp" 
# Скопировать все файлы из папки 'ClientApp' проекта в папку 'ClientApp' образа   
COPY "Web.ClientUI/ClientApp" . 
# Подтянуть все npm-пакеты согласно 'package.json'    
RUN npm install 
# Сбилдить Angular-приложение в режиме 'production'        
RUN npm run build       

#
# Промежуточный образ для сборки ASP.NET Core приложения
#
# В результате получим папку 'src/publish' с опубликованным приложением, но без Angular-файлов
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# Установить значение переменной окружения 'CRISP_DOCKER_PUBLISH', чтобы проигнорировать команды подтягивания npm-пакетов при сборке,
# которые необходимы при публикации не в контейнер (см. .csproj файл)
ENV CRISP_DOCKER_PUBLISH=true
ENV ASPNETCORE_ENVIRONMENT=Production
# Создать в образе папку 'src' и перейти в неё
WORKDIR "/src" 
# Скопировать все файлы проекта в папку 'src' образа 
COPY "Core" "Core/"
COPY "Web.ClientUI" "Web.ClientUI/"
# Подтянуть все NuGet-пакеты                   
RUN dotnet restore "Web.ClientUI/Web.ClientUI.csproj" 
# Опубликовать ASP.NET Core приложение в папку 'src/publish' образа
RUN dotnet publish "Web.ClientUI/Web.ClientUI.csproj" -c Release -o "publish"
  
#
# Итоговый образ
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
## Создать в образе папку 'app' и перейти в неё
WORKDIR "/app"                      
# Скопировать в папку 'app' все файлы опубликованного ASP.NET Core приложения из промежуточного образа 'build'
COPY --from=build "src/publish" .
# Скопировать в папку 'app/wwwroot' все файлы Angular из промежуточного образа 'node-build'
COPY --from=build-node "ClientApp/dist" "wwwroot"
# Запуск ASP.NET Core приложения при запуске контейнера
ENTRYPOINT ["dotnet", "Web.ClientUI.dll"]
