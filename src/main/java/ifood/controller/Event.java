package ifood.controller;

import ifood.model.EventsAcknowledgment;
import ifood.model.EventsPolling;
import ifood.repository.EventsRepository;
import log.LoggerInFile;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class Event {

    private final static EventsRepository repository = new EventsRepository();

    /**
     * consulta eventos na lista de polling do ifood
     * salva como cabeçalho na tabela TB_PEDIDO_INTEGRACAO
     * confirma ai ifood que o evento foi recebido e salvo
     */
    public static void getEventsPolling() {
        List<EventsPolling> events = repository.getEvents();
        if (events.size() > 0) {
            List<EventsAcknowledgment> eventsAcknowledgments = new ArrayList<>();

            for (EventsPolling e : events) {
                if (!repository.findEventHeader(e.getOrderId())) {
                    if (repository.saveEventHeader(e)) {
                        eventsAcknowledgments.add(new EventsAcknowledgment(e.getId()));
                    }
                } else {
                    if (repository.updateEventHeader(e)) {
                        eventsAcknowledgments.add(new EventsAcknowledgment(e.getId()));
                    }
                }
            }

            repository.postEventsAcknowledgment(eventsAcknowledgments);
        }
    }
}
