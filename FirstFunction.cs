using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.ServiceBus;

namespace AzureFunctions
{
    public class FirstFunction
    {
        [FunctionName("ServiceBusQueueTriggerCSharp")]
        [return: ServiceBus(queueOrTopicName: "queue1", 
                            entityType: EntityType.Queue, 
                            Connection = "ServiceBusConnection")]
        public static string Run([CosmosDBTrigger(
            databaseName: "devdatabase",
            collectionName: "bankotcexchange-transfero-collection",
            ConnectionStringSetting= "CosmosDBConnection",
            LeaseCollectionName = "leases",
            LeaseCollectionPrefix = "ServiceBusOutput-")]IReadOnlyList<Document> documents,
            ILogger log)
        {
            if (documents != null && documents.Count > 0)
            {
                foreach (Document document in documents)
                {
                    log.LogInformation($"DocumentId: {document.Id}");
                }
            }

            return documents[0].Id;
        }
    }
}