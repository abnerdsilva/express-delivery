using ExpressDelivery.Models;
using ExpressDelivery.Repository;

namespace ExpressDelivery.Controllers
{
    public class PedidoController
    {
        private readonly PedidoRepository _pedidoRepository = new PedidoRepository();

        public string MessageError = "";

        public int LoadLastOrderId()
        {
            var resp = _pedidoRepository.LoadLastOrderId();
            MessageError = _pedidoRepository.Message;
            return resp;
        }
        
        public int SaveOrder(Pedido order, string type)
        {
            var resp = _pedidoRepository.SaveOrder(order, type);
            MessageError = _pedidoRepository.Message;
            return resp;
        }
    }
}