package delivery.controller;

import delivery.model.ClienteDelivery;
import delivery.model.PagamentoDelivery;
import delivery.model.PedidoDelivery;
import delivery.model.PedidoItemDelivery;
import delivery.model.dao.ClienteDao;
import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;
import delivery.model.dao.ProdutoDao;
import delivery.repository.ClienteRepository;
import delivery.repository.PedidoRepository;
import delivery.repository.ProdutoRepository;
import imprime.Impressora;
import log.LoggerInFile;

import javax.print.PrintException;
import java.io.IOException;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ImprimeController {
    private static final PedidoRepository pedidoRepository = new PedidoRepository();
    private static final ClienteRepository clienteRepository = new ClienteRepository();
    private static final ProdutoRepository produtoRepository = new ProdutoRepository();

    private final static long timeSleepPrinter = 5000;

    public boolean imprimePedido(PedidoDelivery pedido) {
        boolean statusImpressao = false;
        Impressora imprimir = new Impressora();

        String textToPrint = "\n-----------------------------------------------------------\n";
        textToPrint += imprimir.preencheLinha("Pedido Delivery", " ", 60, "ED");
        textToPrint += "\n-----------------------------------------------------------";

        textToPrint += "\n";

//        textToPrint += imprimir.preencheLinha("VIA: 1", "*", 60, "ED");
//        textToPrint += "\n";
//        textToPrint += "\n";

        textToPrint += imprimir.preencheLinha("Cliente: " + pedido.getCliente().getNome(), " ", 60, "E");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
        textToPrint += imprimir.preencheLinha("Endereco: " + pedido.getCliente().getLogradouro(), " ", 60, "E");
        textToPrint += imprimir.preencheLinha("\n\n", " ", 60, "D");

        textToPrint += imprimir.preencheLinha("Pedido: " + pedido.getCodPedido(), " ", 60, "E");
        textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");
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
                    + imprimir.preencheLinha(Double.toString(p.getVrUnit()), " ", 10, "D")
                    + imprimir.preencheLinha(Double.toString(p.getVrTotal()), " ", 10, "D");

            textToPrint += imprimir.preencheLinha("\n", " ", 60, "D");

            if (p.getObservacao() != null) {
                if (!p.getObservacao().isEmpty()) {
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

    public void startPrinter() {
        new Thread(() -> {
            for (; ; ) {
                System.out.println("loop printer");
                try {
                    List<PedidoDao> pedidosImprimir = pedidoRepository.getPedidosParaImprimir();
                    for (PedidoDao p : pedidosImprimir) {
                        PagamentoDelivery pagamentoDelivery = new PagamentoDelivery();
                        pagamentoDelivery.setNome(p.getFormaPagamento());
                        pagamentoDelivery.setPrePago(false);
                        pagamentoDelivery.setTroco(p.getVrTroco());
                        pagamentoDelivery.setValor(p.getVrTotal());

                        List<PedidoItemDelivery> itens = new ArrayList<>();
                        try {
                            List<PedidoItemDao> itensPedido = pedidoRepository.loadItensByCode(p.getCodPedido());
                            for (PedidoItemDao it : itensPedido) {
                                ProdutoDao produtoDao = produtoRepository.loadById(it.getCodProduto());

                                PedidoItemDelivery item = new PedidoItemDelivery();
                                item.setNome(produtoDao.getNome());
                                item.setCodExterno(Integer.toString(it.getCodProduto()));
                                item.setObservacao(it.getObservacao());
                                item.setQuantidade(it.getQuantidade());
                                item.setVrDesconto(0);
                                item.setVrAdicional(0);
                                item.setVrUnit(it.getVrUnitario());
                                item.setVrTotal(it.getVrTotal());

                                itens.add(item);
                            }
                        } catch (IOException e) {
                            e.printStackTrace();
                        }

                        ClienteDao clienteDao = clienteRepository.loadById(p.getCodCliente());
                        ClienteDelivery clienteDelivery = new ClienteDelivery();
                        clienteDelivery.setNome(clienteDao.getNome());
                        clienteDelivery.setCodCliente((int) clienteDao.getCodCliente());
                        clienteDelivery.setDocumento(clienteDao.getCpf());
                        clienteDelivery.setBairro(clienteDao.getBairro());
                        clienteDelivery.setLogradouro(clienteDao.getLogradouro());
                        clienteDelivery.setNumero(clienteDao.getNumero());
                        clienteDelivery.setCidade(clienteDao.getCidade());
                        clienteDelivery.setEstado(clienteDao.getEstado());
                        clienteDelivery.setCep(clienteDao.getCep());
                        clienteDelivery.setEmail(clienteDao.getEmail());
                        clienteDelivery.setTelefone(clienteDao.getTelefone());

                        PedidoDelivery pedidoDelivery = new PedidoDelivery();
                        pedidoDelivery.setCodPedido(p.getCodPedido());
                        pedidoDelivery.setDataCriacao(p.getDataPedido());
                        pedidoDelivery.setAgendado(false);
                        pedidoDelivery.setDataEntrega(p.getDataEntrega());
                        pedidoDelivery.setObservacao(p.getObservacao());
                        pedidoDelivery.setReferencia("");
                        pedidoDelivery.setReferenciaCurta("");
                        pedidoDelivery.setTipo(p.getTipoPedido());
                        pedidoDelivery.setVrTotal(p.getVrTotal());
                        pedidoDelivery.setVrAdicional(p.getVrTaxa());
                        pedidoDelivery.setVrDesconto(0.0);
                        pedidoDelivery.setPagamento(pagamentoDelivery);
                        pedidoDelivery.setItens(itens);
                        pedidoDelivery.setCliente(clienteDelivery);
                        pedidoDelivery.setOrigem(p.getOrigem());

                        if (imprimePedido(pedidoDelivery)) {
                            LoggerInFile.printInfo("Pedido " + p.getCodPedido() + " impresso com sucesso");

                            pedidoRepository.updateOrderPrinted(p.getCodPedido());
                        } else {
                            LoggerInFile.printInfo("Falha ao imprimir pedido " + p.getCodPedido());
                        }
                    }
                } catch (SQLException e) {
                    e.printStackTrace();
                    LoggerInFile.printError(e.getMessage());
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
}
