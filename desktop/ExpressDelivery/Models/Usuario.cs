namespace ExpressDelivery.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }
        public int Status { get; set; }
    }
}