package ifood.repository.interfaces;

import ifood.model.EventsAcknowledgment;
import ifood.model.EventsPolling;

import java.util.List;

public interface IEventsRepository {
    List<EventsPolling> getEvents();

    boolean saveEventHeader(EventsPolling event);

    boolean updateEventHeader(EventsPolling event);

    boolean findEventHeader(String orderId);

    void postEventsAcknowledgment(List<EventsAcknowledgment> eventsAcknowledgments);
}
