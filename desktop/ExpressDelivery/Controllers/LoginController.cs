using System;
using System.Threading.Tasks;
using ExpressDelivery.Models;
using ExpressDelivery.Repository;

namespace ExpressDelivery.Controllers
{
    public class LoginController
    {
        public bool Status;
        public string Message = "";

        public async Task<Usuario> Acessar(string login, string password)
        {
            try
            {
                LoginRepository loginDao = new LoginRepository();
                var usuario = await loginDao.Login(login, password);
                if (!loginDao.Message.Equals("") && !loginDao.Status)
                {
                    Message = "Usuário e/ou senha inválido";
                    return null;
                }

                Status = true;
                return usuario;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return null;
            }
        }
    }
}