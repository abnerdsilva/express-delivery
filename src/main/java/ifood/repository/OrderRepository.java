package ifood.repository;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import db.DatabaseConnection;
import ifood.model.Order;
import ifood.model.OrderIntegration;
import ifood.repository.interfaces.IOrderRepository;
import ifood.utils.Geral;
import log.LoggerInFile;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;
import okhttp3.ResponseBody;

import java.io.IOException;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

import static ifood.utils.Geral.URL_BASE_IFOOD;

public class OrderRepository implements IOrderRepository {

    private final OkHttpClient client = new OkHttpClient();
    private Connection connection;

    @Override
    public List<OrderIntegration> getOrdersPendingToConfirmation() throws SQLException {
        String sql = "SELECT * FROM TB_PEDIDO_INTEGRACAO WHERE nr_pedido = 0 AND codigo_status_integracao!='CAN'";

        DatabaseConnection.connect();
        connection = DatabaseConnection.connection;

        List<OrderIntegration> pedidos = new ArrayList<>();
        try {
            PreparedStatement stmt = connection.prepareStatement(sql);
            ResultSet resultSet = stmt.executeQuery();
            while (resultSet.next()) {
                OrderIntegration order = new OrderIntegration();
                order.setIdPedido(resultSet.getInt(1));
                order.setId(resultSet.getString(2));
                order.setCodPedidoIntegracao(resultSet.getString(3));
                order.setDataCriacao(resultSet.getTimestamp(4));
                order.setStatusIntegracao(resultSet.getString(5));
                order.setCodStatusIntegracao(resultSet.getString(6));
                order.setNrPedido(resultSet.getInt(7));

                pedidos.add(order);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return pedidos;
    }

    @Override
    public Order getOrderDetails(String orderId) {
        final String url = URL_BASE_IFOOD + "/order/v1.0/orders/" + orderId;
        Request request = new Request.Builder()
                .url(url)
                .addHeader("Authorization", Geral.accessToken)
                .addHeader("Content-type", "application/json")
                .get()
                .build();

        Gson gson = new GsonBuilder().create();
        ResponseBody responseBody = null;
        try {
            Response response = client.newCall(request).execute();
            responseBody = response.peekBody(Long.MAX_VALUE);

            if (response.code() != 200) {
                LoggerInFile.printError(responseBody.string());

                return null;
            }

            final String body = response.body().string();
            response.close();

            return gson.fromJson(body, Order.class);
        } catch (IOException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return null;
    }

    @Override
    public boolean updateOrderId(int id, String codPedidoIntegracao) {
        String sql = "UPDATE TB_PEDIDO_INTEGRACAO SET"
                + " nr_pedido=" + id + " "
                + " WHERE cod_pedido_integracao='" + codPedidoIntegracao + "';";

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
                return true;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return false;
    }
}
