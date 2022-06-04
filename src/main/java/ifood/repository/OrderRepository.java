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
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import static ifood.utils.Geral.JSON_APPLICATION;
import static ifood.utils.Geral.URL_BASE_IFOOD;

public class OrderRepository implements IOrderRepository {

    private final OkHttpClient client = new OkHttpClient();

    @Override
    public List<OrderIntegration> getOrdersPendingToConfirmation() throws SQLException {
        String sql = "SELECT * FROM TB_PEDIDO_INTEGRACAO WHERE nr_pedido = 0 AND codigo_status_integracao!='CAN'";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        List<OrderIntegration> pedidos = new ArrayList<>();
        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                OrderIntegration order = new OrderIntegration();
                order.setIdPedido(bd.rs.getInt(1));
                order.setId(bd.rs.getString(2));
                order.setCodPedidoIntegracao(bd.rs.getString(3));
                order.setDataCriacao(bd.rs.getTimestamp(4));
                order.setStatusIntegracao(bd.rs.getString(5));
                order.setCodStatusIntegracao(bd.rs.getString(6));
                order.setNrPedido(bd.rs.getInt(7));

                pedidos.add(order);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
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
        String sql = "SELECT * FROM TB_PEDIDO WHERE STATUS_PEDIDO='ABERTO' AND ORIGEM='IFOOD' AND DATA_ATUALIZACAO IS NULL";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        List<PedidoDao> pedidos = new ArrayList<>();
        try {
            bd.st = bd.connection.prepareStatement(sql);
            if (bd.st == null) {
                Thread.sleep(500);
            }
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoDao order = new PedidoDao();
                order.setCodPedido(bd.rs.getInt("cod_pedido"));
                order.setCodCliente(bd.rs.getInt("cod_cliente"));
                order.setCodPedidoIntegracao(bd.rs.getString("cod_pedido_integracao"));
                order.setStatusPedido(bd.rs.getString("status_pedido"));
                order.setDataPedido(bd.rs.getString("data_pedido"));
                order.setDataEntrega(bd.rs.getString("data_entrega"));
                order.setVrTotal(bd.rs.getDouble("vr_total"));
                order.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                order.setVrTroco(bd.rs.getDouble("vr_troco"));
                order.setOrigem(bd.rs.getString("origem"));
                order.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                order.setFormaPagamento(bd.rs.getString("forma_pagamento"));
                order.setObservacao(bd.rs.getString("observacao"));
                order.setTipoPedido(bd.rs.getString("tipo_pedido"));

                pedidos.add(order);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return pedidos;
    }

    public List<PedidoDao> getOrdersToDispatch() throws SQLException {
        String sql = "SELECT * FROM TB_PEDIDO WHERE STATUS_PEDIDO='ABERTO' AND ORIGEM='IFOOD' AND DATA_ATUALIZACAO IS NOT NULL";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        List<PedidoDao> pedidos = new ArrayList<>();
        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                PedidoDao order = new PedidoDao();
                order.setCodPedido(bd.rs.getInt("cod_pedido"));
                order.setCodCliente(bd.rs.getInt("cod_cliente"));
                order.setCodPedidoIntegracao(bd.rs.getString("cod_pedido_integracao"));
                order.setStatusPedido(bd.rs.getString("status_pedido"));
                order.setDataPedido(bd.rs.getString("data_pedido"));
                order.setDataEntrega(bd.rs.getString("data_entrega"));
                order.setVrTotal(bd.rs.getDouble("vr_total"));
                order.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                order.setVrTroco(bd.rs.getDouble("vr_troco"));
                order.setOrigem(bd.rs.getString("origem"));
                order.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                order.setFormaPagamento(bd.rs.getString("forma_pagamento"));
                order.setObservacao(bd.rs.getString("observacao"));
                order.setTipoPedido(bd.rs.getString("tipo_pedido"));

                pedidos.add(order);
            }
            bd.st.close();
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return pedidos;
    }
}
