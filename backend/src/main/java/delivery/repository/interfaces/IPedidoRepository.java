package delivery.repository.interfaces;

import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;

import java.sql.SQLException;
import java.util.List;

public interface IPedidoRepository {
    List<PedidoItemDao> loadItensByCode(String code);

    int loadMaxOrder() throws SQLException;

    String saveOrder(PedidoDao pedido);

    int saveOrderItem(PedidoItemDao item);

    int updateOrderPrinted(String idPedido);

    List<PedidoDao> getPedidosParaImprimir();

    List<PedidoDao> findAll();

    List<PedidoDao> getOrdersFromToday();

    List<PedidoDao> findAllByDate(String start, String end);

    List<PedidoDao> findAllByIntegracaoIfood();

    PedidoDao getOrderById(int id);

    PedidoDao getOrderByCode(String code);

    int updateStatusOrder(int id, String status);
}
