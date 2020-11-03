using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace AzureFunctions
{
    public class FirstFunction
    {
        [FunctionName("FirstFunction")]
        public static void Run(
            [CosmosDBTrigger(
                databaseName: "devdatabase",
                collectionName: "bankotcexchange-transfero-collection",
                ConnectionStringSetting= "connectionString",
                LeaseCollectionName = "leases",
                LeaseCollectionPrefix = "ServiceBusOutput-")]IReadOnlyList<Document> documents,
            [ServiceBus(queueOrTopicName: "queue1", 
                        entityType: EntityType.Queue, 
                        Connection = "ServiceBusConnection")] IAsyncCollector<string> output,
            ILogger log)
        {
            if (documents != null && documents.Count > 0)
            {
                foreach (Document document in documents)
                {
                    log.LogInformation($"DocumentId: {document.Id}");
                    output.AddAsync(document.Id);
                }
            }

            return;
        }
    }
}