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
    public PedidoDao loadMaxOrder() {
        String sql = "SELECT * FROM TB_PEDIDO TP" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TP.COD_CLIENTE" +
                " ORDER BY TP.ID DESC LIMIT 1";

        PedidoDao pedido = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                pedido = new PedidoDao();
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

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

                pedido.setCliente(cliente);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return pedido;
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
        String sql = "SELECT * FROM TB_PEDIDO TP" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TP.COD_CLIENTE" +
                " WHERE IMPRIME_PEDIDO = 1";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
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

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

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
    public List<PedidoDao> getOrdersFromToday() {
        String sql = "SELECT * FROM TB_PEDIDO TP" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TP.COD_CLIENTE" +
                " WHERE DATA_PEDIDO > SUBDATE(now(), INTERVAL 3 hour)";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
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

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

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
    public List<PedidoDao> findAllByDateAndStatus(String start, String end, String status) {
        String sql = "SELECT * FROM TB_PEDIDO" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TB_PEDIDO.COD_CLIENTE";

        String where = " WHERE STATUS_PEDIDO = '" + status + "' AND DATA_PEDIDO BETWEEN '" + start + "' AND '" + end + " 23:59:59'";
        if (status.equals("TODOS") || status.isEmpty()) {
            where = " WHERE DATA_PEDIDO BETWEEN '" + start + "' AND '" + end + " 23:59:59'";
        }

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        sql = sql + where;

        try {
            bd.st = bd.connection.prepareStatement(sql);
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
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

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
    public List<PedidoDao> findAllByDate(String start, String end) {
        String sql = "SELECT TB_PEDIDO.*, NOME FROM TB_PEDIDO" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TB_PEDIDO.COD_CLIENTE" +
                " WHERE DATA_PEDIDO BETWEEN '" + start + "' AND '" + end + " 23:59:59'";

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
        String sql = "SELECT * FROM TB_PEDIDO TP" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TP.COD_CLIENTE" +
                " WHERE STATUS_PEDIDO='ABERTO' AND ORIGEM='IFOOD'" +
                " AND cod_pedido_integracao IS NOT NULL AND DATA_ATUALIZACAO IS NULL ORDER BY DATA_PEDIDO DESC";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
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

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

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
    public List<PedidoDao> getOrdersByIdAndStatus(String status, int id) {
        String sql = "SELECT * FROM TB_PEDIDO TP" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TP.COD_CLIENTE";

        String where = " WHERE STATUS_PEDIDO = '" + status + "' AND TP.ID = ?";
        if (status.equals("TODOS")) {
            where = " WHERE TP.ID = ?";
        }

        sql = sql + where;

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setInt(1, id);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoDao pedido = new PedidoDao();
                pedido.setId(bd.rs.getInt("id"));
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
                pedido.setCodUsuario(bd.rs.getString("cod_usuario"));

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

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
    public List<PedidoDao> getOrdersByStatus(String status) {
        String sql = "SELECT * FROM TB_PEDIDO" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TB_PEDIDO.COD_CLIENTE" +
                " WHERE STATUS_PEDIDO = '" + status + "'";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoDao pedido = new PedidoDao();
                pedido.setId(bd.rs.getInt("id"));
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
                pedido.setCodUsuario(bd.rs.getString("cod_usuario"));

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

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
    public PedidoDao getOrderById(int code) {
        String sql = "SELECT * FROM TB_PEDIDO TP" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TP.COD_CLIENTE" +
                " WHERE TP.ID = " + code;

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

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

                pedido.setCliente(cliente);

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
        String sql = "SELECT * FROM TB_PEDIDO TP" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TP.COD_CLIENTE" +
                " WHERE COD_PEDIDO = '" + code + "'";

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
                pedido.setCodUsuario(bd.rs.getString("cod_usuario"));

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

                pedido.setCliente(cliente);

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

        String insertSql = "UPDATE TB_PEDIDO SET STATUS_PEDIDO=?, DATA_ATUALIZACAO=current_timestamp() WHERE ID = ?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(insertSql);
//            PreparedStatement ps = bd.connection.prepareStatement(insertSql, Statement.RETURN_GENERATED_KEYS);
            bd.st.setString(1, status);
            bd.st.setInt(2, id);
//            ps.execute();
            return bd.st.executeUpdate();
//            bd.rs = ps.getGeneratedKeys();

//            if (bd.rs.next()) {
//                return 1;
//            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return ret;
    }

    @Override
    public int updateOrder(PedidoDao order) {
        int ret = -1;

        String insertSql = "UPDATE TB_PEDIDO SET VR_TAXA=?, VR_TOTAL=?, VR_TROCO=?, OBSERVACAO=?," +
                " DATA_ATUALIZACAO=current_timestamp() WHERE ID = ?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(insertSql);
            bd.st.setDouble(1, order.getVrTaxa());
            bd.st.setDouble(2, order.getVrTotal());
            bd.st.setDouble(3, order.getVrTroco());
            bd.st.setString(4, order.getObservacao());
            bd.st.setInt(5, order.getId());
            return bd.st.executeUpdate();
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
        String sql = "SELECT * FROM TB_PEDIDO TP" +
                " INNER JOIN TB_CLIENTE TC on TC.COD_CLIENTE = TP.COD_CLIENTE";

        List<PedidoDao> pedidos = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
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

                var cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getString("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setObservacao(bd.rs.getString("observacao"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));

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
}
