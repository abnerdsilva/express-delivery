using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using ExpressDelivery.Models;
using Microsoft.Data.SqlClient;

namespace ExpressDelivery.Repository
{
    public class PedidoRepository
    {
        public string Message = "";

        private readonly SqlCommand _cmd = new SqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private SqlDataReader _dr;
        private SqlDataReader _dr2;

        public int LoadLastOrderId()
        {
            _cmd.CommandText = $"SELECT MAX(COD_PEDIDO) AS LAST_ID FROM TB_PEDIDO;";

            var lastId = 0;

            try
            {
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    if(_dr["LAST_ID"] != DBNull.Value)
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

        public int SaveOrder(Pedido order, string type)
        {
            var nextOrderId = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            
            using (SqlConnection oConnection = new SqlConnection(connectionString))
            {
                oConnection.Open();
                using (SqlTransaction oTransaction = oConnection.BeginTransaction())
                {
                    var nfi = new NumberFormatInfo();
                    nfi.NumberDecimalSeparator = ".";

                    using (SqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.Transaction = oTransaction;
                        oCommand.CommandType = CommandType.Text;

                        try
                        {
                            if (type == "new")
                            {
                                oCommand.CommandText =
                                    $"INSERT INTO TB_PEDIDO (COD_CLIENTE, STATUS_PEDIDO, DATA_PEDIDO, VR_TOTAL, VR_TAXA, VR_TROCO," +
                                    $" LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP, TIPO_PEDIDO, ORIGEM, OBSERVACAO)" +
                                    $" VALUES ({order.CodCliente}, '{order.StatusPedido}', '{order.DataPedido:yyyy-MM-dd HH:mm:ss}'," +
                                    $" {order.VrTotal.ToString(nfi)}, {order.VrTaxa.ToString(nfi)}, {order.VrTroco.ToString(nfi)}, '{order.Logradouro}'," +
                                    $" {order.Numero}, '{order.Bairro}', '{order.Cidade}', '{order.Estado}', '{order.CEP}'," +
                                    $" '{order.TipoPedido}', '{order.Origem}', '{order.Observacao}');";
                            }
                            else
                            {
                                oCommand.CommandText =
                                    $"UPDATE TB_PEDIDO SET COD_CLIENTE={order.CodCliente}, STATUS_PEDIDO='{order.StatusPedido}'," +
                                    $" DATA_PEDIDO='{order.DataPedido}', LOGRADOURO='{order.Logradouro}', NUMERO='{order.Numero}'," +
                                    $" BAIRRO='{order.Bairro}', CIDADE='{order.Cidade}', ESTADO='{order.Estado}', CEP='{order.CEP}'," +
                                    $" VR_TOTAL='{order.VrTotal.ToString(nfi)}', VR_TAXA='{order.VrTaxa.ToString(nfi)}'," +
                                    $" VR_TROCO='{order.VrTroco}', TIPO_PEDIDO='{order.TipoPedido}', ORIGEM='{order.Origem}'," +
                                    $" DATA_ATUALIZACAO='{order.DataAtualizacao:yyyy-MM-dd HH:mm:ss}', OBSERVACAO='{order.Observacao}'" +
                                    $" WHERE COD_PEDIDO={order.Id};";
                            }

                            if (oCommand.ExecuteNonQuery() != 1)
                                throw new InvalidProgramException();

                            oCommand.CommandText = "SELECT * FROM TB_PEDIDO";

                            _dr2 = oCommand.ExecuteReader();
                            while (_dr2.Read())
                                nextOrderId = Convert.ToInt16(_dr2["COD_PEDIDO"]);
                        }
                        catch (SqlException e)
                        {
                            Message = e.Message;
                            return -1;
                        }
                        catch (Exception e)
                        {
                            oTransaction.Rollback();
                            Message = e.Message;
                            return -1;
                        }
                        finally
                        {
                            oCommand.Dispose();
                        }
                    }

                    using (SqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.Transaction = oTransaction;
                        oCommand.CommandType = CommandType.Text;

                        try
                        {
                            foreach (var item in order.Itens)
                            {
                                if (type == "new")
                                {
                                    oCommand.CommandText =
                                        $"INSERT INTO TB_PEDIDO_ITEM (COD_PEDIDO, COD_PRODUTO, QUANTIDADE, VR_UNITARIO, VR_TOTAL, OBSERVACAO)" +
                                        $" VALUES ({nextOrderId}, {item.CodProduto}, {item.Quantidade}, {item.VrUnitario.ToString(nfi)}," +
                                        $" {item.VrTotal.ToString(nfi)}, '{item.Observacao}');";
                                }
                                else
                                {
                                    oCommand.CommandText =
                                        $"UPDATE TB_PEDIDO SET COD_PEDIDO={item.CodPedido}, COD_PRODUTO={item.CodProduto}," +
                                        $" QUANTIDADE={item.Quantidade}, VR_UNITARIO={item.VrUnitario.ToString(nfi)}," +
                                        $" VR_TOTAL={item.VrTotal.ToString(nfi)}, OBSERVACAO='{item.Observacao}'" +
                                        $" WHERE COD_PEDIDO={item.Id};";
                                }

                                if (oCommand.ExecuteNonQuery() != 1)
                                    throw new InvalidProgramException();
                            }
                        }
                        catch (SqlException e)
                        {
                            Message = e.Message;
                            return -1;
                        }
                        catch (Exception e)
                        {
                            oTransaction.Rollback();
                            Message = e.Message;
                            return -1;
                        }
                        finally
                        {
                            oCommand.Dispose();
                        }
                    }

                    oTransaction.Commit();
                }
            }

            return nextOrderId;
        }
    }
}