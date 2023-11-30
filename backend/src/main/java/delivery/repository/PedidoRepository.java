package delivery.repository;

import db.DatabaseConnection;
import delivery.model.dao.ClienteDao;
import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;
import delivery.repository.interfaces.IPedidoRepository;
import log.LoggerInFile;
import org.springframework.stereotype.Repository;

import java.sql.PreparedStatement;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

@Repository
public class PedidoRepository implements IPedidoRepository {
    /**
     * consulta itens do pedido de acordo com codigo do pedido
     *
     * @param code - codigo do pedido que será consultado
     * @return - retorna lista com itens do pedido
     */
    @Override
    public List<PedidoItemDao> loadItensByCode(String code) {
        String sql = "SELECT * FROM TB_PEDIDO_ITEM" +
                " INNER JOIN TB_PRODUTO TP on (TP.COD_PRODUTO = TB_PEDIDO_ITEM.COD_PRODUTO)" +
                " WHERE COD_PEDIDO = '" + code + "'";

        List<PedidoItemDao> itens = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoItemDao item = new PedidoItemDao();
                item.setCodPedido(bd.rs.getString("cod_pedido"));
                item.setCodPedidoItem(bd.rs.getString("cod_pedido_item"));
                item.setCodProduto(bd.rs.getString("cod_produto"));
                item.setObservacao(bd.rs.getString("observacao"));
                item.setQuantidade(bd.rs.getInt("quantidade"));
                item.setVrTotal(bd.rs.getDouble("vr_total"));
                item.setVrUnitario(bd.rs.getDouble("vr_unitario"));
                item.setNome(bd.rs.getString("nome"));

                itens.add(item);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return itens;
    }

    /**
     * consulta codigo do ultimo pedido cadastrado
     *
     * @return - retorna codigo do ultimo pedido ou -1 quando ocorre erro
     */
    @Override
    public int loadMaxOrder() {
        String sql = "SELECT MAX(ID) AS orderID FROM TB_PEDIDO";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                return bd.rs.getInt(1);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }

    /**
     * salva dados do pedido
     *
     * @param pedido - informações do pedido
     * @return - retorna id do pedido cadastado ou -1 quando ocorre erro
     */
    @Override
    public String saveOrder(PedidoDao pedido) {
        String sql = "INSERT INTO TB_PEDIDO (COD_CLIENTE, DATA_PEDIDO, DATA_ENTREGA, VR_TOTAL, VR_TAXA, VR_TROCO," +
                " LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP, TIPO_PEDIDO, ORIGEM, OBSERVACAO, FORMA_PAGAMENTO," +
                " cod_pedido_integracao, COD_USUARIO, COD_PEDIDO) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

        var uid = UUID.randomUUID();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();
        try {
            bd.connection.beginRequest();
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, pedido.getCliente().getCodCliente());
            bd.st.setString(2, pedido.getDataPedido());
            bd.st.setString(3, pedido.getDataEntrega());
            bd.st.setDouble(4, pedido.getVrTotal());
            bd.st.setDouble(5, pedido.getVrTaxa());
            bd.st.setDouble(6, pedido.getVrTroco());
            bd.st.setString(7, pedido.getLogradouro());
            bd.st.setInt(8, pedido.getNumero());
            bd.st.setString(9, pedido.getBairro());
            bd.st.setString(10, pedido.getCidade());
            bd.st.setString(11, pedido.getEstado());
            bd.st.setString(12, pedido.getCep());
            bd.st.setString(13, pedido.getTipoPedido());
            bd.st.setString(14, pedido.getOrigem());
            bd.st.setString(15, pedido.getObservacao());
            bd.st.setString(16, pedido.getFormaPagamento());
            bd.st.setString(17, pedido.getCodPedidoIntegracao());
            bd.st.setString(18, "VERIFICAR");
            bd.st.setString(19, uid.toString());

            int resultInsert = bd.st.executeUpdate();
            if (resultInsert > 0) {
                return uid.toString();
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return "-1";
    }

    /**
     * salva item do pedido
     *
     * @param item - informações do item
     * @return - retorna id do item do pedido que foi salvo ou -1 quando ocorre erro
     */
    @Override
    public int saveOrderItem(PedidoItemDao item) {
        String sql = "INSERT INTO TB_PEDIDO_ITEM (COD_PEDIDO, COD_PRODUTO, QUANTIDADE, VR_UNITARIO, VR_TOTAL," +
                " OBSERVACAO, COD_PEDIDO_ITEM) VALUES (?,?,?,?,?,?, uuid())";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, item.getCodPedido());
            bd.st.setString(2, item.getCodProduto());
            bd.st.setInt(3, item.getQuantidade());
            bd.st.setDouble(4, item.getVrUnitario());
            bd.st.setDouble(5, item.getVrTotal());
            bd.st.setString(6, item.getObservacao());

            return bd.st.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }

    /**
     * atualiza status de impresso o pedido para 0
     *
     * @param idPedido - id do pedido que será atualizado
     * @return - retorna 1 para atualizado e -1 quando ocorre erro
     */
    @Override
    public int updateOrderPrinted(String idPedido) {
        int ret = -1;

        String insertSql = "UPDATE TB_PEDIDO SET IMPRIME_PEDIDO=0 WHERE COD_PEDIDO = ?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            PreparedStatement prepsInsertProduct = bd.connection.prepareStatement(insertSql, Statement.RETURN_GENERATED_KEYS);
            prepsInsertProduct.setString(1, idPedido);
            prepsInsertProduct.execute();
            bd.rs = prepsInsertProduct.getGeneratedKeys();

            if (bd.rs.next()) {
                return 1;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return ret;
    }

    /**
     * consulta pedidos que estão com status de imprime_pedido = 1
     *
     * @return - retorna lista com pedidos pendentes para imprimir
     */
    @Override
    public List<PedidoDao> getPedidosParaImprimir() {
        String sql = "SELECT * FROM TB_PEDIDO WHERE IMPRIME_PEDIDO = 1";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoDao pedido = new PedidoDao();
                pedido.setCodPedido(bd.rs.getString("cod_pedido"));
                pedido.setCodPedidoIntegracao(bd.rs.getString("cod_pedido_integracao"));
                pedido.setDataEntrega(bd.rs.getString("data_entrega"));
                pedido.setDataPedido(bd.rs.getString("data_pedido"));
                pedido.setLogradouro(bd.rs.getString("logradouro"));
                pedido.setNumero(bd.rs.getInt("numero"));
                pedido.setBairro(bd.rs.getString("bairro"));
                pedido.setCidade(bd.rs.getString("cidade"));
                pedido.setEstado(bd.rs.getString("estado"));
                pedido.setCep(bd.rs.getString("cep"));
                pedido.setTipoPedido(bd.rs.getString("tipo_pedido"));
                pedido.setOrigem(bd.rs.getString("origem"));
                pedido.setObservacao(bd.rs.getString("observacao"));
                pedido.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                pedido.setFormaPagamento(bd.rs.getString("forma_pagamento"));
                pedido.setCodCliente(bd.rs.getString("cod_cliente"));
                pedido.setVrTotal(bd.rs.getDouble("vr_total"));
                pedido.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                pedido.setVrTroco(bd.rs.getDouble("vr_troco"));

                pedidos.add(pedido);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return pedidos;
    }

    @Override
    public List<PedidoDao> getOrdersFromToday() {
        String sql = "SELECT * FROM TB_PEDIDO WHERE DATA_PEDIDO > CURRENT_DATE()";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoDao pedido = new PedidoDao();
                pedido.setCodPedido(bd.rs.getString("cod_pedido"));
                pedido.setCodPedidoIntegracao(bd.rs.getString("cod_pedido_integracao"));
                pedido.setDataEntrega(bd.rs.getString("data_entrega"));
                pedido.setDataPedido(bd.rs.getString("data_pedido"));
                pedido.setLogradouro(bd.rs.getString("logradouro"));
                pedido.setNumero(bd.rs.getInt("numero"));
                pedido.setBairro(bd.rs.getString("bairro"));
                pedido.setCidade(bd.rs.getString("cidade"));
                pedido.setEstado(bd.rs.getString("estado"));
                pedido.setCep(bd.rs.getString("cep"));
                pedido.setTipoPedido(bd.rs.getString("tipo_pedido"));
                pedido.setOrigem(bd.rs.getString("origem"));
                pedido.setObservacao(bd.rs.getString("observacao"));
                pedido.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                pedido.setFormaPagamento(bd.rs.getString("forma_pagamento"));
                pedido.setCodCliente(bd.rs.getString("cod_cliente"));
                pedido.setVrTotal(bd.rs.getDouble("vr_total"));
                pedido.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                pedido.setVrTroco(bd.rs.getDouble("vr_troco"));
                pedido.setStatusPedido(bd.rs.getString("status_pedido"));

                pedidos.add(pedido);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return pedidos;
    }

    @Override
    public List<PedidoDao> findAllByDate(String start, String end) {
        String sql = "SELECT TB_PEDIDO.*, NOME FROM TB_PEDIDO" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TB_PEDIDO.COD_CLIENTE" +
                " WHERE DATA_PEDIDO BETWEEN ? AND ?";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, start);
            bd.st.setString(2, end);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoDao pedido = new PedidoDao();
                pedido.setCodPedido(bd.rs.getString("cod_pedido"));
                pedido.setCodPedidoIntegracao(bd.rs.getString("cod_pedido_integracao"));
                pedido.setStatusPedido(bd.rs.getString("status_pedido"));
                pedido.setDataEntrega(bd.rs.getString("data_entrega"));
                pedido.setDataPedido(bd.rs.getString("data_pedido"));
                pedido.setLogradouro(bd.rs.getString("logradouro"));
                pedido.setNumero(bd.rs.getInt("numero"));
                pedido.setBairro(bd.rs.getString("bairro"));
                pedido.setCidade(bd.rs.getString("cidade"));
                pedido.setEstado(bd.rs.getString("estado"));
                pedido.setCep(bd.rs.getString("cep"));
                pedido.setTipoPedido(bd.rs.getString("tipo_pedido"));
                pedido.setOrigem(bd.rs.getString("origem"));
                pedido.setObservacao(bd.rs.getString("observacao"));
                pedido.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                pedido.setFormaPagamento(bd.rs.getString("forma_pagamento"));
                pedido.setCodCliente(bd.rs.getString("cod_cliente"));
                pedido.setVrTotal(bd.rs.getDouble("vr_total"));
                pedido.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                pedido.setVrTroco(bd.rs.getDouble("vr_troco"));
                pedido.setId(bd.rs.getInt("id"));
                pedido.setCodUsuario(bd.rs.getString("cod_usuario"));

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));

                pedido.setCliente(cliente);

                pedidos.add(pedido);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return pedidos;
    }

    @Override
    public List<PedidoDao> findAllByIntegracaoIfood() {
        String sql = "SELECT COD_PEDIDO, DATA_PEDIDO FROM TB_PEDIDO WHERE STATUS_PEDIDO='ABERTO' AND ORIGEM='IFOOD'" +
                " AND cod_pedido_integracao IS NOT NULL AND DATA_ATUALIZACAO IS NULL ORDER BY DATA_PEDIDO DESC";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoDao pedido = new PedidoDao();
                pedido.setCodPedido(bd.rs.getString("cod_pedido"));
                pedido.setCodPedidoIntegracao(bd.rs.getString("cod_pedido_integracao"));
                pedido.setDataEntrega(bd.rs.getString("data_entrega"));
                pedido.setDataPedido(bd.rs.getString("data_pedido"));
                pedido.setLogradouro(bd.rs.getString("logradouro"));
                pedido.setNumero(bd.rs.getInt("numero"));
                pedido.setBairro(bd.rs.getString("bairro"));
                pedido.setCidade(bd.rs.getString("cidade"));
                pedido.setEstado(bd.rs.getString("estado"));
                pedido.setCep(bd.rs.getString("cep"));
                pedido.setTipoPedido(bd.rs.getString("tipo_pedido"));
                pedido.setOrigem(bd.rs.getString("origem"));
                pedido.setObservacao(bd.rs.getString("observacao"));
                pedido.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                pedido.setFormaPagamento(bd.rs.getString("forma_pagamento"));
                pedido.setCodCliente(bd.rs.getString("cod_cliente"));
                pedido.setVrTotal(bd.rs.getDouble("vr_total"));
                pedido.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                pedido.setVrTroco(bd.rs.getDouble("vr_troco"));

                pedidos.add(pedido);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return pedidos;
    }

    @Override
    public PedidoDao getOrderById(int code) {
        String sql = "SELECT * FROM TB_PEDIDO WHERE ID = " + code;

        PedidoDao order = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();

            if (bd.rs.next()) {
                PedidoDao pedido = new PedidoDao();
                pedido.setId(bd.rs.getInt("id"));
                pedido.setCodPedido(bd.rs.getString("cod_pedido"));
                pedido.setCodPedidoIntegracao(bd.rs.getString("cod_pedido_integracao"));
                pedido.setDataEntrega(bd.rs.getString("data_entrega"));
                pedido.setDataPedido(bd.rs.getString("data_pedido"));
                pedido.setLogradouro(bd.rs.getString("logradouro"));
                pedido.setNumero(bd.rs.getInt("numero"));
                pedido.setBairro(bd.rs.getString("bairro"));
                pedido.setCidade(bd.rs.getString("cidade"));
                pedido.setEstado(bd.rs.getString("estado"));
                pedido.setCep(bd.rs.getString("cep"));
                pedido.setTipoPedido(bd.rs.getString("tipo_pedido"));
                pedido.setOrigem(bd.rs.getString("origem"));
                pedido.setObservacao(bd.rs.getString("observacao"));
                pedido.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                pedido.setFormaPagamento(bd.rs.getString("forma_pagamento"));
                pedido.setCodCliente(bd.rs.getString("cod_cliente"));
                pedido.setVrTotal(bd.rs.getDouble("vr_total"));
                pedido.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                pedido.setVrTroco(bd.rs.getDouble("vr_troco"));
                pedido.setStatusPedido(bd.rs.getString("status_pedido"));

                order = pedido;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return order;
    }

    @Override
    public PedidoDao getOrderByCode(String code) {
        String sql = "SELECT * FROM TB_PEDIDO WHERE COD_PEDIDO = '" + code + "'";

        PedidoDao order = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();

            if (bd.rs.next()) {
                PedidoDao pedido = new PedidoDao();
                pedido.setCodPedido(bd.rs.getString("cod_pedido"));
                pedido.setCodPedidoIntegracao(bd.rs.getString("cod_pedido_integracao"));
                pedido.setDataEntrega(bd.rs.getString("data_entrega"));
                pedido.setDataPedido(bd.rs.getString("data_pedido"));
                pedido.setLogradouro(bd.rs.getString("logradouro"));
                pedido.setNumero(bd.rs.getInt("numero"));
                pedido.setBairro(bd.rs.getString("bairro"));
                pedido.setCidade(bd.rs.getString("cidade"));
                pedido.setEstado(bd.rs.getString("estado"));
                pedido.setCep(bd.rs.getString("cep"));
                pedido.setTipoPedido(bd.rs.getString("tipo_pedido"));
                pedido.setOrigem(bd.rs.getString("origem"));
                pedido.setObservacao(bd.rs.getString("observacao"));
                pedido.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                pedido.setFormaPagamento(bd.rs.getString("forma_pagamento"));
                pedido.setCodCliente(bd.rs.getString("cod_cliente"));
                pedido.setVrTotal(bd.rs.getDouble("vr_total"));
                pedido.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                pedido.setVrTroco(bd.rs.getDouble("vr_troco"));
                pedido.setStatusPedido(bd.rs.getString("status_pedido"));
                pedido.setId(bd.rs.getInt("id"));
                pedido.setCodUsuario(bd.rs.getString("cod_usuario"));

                order = pedido;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return order;
    }

    @Override
    public int updateStatusOrder(int id, String status) {
        int ret = -1;

        String insertSql = "UPDATE TB_PEDIDO SET STATUS_PEDIDO=? WHERE COD_PEDIDO = ?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            PreparedStatement ps = bd.connection.prepareStatement(insertSql, Statement.RETURN_GENERATED_KEYS);
            ps.setString(1, status);
            ps.setInt(2, id);
            ps.execute();
            bd.rs = ps.getGeneratedKeys();

            if (bd.rs.next()) {
                return 1;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return ret;
    }

    @Override
    public List<PedidoDao> findAll() {
        String sql = "SELECT * FROM TB_PEDIDO";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoDao pedido = new PedidoDao();
                pedido.setCodPedido(bd.rs.getString("cod_pedido"));
                pedido.setCodPedidoIntegracao(bd.rs.getString("cod_pedido_integracao"));
                pedido.setDataEntrega(bd.rs.getString("data_entrega"));
                pedido.setDataPedido(bd.rs.getString("data_pedido"));
                pedido.setLogradouro(bd.rs.getString("logradouro"));
                pedido.setNumero(bd.rs.getInt("numero"));
                pedido.setBairro(bd.rs.getString("bairro"));
                pedido.setCidade(bd.rs.getString("cidade"));
                pedido.setEstado(bd.rs.getString("estado"));
                pedido.setCep(bd.rs.getString("cep"));
                pedido.setTipoPedido(bd.rs.getString("tipo_pedido"));
                pedido.setOrigem(bd.rs.getString("origem"));
                pedido.setObservacao(bd.rs.getString("observacao"));
                pedido.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                pedido.setFormaPagamento(bd.rs.getString("forma_pagamento"));
                pedido.setCodCliente(bd.rs.getString("cod_cliente"));
                pedido.setVrTotal(bd.rs.getDouble("vr_total"));
                pedido.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                pedido.setVrTroco(bd.rs.getDouble("vr_troco"));

                pedidos.add(pedido);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return pedidos;
    }
}
