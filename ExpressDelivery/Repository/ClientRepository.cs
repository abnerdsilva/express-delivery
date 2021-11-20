using System;
using System.Collections.Generic;
using ExpressDelivery.Models;
using Microsoft.Data.SqlClient;

namespace ExpressDelivery.Repository
{
    public class ClientRepository
    {
        public string Message = "";

        private readonly SqlCommand _cmd = new SqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private SqlDataReader _dr;

        public List<Client> LoadAll()
        {
            List<Client> clients = new List<Client>();

            _cmd.CommandText = $"SELECT * FROM TB_CLIENTE;";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var client = new Client
                    {
                        Id = Convert.ToInt16(_dr["COD_CLIENTE"]),
                        Nome = _dr["NOME"].ToString(),
                        Telefone = _dr["TELEFONE"].ToString(),
                        Endereco = _dr["LOGRADOURO"].ToString(),
                        Numero = Convert.ToInt16(_dr["NUMERO"]),
                        Bairro = _dr["BAIRRO"].ToString(),
                        Cidade = _dr["CIDADE"].ToString(),
                        Estado = _dr["ESTADO"].ToString(),
                        CEP = _dr["CEP"].ToString(),
                        Email = _dr["EMAIL"].ToString(),
                        Status = Convert.ToInt16(_dr["STATUS_CLIENTE"]),
                        CPF = _dr["CPF"].ToString(),
                        RG = _dr["RG"].ToString(),
                        Observacao = _dr["OBSERVACAO"].ToString()
                    };

                    clients.Add(client);
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

            return clients;
        }

        public List<Client> LoadByName(string name)
        {
            List<Client> clients = new List<Client>();

            _cmd.CommandText = $"SELECT * FROM TB_CLIENTE WHERE NOME LIKE '%{name}%';";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var client = new Client
                    {
                        Id = Convert.ToInt16(_dr["COD_CLIENTE"]),
                        Nome = _dr["NOME"].ToString(),
                        Telefone = _dr["TELEFONE"].ToString(),
                        Endereco = _dr["LOGRADOURO"].ToString()
                    };

                    clients.Add(client);
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

            return clients;
        }

        public List<Client> LoadById(string id)
        {
            List<Client> clients = new List<Client>();

            _cmd.CommandText = $"SELECT * FROM TB_CLIENTE WHERE COD_CLIENTE LIKE '%{id}%';";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var client = new Client
                    {
                        Id = Convert.ToInt16(_dr["COD_CLIENTE"]),
                        Nome = _dr["NOME"].ToString(),
                        Telefone = _dr["TELEFONE"].ToString(),
                        Endereco = _dr["LOGRADOURO"].ToString()
                    };

                    clients.Add(client);
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

            return clients;
        }

        public Client LoadByPhone(string phone)
        {
            var client = new Client();

            _cmd.CommandText = $"SELECT * FROM TB_CLIENTE WHERE TELEFONE='{phone}';";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    client.Id = Convert.ToInt16(_dr["COD_CLIENTE"]);
                    client.Nome = _dr["NOME"].ToString();
                    client.Telefone = _dr["TELEFONE"].ToString();
                    client.Endereco = _dr["LOGRADOURO"].ToString();
                    client.Numero = Convert.ToInt16(_dr["NUMERO"]);
                    client.Bairro = _dr["BAIRRO"].ToString();
                    client.Cidade = _dr["CIDADE"].ToString();
                    client.Estado = _dr["ESTADO"].ToString();
                    client.CEP = _dr["CEP"].ToString();
                    client.Email = _dr["EMAIL"].ToString();
                    client.Status = Convert.ToInt16(_dr["STATUS_CLIENTE"]);
                    client.CPF = _dr["CPF"].ToString();
                    client.RG = _dr["RG"].ToString();
                    client.Observacao = _dr["OBSERVACAO"].ToString();
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

            return client;
        }

        public int LastClientId()
        {
            _cmd.CommandText = $"SELECT MAX(COD_CLIENTE) AS LAST_ID FROM TB_CLIENTE;";

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

            return lastId;
        }

        public int Save(Client client, string type)
        {
            if (type == "new")
            {
                _cmd.CommandText =
                    $"INSERT INTO TB_CLIENTE (NOME, TELEFONE, CPF, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP," +
                    $" STATUS_CLIENTE, RG, EMAIL, OBSERVACAO) VALUES ('{client.Nome}', '{client.Telefone}', '{client.CPF}'," +
                    $" '{client.Endereco}', {client.Numero}, '{client.Bairro}', '{client.Cidade}', '{client.Estado}'," +
                    $" '{client.CEP}', {client.Status}, '{client.RG}', '{client.Email}', '{client.Observacao}');";
            }
            else
            {
                _cmd.CommandText =
                    $"UPDATE TB_CLIENTE SET NOME='{client.Nome}', TELEFONE='{client.Telefone}', CPF='{client.CPF}'," +
                    $" LOGRADOURO='{client.Endereco}', NUMERO='{client.Numero}', BAIRRO='{client.Bairro}'," +
                    $" CIDADE='{client.Cidade}', ESTADO='{client.Estado}', CEP='{client.CEP}'," +
                    $" STATUS_CLIENTE='{client.Status}', RG='{client.RG}', EMAIL='{client.Email}'," +
                    $" DATA_ATUALIZACAO='{DateTime.Now:yyyy-MM-dd HH:mm:ss}', OBSERVACAO='{client.Observacao}'" +
                    $" WHERE COD_CLIENTE={client.Id};";
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
        }
    }
}