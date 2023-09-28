using ExpressDelivery.Models;
using ExpressDelivery.Repository;
using System.Collections.Generic;

namespace ExpressDelivery.Controllers
{
    class UsuarioController
    {
        private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();

        public string MessageError = "";

        public List<Usuario> LoadAll()
        {
            var resp = _usuarioRepository.LoadAll().Result;
            MessageError = _usuarioRepository.Message;
            return resp;
        }

        public List<Usuario> LoadByName(string name)
        {
            var resp = _usuarioRepository.LoadByName(name);
            MessageError = _usuarioRepository.Message;
            return resp;
        }

        public int LastUserId()
        {
            var resp = _usuarioRepository.LastUserId();
            MessageError = _usuarioRepository.Message;
            return resp;
        }

        public List<Usuario> LoadById(string id)
        {
            var resp = _usuarioRepository.LoadById(id);
            MessageError = _usuarioRepository.Message;
            return resp;
        }

        public int Save(Usuario user, string type)
        {
            var result = _usuarioRepository.Save(user, type);
            MessageError = _usuarioRepository.Message;
            return result;
        }
    }
}
