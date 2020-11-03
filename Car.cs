using System.Text.Json.Serialization;

namespace ServiceBusOutputFunction
{
    public class Car
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        public string Brand { get; set; }
        public int Wheels { get; set; }
    }
}
