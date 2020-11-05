using System;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;

namespace ServiceBusOutputFunction
{
    public class ThirdFunction
    {
        private readonly string _emailTo;
        private readonly string _emailFrom;
        private readonly IConfiguration _configuration;

        public ThirdFunction(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _emailTo = configuration["EmailTo"] ?? throw new ArgumentNullException(nameof(configuration));
            _emailFrom = configuration["EmailFrom"] ?? throw new ArgumentNullException(nameof(configuration));
        }

        [FunctionName("ThirdFunction")]
        public void Run([ServiceBusTrigger(topicName: "mytopic", 
                                                  subscriptionName: "S1", 
                                                  Connection = "ServiceBusConnection")] string message, 
                               [SendGrid(ApiKey = "SendGridKey")] ICollector<SendGridMessage> sender,
                               ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function is processing message: {message}");

            Car car = JsonSerializer.Deserialize<Car>(message);

            //var sendGridMessage = new SendGridMessage();
            //sendGridMessage.From = new EmailAddress(_emailFrom);
            //sendGridMessage.AddTo(email: _emailTo);
            //sendGridMessage.PlainTextContent = $"The car has {car.Wheels} wheels";
            //sendGridMessage.Subject = $"A new {car.Brand} car has arrived";

            //sender.Add(sendGridMessage);
            //return;
        }
    }
}
