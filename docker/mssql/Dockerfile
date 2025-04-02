FROM mcr.microsoft.com/mssql/server:2022-latest

# Set the user to root to allow to create directories and set permissions
USER root

# Create a config directory
RUN mkdir -p /usr/config
WORKDIR /usr/config

# Bundle config source
COPY . /usr/config

# Grant permissions for to our scripts to be executable
RUN chmod +x /usr/config/entrypoint.sh
RUN chmod +x /usr/config/configure-db.sh

# return to the mssql user
USER mssql

ENTRYPOINT ["./entrypoint.sh"]