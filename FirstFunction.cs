using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Azure.ServiceBus;
using System.Threading.Tasks;
using System.Text;
using ServiceBusOutputFunction;
using System.Text.Json;

namespace AzureFunctions
{
    public class FirstFunction
    {
        private readonly IQueueClient _queueClient;

        public FirstFunction(IQueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        [FunctionName("FirstFunction")]
        public async Task Run(
            [CosmosDBTrigger(
                databaseName: "devdatabase",
                collectionName: "bankotcexchange-transfero-collection",
                ConnectionStringSetting= "connectionString",
                LeaseCollectionName = "leases",
                LeaseCollectionPrefix = "ServiceBusOutput-")]IReadOnlyList<Document> documents,
            ILogger log)
        {
            if (documents != null && documents.Count > 0)
            {
                foreach (Document document in documents)
                {
                    Car car = JsonSerializer.Deserialize<Car>(document.ToString());

                    if (car.Brand == "BMW")
                    {
                        log.LogInformation($"DocumentId: {document.Id}");
                        await SendMessageAsync(document.Id);
                    }
                }
            }

            return;
        }

        private async Task SendMessageAsync(string messageBody)
        {
            Message message = new Message(Encoding.UTF8.GetBytes(messageBody));
            await _queueClient.SendAsync(message);
        }
    }
}