using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctions
{
    public class CosmosDBTriggerServiceBusOutputBinding
    {
        [FunctionName("ServiceBusQueueTriggerCSharp")]
        [return: ServiceBus("queue1", Connection = "ServiceBusConnection")]
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