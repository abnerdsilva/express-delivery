using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExpressDelivery.Repository
{
    class BairroRepository
    {
        public string Message = "";

        public async Task<List<Bairro>> LoadAll()
        {
            List<Bairro> bairros = new List<Bairro>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/districts").Result;
                var result = await response.Content.ReadAsStringAsync();

                var itemJson = JsonConvert.DeserializeObject<List<Bairro>>(result);
                if (itemJson == null)
                    throw new Exception("falha ao listar pedidos");

                bairros.AddRange(itemJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                return bairros;
            }

            return bairros;
        }

        public async Task<String> Save(Bairro bairro, string type)
        {
            try
            {
                var json = JsonConvert.SerializeObject(bairro);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = ConfigHttp.client.PostAsync(ConfigHttp.BaseUrl + "/v1/district", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                var itemJson = JsonConvert.DeserializeObject<Bairro>(result);
                if (itemJson == null || itemJson.Id == "")
                    return "-1";

                return itemJson.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                return "-1";
            }
        }
    }
}