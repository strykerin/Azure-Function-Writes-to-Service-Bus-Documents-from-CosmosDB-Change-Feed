using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ServiceBusOutputFunction;

namespace AzureFunctions
{
    public class SecondFunction
    {
        private readonly ITopicClient _topicClient;

        public SecondFunction(ITopicClient topicClient)
        {
            _topicClient = topicClient;
        }

        [FunctionName("SecondFunction")]
        public async Task Run(
            [ServiceBusTrigger(queueName: "queue1", Connection = "ServiceBusConnection")] 
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

            // Send string to Topic
            Car car = JsonSerializer.Deserialize<Car>(myQueueItem);
            if (car?.Wheels == 4)
            {
                await SendMessageEmailLabelAsync(myQueueItem);
            }
        }

        private async Task SendMessageEmailLabelAsync(string messageBody)
        {
            Message message = new Message(Encoding.UTF8.GetBytes(messageBody));
            message.Label = "Email";
            await _topicClient.SendAsync(message);
        }
    }
}