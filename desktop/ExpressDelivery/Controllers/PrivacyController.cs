using System;
using System.Threading.Tasks;
using ExpressDelivery.Models;
using ExpressDelivery.Repository;

namespace ExpressDelivery.Controllers
{
    public class PrivacyController
    {
        private readonly ConfigRepository _configRepository = new ConfigRepository();

        public bool Status;
        public string Message = "";

        public Task<bool> HasPrivacy()
        {
            try
            {
                var hasPrivacy = _configRepository.HasPrivacy().Result;
                if (hasPrivacy)
                {
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }
            catch (Exception e)
            {
                GeraLog.PrintError(e.Message);
                Message = e.Message;
                return Task.FromResult(false);
            }
        }
        
        public Task<bool> AddPrivacy(string user)
        {
            try
            {
                var hasPrivacy = _configRepository.AddPrivacy(user).Result;
                if (hasPrivacy)
                {
                    Message = "Usuário e/ou senha inválido";
                    GeraLog.PrintError(Message);
                    return Task.FromResult(false);
                }

                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                GeraLog.PrintError(e.Message);
                Message = e.Message;
                return Task.FromResult(false);
            }
        }
    }
}