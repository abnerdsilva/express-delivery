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
                        Observacao = _dr["OBSERVACAO"].ToString(),
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
        
        public int LastProductId()
        {
            _cmd.CommandText = $"SELECT MAX(COD_PRODUTO) AS LAST_ID FROM TB_PRODUTO;";

            var lastId = 0;

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
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
        
        public int Save(Product product, string type)
        {
            if (type == "new")
            {
                _cmd.CommandText =
                    $"INSERT INTO TB_PRODUTO (NOME, CATEGORIA, VR_COMPRA, VR_UNITARIO, LOCALIZACAO, STATUS_PRODUTO," +
                    $" MARGEM_LUCRO, UN_MEDIDA, OBSERVACAO, COD_BARRAS) VALUES ('{product.Descricao}'," +
                    $" '{product.Categoria}', {product.PrecoCompra}, {product.PrecoVenda}, '{product.Localizacao}'," +
                    $" {product.Status}, {product.MargemLucro}, '{product.UnMedida}', '{product.Observacao}'," +
                    $" '{product.CodBarras}');";
            }
            else
            {
                _cmd.CommandText =
                    $"UPDATE TB_PRODUTO SET NOME='{product.Descricao}', CATEGORIA='{product.Categoria}'," +
                    $" VR_COMPRA={product.PrecoCompra}, VR_UNITARIO={product.PrecoVenda}, LOCALIZACAO='{product.Localizacao}'," +
                    $" STATUS_PRODUTO={product.Status}, MARGEM_LUCRO={product.MargemLucro}, UN_MEDIDA='{product.UnMedida}'," +
                    $" OBSERVACAO='{product.Observacao}', COD_BARRAS='{product.CodBarras}'," +
                    $" DATA_ATUALIZACAO='{DateTime.Now:yyyy-MM-dd HH:mm:ss}' WHERE COD_PRODUTO={product.Id};";
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