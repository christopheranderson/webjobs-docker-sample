# ASP.NET + Azure WebJobs SDK docker example

This is an example of how to host a ASP.NET site and an Azure WebJob in the same container. This is useful for when you want to run on Azure App Service Linux, as it has yet to provide out of the box WebJobs support. This sample uses an Azure WebJobs SDK sample, but this would work with any console application.

## Getting started locally

This assumes that you have docker and dotnet core 2.0 installed.

1. Clone the repo
2. Run `docker build -t webandwebjobs .`
3. Run `docker run -d --rm -p 80:80 -e "AzureWebJobsStorage=<REPLACETHIS>" -e "AzureWebJobsDashboard=<REPLACETHIS>" --name myapp webandwebjobs` with the "<REPLACETHIS>" tags replaced with your connections strings.
4. You should be able to see the "Hello world" response from your website now (for instance at 0.0.0.0).
5. If you add a queue message to your Storage Queue (default is `testqueue`, you should see it disappear
6. To access the logs, you can use an interactive bash session: `sudo docker exec -i -t myapp /bin/bash`. The logs are under `/app/logs`.

You can also set an Environment variable for `APPINSIGHTS_INSTRUMENTATIONKEY` and see some data flow up to App Insights. There is usally a latency of a few minutes, so be patient.

## Deploying to Azure App Service Linux

*TBD*

## LICENSE

[MIT](LICENSE)