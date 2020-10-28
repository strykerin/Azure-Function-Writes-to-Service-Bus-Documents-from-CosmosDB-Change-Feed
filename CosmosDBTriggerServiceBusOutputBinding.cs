using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctions
{
    public class ServiceBusOutputBinding
    {
        [FunctionName("ServiceBusQueueTriggerCSharp")]
        public static void Run([CosmosDBTrigger(
            databaseName: "devdatabase",
            collectionName: "bankotcexchange-transfero-collection",
            ConnectionStringSetting= "CosmosDBConnection",
            LeaseCollectionName = "leases",
            LeaseCollectionPrefix = "ServiceBusOutput-")]IReadOnlyList<Document> documents,
            ILogger log)
        {
        }
    }
}