package delivery.repository;

import db.DatabaseConnection;
import log.LoggerInFile;
import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;
import delivery.repository.interfaces.IPedidoRepository;

import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.List;

public class PedidoRepository implements IPedidoRepository {
    private ResultSet resultSet;
    private Connection connection;

    @Override
    public List<PedidoDao> loadAllOrders() throws IOException {
        return null;
    }

    @Override
    public PedidoDao loadOrderById(int idPedido) throws SQLException {
        String sql = "SELECT * FROM TB_PEDIDO WHERE COD_PEDIDO = ?";

        PedidoDao pedido = null;

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            PreparedStatement stmt = connection.prepareStatement(sql);
            stmt.setInt(1, idPedido);
            resultSet = stmt.executeQuery(sql);
            while (resultSet.next()) {
                pedido = new PedidoDao();
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            DatabaseConnection.disconnect();
        }

        return pedido;
    }

    @Override
    public int loadMaxOrder() throws SQLException {
        String sql = "SELECT MAX(COD_PEDIDO) AS orderID FROM TB_PEDIDO";

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            PreparedStatement stmt = connection.prepareStatement(sql);
            resultSet = stmt.executeQuery();
            if (resultSet.next()) {
                return resultSet.getInt(1);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            DatabaseConnection.disconnect();
        }

        return -1;
    }

    @Override
    public int saveOrder(PedidoDao pedido) throws Exception {
        String sql = "INSERT INTO TB_PEDIDO (COD_CLIENTE, DATA_PEDIDO, DATA_ENTREGA, VR_TOTAL, VR_TAXA, VR_TROCO, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP, TIPO_PEDIDO, ORIGEM, OBSERVACAO, FORMA_PAGAMENTO, cod_pedido_integracao) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;
            connection.beginRequest();

            PreparedStatement stmt = connection.prepareStatement(sql);
            stmt.setInt(1, pedido.getCodCliente());
            stmt.setString(2, pedido.getDataPedido());
            stmt.setString(3, pedido.getDataEntrega());
            stmt.setDouble(4, pedido.getVrTotal());
            stmt.setDouble(5, pedido.getVrTaxa());
            stmt.setDouble(6, pedido.getVrTroco());
            stmt.setString(7, pedido.getLogradouro());
            stmt.setInt(8, pedido.getNumero());
            stmt.setString(9, pedido.getBairro());
            stmt.setString(10, pedido.getCidade());
            stmt.setString(11, pedido.getEstado());
            stmt.setString(12, pedido.getCep());
            stmt.setString(13, pedido.getTipoPedido());
            stmt.setString(14, pedido.getOrigem());
            stmt.setString(15, pedido.getObservacao());
            stmt.setString(16, pedido.getFormaPagamento());
            stmt.setString(17, pedido.getCodPedidoIntegracao());
            int resultInsert = stmt.executeUpdate();
            if (resultInsert > 0) {
                int maxOrderId = loadMaxOrder();
                if (maxOrderId > 0) {
                    return maxOrderId;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
            connection.rollback();
        } finally {
            DatabaseConnection.disconnect();
        }

        return -1;
    }

    @Override
    public int saveOrderItem(PedidoItemDao item) throws Exception {
        String sql = "INSERT INTO TB_PEDIDO_ITEM (COD_PEDIDO, COD_PRODUTO, QUANTIDADE, VR_UNITARIO, VR_TOTAL, OBSERVACAO) VALUES (?,?,?,?,?,?)";

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            PreparedStatement stmt = connection.prepareStatement(sql);
            stmt.setInt(1, item.getCodPedido());
            stmt.setInt(2, item.getCodProduto());
            stmt.setInt(3, item.getQuantidade());
            stmt.setDouble(4, item.getVrUnitario());
            stmt.setDouble(5, item.getVrTotal());
            stmt.setString(6, item.getObservacao());

            int result = stmt.executeUpdate();
            connection.commit();
            return result;
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
            connection.rollback();
        } finally {
            DatabaseConnection.disconnect();
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
