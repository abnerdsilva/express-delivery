package delivery;

import java.util.Map;

public class Erro implements MessageException{
    public String message;

    public Erro(String message) {
        this.message = message;
    }

    @Override
    public String getExceptionKey() {
        return null;
    }

    @Override
    public Map<String, Object> getMapDetails() {
        return null;
    }
}
