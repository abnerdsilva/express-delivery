package delivery.repository.interfaces;

import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;

import java.sql.SQLException;
import java.util.List;

public interface IPedidoRepository {
    List<PedidoItemDao> loadItensByCode(int code);

    int loadMaxOrder() throws SQLException;

    int saveOrder(PedidoDao pedido);

    int saveOrderItem(PedidoItemDao item);

    int updateOrderPrinted(int idPedido);

    List<PedidoDao> getPedidosParaImprimir();

    List<PedidoDao> getAll();

    PedidoDao getOrderById(int id);
}
