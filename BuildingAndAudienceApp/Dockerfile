# Используем официальный образ Node.js
FROM node:18 AS build

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем package.json и package-lock.json и устанавливаем зависимости
COPY package*.json ./
RUN npm install

# Копируем все файлы и собираем приложение
COPY . .
RUN npm run build --prod

# Используем официальный образ Nginx для сервировки статики
FROM nginx:alpine
COPY --from=build /app/dist/ /usr/share/nginx/html

# Открываем порт 80
EXPOSE 80
