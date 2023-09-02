package ifood.model;

public class EventsAcknowledgment {
    String id;

    public EventsAcknowledgment(String id) {
        this.id = id;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    @Override
    public String toString() {
        return "{" +
                "\"id\":\"" + id + "\"" +
                "}";
    }
}
