# Azure-Function-Writes-to-Service-Bus-Documents-from-CosmosDB-Change-Feed

This repo contains two Azure Functions. The first function is triggered by the CosmosDB Change Feed and sends a message to a Azure Service Bus Queue. The second function is triggered by the Azure Service Bus and will write the message information on the console.

## Azure Cosmos DB 
Azure Cosmos DB is a NoSQL database provided by Microsoft that has as its core feature performance. It is a globally-distributed and a multi-model database suited for highly responsive applications.

Azure Cosmos DB resouce model can be divided into: 
- Accounts
- Dabatases 
- Containers 
- Items



## Steps
### 1st: 

Create the Azure Function project by using the following command:

`func init ServiceBusOutputFunction`

### 2nd:

Donwload the Nuget package for the Azure Service Bus: 

`dotnet add package Microsoft.Azure.WebJobs.Extensions.ServiceBus --version 4.2.0`

### 3rd:

Download the Nuget package for the CosmosDB:

`dotnet add package Microsoft.Azure.WebJobs.Extensions.CosmosDB --version 3.0.7`

## Reference
https://docs.microsoft.com/en-us/azure/cosmos-db/introduction