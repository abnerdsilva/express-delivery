using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpressDelivery.Models;
using MySqlConnector;
using Newtonsoft.Json;

namespace ExpressDelivery.Repository
{
    public class ProdutoRepository
    {
        public string Message = "";

        private readonly MySqlCommand _cmd = new MySqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private MySqlDataReader _dr;
        
        public async Task<List<Product>> LoadAll()
        {
            var products = new List<Product>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + "/v1/products").Result;
                var result = await response.Content.ReadAsStringAsync();

                var productsJson = JsonConvert.DeserializeObject<List<Product>>(result);
                if (productsJson == null)
                {
                    throw new Exception("falha na conversão dos produtos");
                }

                products.AddRange(productsJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                throw;
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
                        Uid = Convert.ToString(_dr["COD_PRODUTO"]),
                        Descricao = _dr["NOME"].ToString(),
                        PrecoCompra = Convert.ToDouble(_dr["VR_COMPRA"]),
                        UnMedida = _dr["UN_MEDIDA"].ToString(),
                        PrecoVenda = Convert.ToDouble(_dr["VR_UNITARIO"]),
                        Status = Convert.ToInt16(_dr["STATUS_PRODUTO"]),
                    };

                    products.Add(product);
                }
            }
            catch (MySqlException e)
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
                        Uid = Convert.ToString(_dr["COD_PRODUTO"]),
                        Status = Convert.ToInt16(_dr["STATUS_PRODUTO"]),
                        Descricao = _dr["NOME"].ToString(),
                        PrecoCompra = Convert.ToDouble(_dr["VR_COMPRA"]),
                        UnMedida = _dr["UN_MEDIDA"].ToString(),
                        PrecoVenda = Convert.ToDouble(_dr["VR_UNITARIO"]),
                    };

                    products.Add(product);
                }
            }
            catch (MySqlException e)
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
                    if (_dr["LAST_ID"] != DBNull.Value)
                        lastId = Convert.ToInt16(_dr["LAST_ID"]);
                }
            }
            catch (MySqlException e)
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
            var precoCompra = product.PrecoCompra.ToString().Replace(",", ".");
            var vrUnitario = product.PrecoVenda.ToString().Replace(",", ".");
            var margemLucro = product.MargemLucro.ToString().Replace(",", ".");

            if (type == "new")
            {
                _cmd.CommandText =
                    $"INSERT INTO TB_PRODUTO (COD_PRODUTO, NOME, CATEGORIA, VR_COMPRA, VR_UNITARIO, LOCALIZACAO, STATUS_PRODUTO," +
                    $" MARGEM_LUCRO, UN_MEDIDA, OBSERVACAO, COD_BARRAS) VALUES (UUID(), '{product.Descricao}'," +
                    $" '{product.Categoria}', {precoCompra}, {vrUnitario}, '{product.Localizacao}'," +
                    $" {product.Status}, {margemLucro}, '{product.UnMedida}', '{product.Observacao}'," +
                    $" '{product.CodBarras}');";
            }
            else
            {
                _cmd.CommandText =
                    $"UPDATE TB_PRODUTO SET NOME='{product.Descricao}', CATEGORIA='{product.Categoria}'," +
                    $" VR_COMPRA={precoCompra}, VR_UNITARIO={vrUnitario}, LOCALIZACAO='{product.Localizacao}'," +
                    $" STATUS_PRODUTO={product.Status}, MARGEM_LUCRO={margemLucro}, UN_MEDIDA='{product.UnMedida}'," +
                    $" OBSERVACAO='{product.Observacao}', COD_BARRAS='{product.CodBarras}'," +
                    $" DATA_ATUALIZACAO='{DateTime.Now:yyyy-MM-dd HH:mm:ss}' WHERE COD_PRODUTO={product.Uid};";
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