using ExpressDelivery.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Newtonsoft.Json;

namespace ExpressDelivery.Repository
{
    class UsuarioRepository
    {
        public string Message = "";

        private readonly MySqlCommand _cmd = new MySqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private MySqlDataReader _dr;

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

        public List<Usuario> LoadByName(string name)
        {
            List<Usuario> users = new List<Usuario>();

            _cmd.CommandText = $"SELECT * FROM TB_USUARIO WHERE USUARIO LIKE '%{name}%';";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var user = new Usuario
                    {
                        Id = _dr.GetString("ID_USER"),
                        Status = Convert.ToInt16(_dr["STATUS_USUARIO"]),
                        Login = _dr["USUARIO"].ToString(),
                        Senha = _dr["SENHA"].ToString(),
                        TipoUsuario = _dr["TIPO_USUARIO"].ToString(),
                    };

                    users.Add(user);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return null;
            }
            finally
            {
                _con.Disconnect();
            }

            return users;
        }

        public List<Usuario> LoadById(string id)
        {
            List<Usuario> users = new List<Usuario>();

            _cmd.CommandText = $"SELECT * FROM TB_USUARIO WHERE ID_USER LIKE '%{id}%';";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var user = new Usuario
                    {
                        Id = _dr.GetString("ID_USER"),
                        Status = Convert.ToInt16(_dr["STATUS_USUARIO"]),
                        Login = _dr["USUARIO"].ToString(),
                        Senha = _dr["SENHA"].ToString(),
                        TipoUsuario = _dr["TIPO_USUARIO"].ToString(),
                    };

                    users.Add(user);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return null;
            }
            finally
            {
                _con.Disconnect();
            }

            return users;
        }

        public int LastUserId()
        {
            _cmd.CommandText = $"SELECT MAX(ID_USER) AS LAST_ID FROM TB_USUARIO;";

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
                Message = e.Message;
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return -1;
            }
            finally
            {
                _con.Disconnect();
            }

            return lastId;
        }

        public int Save(Usuario user, string type)
        {
            if (type == "new")
            {
                _cmd.CommandText =
                    $"INSERT INTO TB_USUARIO (USUARIO, SENHA, TIPO_USUARIO, STATUS_USUARIO)" +
                    $" VALUES ('{user.Login}', '{user.Senha}', '{user.TipoUsuario}', {user.Status});";
            }
            else
            {
                _cmd.CommandText =
                    $"UPDATE TB_USUARIO SET USUARIO='{user.Login}', SENHA='{user.Senha}', STATUS_USUARIO={user.Status}," +
                    $" TIPO_USUARIO='{user.TipoUsuario}' WHERE ID_USER={user.Id};";
            }

            try
            {
                _cmd.Connection = _con.Connect();
                return _cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                return -1;
            }
            finally
            {
                _con.Disconnect();
            }
        }
    }
}
