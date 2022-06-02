package delivery;

import delivery.controller.PedidoController;
import delivery.model.ClienteDelivery;
import delivery.model.PagamentoDelivery;
import delivery.model.PedidoDelivery;
import delivery.model.PedidoItemDelivery;
import log.LoggerInFile;

import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

public class AppDelivery {
    private static final PedidoController pedidoController = new PedidoController();

    public static void main(String[] args) {
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");
        LocalDateTime now = LocalDateTime.now();

        PagamentoDelivery pagamentoDelivery = new PagamentoDelivery();
        pagamentoDelivery.setNome("Visa");
        pagamentoDelivery.setPrePago(false);
        pagamentoDelivery.setTipo("credito");
        pagamentoDelivery.setTroco(0);
        pagamentoDelivery.setValor(15.5);

        List<PedidoItemDelivery> itens = new ArrayList<>();

        PedidoItemDelivery pedidoItemDelivery = new PedidoItemDelivery();
        pedidoItemDelivery.setNome("Esfiha de carne");
        pedidoItemDelivery.setCodExterno("1");
        pedidoItemDelivery.setObservacao("Sem azeitona");
        pedidoItemDelivery.setQuantidade(1);
        pedidoItemDelivery.setVrDesconto(0);
        pedidoItemDelivery.setVrAdicional(0);
        pedidoItemDelivery.setVrUnit(15.5);
        pedidoItemDelivery.setVrTotal(15.5);

        itens.add(pedidoItemDelivery);

        ClienteDelivery clienteDelivery = new ClienteDelivery();
        clienteDelivery.setNome("Abner Silva");
        clienteDelivery.setCodCliente(1006);
        clienteDelivery.setDocumento("");
        clienteDelivery.setBairro("Jardim Xpto");
        clienteDelivery.setLogradouro("Rua Xpto");
        clienteDelivery.setNumero(15);
        clienteDelivery.setCidade("Indaiatuba");
        clienteDelivery.setEstado("SP");
        clienteDelivery.setCep(13345700);
        clienteDelivery.setEmail("silvabner@gmail.com");
        clienteDelivery.setTelefone("(19)995323443");

        PedidoDelivery pedidoDelivery = new PedidoDelivery();
        pedidoDelivery.setCodPedido(0);
        pedidoDelivery.setDataCriacao(now.format(dtf));
        pedidoDelivery.setAgendado(false);
        pedidoDelivery.setDataEntrega("2022/04/22 23:58:00");
        pedidoDelivery.setObservacao("sem observação");
        pedidoDelivery.setReferencia("123");
        pedidoDelivery.setReferenciaCurta("");
        pedidoDelivery.setTipo("ENTREGA");
        pedidoDelivery.setVrTotal(15.5);
        pedidoDelivery.setVrAdicional(0.0);
        pedidoDelivery.setVrDesconto(0.0);
        pedidoDelivery.setPagamento(pagamentoDelivery);
        pedidoDelivery.setItens(itens);
        pedidoDelivery.setCliente(clienteDelivery);
        pedidoDelivery.setOrigem("IFOOD");

        try {
            pedidoController.savePedido(pedidoDelivery);
        } catch (SQLException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }
    }
}
