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
            var resp = _usuarioRepository.LoadByName(name).Result;
            MessageError = _usuarioRepository.Message;
            return resp;
        }

        public List<Usuario> LoadById(string id)
        {
            var resp = _usuarioRepository.LoadById(id).Result;
            MessageError = _usuarioRepository.Message;
            return resp;
        }

        public bool Save(Usuario user, string type)
        {
            var isCreated = false;
            MessageError = "";
            if (user.Login == null || user.Senha == null || user.TipoUsuario == null || user.Status == null)
            {
                MessageError = @"Verique os campos obrigatórios";
                return isCreated;
            }

            if (user.Login.Equals("") || user.Senha.Equals("") || user.TipoUsuario == "" ||
                user.Status == "")
            {
                MessageError = @"Verique os campos obrigatórios";
                return isCreated;
            }

            if (type.Equals("new"))
                isCreated = _usuarioRepository.Create(user).Result;
            else
            {
                var usuario = _usuarioRepository.Update(user).Result;
                if (usuario != null && !usuario.Id.Equals(""))
                    isCreated = true;
            }

            MessageError = _usuarioRepository.Message;
            return isCreated;
        }
    }
}