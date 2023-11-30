using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExpressDelivery.Models;
using MySqlConnector;
using Newtonsoft.Json;

namespace ExpressDelivery.Repository
{
    public class LoginRepository
    {
        public bool Status;
        public string Message = "";

        private readonly MySqlCommand _cmd = new MySqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private MySqlDataReader _dr;

        public Usuario VerificaLogin(string login, string password)
        {
            var usuario = new Usuario();

            _cmd.CommandText = $"SELECT * FROM TB_USUARIO WHERE USUARIO = @LOGIN_USER AND SENHA = @PASS AND STATUS_USUARIO=1;";
            _cmd.Parameters.AddWithValue("@LOGIN_USER", login);
            _cmd.Parameters.AddWithValue("@PASS", password);

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();
                if (_dr.HasRows)
                {
                    if (_dr.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = _dr.GetString("ID_USER"),
                            Login = _dr["USUARIO"].ToString(),
                            Senha = _dr["SENHA"].ToString(),
                            TipoUsuario = _dr["TIPO_USUARIO"].ToString(),
                        };

                        Status = true;
                    }
                }
                else
                {
                    Message = "Usuário e/ou senha inválidos";
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                return null;
            }
            finally
            {
                _con.Disconnect();
            }

            return usuario;
        }

        public async Task<Usuario> Login(string username, string password)
        {
            var usuario = new Usuario();

            var userTemp = new LoginUsuario();
            userTemp.Username = username;
            userTemp.Password = password;

            var json = JsonConvert.SerializeObject(userTemp);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = ConfigHttp.client.PostAsync(ConfigHttp.BaseUrl + "/auth/login2", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                var tokenLogin = JsonConvert.DeserializeObject<TokenLogin>(result);
                if (tokenLogin == null || (tokenLogin.Error != null))
                {
                    throw new Exception(tokenLogin.Error);
                }

                ConfigHttp.setHeader(tokenLogin.Token);

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(tokenLogin.Token);
                var tokenS = jsonToken as JwtSecurityToken;

                if (tokenS == null)
                {
                    throw new Exception("falha na leitura do token");
                }

                foreach (var claim in tokenS.Claims)
                {
                    switch (claim.Type)
                    {
                        case "id":
                            usuario.Id = claim.Value;
                            break;
                        case "sub":
                            usuario.Login = claim.Value;
                            break;
                        case "type":
                            usuario.TipoUsuario = claim.Value;
                            break;
                    }
                }

                usuario.Status = "ATIVO";

                Status = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                Status = false;
                GeraLog.PrintError(e.Message);
                throw;
            }

            return usuario;
        }
    }
}