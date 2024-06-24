FROM node:latest as node
WORKDIR /app
COPY ITProjectPriceCalculationManager.WebApp/ .
RUN npm install --force
RUN npm run build --prod

FROM nginx:latest
COPY ITProjectPriceCalculationManager.WebApp/nginx.conf /etc/nginx/nginx.conf
COPY --from=node /app/dist/angular-app/browser /usr/share/nginx/html