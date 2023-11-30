using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExpressDelivery.Models;
using MySqlConnector;
using Newtonsoft.Json;

namespace ExpressDelivery.Repository
{
    public class ClientRepository
    {
        public string Message = "";

        private readonly MySqlCommand _cmd = new MySqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private MySqlDataReader _dr;

        public async Task<List<Client>> LoadAll()
        {
            List<Client> clients = new List<Client>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + "/v1/clients").Result;
                var result = await response.Content.ReadAsStringAsync();

                var clientsJson = JsonConvert.DeserializeObject<List<Client>>(result);
                if (clientsJson == null)
                {
                    throw new Exception("falha na conversão dos clientes");
                }

                clients.AddRange(clientsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                throw;
            }

            return clients;
        }

        public async Task<List<Client>> LoadByName(string name)
        {
            List<Client> clients = new List<Client>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/clients?name={name}").Result;
                var result = await response.Content.ReadAsStringAsync();

                var clientsJson = JsonConvert.DeserializeObject<List<Client>>(result);
                if (clientsJson == null)
                {
                    throw new Exception("falha na conversão dos clientes");
                }
                
                clients.AddRange(clientsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                throw;
            }

            return clients;
        }

        public async Task<List<Client>> LoadById(string id)
        {
            List<Client> clients = new List<Client>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/client/{id}").Result;
                var result = await response.Content.ReadAsStringAsync();

                var clientJson = JsonConvert.DeserializeObject<Client>(result);
                if (clientJson == null)
                {
                    throw new Exception("falha na conversão do cliente");
                }

                clients.Add(clientJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                throw;
            }

            return clients;
        }

        public async Task<Client> LoadByPhone(string phone)
        {
            Client client = new Client();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/client?phone={phone}").Result;
                var result = await response.Content.ReadAsStringAsync();

                var clientsJson = JsonConvert.DeserializeObject<Client>(result);
                if (clientsJson == null)
                {
                    // throw new Exception("falha na conversão do cliente");
                    return client;
                }

                client = clientsJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                throw;
            }

            return client;
        }

        public int LastClientIdOld()
        {
            _cmd.CommandText = $"SELECT MAX(ID) AS LAST_ID FROM TB_CLIENTE;";

            var lastId = 0;

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    if (_dr["LAST_ID"] != DBNull.Value)
                        lastId = Convert.ToInt16(_dr["LAST_ID"]);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                GeraLog.PrintError(e.Message);
                Message = e.Message;
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                throw;
            }
            finally
            {
                _con.Disconnect();
            }

            return lastId;
        }

        public async Task<Client> Create(Client client)
        {
            Client newClient;
            try
            {
                var json = JsonConvert.SerializeObject(client);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = ConfigHttp.client.PostAsync($"{ConfigHttp.BaseUrl}/v1/client", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                var clientJson = JsonConvert.DeserializeObject<Client>(result);
                if (clientJson == null)
                {
                    return null;
                }

                newClient = clientJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                throw;
            }

            return newClient;
        }

        public async Task<Client> Update(Client client)
        {
            Client editedClient;

            try
            {
                var json = JsonConvert.SerializeObject(client);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = ConfigHttp.client.PutAsync($"{ConfigHttp.BaseUrl}/v1/client/{client.Id}", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                var clientJson = JsonConvert.DeserializeObject<Client>(result);
                if (clientJson == null)
                {
                    return null;
                }

                editedClient = clientJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                throw;
            }

            return editedClient;
        }
    }
}