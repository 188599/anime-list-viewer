# Use the node image from official Docker Hub
FROM node:22-alpine AS build-stage
# set the working directory
WORKDIR /app

# Copy the working directory in the container
COPY frontend/package*.json ./
# Install the project dependencies
RUN npm install

# Copy the rest of the project files to the container
COPY frontend .
# Build the Vue.js application to the production mode to dist folder
RUN npm run build
# Use the lightweight Nginx image from the previous stage for the nginx container
FROM nginx:stable-alpine AS production-stage
# Copy the build application from the previous stage to the Nginx container
COPY --from=build-stage /app/dist /usr/share/nginx/html/
# Copy the nginx configuration file
COPY docker/nginx/default.conf /etc/nginx/conf.d/default.conf
# Expose the port 80
EXPOSE 80

COPY docker/nginx/variables.conf.template /etc/nginx/templates/10-variables.conf.template

# COPY docker/nginx/entrypoint.sh /docker-entrypoint.d
# RUN chmod +x /docker-entrypoint.d/entrypoint.sh

# RUN apk add --no-cache gettext

# WORKDIR /app

# Start Nginx to serve the application
CMD ["nginx", "-g", "daemon off;"]
