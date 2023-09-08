using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using ExpressDelivery.Models;
using MySqlConnector;

namespace ExpressDelivery.Repository
{
    public class PedidoRepository
    {
        public string Message = "";

        private readonly MySqlCommand _cmd = new MySqlCommand();
        private readonly ConnectionDbRepository _con = new ConnectionDbRepository();
        private readonly ConnectionDbRepository _con2 = new ConnectionDbRepository();
        private MySqlDataReader _dr;
        private MySqlDataReader _dr2;

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

        public List<Pedido> LoadAll()
        {
            var pedidos = new List<Pedido>();

            try
            {
                var today = DateTime.Today.ToString("yyyy-MM-dd");
                var tomorrow = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
                _cmd.CommandText =
                    $"SELECT TB_PEDIDO.*, NOME FROM TB_PEDIDO INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TB_PEDIDO.COD_CLIENTE WHERE DATA_PEDIDO BETWEEN '{today}' AND '{tomorrow}';";
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var idPedido = Convert.ToInt16(_dr["COD_PEDIDO"]);

                    var pedidoItens = new List<PedidoItem>();
                    var pedido = new Pedido();

                    var dataPedido = DateTime.Parse(_dr["DATA_PEDIDO"].ToString(), CultureInfo.CurrentCulture);
                    var dataAtualizacao = _dr["DATA_ATUALIZACAO"] == DBNull.Value
                        ? DateTime.Today
                        : DateTime.Parse(_dr["DATA_ATUALIZACAO"].ToString(), CultureInfo.CurrentCulture);
                    var dataEntrega = _dr["DATA_ENTREGA"] == DBNull.Value
                        ? DateTime.Today
                        : DateTime.Parse(_dr["DATA_ENTREGA"].ToString(), CultureInfo.CurrentCulture);

                    // -----------------------

                    _cmd.CommandText =
                        $"SELECT TB_PEDIDO_ITEM.*, NOME FROM TB_PEDIDO_ITEM INNER JOIN TB_PRODUTO TP on TP.COD_PRODUTO = TB_PEDIDO_ITEM.COD_PRODUTO WHERE COD_PEDIDO={idPedido};";
                    _cmd.Connection = _con2.Connect();
                    _dr2 = _cmd.ExecuteReader();

                    while (_dr2.Read())
                    {
                        var item = new PedidoItem
                        {
                            Id = Convert.ToInt16(_dr2["COD_PEDIDO_ITEM"]),
                            CodPedido = Convert.ToInt16(_dr2["COD_PEDIDO"]),
                            CodProduto = Convert.ToString(_dr2["COD_PRODUTO"]),
                            Nome = _dr2["NOME"].ToString(),
                            Observacao = _dr2["OBSERVACAO"].ToString(),
                            VrTotal = Convert.ToDouble(_dr2["VR_TOTAL"]),
                            VrUnitario = Convert.ToDouble(_dr2["VR_UNITARIO"]),
                            Quantidade = Convert.ToInt16(_dr2["QUANTIDADE"]),
                        };

                        pedidoItens.Add(item);
                    }

                    pedido = new Pedido
                    {
                        Id = Convert.ToInt16(_dr["COD_PEDIDO"]),
                        CodCliente = Convert.ToInt16(_dr["COD_CLIENTE"]),
                        Nome = _dr["NOME"].ToString(),
                        Origem = _dr["ORIGEM"].ToString(),
                        TipoPedido = _dr["TIPO_PEDIDO"].ToString(),
                        Logradouro = _dr["LOGRADOURO"].ToString(),
                        Numero = Convert.ToInt16(_dr["NUMERO"]),
                        Bairro = _dr["BAIRRO"].ToString(),
                        Cidade = _dr["CIDADE"].ToString(),
                        Estado = _dr["ESTADO"].ToString(),
                        CEP = _dr["CEP"].ToString(),
                        StatusPedido = _dr["STATUS_PEDIDO"].ToString(),
                        DataPedido = dataPedido,
                        DataAtualizacao = dataAtualizacao,
                        DataEntrega = dataEntrega,
                        Observacao = _dr["OBSERVACAO"].ToString(),
                        FormaPagamento = _dr["FORMA_PAGAMENTO"].ToString(),
                        VrTaxa = Convert.ToDouble(_dr["VR_TAXA"]),
                        VrTotal = Convert.ToDouble(_dr["VR_TOTAL"]),
                        VrTroco = Convert.ToDouble(_dr["VR_TROCO"]),
                    };

                    pedido.Itens = pedidoItens;
                    pedidos.Add(pedido);

                    _con2.Disconnect();
                }
            }
            catch (MySqlException e)
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

            return pedidos;
        }

        public List<Pedido> LoadByCode(int code, string status)
        {
            var pedidos = new List<Pedido>();

            try
            {
                if (status.Equals("TODOS"))
                    _cmd.CommandText =
                        $"SELECT * FROM TB_PEDIDO INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TB_PEDIDO.COD_CLIENTE WHERE TB_PEDIDO.COD_PEDIDO={code};";
                else
                    _cmd.CommandText =
                        $"SELECT * FROM TB_PEDIDO INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TB_PEDIDO.COD_CLIENTE WHERE TB_PEDIDO.COD_PEDIDO={code} AND STATUS_PEDIDO='{status}';";

                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var idPedido = code;

                    var pedidoItens = new List<PedidoItem>();
                    var pedido = new Pedido();

                    var dataPedido = DateTime.Parse(_dr["DATA_PEDIDO"].ToString(), CultureInfo.CurrentCulture);
                    var dataAtualizacao = _dr["DATA_ATUALIZACAO"] == DBNull.Value
                        ? DateTime.Today
                        : DateTime.Parse(_dr["DATA_ATUALIZACAO"].ToString(), CultureInfo.CurrentCulture);
                    var dataEntrega = _dr["DATA_ENTREGA"] == DBNull.Value
                        ? DateTime.Today
                        : DateTime.Parse(_dr["DATA_ENTREGA"].ToString(), CultureInfo.CurrentCulture);

                    // -----------------------

                    _cmd.CommandText =
                        $"SELECT TB_PEDIDO_ITEM.*, NOME FROM TB_PEDIDO_ITEM INNER JOIN TB_PRODUTO TP on TP.COD_PRODUTO = TB_PEDIDO_ITEM.COD_PRODUTO WHERE COD_PEDIDO={idPedido};";
                    _cmd.Connection = _con2.Connect();
                    _dr2 = _cmd.ExecuteReader();

                    while (_dr2.Read())
                    {
                        var item = new PedidoItem
                        {
                            Id = Convert.ToInt16(_dr2["COD_PEDIDO_ITEM"]),
                            CodPedido = Convert.ToInt16(_dr2["COD_PEDIDO"]),
                            CodProduto = Convert.ToString(_dr2["COD_PRODUTO"]),
                            Nome = _dr2["NOME"].ToString(),
                            Observacao = _dr2["OBSERVACAO"].ToString(),
                            VrTotal = Convert.ToDouble(_dr2["VR_TOTAL"]),
                            VrUnitario = Convert.ToDouble(_dr2["VR_UNITARIO"]),
                            Quantidade = Convert.ToInt16(_dr2["QUANTIDADE"]),
                        };

                        pedidoItens.Add(item);
                    }

                    pedido = new Pedido
                    {
                        Id = Convert.ToInt16(_dr["COD_PEDIDO"]),
                        CodCliente = Convert.ToInt16(_dr["COD_CLIENTE"]),
                        Nome = _dr["NOME"].ToString(),
                        Origem = _dr["ORIGEM"].ToString(),
                        TipoPedido = _dr["TIPO_PEDIDO"].ToString(),
                        Logradouro = _dr["LOGRADOURO"].ToString(),
                        Numero = Convert.ToInt16(_dr["NUMERO"]),
                        Bairro = _dr["BAIRRO"].ToString(),
                        Cidade = _dr["CIDADE"].ToString(),
                        Estado = _dr["ESTADO"].ToString(),
                        CEP = _dr["CEP"].ToString(),
                        StatusPedido = _dr["STATUS_PEDIDO"].ToString(),
                        DataPedido = dataPedido,
                        DataAtualizacao = dataAtualizacao,
                        DataEntrega = dataEntrega,
                        Observacao = _dr["OBSERVACAO"].ToString(),
                        VrTaxa = Convert.ToDouble(_dr["VR_TAXA"]),
                        VrTotal = Convert.ToDouble(_dr["VR_TOTAL"]),
                        VrTroco = Convert.ToDouble(_dr["VR_TROCO"]),
                    };

                    pedido.Itens = pedidoItens;
                    pedidos.Add(pedido);

                    _con2.Disconnect();
                    break;
                }
            }
            catch (MySqlException e)
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

            return pedidos;
        }

        public List<Pedido> LoadByDate(string inicio, string fim, string status)
        {
            var pedidos = new List<Pedido>();

            try
            {
                var cmdStatus = $"AND STATUS_PEDIDO = '{status}'";
                if (status.Equals("TODOS"))
                    cmdStatus = "";
                _cmd.CommandText =
                    $"SELECT TB_PEDIDO.*, NOME FROM TB_PEDIDO INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TB_PEDIDO.COD_CLIENTE" +
                    $" WHERE DATA_PEDIDO BETWEEN '{inicio}' AND '{fim} 23:59:59' {cmdStatus};";
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var idPedido = Convert.ToInt16(_dr["COD_PEDIDO"]);

                    var pedidoItens = new List<PedidoItem>();
                    var pedido = new Pedido();

                    var dataPedido = DateTime.Parse(_dr["DATA_PEDIDO"].ToString(), CultureInfo.CurrentCulture);
                    var dataAtualizacao = _dr["DATA_ATUALIZACAO"] == DBNull.Value
                        ? DateTime.Today
                        : DateTime.Parse(_dr["DATA_ATUALIZACAO"].ToString(), CultureInfo.CurrentCulture);
                    var dataEntrega = _dr["DATA_ENTREGA"] == DBNull.Value
                        ? DateTime.Today
                        : DateTime.Parse(_dr["DATA_ENTREGA"].ToString(), CultureInfo.CurrentCulture);

                    // -----------------------

                    _cmd.CommandText =
                        $"SELECT TB_PEDIDO_ITEM.*, NOME FROM TB_PEDIDO_ITEM INNER JOIN TB_PRODUTO TP on TP.COD_PRODUTO = TB_PEDIDO_ITEM.COD_PRODUTO WHERE COD_PEDIDO={idPedido};";
                    _cmd.Connection = _con2.Connect();
                    _dr2 = _cmd.ExecuteReader();

                    while (_dr2.Read())
                    {
                        var item = new PedidoItem
                        {
                            Id = Convert.ToInt16(_dr2["COD_PEDIDO_ITEM"]),
                            CodPedido = Convert.ToInt16(_dr2["COD_PEDIDO"]),
                            CodProduto = Convert.ToString(_dr2["COD_PRODUTO"]),
                            Nome = _dr2["NOME"].ToString(),
                            Observacao = _dr2["OBSERVACAO"].ToString(),
                            VrTotal = Convert.ToDouble(_dr2["VR_TOTAL"]),
                            VrUnitario = Convert.ToDouble(_dr2["VR_UNITARIO"]),
                            Quantidade = Convert.ToInt16(_dr2["QUANTIDADE"]),
                        };

                        pedidoItens.Add(item);
                    }

                    pedido = new Pedido
                    {
                        Id = Convert.ToInt16(_dr["COD_PEDIDO"]),
                        CodCliente = Convert.ToInt16(_dr["COD_CLIENTE"]),
                        Nome = _dr["NOME"].ToString(),
                        Origem = _dr["ORIGEM"].ToString(),
                        TipoPedido = _dr["TIPO_PEDIDO"].ToString(),
                        Logradouro = _dr["LOGRADOURO"].ToString(),
                        Numero = Convert.ToInt16(_dr["NUMERO"]),
                        Bairro = _dr["BAIRRO"].ToString(),
                        Cidade = _dr["CIDADE"].ToString(),
                        Estado = _dr["ESTADO"].ToString(),
                        CEP = _dr["CEP"].ToString(),
                        StatusPedido = _dr["STATUS_PEDIDO"].ToString(),
                        DataPedido = dataPedido,
                        DataAtualizacao = dataAtualizacao,
                        DataEntrega = dataEntrega,
                        Observacao = _dr["OBSERVACAO"].ToString(),
                        VrTaxa = Convert.ToDouble(_dr["VR_TAXA"]),
                        VrTotal = Convert.ToDouble(_dr["VR_TOTAL"]),
                        VrTroco = Convert.ToDouble(_dr["VR_TROCO"]),
                    };

                    pedido.Itens = pedidoItens;
                    pedidos.Add(pedido);

                    _con2.Disconnect();
                }
            }
            catch (MySqlException e)
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

            return pedidos;
        }

        public string LoadPedidosAbertosIntegracao()
        {
            var ret = "";

            try
            {
                _cmd.CommandText =
                    $"SELECT COD_PEDIDO, DATA_PEDIDO FROM TB_PEDIDO WHERE STATUS_PEDIDO='ABERTO' AND ORIGEM='IFOOD'" +
                    $" AND cod_pedido_integracao IS NOT NULL AND DATA_ATUALIZACAO IS NULL ORDER BY DATA_PEDIDO DESC";
                _cmd.Connection = _con.Connect();
                _dr = _cmd.ExecuteReader();

                while (_dr.Read())
                {
                    var idPedido = Convert.ToInt16(_dr["COD_PEDIDO"]);
                    var dataPedido = DateTime.Parse(_dr["DATA_PEDIDO"].ToString(), CultureInfo.CurrentCulture);

                    ret = "Ped: " + idPedido + " -> " + dataPedido;
                }
            }
            catch (MySqlException e)
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

            return ret;
        }

        public int SaveOrder(Pedido order, string type)
        {
            var nextOrderId = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            using (MySqlConnection oConnection = new MySqlConnection(connectionString))
            {
                oConnection.Open();
                using (MySqlTransaction oTransaction = oConnection.BeginTransaction())
                {
                    var nfi = new NumberFormatInfo();
                    nfi.NumberDecimalSeparator = ".";

                    using (MySqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.Transaction = oTransaction;
                        oCommand.CommandType = CommandType.Text;

                        try
                        {
                            if (type == "new")
                            {
                                oCommand.CommandText =
                                    $"INSERT INTO TB_PEDIDO (COD_CLIENTE, STATUS_PEDIDO, DATA_PEDIDO, VR_TOTAL, VR_TAXA, VR_TROCO," +
                                    $" LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP, TIPO_PEDIDO, ORIGEM, OBSERVACAO," +
                                    $" FORMA_PAGAMENTO, IMPRIME_PEDIDO, ID_USER) VALUES ({order.CodCliente}, '{order.StatusPedido}', '{order.DataPedido:yyyy-MM-dd HH:mm:ss}'," +
                                    $" {order.VrTotal.ToString(nfi)}, {order.VrTaxa.ToString(nfi)}, {order.VrTroco.ToString(nfi)}, '{order.Logradouro}'," +
                                    $" {order.Numero}, '{order.Bairro}', '{order.Cidade}', '{order.Estado}', '{order.CEP}'," +
                                    $" '{order.TipoPedido}', '{order.Origem}', '{order.Observacao}', '{order.FormaPagamento}', 1, '{order.IdOperador}');";
                            }
                            else
                            {
                                oCommand.CommandText =
                                    $"UPDATE TB_PEDIDO SET COD_CLIENTE={order.CodCliente}, STATUS_PEDIDO='{order.StatusPedido}'," +
                                    $" LOGRADOURO='{order.Logradouro}', NUMERO='{order.Numero}', FORMA_PAGAMENTO='{order.FormaPagamento}'," +
                                    $" BAIRRO='{order.Bairro}', CIDADE='{order.Cidade}', ESTADO='{order.Estado}', CEP='{order.CEP}'," +
                                    $" VR_TOTAL='{order.VrTotal.ToString(nfi)}', VR_TAXA='{order.VrTaxa.ToString(nfi)}'," +
                                    $" VR_TROCO='{order.VrTroco.ToString(nfi)}', TIPO_PEDIDO='{order.TipoPedido}'," +
                                    $" DATA_ATUALIZACAO='{DateTime.Now:yyyy-MM-dd HH:mm:ss}', OBSERVACAO='{order.Observacao}'," +
                                    $" IMPRIME_PEDIDO=1" +
                                    $" WHERE COD_PEDIDO={order.Id};";
                            }

                            if (oCommand.ExecuteNonQuery() != 1)
                                throw new InvalidProgramException();

                            if (type == "new")
                            {
                                oCommand.CommandText = "SELECT MAX(COD_PEDIDO) AS COD_PEDIDO FROM TB_PEDIDO";
                                _dr2 = oCommand.ExecuteReader();
                                while (_dr2.Read())
                                    nextOrderId = Convert.ToInt16(_dr2["COD_PEDIDO"]);
                            }
                            else
                                nextOrderId = order.Id;
                        }
                        catch (MySqlException e)
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

                    using (MySqlCommand oCommand = oConnection.CreateCommand())
                    {
                        oCommand.Transaction = oTransaction;
                        oCommand.CommandType = CommandType.Text;

                        try
                        {
                            foreach (var item in order.Itens)
                            {
                                if (item.StatusEditar != 2)
                                {
                                    oCommand.CommandText =
                                        $"INSERT INTO TB_PEDIDO_ITEM (COD_PEDIDO, COD_PRODUTO, QUANTIDADE, VR_UNITARIO, VR_TOTAL, OBSERVACAO)" +
                                        $" VALUES ({nextOrderId}, {item.CodProduto}, {item.Quantidade}, {item.VrUnitario.ToString(nfi)}," +
                                        $" {item.VrTotal.ToString(nfi)}, '{item.Observacao}');";

                                    if (oCommand.ExecuteNonQuery() != 1)
                                        throw new InvalidProgramException();
                                }
                            }
                        }
                        catch (MySqlException e)
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

        public int UpdateOrder(string status, int id)
        {
            var value = 0;
            try
            {
                _cmd.CommandText = $"UPDATE TB_PEDIDO SET STATUS_PEDIDO='{status}' WHERE COD_PEDIDO={id};";
                _cmd.Connection = _con.Connect();
                value = _cmd.ExecuteNonQuery();
            }
            catch (MySqlException e)
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

            return value;
        }
    }
}