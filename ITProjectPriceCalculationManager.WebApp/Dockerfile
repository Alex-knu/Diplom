FROM node:16.18.1-alpine3.15 as node
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod

FROM nginx:alpine
COPY --from=node /app/dist/angular-app /usr/share/nginx/html