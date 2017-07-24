FROM microsoft/aspnetcore:2.0.0-preview2

WORKDIR /app

#supervisor to manage multiple processes
RUN apt-get update && apt-get install -y supervisor
RUN mkdir -p /var/log/supervisor
COPY supervisord.conf ./
COPY startup.sh ./
RUN mkdir -p /app/log/web && touch /app/log/web/web.log
RUN mkdir -p /app/log/webjob && touch /app/log/webjob/webjob.log

# Bring in projects
COPY ./src/Sample.WebApp/out ./web
COPY ./src/Sample.WebJob/out ./webjob

# Setting both of these for now
ENV PORT 8080
ENV ASPNETCORE_URLS http://*:8080

ENTRYPOINT ["/app/startup.sh"]