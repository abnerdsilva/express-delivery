package ifood.repository.interfaces;

import ifood.model.EventsAcknowledgment;
import ifood.model.EventsPolling;

import java.sql.SQLException;
import java.util.List;

public interface IEventsRepository {
    List<EventsPolling> getEvents();

    boolean saveEventHeader(EventsPolling event);

    boolean updateEventHeader(EventsPolling event);

    boolean findEventHeader(EventsPolling event) throws SQLException;

    void postEventsAcknowledgment(List<EventsAcknowledgment> eventsAcknowledgments);
}
