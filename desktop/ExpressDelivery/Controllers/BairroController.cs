using ExpressDelivery.Models;
using ExpressDelivery.Repository;
using System.Collections.Generic;

namespace ExpressDelivery.Controllers
{
    class BairroController
    {
        private readonly BairroRepository _bairroRepository = new BairroRepository();

        public string MessageError = "";

        public List<Bairro> LoadAll()
        {
            var resp = _bairroRepository.LoadAll();
            MessageError = _bairroRepository.Message;
            return resp;
        }

        public int Save(Bairro bairro, string type)
        {
            var result = _bairroRepository.Save(bairro, type);
            MessageError = _bairroRepository.Message;
            return result;
        }
    }
}
