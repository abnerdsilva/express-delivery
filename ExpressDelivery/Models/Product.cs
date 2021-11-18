namespace ExpressDelivery.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string CodBarras { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Localizacao { get; set; }
        public double PrecoCompra { get; set; }
        public double PrecoVenda { get; set; }
        public double MargemLucro { get; set; }
        public string UnMedida { get; set; }
        public string Observacao { get; set; }
    }
}