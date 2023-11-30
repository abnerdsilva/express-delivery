using System.Collections.Generic;
using System.Threading.Tasks;
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
            var products = _produtoRepository.LoadAll().Result;
            MessageError = _produtoRepository.Message;
            return products;
        }

        public List<Product> LoadByName(string name)
        {
            var products = _produtoRepository.LoadByName(name).Result;
            MessageError = _produtoRepository.Message;
            return products;
        }

        public List<Product> LoadById(string name)
        {
            var products = _produtoRepository.LoadById(name).Result;
            MessageError = _produtoRepository.Message;
            return products;
        }

        public Product LastProductId()
        {
            return _produtoRepository.LastProductId().Result;
        }

        public async Task<Product> Save(Product product, string type)
        {
            Product item;
            if (type.Equals("new"))
                item = _produtoRepository.Create(product).Result;
            else
                item = await _produtoRepository.Update(product);

            MessageError = _produtoRepository.Message;
            return item;
        }
    }
}