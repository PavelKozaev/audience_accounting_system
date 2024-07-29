# Используем официальный образ .NET 8 SDK как базовый
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем CSPROJ файлы и восстанавливаем зависимости
COPY Common.Messages/Common.Messages/Common.Messages.csproj ./Common.Messages/
COPY AudienceService.Api/*.csproj ./AudienceService.Api/
COPY AudienceService.Application/*.csproj ./AudienceService.Application/
COPY AudienceService.Db/*.csproj ./AudienceService.Db/
COPY AudienceService.Domain/*.csproj ./AudienceService.Domain/
COPY AudienceService.Integrations/*.csproj ./AudienceService.Integrations/
COPY AudienceService.Repository/*.csproj ./AudienceService.Repository/
RUN dotnet restore AudienceService.Api/AudienceService.Api.csproj

# Копируем все файлы и публикуем проект
COPY . .
WORKDIR /app/AudienceService.Api
RUN dotnet publish -c Release -o out

# Создаем финальный образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/AudienceService.Api/out .
ENTRYPOINT ["dotnet", "AudienceService.Api.dll"]
