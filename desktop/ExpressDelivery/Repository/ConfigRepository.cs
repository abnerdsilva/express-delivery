using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using Newtonsoft.Json;

namespace ExpressDelivery.Repository
{
    class ConfigRepository
    {
        public string Message = "";

        public async Task<bool> HasPrivacy()
        {
            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + "/v1/privacy").Result;
                await response.Content.ReadAsStringAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("falha na conversão dos usuários");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }
        }
        
        public async Task<bool> AddPrivacy(string user)
        {
            try
            {
                var response = ConfigHttp.client.PostAsync(ConfigHttp.BaseUrl + $"/v1/privacy/{user}", null).Result;
                await response.Content.ReadAsStringAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception("falha ao aceitar politica privacidade");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }
        }
    }
}