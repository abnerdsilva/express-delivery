using System;
using System.Collections.Generic;
using ExpressDelivery.Models;
using Microsoft.Data.SqlClient;

namespace ExpressDelivery.Repository
{
    public class ProdutoRepository
    {
        public string Message = "";

        private readonly SqlCommand _cmd = new SqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private SqlDataReader _dr;
        
        public List<Product> LoadAll()
        {
            var products = new List<Product>();

            _cmd.CommandText = $"SELECT * FROM TB_PRODUTO;";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var product = new Product
                    {
                        Id = Convert.ToInt16(_dr["COD_PRODUTO"]),
                        Status = Convert.ToInt16(_dr["STATUS_PRODUTO"]),
                        CodBarras = _dr["COD_BARRAS"].ToString(),
                        Descricao = _dr["NOME"].ToString(),
                        Categoria = _dr["CATEGORIA"].ToString(),
                        PrecoCompra = Convert.ToDouble(_dr["VR_COMPRA"]),
                        PrecoVenda = Convert.ToDouble(_dr["VR_UNITARIO"]),
                        MargemLucro = Convert.ToDouble(_dr["MARGEM_LUCRO"]),
                        UnMedida = _dr["UN_MEDIDA"].ToString(),
                        Localizacao = _dr["LOCALIZACAO"].ToString(),
                    };

                    products.Add(product);
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

            return products;
        }

        public List<Product> LoadByName(string name)
        {
            List<Product> products = new List<Product>();

            _cmd.CommandText = $"SELECT * FROM TB_PRODUTO WHERE NOME LIKE '%{name}%';";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var product = new Product
                    {
                        Id = Convert.ToInt16(_dr["COD_PRODUTO"]),
                        Descricao = _dr["NOME"].ToString(),
                        PrecoCompra = Convert.ToDouble(_dr["VR_COMPRA"]),
                        UnMedida = _dr["UN_MEDIDA"].ToString(),
                        PrecoVenda = Convert.ToDouble(_dr["VR_UNITARIO"]),
                        Status = Convert.ToInt16(_dr["STATUS_PRODUTO"]),
                    };

                    products.Add(product);
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

            return products;
        }

        public List<Product> LoadById(string id)
        {
            var products = new List<Product>();

            _cmd.CommandText = $"SELECT * FROM TB_PRODUTO WHERE COD_PRODUTO LIKE '%{id}%';";

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var product = new Product
                    {
                        Id = Convert.ToInt16(_dr["COD_PRODUTO"]),
                        Descricao = _dr["NOME"].ToString(),
                        PrecoCompra = Convert.ToDouble(_dr["VR_COMPRA"]),
                        UnMedida = _dr["UN_MEDIDA"].ToString(),
                        PrecoVenda = Convert.ToDouble(_dr["VR_UNITARIO"]),
                    };

                    products.Add(product);
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

            return products;
        }
    }
}