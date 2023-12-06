using System;
using System.Threading.Tasks;
using ExpressDelivery.Models;
using ExpressDelivery.Repository;

namespace ExpressDelivery.Controllers
{
    public class LoginController
    {
        private readonly LoginRepository _loginRepository = new LoginRepository();
        
        public bool Status;
        public string Message = "";

        public async Task<Usuario> Acessar(string login, string password)
        {
            Message = "";
            try
            {
                var usuario = await _loginRepository.Login(login, password);
                if (!_loginRepository.Message.Equals("") && !_loginRepository.Status)
                {
                    Message = "Usuário e/ou senha inválido";
                    GeraLog.PrintError(Message);
                    return null;
                }

                Status = true;
                return usuario;
            }
            catch (Exception e)
            {
                GeraLog.PrintError(e.Message);
                Message = e.Message;
                return null;
            }
        }
    }
}