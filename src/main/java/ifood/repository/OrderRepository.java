package ifood.repository;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import db.DatabaseConnection;
import ifood.model.Order;
import ifood.model.OrderIntegration;
import ifood.model.dao.PedidoDao;
import ifood.repository.interfaces.IOrderRepository;
import ifood.utils.Geral;
import log.LoggerInFile;
import okhttp3.*;

import java.io.IOException;
import java.sql.Connection;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;

import static ifood.utils.Geral.JSON_APPLICATION;
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

    @Override
    public boolean confirmProductionOrder(String codPedidoIntegracao) {
        boolean ret = false;

        final String url = URL_BASE_IFOOD + "/order/v1.0/orders/" + codPedidoIntegracao + "/confirm";
        RequestBody requestBody = RequestBody.create(JSON_APPLICATION, "");
        Request request = new Request.Builder()
                .url(url)
                .addHeader("Authorization", Geral.accessToken)
                .addHeader("Content-type", "application/json")
                .post(requestBody)
                .build();

        try {
            Response response = client.newCall(request).execute();
            ResponseBody responseBody = response.peekBody(Long.MAX_VALUE);

            if (response.code() != 202) {
                LoggerInFile.printError(responseBody.string());
            } else {
                ret = true;
            }
        } catch (IOException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return ret;
    }

    public boolean confirmDispatchOrder(String codPedidoIntegracao) {
        boolean ret = false;

        final String url = URL_BASE_IFOOD + "/order/v1.0/orders/" + codPedidoIntegracao + "/dispatch";
        RequestBody requestBody = RequestBody.create(JSON_APPLICATION, "");
        Request request = new Request.Builder()
                .url(url)
                .addHeader("Authorization", Geral.accessToken)
                .addHeader("Content-type", "application/json")
                .post(requestBody)
                .build();

        try {
            Response response = client.newCall(request).execute();
            ResponseBody responseBody = response.peekBody(Long.MAX_VALUE);

            if (response.code() != 202) {
                LoggerInFile.printError(responseBody.string());
            } else {
                ret = true;
            }
        } catch (IOException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return ret;
    }

    public List<PedidoDao> getOrdersToConfirmProduction() throws SQLException {
        String sql = "SELECT * FROM TB_PEDIDO WHERE STATUS_PEDIDO='ABERTO' AND DATA_ATUALIZACAO IS NULL";

        DatabaseConnection.connect();
        connection = DatabaseConnection.connection;

        List<PedidoDao> pedidos = new ArrayList<>();
        try {
            PreparedStatement stmt = connection.prepareStatement(sql);
            ResultSet resultSet = stmt.executeQuery();
            while (resultSet.next()) {
                PedidoDao order = new PedidoDao();
                order.setCodPedido(resultSet.getInt("cod_pedido"));
                order.setCodCliente(resultSet.getInt("cod_cliente"));
                order.setCodPedidoIntegracao(resultSet.getString("cod_pedido_integracao"));
                order.setStatusPedido(resultSet.getString("status_pedido"));
                order.setDataPedido(resultSet.getString("data_pedido"));
                order.setDataEntrega(resultSet.getString("data_entrega"));
                order.setVrTotal(resultSet.getDouble("vr_total"));
                order.setVrTaxa(resultSet.getDouble("vr_taxa"));
                order.setVrTroco(resultSet.getDouble("vr_troco"));
                order.setOrigem(resultSet.getString("origem"));
                order.setDataAtualizacao(resultSet.getString("data_atualizacao"));
                order.setFormaPagamento(resultSet.getString("forma_pagamento"));
                order.setObservacao(resultSet.getString("observacao"));
                order.setTipoPedido(resultSet.getString("tipo_pedido"));

                pedidos.add(order);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return pedidos;
    }

    public List<PedidoDao> getOrdersToDispatch() throws SQLException {
        String sql = "SELECT * FROM TB_PEDIDO WHERE STATUS_PEDIDO='ABERTO' AND DATA_ATUALIZACAO IS NOT NULL";

        DatabaseConnection.connect();
        connection = DatabaseConnection.connection;

        List<PedidoDao> pedidos = new ArrayList<>();
        try {
            PreparedStatement stmt = connection.prepareStatement(sql);
            ResultSet resultSet = stmt.executeQuery();
            while (resultSet.next()) {
                PedidoDao order = new PedidoDao();
                order.setCodPedido(resultSet.getInt("cod_pedido"));
                order.setCodCliente(resultSet.getInt("cod_cliente"));
                order.setCodPedidoIntegracao(resultSet.getString("cod_pedido_integracao"));
                order.setStatusPedido(resultSet.getString("status_pedido"));
                order.setDataPedido(resultSet.getString("data_pedido"));
                order.setDataEntrega(resultSet.getString("data_entrega"));
                order.setVrTotal(resultSet.getDouble("vr_total"));
                order.setVrTaxa(resultSet.getDouble("vr_taxa"));
                order.setVrTroco(resultSet.getDouble("vr_troco"));
                order.setOrigem(resultSet.getString("origem"));
                order.setDataAtualizacao(resultSet.getString("data_atualizacao"));
                order.setFormaPagamento(resultSet.getString("forma_pagamento"));
                order.setObservacao(resultSet.getString("observacao"));
                order.setTipoPedido(resultSet.getString("tipo_pedido"));

                pedidos.add(order);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return pedidos;
    }
}
