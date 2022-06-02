package delivery.repository.interfaces;

import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;

import java.io.IOException;
import java.sql.SQLException;
import java.util.List;

public interface IPedidoRepository {
    List<PedidoDao> loadAllOrders() throws IOException;

    PedidoDao loadOrderById(int idPedido) throws IOException, SQLException;

    int loadMaxOrder() throws SQLException;

    int saveOrder(PedidoDao pedido) throws Exception;

    int saveOrderItem(PedidoItemDao item) throws Exception;

    int update(String idPedido);

    int delete(String idPedido);
}
