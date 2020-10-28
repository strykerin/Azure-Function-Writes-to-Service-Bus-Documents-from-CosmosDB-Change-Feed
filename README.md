# Azure-Function-Writes-to-Service-Bus-Documents-from-CosmosDB-Change-Feed

This repo contains two Azure Functions. One function is triggered by the CosmosDB Change Feed and the other is triggered by the Azure Service Bus.

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