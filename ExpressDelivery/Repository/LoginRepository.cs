using System;
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
        
        public bool VerificaLogin(string login, string password)
        {
            _cmd.CommandText = $"SELECT * FROM TB_USUARIOS WHERE LOGIN_USER = @LOGIN_USER AND PASS = @PASS;";
            _cmd.Parameters.AddWithValue("@LOGIN_USER", login);
            _cmd.Parameters.AddWithValue("@PASS", password);

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();
                if (_dr.HasRows)
                {
                    Status = true;
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
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
            }
            finally
            {
                _con.Disconnect();
            }
            
            return Status;
        }
    }
}