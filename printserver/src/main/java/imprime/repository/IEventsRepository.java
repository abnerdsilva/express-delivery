package imprime.repository;

import imprime.model.PedidoDelivery;

import java.util.List;

public interface IEventsRepository {
    List<PedidoDelivery> getEvents(String token);

    boolean setOrderPrinted(String code, String token);
}
