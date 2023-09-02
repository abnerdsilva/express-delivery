using System.Collections.Generic;
using ExpressDelivery.Models;
using ExpressDelivery.Repository;

namespace ExpressDelivery.Controllers
{
    public class ProdutoController
    {
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();

        public string MessageError = "";

        public List<Product> LoadAll()
        {
            var products = _produtoRepository.LoadAll();
            MessageError = _produtoRepository.Message;
            return products;
        }

        public List<Product> LoadByName(string name)
        {
            var products = _produtoRepository.LoadByName(name);
            MessageError = _produtoRepository.Message;
            return products;
        }

        public List<Product> LoadById(string name)
        {
            var products = _produtoRepository.LoadById(name);
            MessageError = _produtoRepository.Message;
            return products;
        }
        
        public int LastProductId()
        {
            return _produtoRepository.LastProductId();
        }
        
        public void Save(Product product, string type)
        {
            _produtoRepository.Save(product, type);
            MessageError = _produtoRepository.Message;
        }
    }
}