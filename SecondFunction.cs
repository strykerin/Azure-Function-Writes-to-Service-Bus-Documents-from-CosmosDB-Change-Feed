using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctions
{
    public class SecondFunction
    {
        [FunctionName("ServiceBusQueueTriggerServiceBusTopicOutput")]
        public static void Run([ServiceBusTrigger("queue1", Connection = "ServiceBusConnection")] 
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
}