using Newtonsoft.Json;

namespace ExpressDelivery.Models
{
    public class Product
    {
        [JsonProperty("codProduto")]
        public string Uid { get; set; }
        
        [JsonProperty("statusProduto")]
        public int Status { get; set; }
       
        [JsonProperty("codBarras")]
        public string CodBarras { get; set; }
        
        [JsonProperty("nome")]
        public string Descricao { get; set; }
      
        [JsonProperty("categoria")]
        public string Categoria { get; set; }
        
        [JsonProperty("localizacao")]
        public string Localizacao { get; set; }
       
        [JsonProperty("vrCompra")]
        public double PrecoCompra { get; set; }
        
        [JsonProperty("vrUnitario")]
        public double PrecoVenda { get; set; }
        
        [JsonProperty("margemLucro")]
        public double MargemLucro { get; set; }
        
        [JsonProperty("unMedida")]
        public string UnMedida { get; set; }
        
        [JsonProperty("observacao")]
        public string Observacao { get; set; }
    }
}