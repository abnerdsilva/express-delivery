package ifood.repository.interfaces;


import ifood.model.Order;
import ifood.model.OrderIntegration;
import ifood.model.dao.PedidoDao;

import java.sql.SQLException;
import java.util.List;

public interface IOrderRepository {

    List<OrderIntegration> getOrdersPendingToConfirmation() throws SQLException;

    Order getOrderDetails(String orderId);

    boolean updateOrderId(int id, String codPedidoIntegracao);

    boolean confirmProductionOrder(String codPedidoIntegracao);

    boolean confirmDispatchOrder(String codPedidoIntegracao);

    List<PedidoDao> getOrdersToDispatch() throws SQLException;
}
