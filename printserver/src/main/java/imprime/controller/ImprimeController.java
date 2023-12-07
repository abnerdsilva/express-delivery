package imprime.controller;

import imprime.model.PedidoDelivery;
import imprime.repository.EventsRepository;
import imprime.repository.LoginRepository;
import log.LoggerInFile;

import javax.print.PrintException;

public class ImprimeController {

    EventsRepository eventsRepository = new EventsRepository();
    LoginRepository loginRepository = new LoginRepository();

    private final static long timeSleepPrinter = 10000;

    public void getOrders() {
        var token = loginRepository.auth();
        if (token.equals("-1")) {
            LoggerInFile.printError("falha ao gerar token");
            return;
        }

        new Thread(() -> {
            for (; ; ) {
                var ordersToPrint = eventsRepository.getEvents(token);
                for (var order : ordersToPrint) {
                    var statusPrinted = imprimePedido(order);
                    if (statusPrinted) {
                        eventsRepository.setOrderPrinted(order.getCodPedido(), token);
                    }
                }

                try {
                    Thread.sleep(timeSleepPrinter);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                    LoggerInFile.printError(e.getMessage());
                }
            }
        }).start();
    }

    /**
     * imprime pedido de acordo com dados informados
     *
     * @param pedido - dados do pedido
     * @return - status do processo de imprimir pedido
     */
    public static boolean imprimePedido(PedidoDelivery pedido) {
        boolean statusImpressao = false;
        Impressora imprimir = new Impressora();

        String textToPrint = "\n-----------------------------------------------------------\n";
        textToPrint += imprimir.preencheLinha("Pedido Delivery", " ", 60, "ED");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        textToPrint += imprimir.preencheLinha("Pedido: " + pedido.getId(), " ", 60, "ED");
        textToPrint += "\n-----------------------------------------------------------";

        textToPrint += "\n";

//        textToPrint += imprimir.preencheLinha("VIA: 1", "*", 60, "ED");
//        textToPrint += "\n";
//        textToPrint += "\n";

        textToPrint += imprimir.preencheLinha("Cliente: " + pedido.getCliente().getNome(), " ", 60, "E");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        String infoEndereco = "Pedido para retirar";
        if (!pedido.getCliente().getLogradouro().equals("")) {
            infoEndereco = pedido.getCliente().getLogradouro() + " - " + pedido.getCliente().getNumero() + ", " + pedido.getCliente().getBairro();
        }
        textToPrint += imprimir.preencheLinha("Endereco: " + infoEndereco, " ", 60, "E");
        textToPrint += imprimir.preencheLinha("\n\n", " ", 60, "D");

        textToPrint += imprimir.preencheLinha("Data entrega: " + pedido.getDataEntrega(), " ", 60, "E");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        textToPrint += imprimir.preencheLinha("Origem: " + pedido.getOrigem(), " ", 60, "E");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        textToPrint += imprimir.preencheLinha("Obs.: " + pedido.getReferencia(), " ", 60, "E");
        textToPrint += imprimir.preencheLinha("\n\n", " ", 60, "D");

        textToPrint += imprimir.preencheLinha("-", "-", 60, "D");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");

        textToPrint += imprimir.preencheLinha("Nome", " ", 30, "E")
                + imprimir.preencheLinha("Qtde", " ", 7, "E")
                + imprimir.preencheLinha("V.Unit", " ", 10, "D")
                + imprimir.preencheLinha("V.Total", " ", 10, "D");

        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        textToPrint += imprimir.preencheLinha("-", "-", 60, "D");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");

        for (var p : pedido.getItens()) {
            textToPrint += imprimir.preencheLinha(p.getNome(), " ", 30, "E")
                    + imprimir.preencheLinha(Integer.toString(p.getQuantidade()), " ", 7, "ED")
                    + imprimir.preencheLinha(Double.toString(p.getVrUnitario()), " ", 10, "D")
                    + imprimir.preencheLinha(Double.toString(p.getVrTotal()), " ", 10, "D");

            textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");

            if (p.getObservacao() != null) {
                if (!p.getObservacao().isEmpty() && !p.getObservacao().equals("null")) {
                    textToPrint += imprimir.preencheLinha("  Obs.: " + p.getObservacao(), " ", 60, "E");
                    textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
                }
            }
        }

        textToPrint += imprimir.preencheLinha("-", "-", 60, "D");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");

        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        textToPrint += imprimir.preencheLinha("Valor Produtos: ", " ", 50, "E");
        textToPrint += imprimir.preencheLinha(Double.toString(pedido.getVrTotal()), " ", 10, "E");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        textToPrint += imprimir.preencheLinha("Valor Taxa: ", " ", 50, "E");
        textToPrint += imprimir.preencheLinha(Double.toString(pedido.getVrAdicional()), " ", 10, "E");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        textToPrint += imprimir.preencheLinha("Valor desconto: ", " ", 50, "E");
        textToPrint += imprimir.preencheLinha(Double.toString(pedido.getVrDesconto()), " ", 10, "E");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        textToPrint += imprimir.preencheLinha("Valor Total Pedido: ", " ", 50, "E");
        textToPrint += imprimir.preencheLinha(Double.toString(pedido.getVrTotal() + pedido.getVrAdicional()), " ", 10, "E");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");

        imprimir.detectaImpressoras();
        try {
            imprimir.imprime(textToPrint);
            imprimir.imprime("\n");
            imprimir.imprime("\n");

            statusImpressao = true;
        } catch (PrintException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return statusImpressao;
    }
}
