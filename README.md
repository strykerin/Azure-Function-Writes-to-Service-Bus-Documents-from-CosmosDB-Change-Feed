# Azure-Function-Writes-to-Service-Bus-Documents-from-CosmosDB-Change-Feed

1st: 

func init ServiceBusOutputFunction

2nd:

Serve Bus Nuget Package
dotnet add package Microsoft.Azure.WebJobs.Extensions.ServiceBus --version 4.2.0

3rd:

CosmosDB Nuget Package
dotnet add package Microsoft.Azure.WebJobs.Extensions.CosmosDB --version 3.0.7