package delivery;

import delivery.controller.ConfigController;
import delivery.controller.ImprimeController;
import delivery.controller.PedidoController;
import delivery.model.*;
import ifood.AppIfood;
import log.LoggerInFile;
import log.MessageDefault;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

@SpringBootApplication
public class AppDelivery {
    private static ConfigController configController;
    private static PedidoController pedidoController;
    private static ImprimeController imprimeController;

    /**
     * inicia aplicação - verifica permissão de modulo de integração com ifood e impressão
     *
     * @param args - argumentos de inicio do projeto
     */
    public static void main(String[] args) {
        configController = new ConfigController();
        pedidoController = PedidoController.getInstance();
        imprimeController = new ImprimeController();

        LoggerInFile.start();

        PropertiesEnv.start();

        try {
            boolean statusIntegration = configController.checkIntegrationPermition();
            if (!statusIntegration) {
                System.out.println(MessageDefault.msgAccessIntegrationNotGranted);
                LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationNotGranted);
            } else {
                LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationGranted);
                AppIfood.start();
            }

            boolean permiteModuloImpressao = configController.checkPrinterPermition();
            if (!permiteModuloImpressao) {
                System.out.println(MessageDefault.msgAccessPrnterNotGranted);
                LoggerInFile.printInfo(MessageDefault.msgAccessPrnterNotGranted);
            } else {
                LoggerInFile.printInfo(MessageDefault.msgAccessrPrinterGranted);
                imprimeController.startPrinter();
            }

            boolean webserverPermition = configController.checkWebserverPermition();
            if (!webserverPermition) {
                System.out.println(MessageDefault.msgAccessWebserverNotGranted);
                LoggerInFile.printInfo(MessageDefault.msgAccessWebserverNotGranted);
            } else {
                LoggerInFile.printInfo(MessageDefault.msgAccessrWebserverGranted);

                SpringApplication.run(AppDelivery.class, args);
            }

        } catch (SQLException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }
    }

    /**
     * inicia, salva e imprime pedido de exemplo
     */
    public static void saveOrderTest() {
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");
        LocalDateTime now = LocalDateTime.now();

        PagamentoDelivery pagamentoDelivery = new PagamentoDelivery();
        pagamentoDelivery.setNome("Visa");
        pagamentoDelivery.setPrePago(false);
        pagamentoDelivery.setTipo("credito");
        pagamentoDelivery.setTroco(0);
        pagamentoDelivery.setValor(15.5);

        List<PedidoItemDelivery> itens = new ArrayList<>();
        for (int i = 1; i < 5; i++) {
            PedidoItemDelivery pedidoItemDelivery = new PedidoItemDelivery();
            pedidoItemDelivery.setNome("Esfiha de carne " + i);
            pedidoItemDelivery.setCodExterno(Integer.toString(i));
            pedidoItemDelivery.setObservacao("tesdfksjhskfjd lskdjfksdfl");
            pedidoItemDelivery.setQuantidade(1);
            pedidoItemDelivery.setVrDesconto(0);
            pedidoItemDelivery.setVrAdicional(0);
            pedidoItemDelivery.setVrUnit(15.587);
            pedidoItemDelivery.setVrTotal(15.587);

            itens.add(pedidoItemDelivery);
        }

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
        pedidoDelivery.setCodPedido(123);
        pedidoDelivery.setDataCriacao(now.format(dtf));
        pedidoDelivery.setAgendado(false);
        pedidoDelivery.setDataEntrega("2022/04/22 23:58:00");
        pedidoDelivery.setObservacao("sem observação");
        pedidoDelivery.setReferencia("123");
        pedidoDelivery.setReferenciaCurta("");
        pedidoDelivery.setTipo("ENTREGA");
        pedidoDelivery.setVrTotal(15.585);
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

        if (imprimeController.imprimePedido(pedidoDelivery)) {
            LoggerInFile.printInfo("Pedido impresso com sucesso");
        }
    }
}
