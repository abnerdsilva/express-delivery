using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExpressDelivery.Models
{
    public class Pedido
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("codPedido")]
        public string CodPedido { get; set; }
        
        [JsonProperty("codCliente")]
        public string CodCliente { get; set; }
       
        [JsonProperty("nome")]
        public string Nome { get; set; }
        
        [JsonProperty("statusPedido")]
        public string StatusPedido { get; set; }
        
        [JsonProperty("dataPedido")]
        public DateTime DataPedido { get; set; }
        
        [JsonProperty("dataAtualizacao")]
        public DateTime? DataAtualizacao { get; set; }
        
        [JsonProperty("dataEntrega")]
        public DateTime? DataEntrega { get; set; }
        
        [JsonProperty("vrTotal")]
        public double VrTotal { get; set; }
        
        [JsonProperty("vrTaxa")]
        public double VrTaxa { get; set; }
        
        [JsonProperty("vrTroco")]
        public double VrTroco { get; set; }
        
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        
        [JsonProperty("numero")]
        public int Numero { get; set; }
        
        [JsonProperty("codUsuario")]
        public string IdOperador { get; set; }
        
        [JsonProperty("bairro")]
        public string Bairro { get; set; }
        
        [JsonProperty("cidade")]
        public string Cidade { get; set; }
       
        [JsonProperty("estado")]
        public string Estado { get; set; }
       
        [JsonProperty("cep")]
        public string CEP { get; set; }
       
        [JsonProperty("tipoPedido")]
        public string TipoPedido { get; set; }
       
        [JsonProperty("origem")]
        public string Origem { get; set; }
       
        [JsonProperty("observacao")]
        public string Observacao { get; set; }
       
        [JsonProperty("formaPagamento")]
        public string FormaPagamento { get; set; }
        
        [JsonProperty("cliente")]
        public Client Cliente { get; set; }
        
        [JsonProperty("itens")]
        public List<PedidoItem> Itens { get; set; }
    }

    public class PedidoItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("codPedido")]
        public string CodPedido { get; set; }
        
        [JsonProperty("codProduto")]
        public string CodProduto { get; set; }
        
        [JsonProperty("nome")]
        public string Nome { get; set; }
        
        [JsonProperty("quantidade")]
        public double Quantidade { get; set; }
        
        [JsonProperty("vrUnitario")]
        public double VrUnitario { get; set; }
        
        [JsonProperty("vrTotal")]
        public double VrTotal { get; set; }
        
        [JsonProperty("observacao")]
        public string Observacao { get; set; }
        
        [JsonProperty("statusEditar")]
        public int StatusEditar { get; set; }
    }
}