using System.Collections.Generic;
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
        
        public List<Pedido> LoadAll()
        {
            var resp = _pedidoRepository.LoadAll();
            MessageError = _pedidoRepository.Message;
            return resp;
        }
        
        public List<Pedido> LoadByCode(int code, string status)
        {
            var resp = _pedidoRepository.LoadByCode(code, status);
            MessageError = _pedidoRepository.Message;
            return resp;
        }
        
        public List<Pedido> LoadByDate(string inicio, string fim)
        {
            var resp = _pedidoRepository.LoadByDate(inicio, fim);
            MessageError = _pedidoRepository.Message;
            return resp;
        }
        
        public int SaveOrder(Pedido order, string type)
        {
            var resp = _pedidoRepository.SaveOrder(order, type);
            MessageError = _pedidoRepository.Message;
            return resp;
        }
        
        public int UpdateOrder(string status, int id)
        {
            var resp = _pedidoRepository.UpdateOrder(status, id);
            MessageError = _pedidoRepository.Message;
            return resp;
        }
    }
}