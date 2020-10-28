using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ServiceBusOutputBinding 
{
    [FunctionName("ServiceBusQueueTriggerCSharp")]
    public static void Run(
        [ServiceBusTrigger("myqueue", Connection = "ServiceBusConnection")]
            string myQueueItem,
                Int32 deliveryCount,
                DateTime enqueuedTimeUtc,
                string messageId,
                ILogger log)
    {
        log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
        log.LogInformation($"DeliveryCount={deliveryCount}");
        log.LogInformation($"MessageId={messageId}");
    }
}