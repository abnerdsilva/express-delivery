using Newtonsoft.Json;

namespace ExpressDelivery.Models
{
    public class Error
    {
        [JsonProperty("error")]
        public string Erro { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}