using System;
using ExpressDelivery.Models;
using Microsoft.Data.SqlClient;

namespace ExpressDelivery.Repository
{
    public class LoginRepository
    {
        public bool Status;
        public string Message = "";

        private readonly SqlCommand _cmd = new SqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private SqlDataReader _dr;
        
        public Usuario VerificaLogin(string login, string password)
        {
            var usuario = new Usuario();
            
            _cmd.CommandText = $"SELECT * FROM TB_USUARIO WHERE USUARIO = @LOGIN_USER AND SENHA = @PASS;";
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
                            Id = Convert.ToInt16(_dr["ID_USER"]),
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
            catch (SqlException e)
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
            
            return usuario;
        }
    }
}