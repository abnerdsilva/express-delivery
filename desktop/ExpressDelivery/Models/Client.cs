using Newtonsoft.Json;

namespace ExpressDelivery.Models
{
    public class Client
    {
        [JsonProperty("codCliente")]
        public string Id { get; set; }
       
        [JsonProperty("statusCliente")]
        public int Status { get; set; }
        
        [JsonProperty("nome")]
        public string Nome { get; set; }
        
        [JsonProperty("cpf")]
        public string CPF { get; set; }
        
        [JsonProperty("rg")]
        public string RG { get; set; }

        [JsonProperty("logradouro")]
        public string Endereco { get; set; }
        
        [JsonProperty("numero")]
        public int Numero { get; set; }
        
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        
        [JsonProperty("cidade")]
        public string Cidade { get; set; }
        
        [JsonProperty("estado")]
        public string Estado { get; set; }
        
        [JsonProperty("cep")]
        public string CEP { get; set; }
        
        [JsonProperty("telefone")]
        public string Telefone { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("observacao")]
        public string Observacao { get; set; }
    }
}