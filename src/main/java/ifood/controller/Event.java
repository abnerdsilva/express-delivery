package ifood.controller;

import ifood.model.EventsAcknowledgment;
import ifood.model.EventsPolling;
import ifood.repository.EventsRepository;
import ifood.repository.OrderRepository;

import java.util.ArrayList;
import java.util.List;

public class Event {

    private static EventsRepository _eventRepository;
    private static OrderRepository _orderRepository;

    public Event() {
        _eventRepository = new EventsRepository();
        _orderRepository = new OrderRepository();
    }

    /**
     * consulta eventos na lista de polling do ifood
     * salva como cabeçalho na tabela TB_PEDIDO_INTEGRACAO
     * confirma ai ifood que o evento foi recebido e salvo
     */
    public static void getEventsPolling() {
        List<EventsPolling> events = _eventRepository.getEvents();
        if (events.size() > 0) {
            List<EventsAcknowledgment> eventsAcknowledgments = new ArrayList<>();

            for (EventsPolling e : events) {
                if (!_eventRepository.findEventHeader(e.getOrderId())) {
                    if (_eventRepository.saveEventHeader(e)) {
                        eventsAcknowledgments.add(new EventsAcknowledgment(e.getId()));
                    }
                } else {
                    if (_eventRepository.updateEventHeader(e)) {
                        eventsAcknowledgments.add(new EventsAcknowledgment(e.getId()));
                    }
                }

                if (e.getCode().equals("CAN")) {
                    System.out.println("CANCELAR PEDIDO");
                    _orderRepository.updateStatusOrderCancelled(e.getOrderId());
                }
            }

            _eventRepository.postEventsAcknowledgment(eventsAcknowledgments);
        }
    }
}
