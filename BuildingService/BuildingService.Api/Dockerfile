# Используем официальный образ .NET 8 SDK как базовый
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем CSPROJ файлы и восстанавливаем зависимости
COPY Common.Messages/Common.Messages/Common.Messages.csproj ./Common.Messages/
COPY BuildingService.Api/*.csproj ./BuildingService.Api/
COPY BuildingService.Application/*.csproj ./BuildingService.Application/
COPY BuildingService.Db/*.csproj ./BuildingService.Db/
COPY BuildingService.Domain/*.csproj ./BuildingService.Domain/
COPY BuildingService.Integrations/*.csproj ./BuildingService.Integrations/
COPY BuildingService.Repository/*.csproj ./BuildingService.Repository/
RUN dotnet restore BuildingService.Api/BuildingService.Api.csproj

# Копируем все файлы и публикуем проект
COPY . .
WORKDIR /app/BuildingService.Api
RUN dotnet publish -c Release -o out

# Создаем финальный образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/BuildingService.Api/out .
ENTRYPOINT ["dotnet", "BuildingService.Api.dll"]
