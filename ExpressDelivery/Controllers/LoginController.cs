using ExpressDelivery.Models;
using ExpressDelivery.Repository;

namespace ExpressDelivery.Controllers
{
    public class LoginController
    {
        public bool Status;
        public string Message = "";
        
        public Usuario Acessar(string login, string password)
        {
            LoginRepository loginDao = new LoginRepository();
            var usuario = loginDao.VerificaLogin(login, password);
            if (loginDao.Message.Equals("") && loginDao.Status)
            {
                Status = true;
                return usuario;
            }

            Message = loginDao.Message;
            return null;
        }
    }
}