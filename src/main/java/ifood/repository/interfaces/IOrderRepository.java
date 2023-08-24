package ifood.repository.interfaces;


import ifood.model.Order;
import ifood.model.OrderIntegration;
import ifood.model.dao.PedidoDao;

import java.util.List;

public interface IOrderRepository {

    List<OrderIntegration> getOrdersPendingToConfirmation();

    Order getOrderDetails(String orderId);

    boolean updateOrderId(int id, String codPedidoIntegracao);

    boolean confirmProductionOrder(String codPedidoIntegracao);

    boolean confirmDispatchOrder(String codPedidoIntegracao);

    List<PedidoDao> getOrdersToConfirmProduction();

    List<PedidoDao> getOrdersToDispatch();

    boolean hasOrderLaunched(String code);

    boolean updateStatusSyncOrder(String code);

    int updateStatusOrderCancelled(String code);
}
