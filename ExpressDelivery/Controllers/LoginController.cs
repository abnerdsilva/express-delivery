using ExpressDelivery.Repository;

namespace ExpressDelivery.Controllers
{
    public class LoginController
    {
        public bool Status;
        public string Message = "";

        public void Acessar(string login, string password)
        {
            LoginRepository loginDao = new LoginRepository();
            Status = loginDao.VerificaLogin(login, password);
            if (loginDao.Message.Equals("") && loginDao.Status)
            {
                Status = true;
                return;
            }

            Message = loginDao.Message;
        }
    }
}