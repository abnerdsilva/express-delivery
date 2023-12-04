using System;
using System.Collections.Generic;
using ExpressDelivery.Models;
using ExpressDelivery.Repository;

namespace ExpressDelivery.Controllers
{
    public class PedidoController
    {
        private readonly PedidoRepository _pedidoRepository = new PedidoRepository();

        public string MessageError = "";

        public Pedido LoadLastOrderId()
        {
            try
            {
                var resp = _pedidoRepository.LoadLastOrderId().Result;
                MessageError = _pedidoRepository.Message;
                return resp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageError = e.Message;
                throw;
            }
        }

        public List<Pedido> LoadAll()
        {
            MessageError = "";
            var resp = _pedidoRepository.LoadAll().Result;
            MessageError = _pedidoRepository.Message;
            return resp;
        }

        public List<Pedido> LoadByCode(int code, string status)
        {
            MessageError = "";
            var resp = _pedidoRepository.LoadByCode(code, status).Result;
            MessageError = _pedidoRepository.Message;
            return resp;
        }

        public List<Pedido> LoadByDate(string inicio, string fim, string status)
        {
            var resp = _pedidoRepository.LoadByDate(inicio, fim, status).Result;
            MessageError = _pedidoRepository.Message;
            return resp;
        }

        public string LoadPedidosAberto()
        {
            var resp = _pedidoRepository.LoadPedidosAbertosIntegracao().Result;
            MessageError = _pedidoRepository.Message;
            return resp;
        }

        public int SaveOrder(Pedido order, string type)
        {
            int resp;
            if (type.Equals("new"))
                resp = _pedidoRepository.SaveOrder(order, type).Result;
            else
                resp = _pedidoRepository.UpdateOrder(order).Result;
            MessageError = _pedidoRepository.Message;
            return resp;
        }

        public int UpdateStatusOrder(string code)
        {
            var resp = _pedidoRepository.UpdateStatusOrder(code).Result;
            MessageError = _pedidoRepository.Message;
            return resp;
        }

        public int CancelOrder(string code)
        {
            var resp = _pedidoRepository.CancelOrder(code).Result;
            MessageError = _pedidoRepository.Message;
            return resp;
        }
    }
}