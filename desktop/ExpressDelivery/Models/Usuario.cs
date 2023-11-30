using Newtonsoft.Json;

namespace ExpressDelivery.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        
        [JsonProperty("username")]
        public string Login { get; set; }
        
        [JsonProperty("currentPassword")]
        public string SenhaAtual { get; set; }
        
        [JsonProperty("password")]
        public string Senha { get; set; }
        
        [JsonProperty("type")]
        public string TipoUsuario { get; set; }
        
        [JsonProperty("status")]
        public string Status { get; set; }
    }
    
    public class LoginUsuario
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        
        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class TokenLogin
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}