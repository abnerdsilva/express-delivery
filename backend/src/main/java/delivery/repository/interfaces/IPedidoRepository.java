package delivery.repository.interfaces;

import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;

import java.sql.SQLException;
import java.util.List;

public interface IPedidoRepository {
    List<PedidoItemDao> loadItensByCode(String code);

    PedidoDao loadMaxOrder() throws SQLException;

    String saveOrder(PedidoDao pedido);

    int saveOrderItem(PedidoItemDao item);

    int updateOrderPrinted(String idPedido);

    List<PedidoDao> getPedidosParaImprimir();

    List<PedidoDao> findAll();

    List<PedidoDao> getOrdersFromToday();

    List<PedidoDao> findAllByDate(String start, String end);

    List<PedidoDao> findAllByDateAndStatus(String start, String end, String status);

    List<PedidoDao> findAllByIntegracaoIfood();

    List<PedidoDao> getOrdersByIdAndStatus(String status, int id);

    List<PedidoDao> getOrdersByStatus(String status);

    PedidoDao getOrderById(int id);

    PedidoDao getOrderByCode(String code);

    int updateStatusOrder(int id, String status);

    int updateOrder(PedidoDao order);
}
