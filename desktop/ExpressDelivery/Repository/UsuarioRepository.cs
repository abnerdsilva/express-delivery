using ExpressDelivery.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ExpressDelivery.Repository
{
    class UsuarioRepository
    {
        public string Message = "";

        private readonly SqlCommand _cmd = new SqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private SqlDataReader _dr;

        public List<Usuario> LoadAll()
        {
            List<Usuario> users = new List<Usuario>();

            _cmd.CommandText = $"SELECT * FROM TB_USUARIO;";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var user = new Usuario
                    {
                        Id = Convert.ToInt16(_dr["ID_USER"]),
                        Status = Convert.ToInt16(_dr["STATUS_USUARIO"]),
                        Login = _dr["USUARIO"].ToString(),
                        Senha = _dr["SENHA"].ToString(),
                        TipoUsuario = _dr["TIPO_USUARIO"].ToString(),
                    };

                    users.Add(user);
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
                        Id = Convert.ToInt16(_dr["ID_USER"]),
                        Status = Convert.ToInt16(_dr["STATUS_USUARIO"]),
                        Login = _dr["USUARIO"].ToString(),
                        Senha = _dr["SENHA"].ToString(),
                        TipoUsuario = _dr["TIPO_USUARIO"].ToString(),
                    };

                    users.Add(user);
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
                        Id = Convert.ToInt16(_dr["ID_USER"]),
                        Status = Convert.ToInt16(_dr["STATUS_USUARIO"]),
                        Login = _dr["USUARIO"].ToString(),
                        Senha = _dr["SENHA"].ToString(),
                        TipoUsuario = _dr["TIPO_USUARIO"].ToString(),
                    };

                    users.Add(user);
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
            catch (SqlException e)
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
            catch (SqlException e)
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
