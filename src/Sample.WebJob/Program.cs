using System;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Logging;

namespace Sample.WebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Host starting up");

            Console.WriteLine(String.Join(", ", args));

            JobHostConfiguration config = new JobHostConfiguration();
            config.UseTimers();
            
            if(config.IsDevelopment) {
                config.UseDevelopmentSettings();
            } 

            CheckAndEnableAppInsights(config);

            JobHost host = new JobHost(config);
            host.RunAndBlock();
        }

        private static void CheckAndEnableAppInsights(JobHostConfiguration config)
        {
            // If AppInsights is enabled, build up a LoggerFactory
            string instrumentationKey = Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY");
            if (!string.IsNullOrEmpty(instrumentationKey))
            {
                config.DashboardConnectionString = null;

                var filter = new LogCategoryFilter();
                filter.DefaultLevel = LogLevel.Debug;
                filter.CategoryLevels[LogCategories.Function] = LogLevel.Debug;
                filter.CategoryLevels[LogCategories.Results] = LogLevel.Debug;
                filter.CategoryLevels[LogCategories.Aggregator] = LogLevel.Debug;
                filter.CategoryLevels[LogCategories.Startup] = LogLevel.Debug;

                config.LoggerFactory = new LoggerFactory()
                    .AddApplicationInsights(instrumentationKey, filter.Filter)
                    .AddConsole(filter.Filter);
            }
        }
    }
}
