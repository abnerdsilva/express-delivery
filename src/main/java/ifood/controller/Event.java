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

    public static void getEventsPolling() {
        List<EventsPolling> events = repository.getEvents();
        if (events.size() > 0) {
            List<EventsAcknowledgment> eventsAcknowledgments = new ArrayList<>();

            for (EventsPolling e : events) {
                try {
                    if (!repository.findEventHeader(e)) {
                        if (repository.saveEventHeader(e)) {
                            eventsAcknowledgments.add(new EventsAcknowledgment(e.getId()));
                        }
                    } else {
                        if (repository.updateEventHeader(e)) {
                            eventsAcknowledgments.add(new EventsAcknowledgment(e.getId()));
                        }
                    }
                } catch (SQLException ex) {
                    LoggerInFile.printError(ex.getMessage());
                }
            }

            repository.postEventsAcknowledgment(eventsAcknowledgments);
        }

        events.forEach(p -> System.out.println(p.toString()));
    }
}
