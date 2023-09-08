using System;
using System.Collections.Generic;

namespace ExpressDelivery.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int CodCliente { get; set; }
        public string Nome { get; set; }
        public string StatusPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public double VrTotal { get; set; }
        public double VrTaxa { get; set; }
        public double VrTroco { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string IdOperador { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string TipoPedido { get; set; }
        public string Origem { get; set; }
        public string Observacao { get; set; }
        public string FormaPagamento { get; set; }
        public List<PedidoItem> Itens { get; set; }
    }

    public class PedidoItem
    {
        public int Id { get; set; }
        public int CodPedido { get; set; }
        public string CodProduto { get; set; }
        public string Nome { get; set; }
        public double Quantidade { get; set; }
        public double VrUnitario { get; set; }
        public double VrTotal { get; set; }
        public string Observacao { get; set; }
        public int StatusEditar { get; set; }
    }
}