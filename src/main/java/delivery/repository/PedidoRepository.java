package delivery.repository;

import db.DatabaseConnection;
import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;
import delivery.repository.interfaces.IPedidoRepository;
import log.LoggerInFile;

import java.io.IOException;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

public class PedidoRepository implements IPedidoRepository {
    @Override
    public List<PedidoDao> loadAllOrders() throws IOException {
        return null;
    }

    @Override
    public PedidoDao loadOrderById(int idPedido) throws SQLException {
        String sql = "SELECT * FROM TB_PEDIDO WHERE COD_PEDIDO = ?";

        PedidoDao pedido = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setInt(1, idPedido);
            bd.rs = bd.st.executeQuery(sql);
            while (bd.rs.next()) {
                pedido = new PedidoDao();
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return pedido;
    }

    @Override
    public int loadMaxOrder() throws SQLException {
        String sql = "SELECT MAX(COD_PEDIDO) AS orderID FROM TB_PEDIDO";

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

    @Override
    public int saveOrder(PedidoDao pedido) throws Exception {
        String sql = "INSERT INTO TB_PEDIDO (COD_CLIENTE, DATA_PEDIDO, DATA_ENTREGA, VR_TOTAL, VR_TAXA, VR_TROCO, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP, TIPO_PEDIDO, ORIGEM, OBSERVACAO, FORMA_PAGAMENTO, cod_pedido_integracao) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();
        bd.connection.beginRequest();

        try {

            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setInt(1, pedido.getCodCliente());
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
            int resultInsert = bd.st.executeUpdate();
            if (resultInsert > 0) {
                int maxOrderId = loadMaxOrder();
                if (maxOrderId > 0) {
                    return maxOrderId;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }

    @Override
    public int saveOrderItem(PedidoItemDao item) throws Exception {
        String sql = "INSERT INTO TB_PEDIDO_ITEM (COD_PEDIDO, COD_PRODUTO, QUANTIDADE, VR_UNITARIO, VR_TOTAL, OBSERVACAO) VALUES (?,?,?,?,?,?)";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setInt(1, item.getCodPedido());
            bd.st.setInt(2, item.getCodProduto());
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

    @Override
    public int update(String idPedido) {
        return 0;
    }

    @Override
    public int delete(String idPedido) {
        return 0;
    }
}
