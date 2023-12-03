using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExpressDelivery.Models;
using MySqlConnector;
using Newtonsoft.Json;

namespace ExpressDelivery.Repository
{
    public class PedidoRepository
    {
        public string Message = "";

        public async Task<Pedido> LoadLastOrderId()
        {
            Message = "";
            var pedido = new Pedido();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/orders?filter=lastOrder").Result;
                var result = await response.Content.ReadAsStringAsync();

                if (!result.Equals(""))
                {
                    var itemJson = JsonConvert.DeserializeObject<Pedido>(result);
                    if (itemJson == null)
                    {
                        throw new Exception("falha ao listar ultimo pedido");
                    }

                    pedido = itemJson;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                throw;
            }

            return pedido;
        }

        public async Task<List<Pedido>> LoadAll()
        {
            Message = "";
            var pedidos = new List<Pedido>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/orders?filter=date").Result;
                var result = await response.Content.ReadAsStringAsync();

                var itemJson = JsonConvert.DeserializeObject<List<Pedido>>(result);
                if (itemJson == null)
                {
                    throw new Exception("falha ao listar pedidos");
                }

                if (itemJson.Count > 0)
                    pedidos.AddRange(itemJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                return null;
            }

            return pedidos;
        }

        public async Task<List<Pedido>> LoadByCode(int code, string status)
        {
            Message = "";
            var pedidos = new List<Pedido>();

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/orders?status={status}&id={code}").Result;
                var result = await response.Content.ReadAsStringAsync();

                var itemJson = JsonConvert.DeserializeObject<List<Pedido>>(result);
                if (itemJson == null)
                    throw new Exception("falha ao listar pedidos");

                foreach (var pedido in itemJson)
                {
                    if (status == "")
                    {
                        if (pedido.Id == code)
                        {
                            pedidos.AddRange(itemJson);
                        }
                    }
                    else
                    {
                        if (pedido.Id == code && status != "")
                        {
                            pedidos.AddRange(itemJson);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                return null;
            }

            return pedidos;
        }

        public async Task<List<Pedido>> LoadByDate(string inicio, string fim, string status)
        {
            Message = "";
            var pedidos = new List<Pedido>();

            try
            {
                var response = ConfigHttp.client.GetAsync($"{ConfigHttp.BaseUrl}/v1/orders?status={status}&dataInicio={inicio}&dataFim={fim}")
                    .Result;
                var result = await response.Content.ReadAsStringAsync();

                var itemJson = JsonConvert.DeserializeObject<List<Pedido>>(result);
                if (itemJson == null)
                    throw new Exception("falha ao listar pedidos");

                if (itemJson.Count > 0)
                    pedidos.AddRange(itemJson);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                return null;
            }

            return pedidos;
        }

        public async Task<string> LoadPedidosAbertosIntegracao()
        {
            Message = "";
            var ret = "";

            try
            {
                var response = ConfigHttp.client.GetAsync(ConfigHttp.BaseUrl + $"/v1/orders?filter=integracao").Result;
                var result = await response.Content.ReadAsStringAsync();

                var itemJson = JsonConvert.DeserializeObject<List<Pedido>>(result);
                if (itemJson == null)
                    throw new Exception("falha ao listar pedidos");

                foreach (var item in itemJson)
                {
                    if (item.Origem == "IFOOD" && item.StatusPedido == "ABERTO")
                    {
                        ret = "Ped: " + item.Id + " -> " + item.DataEntrega;
                    }
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

            return ret;
        }

        public async Task<int> SaveOrder(Pedido order, string type)
        {
            Message = "";
            Pedido newOrder;
            try
            {
                var json = JsonConvert.SerializeObject(order);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = ConfigHttp.client.PostAsync($"{ConfigHttp.BaseUrl}/v1/order", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                var orderJson = JsonConvert.DeserializeObject<Pedido>(result);
                if (orderJson == null)
                {
                    return -1;
                }

                newOrder = orderJson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                throw;
            }

            return newOrder.Id;

            // var nextOrderId = 0;
            // var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            //
            // using (MySqlConnection oConnection = new MySqlConnection(connectionString))
            // {
            //     oConnection.Open();
            //     using (MySqlTransaction oTransaction = oConnection.BeginTransaction())
            //     {
            //         var nfi = new NumberFormatInfo();
            //         nfi.NumberDecimalSeparator = ".";
            //
            //         using (MySqlCommand oCommand = oConnection.CreateCommand())
            //         {
            //             oCommand.Transaction = oTransaction;
            //             oCommand.CommandType = CommandType.Text;
            //
            //             try
            //             {
            //                 if (type == "new")
            //                 {
            //                     oCommand.CommandText =
            //                         $"INSERT INTO TB_PEDIDO (COD_CLIENTE, STATUS_PEDIDO, DATA_PEDIDO, VR_TOTAL, VR_TAXA, VR_TROCO," +
            //                         $" LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP, TIPO_PEDIDO, ORIGEM, OBSERVACAO," +
            //                         $" FORMA_PAGAMENTO, IMPRIME_PEDIDO, ID_USER) VALUES ({order.CodCliente}, '{order.StatusPedido}', '{order.DataPedido:yyyy-MM-dd HH:mm:ss}'," +
            //                         $" {order.VrTotal.ToString(nfi)}, {order.VrTaxa.ToString(nfi)}, {order.VrTroco.ToString(nfi)}, '{order.Logradouro}'," +
            //                         $" {order.Numero}, '{order.Bairro}', '{order.Cidade}', '{order.Estado}', '{order.CEP}'," +
            //                         $" '{order.TipoPedido}', '{order.Origem}', '{order.Observacao}', '{order.FormaPagamento}', 1, '{order.IdOperador}');";
            //                 }
            //                 else
            //                 {
            //                     oCommand.CommandText =
            //                         $"UPDATE TB_PEDIDO SET COD_CLIENTE={order.CodCliente}, STATUS_PEDIDO='{order.StatusPedido}'," +
            //                         $" LOGRADOURO='{order.Logradouro}', NUMERO='{order.Numero}', FORMA_PAGAMENTO='{order.FormaPagamento}'," +
            //                         $" BAIRRO='{order.Bairro}', CIDADE='{order.Cidade}', ESTADO='{order.Estado}', CEP='{order.CEP}'," +
            //                         $" VR_TOTAL='{order.VrTotal.ToString(nfi)}', VR_TAXA='{order.VrTaxa.ToString(nfi)}'," +
            //                         $" VR_TROCO='{order.VrTroco.ToString(nfi)}', TIPO_PEDIDO='{order.TipoPedido}'," +
            //                         $" DATA_ATUALIZACAO='{DateTime.Now:yyyy-MM-dd HH:mm:ss}', OBSERVACAO='{order.Observacao}'," +
            //                         $" IMPRIME_PEDIDO=1" +
            //                         $" WHERE COD_PEDIDO={order.Id};";
            //                 }
            //
            //                 if (oCommand.ExecuteNonQuery() != 1)
            //                     throw new InvalidProgramException();
            //
            //                 if (type == "new")
            //                 {
            //                     oCommand.CommandText = "SELECT MAX(COD_PEDIDO) AS COD_PEDIDO FROM TB_PEDIDO";
            //                     var _dr2 = oCommand.ExecuteReader();
            //                     while (_dr2.Read())
            //                         nextOrderId = Convert.ToInt16(_dr2["COD_PEDIDO"]);
            //                 }
            //                 else
            //                     nextOrderId = order.Id;
            //             }
            //             catch (MySqlException e)
            //             {
            //                 Message = e.Message;
            //                 GeraLog.PrintError(e.Message);
            //                 return -1;
            //             }
            //             catch (Exception e)
            //             {
            //                 oTransaction.Rollback();
            //                 Message = e.Message;
            //                 GeraLog.PrintError(e.Message);
            //                 return -1;
            //             }
            //             finally
            //             {
            //                 oCommand.Dispose();
            //             }
            //         }
            //
            //         using (MySqlCommand oCommand = oConnection.CreateCommand())
            //         {
            //             oCommand.Transaction = oTransaction;
            //             oCommand.CommandType = CommandType.Text;
            //
            //             try
            //             {
            //                 foreach (var item in order.Itens)
            //                 {
            //                     if (item.StatusEditar != 2)
            //                     {
            //                         oCommand.CommandText =
            //                             $"INSERT INTO TB_PEDIDO_ITEM (COD_PEDIDO, COD_PRODUTO, QUANTIDADE, VR_UNITARIO, VR_TOTAL, OBSERVACAO)" +
            //                             $" VALUES ({nextOrderId}, {item.CodProduto}, {item.Quantidade}, {item.VrUnitario.ToString(nfi)}," +
            //                             $" {item.VrTotal.ToString(nfi)}, '{item.Observacao}');";
            //
            //                         if (oCommand.ExecuteNonQuery() != 1)
            //                             throw new InvalidProgramException();
            //                     }
            //                 }
            //             }
            //             catch (MySqlException e)
            //             {
            //                 Message = e.Message;
            //                 GeraLog.PrintError(e.Message);
            //                 return -1;
            //             }
            //             catch (Exception e)
            //             {
            //                 oTransaction.Rollback();
            //                 Message = e.Message;
            //                 GeraLog.PrintError(e.Message);
            //                 return -1;
            //             }
            //             finally
            //             {
            //                 oCommand.Dispose();
            //             }
            //         }
            //
            //         oTransaction.Commit();
            //     }
            // }
            //
            // return nextOrderId;
        }

        public async Task<int> UpdateStatusOrder(int id)
        {
            Message = "";
            var value = 0;
            try
            {
                var response = ConfigHttp.client.PutAsync($"{ConfigHttp.BaseUrl}/v1/order/{id}/next", null).Result;
                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    value = -1;
                else
                    value = id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                value = -1;
                throw;
            }

            return value;
        }

        public async Task<int> UpdateOrder(Pedido order)
        {
            Message = "";
            var value = 0;
            try
            {
                var json = JsonConvert.SerializeObject(order);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = ConfigHttp.client.PutAsync($"{ConfigHttp.BaseUrl}/v1/order/{order.Id}", data).Result;
                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    value = -1;
                else
                    value = order.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                value = -1;
                throw;
            }

            return value;
        }

        public async Task<int> CancelOrder(int id)
        {
            Message = "";
            var value = 0;
            try
            {
                var response = ConfigHttp.client.PutAsync($"{ConfigHttp.BaseUrl}/v1/order/{id}/cancel", null).Result;
                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    value = -1;
                }

                value = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Message = e.Message;
                GeraLog.PrintError(e.Message);
                value = -1;
                throw;
            }

            return value;
        }
    }
}