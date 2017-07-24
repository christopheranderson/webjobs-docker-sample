using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace Sample.WebJob
{
    public class Jobs
    {
        public static void ListenOnQueue([QueueTrigger("testqueue")] string message, TraceWriter log)
        {
            log.Info($"Hello {message}");
        }
    }
}