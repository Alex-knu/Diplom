FROM node:latest as node
WORKDIR /app
COPY ITProjectPriceCalculationManager.WebApp/ .
RUN npm install
RUN npm run build --prod

FROM nginx:latest
COPY --from=node /app/dist/angular-app /usr/share/nginx/html