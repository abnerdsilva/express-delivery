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
    class UsuarioRepository
    {
        public string Message = "";

        public async Task<List<Usuario>> LoadAll()
        {
            var users = new List<Usuario>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + "/v1/users").Result;
                var result = await response.Content.ReadAsStringAsync();

                var itemJson = JsonConvert.DeserializeObject<List<Usuario>>(result);
                if (itemJson == null)
                {
                    throw new Exception("falha na conversão dos usuários");
                }

                users.AddRange(itemJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return users;
        }

        public async Task<List<Usuario>> LoadByName(string name)
        {
            var users = new List<Usuario>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/users?name={name}").Result;
                var result = await response.Content.ReadAsStringAsync();

                var itemJson = JsonConvert.DeserializeObject<List<Usuario>>(result);
                if (itemJson == null)
                {
                    throw new Exception("falha na conversão dos usuários");
                }

                users.AddRange(itemJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return users;
        }

        public async Task<List<Usuario>> LoadById(string id)
        {
            var users = new List<Usuario>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/users?code{id}").Result;
                var result = await response.Content.ReadAsStringAsync();

                var itemJson = JsonConvert.DeserializeObject<List<Usuario>>(result);
                if (itemJson == null)
                {
                    throw new Exception("falha na conversão dos usuários");
                }

                users.AddRange(itemJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return users;
        }

        public async Task<Usuario> Create(Usuario user)
        {
            Usuario newUser;
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = ConfigHttp.client.PostAsync($"{ConfigHttp.BaseUrl}/v1/user", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                var userJson = JsonConvert.DeserializeObject<Usuario>(result);
                if (userJson == null)
                {
                    return null;
                }

                newUser = userJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return newUser;
        }
        
        public async Task<Usuario> Update(Usuario user)
        {
            Message = "";
            Usuario editedUser;
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = ConfigHttp.client.PutAsync($"{ConfigHttp.BaseUrl}/v1/user/{user.Id}", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var error = JsonConvert.DeserializeObject<Error>(result);
                    Message = error.Message;
                    return null;
                }

                var userJson = JsonConvert.DeserializeObject<Usuario>(result);
                if (userJson == null)
                {
                    return null;
                }

                editedUser = userJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }

            return editedUser;
        }
    }
}
