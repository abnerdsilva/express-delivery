using Newtonsoft.Json;

namespace ExpressDelivery.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }
        public int Status { get; set; }
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