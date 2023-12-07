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
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import static ifood.utils.Geral.JSON_APPLICATION;
import static ifood.utils.Geral.URL_BASE_IFOOD;

public class EventsRepository implements IEventsRepository {

    private final OkHttpClient client = new OkHttpClient();

    /**
     * consulta eventos no polling pendentes na api do ifood
     *
     * @return - retorna lista de eventos no polling do ifood
     */
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

    /**
     * salva evento de cabeçalho na tabela TB_PEDIDO_INTEGRACAO
     *
     * @param event - detalhes do evento pendente informado pelo ifood
     * @return - retorna status verdadeiro ou falso de salvar evento
     */
    @Override
    public boolean saveEventHeader(EventsPolling event) {
        String sql = "INSERT INTO TB_PEDIDO_INTEGRACAO (id_pedido_integracao, id_integracao, cod_pedido_integracao, data_criacao," +
                " status_integracao, codigo_status_integracao) VALUES ("
                + "uuid(), "
                + "'" + event.getId() + "', "
                + "'" + event.getOrderId() + "', "
                + "'" + Geral.formateDateToLocal(event.getCreatedAt()) + "', "
                + "'" + event.getFullCode() + "', "
                + "'" + event.getCode() + "')";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);

            int resultInsert = bd.st.executeUpdate();
            if (resultInsert > 0) {
                return true;
            }
        } catch (Exception er) {
            er.printStackTrace();
            LoggerInFile.printError(er.getMessage());
        } finally {
            bd.close();
        }

        return false;
    }

    /**
     * atualiza status_integracao e codigo do status da integração
     *
     * @param event - detalhes do evento pendente recebido do ifood
     * @return - retorna status da atualização dos dados do evento
     */
    @Override
    public boolean updateEventHeader(EventsPolling event) {
        String sql = "UPDATE TB_PEDIDO_INTEGRACAO SET"
                + " status_integracao='" + event.getFullCode() + "',"
                + " codigo_status_integracao='" + event.getCode() + "'"
                + " WHERE cod_pedido_integracao='" + event.getOrderId() + "';";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
            int result = bd.st.executeUpdate();
            if (result > 0) {
                return true;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return false;
    }

    /**
     * consulta se codigo do evento ja está cadastrado na tabela TB_PEDIDO_INTEGRACAO
     *
     * @param orderId - codigo do evento do ifood
     * @return - retorna status se evento já está salvo no banco de dados
     */
    @Override
    public boolean findEventHeader(String orderId) {
        String sql = "SELECT * FROM TB_PEDIDO_INTEGRACAO WHERE cod_pedido_integracao = ?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, orderId);
            ResultSet resultSet = bd.st.executeQuery();
            if (resultSet.next()) {
                if (!resultSet.getString(1).isEmpty()) {
                    return true;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return false;
    }

    /**
     * envia confirmação de recebimento do evento para ifood
     *
     * @param eventsAcknowledgments - lista de eventos para enviar ao ifood
     */
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
