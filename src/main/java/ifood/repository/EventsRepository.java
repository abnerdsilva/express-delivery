package ifood.repository;

import com.google.gson.Gson;
import db.DatabaseConnection;
import ifood.model.EventsAcknowledgment;
import ifood.model.EventsPolling;
import ifood.repository.interfaces.IEventsRepository;
import ifood.utils.Geral;
import log.LoggerInFile;
import okhttp3.*;

import java.io.IOException;
import java.sql.Connection;
import java.sql.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static ifood.utils.Geral.JSON_APPLICATION;
import static ifood.utils.Geral.URL_BASE_IFOOD;

public class EventsRepository implements IEventsRepository {

    private final OkHttpClient client = new OkHttpClient();
    private Connection connection;

    @Override
    public List<EventsPolling> getEvents() {
        final String url = URL_BASE_IFOOD + "/order/v1.0/events:polling";
        Request request = new Request.Builder()
                .url(url)
                .header("Authorization", Geral.accessToken)
                .build();

        Gson gson = new Gson();
        ResponseBody responseBody;
        try {
            Response response = client.newCall(request).execute();
            responseBody = response.body();

            if (response.code() != 200) {
                if (response.code() != 204) {
                    LoggerInFile.printError(responseBody.string());
                }
                return new ArrayList<>();
            }
        } catch (IOException e) {
            LoggerInFile.printError(e.getMessage());
            return new ArrayList<>();
        }

        try {
            EventsPolling[] events = gson.fromJson(responseBody.string(), EventsPolling[].class);
            return new ArrayList<>(Arrays.asList(events));
        } catch (IOException e) {
            e.printStackTrace();
        }

        return new ArrayList<>();
    }

    @Override
    public boolean saveEventHeader(EventsPolling event) {
        String sql = "INSERT INTO TB_PEDIDO_INTEGRACAO VALUES ("
//                + 0 + ", "
                + "'" + event.getId() + "', "
                + "'" + event.getOrderId() + "', "
                + "'" + event.getCreatedAt() + "', "
                + "'" + event.getFullCode() + "', "
                + "'" + event.getCode() + "', "
                + 0 + ")";

        try {
            DatabaseConnection.connect();
        } catch (SQLException ex) {
            ex.printStackTrace();
        }
        connection = DatabaseConnection.connection;

        try {
            PreparedStatement stmt = connection.prepareStatement(sql);

            int resultInsert = stmt.executeUpdate();
            if (resultInsert > 0) {
                return true;
            }
        } catch (Exception er) {
            er.printStackTrace();
            LoggerInFile.printError(er.getMessage());
        } finally {
            try {
                DatabaseConnection.disconnect();
            } catch (SQLException e) {
                e.printStackTrace();
                LoggerInFile.printError(e.getMessage());
            }
        }

        return false;
    }

    @Override
    public boolean updateEventHeader(EventsPolling event) {
        String sql = "UPDATE TB_PEDIDO_INTEGRACAO SET"
                + " status_integracao='" + event.getFullCode() + "',"
                + " codigo_status_integracao='" + event.getCode() + "'"
                + " WHERE cod_pedido_integracao='" + event.getOrderId() + "';";

        try {
            DatabaseConnection.connect();
        } catch (SQLException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
            return false;
        }

        connection = DatabaseConnection.connection;
        try {
            PreparedStatement stmt = connection.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
            int result = stmt.executeUpdate();
            if (result > 0) {
                System.out.println("Generated: " + result);
            }

            return true;
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return false;
    }

    @Override
    public boolean findEventHeader(EventsPolling event) throws SQLException {
        String sql = "SELECT * FROM TB_PEDIDO_INTEGRACAO WHERE cod_pedido_integracao = ?";

        DatabaseConnection.connect();
        connection = DatabaseConnection.connection;

        try {
            PreparedStatement stmt = connection.prepareStatement(sql);
            stmt.setString(1, event.getOrderId());
            ResultSet resultSet = stmt.executeQuery();
            if (resultSet.next()) {
                if (resultSet.getInt(1) > 0) {
                    return true;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return false;
    }

    @Override
    public void postEventsAcknowledgment(List<EventsAcknowledgment> eventsAcknowledgments) {
        final String url = URL_BASE_IFOOD + "/order/v1.0/events/acknowledgment";
        final String stringBody = eventsAcknowledgments.toString();
        RequestBody body = RequestBody.create(stringBody, JSON_APPLICATION);
        Request request = new Request.Builder()
                .url(url)
                .header("Authorization", Geral.accessToken)
                .header("Content-type", "application/json")
                .post(body)
                .build();

        try {
            Response response = client.newCall(request).execute();
            ResponseBody responseBody = response.body();

            if (response.code() != 202) {
                LoggerInFile.printError(responseBody.string());
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
