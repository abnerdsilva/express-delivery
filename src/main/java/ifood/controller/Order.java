package ifood.controller;

import delivery.controller.PedidoController;
import delivery.model.ClienteDelivery;
import delivery.model.PagamentoDelivery;
import delivery.model.PedidoDelivery;
import delivery.model.PedidoItemDelivery;
import ifood.model.OrderIntegration;
import ifood.model.dao.PedidoDao;
import ifood.repository.OrderRepository;
import ifood.utils.Geral;
import log.LoggerInFile;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class Order {

    private final static OrderRepository repository = new OrderRepository();

    /**
     * consulta detalhes dos pedidos pendentes junto ao ifood,
     * solicita tratamento dos pedidos recebidos e solicita salvar os detalhes dos pedidos
     */
    public static void saveOrdersPending() {
        List<OrderIntegration> ordersPending = repository.getOrdersPendingToConfirmation();

        if (ordersPending.size() > 0) {
            for (OrderIntegration order : ordersPending) {
                ifood.model.Order orderDetails = repository.getOrderDetails(order.getCodPedidoIntegracao());

                PedidoDelivery pedido = trataPedido(orderDetails, order);

                try {
                    PedidoController pedidoController = new PedidoController();
                    int orderId = pedidoController.savePedido(pedido);
                    if (repository.updateOrderId(orderId, pedido.getCodPedidoIntegracao())) {
                        LoggerInFile.printInfo("Sucesso");
                    }
                } catch (SQLException e) {
                    e.printStackTrace();
                    LoggerInFile.printError(e.getMessage());
                }
            }
        }
    }

    /**
     * loop de consulta pedidos pendentes para confirmar a produção junto ao ifood
     */
    public static void ordersToConfirmProduction() {
        List<PedidoDao> confirmedOrders = new ArrayList<>();
        for (; ; ) {
            List<PedidoDao> ordersPending = repository.getOrdersToConfirmProduction();
            for (PedidoDao orderPending : confirmedOrders) {
                var statusPedidoConfirmar = false;
                for (PedidoDao order : ordersPending) {
//                        System.out.println(orderPending.toString());
                    if (orderPending.getCodPedido() == order.getCodPedido()) {
                        statusPedidoConfirmar = true;
                    }
                }

                if (!statusPedidoConfirmar) {
                    System.out.println("confirmar pedido -> " + orderPending.toString());
                    if (repository.confirmProductionOrder(orderPending.getCodPedidoIntegracao())) {
                        LoggerInFile.printInfo("Pedido confirmado com sucesso");
                    }
                }
            }

            confirmedOrders = ordersPending;

            try {
                Thread.sleep(10000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    /**
     * loop de consulta de pedidos pendentes informar despacho
     */
    public static void ordersToConfirmDispatch() {
        List<PedidoDao> dispatchOrders = new ArrayList<>();
        for (; ; ) {
            List<PedidoDao> ordersPending = repository.getOrdersToDispatch();
            for (PedidoDao orderPending : dispatchOrders) {
                var statusPedidoDispatch = false;
                for (PedidoDao order : ordersPending) {
//                        System.out.println(orderPending.toString());
                    if (orderPending.getCodPedido() == order.getCodPedido()) {
                        statusPedidoDispatch = true;
                    }
                }

                if (!statusPedidoDispatch) {
                    System.out.println("despacha pedido -> " + orderPending.toString());
                    if (repository.confirmDispatchOrder(orderPending.getCodPedidoIntegracao())) {
                        LoggerInFile.printInfo("Pedido despachado com sucesso");
                    }
                }
            }

            dispatchOrders = ordersPending;

            try {
                Thread.sleep(10000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    /**
     * trata dados do pedido para salvar no banco de dados
     *
     * @param order            - informações do pedido
     * @param orderIntegration - informações do cabeçalho do pedido de integração
     * @return - retorna pedido tratado
     */
    private static PedidoDelivery trataPedido(ifood.model.Order order, OrderIntegration orderIntegration) {
        PagamentoDelivery pagamentoDelivery = new PagamentoDelivery();
        pagamentoDelivery.setNome(order.getPayments().getMethods().get(0).getCard().getBrand());
        pagamentoDelivery.setPrePago(order.getPayments().getMethods().get(0).isPrepaid());
        pagamentoDelivery.setTipo(order.getPayments().getMethods().get(0).getMethod());
        pagamentoDelivery.setTroco(order.getPayments().getPending());
        pagamentoDelivery.setValor(order.getPayments().getPrepaid());

        List<PedidoItemDelivery> itens = new ArrayList<>();

        for (ifood.model.Order.OrderItems item : order.getItems()) {
            PedidoItemDelivery pedidoItemDelivery = new PedidoItemDelivery();
            pedidoItemDelivery.setNome(item.getName());
            pedidoItemDelivery.setCodExterno(item.getExternalCode());
            String obs = "";
            if (item.getOptions() != null) {
                for (ifood.model.Order.OrderItems.OrderItemsOptions option : item.getOptions()) {
                    obs += " " + option.getName() + "\n";
                }
            }
            obs += " " + item.getObservations() + "\n";
            pedidoItemDelivery.setObservacao(obs);
            pedidoItemDelivery.setQuantidade(item.getQuantity());
            pedidoItemDelivery.setVrDesconto(0);
            pedidoItemDelivery.setVrAdicional(item.getOptionsPrice());
            pedidoItemDelivery.setVrUnit(item.getUnitPrice());
            pedidoItemDelivery.setVrTotal(item.getTotalPrice());

            itens.add(pedidoItemDelivery);
        }

        ClienteDelivery clienteDelivery = new ClienteDelivery();
        clienteDelivery.setNome(order.getCustomer().getName());
        clienteDelivery.setCodCliente(1006);
        clienteDelivery.setDocumento(order.getCustomer().getDocumentNumber());
        String logradouro = "";
        String bairro = "";
        String city = "";
        String state = "";
        String postalCode = "0";
        int numero = 0;
        String dataEntrega = "";
        String observacao = "";
        String referencia = "";

        if (order.getDelivery() != null) {
            logradouro = order.getDelivery().getDeliveryAddress().getStreetName();
            bairro = order.getDelivery().getDeliveryAddress().getNeighborhood();
            postalCode = order.getDelivery().getDeliveryAddress().getPostalCode();
            state = order.getDelivery().getDeliveryAddress().getState();
            city = order.getDelivery().getDeliveryAddress().getCity();
            if (order.getDelivery().getDeliveryAddress().getStreeNumber() != null)
                numero = Integer.parseInt(order.getDelivery().getDeliveryAddress().getStreeNumber());
            referencia = order.getDelivery().getDeliveryAddress().getReference();
            observacao = order.getDelivery().getObservations();
            dataEntrega = Geral.formateDateToLocal(order.getDelivery().getDeliveryDateTime());
        }
        if (order.getTakeout() != null) {
            dataEntrega = Geral.formateDateToLocal(order.getTakeout().getTakeoutDateTime());
        }

        clienteDelivery.setBairro(bairro);
        clienteDelivery.setLogradouro(logradouro);
        clienteDelivery.setNumero(numero);
        clienteDelivery.setCidade(city);
        clienteDelivery.setEstado(state);
        clienteDelivery.setCep(Integer.parseInt(postalCode));
        clienteDelivery.setEmail("");
        clienteDelivery.setTelefone(order.getDisplayId());

//        LocalTime lt1 = LocalTime.parse(order.getCreatedAt()).minusHours(3);

        PedidoDelivery pedidoDelivery = new PedidoDelivery();
        pedidoDelivery.setCodPedido(0);
        pedidoDelivery.setDataCriacao(Geral.formateDateToLocal(order.getCreatedAt()));
//        pedidoDelivery.setDataCriacao(lt1.format(DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss")));
        pedidoDelivery.setAgendado(!order.getOrderTiming().equals("IMMEDIATE"));
        pedidoDelivery.setDataEntrega(dataEntrega);
        pedidoDelivery.setObservacao(observacao);
        pedidoDelivery.setReferencia(referencia);
        pedidoDelivery.setReferenciaCurta(order.getDisplayId());
        pedidoDelivery.setTipo(order.getOrderType());
        pedidoDelivery.setVrTotal(order.getTotal().getSubTotal());
        pedidoDelivery.setVrAdicional(order.getTotal().getDeliveryFee() + order.getTotal().getAdditionalFees());
        pedidoDelivery.setVrDesconto(order.getTotal().getBenefits());
        pedidoDelivery.setPagamento(pagamentoDelivery);
        pedidoDelivery.setItens(itens);
        pedidoDelivery.setCliente(clienteDelivery);
        pedidoDelivery.setOrigem(order.getSalesChannel());
        pedidoDelivery.setCodPedidoIntegracao(orderIntegration.getCodPedidoIntegracao());

        return pedidoDelivery;
    }
}
