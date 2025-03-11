FROM node:20-alpine AS development

WORKDIR /app

RUN npm install -g @angular/cli
COPY package*.json ./
RUN npm install

COPY . .

CMD ["ng", "serve", "--host", "0.0.0.0", "--port", "4200", "--disable-host-check", "--poll", "2000", "--watch"]

EXPOSE 4200
