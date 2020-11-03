# Azure-Function-Writes-to-Service-Bus-Documents-from-CosmosDB-Change-Feed

This repo contains two Azure Functions. The first function is triggered by the CosmosDB Change Feed and sends a message to a Azure Service Bus Queue. The second function is triggered by the Azure Service Bus and will send an email based on the information from the Queue.

## Azure Cosmos DB 
Azure Cosmos DB is a NoSQL database provided by Microsoft that has as its core feature performance. It is a globally-distributed and a multi-model database suited for highly responsive applications.

Azure Cosmos DB resouce model can be divided into the following hierarchy Account, Database, Container and Items.
* Account 
    * It's in the account that we manage the global distribution and availability of our database. It's the fundamental unit of scalability.
* Dabatase
    * For an account we can create multiple databases. A database is the unit for managing containers.
* Container
    * A database can have multiple containers. The items in a container are grouped based on the container's partition key and are distributed across the physical partitions.
* Item
    * In the case of the Cosmos DB SQL API (the one we'll be using in this repo), the item is a JSON document that will be stored in the container. 

## Azure Function
Functions are 


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

https://docs.microsoft.com/en-us/azure/cosmos-db/account-databases-containers-items