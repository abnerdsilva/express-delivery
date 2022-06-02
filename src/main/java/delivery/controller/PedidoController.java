package delivery.controller;

import db.DatabaseConnection;
import delivery.model.dao.ClienteDao;
import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;
import delivery.model.dao.ProdutoDao;
import log.LoggerInFile;
import log.MessageDefault;
import delivery.model.*;
import delivery.repository.PedidoRepository;
import delivery.repository.ProdutoRepository;

import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class PedidoController {
    PedidoRepository pedidoRepository = new PedidoRepository();
    ProdutoRepository produtoRepository = new ProdutoRepository();
    ClienteController clienteController = new ClienteController();

    public int savePedido(PedidoDelivery pedidoDelivery) throws SQLException {
        try {
            long idCliente = clienteController.checkClientExists(pedidoDelivery.getCliente().getCodCliente());
            if (idCliente == -1) {
                idCliente = addCliente(pedidoDelivery.getCliente());
                if (idCliente <= 0) {
                    LoggerInFile.printError(MessageDefault.msgErrorAddClient);
                    return -1;
                }
            }

            PedidoDao pedido = new PedidoDao();
            pedido.setDataPedido(pedidoDelivery.getDataCriacao());
            pedido.setBairro(pedidoDelivery.getCliente().getBairro());
            pedido.setLogradouro(pedidoDelivery.getCliente().getLogradouro());
            pedido.setEstado(pedidoDelivery.getCliente().getEstado());
            pedido.setNumero(pedidoDelivery.getCliente().getNumero());
            pedido.setCidade(pedidoDelivery.getCliente().getCidade());
            pedido.setCep(Integer.toString(pedidoDelivery.getCliente().getCep()));
            pedido.setDataPedido(pedidoDelivery.getDataCriacao());
            pedido.setCodCliente((int) idCliente);
            pedido.setDataEntrega(pedidoDelivery.getDataEntrega());
            pedido.setFormaPagamento(pedidoDelivery.getPagamento().getNome() + "-" + pedidoDelivery.getPagamento().getTipo());
            pedido.setTipoPedido(pedidoDelivery.getTipo());
            pedido.setOrigem(pedidoDelivery.getOrigem());
            pedido.setVrTaxa(pedidoDelivery.getVrAdicional());
            pedido.setVrTotal(pedidoDelivery.getVrTotal());
            pedido.setVrDesconto(pedidoDelivery.getVrDesconto());
            pedido.setVrTroco(0);
            pedido.setCodPedidoIntegracao(pedidoDelivery.getCodPedidoIntegracao());

            String observacao = pedidoDelivery.getObservacao();
            if (pedidoDelivery.isAgendado()) {
                observacao += "\n [AGENDADO]: " + pedidoDelivery.getDataEntrega();
            }
            if (pedidoDelivery.getPagamento().isPrePago()) {
                observacao += "\n [PAGAMENTO JÁ REALIZADO]";
            }

            pedido.setObservacao(observacao);

            int orderId = pedidoRepository.saveOrder(pedido);
            if (orderId <= 0) {
                return -1;
            }

            for (var item : pedidoDelivery.getItens()) {
                int codProdutoExterno = Integer.parseInt(item.getCodExterno());

                ProdutoDao produto = produtoRepository.loadById(codProdutoExterno);
                if (produto == null || produto.getCodProduto() == 0) {
                    LoggerInFile.printError("Produto não encontrado");
                    continue;
                }

                PedidoItemDao pedidoItem = new PedidoItemDao();
                pedidoItem.setCodPedido(orderId);
                pedidoItem.setCodProduto(produto.getCodProduto());
                pedidoItem.setQuantidade(item.getQuantidade());
                pedidoItem.setObservacao(item.getObservacao());
                pedidoItem.setVrUnitario(item.getVrUnit());
                pedidoItem.setVrTotal(item.getVrTotal());

                int statusSaveOrderItem = pedidoRepository.saveOrderItem(pedidoItem);
                if (statusSaveOrderItem <= 0) {
                    LoggerInFile.printError("Erro ao incluir pedido item");
                }
            }

            return orderId;
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            DatabaseConnection.disconnect();
        }

        return -1;
    }

    private int addCliente(ClienteDelivery clienteDelivery) throws SQLException {
        ClienteDao cliente = new ClienteDao();
        cliente.setCodCliente(clienteDelivery.getCodCliente());
        cliente.setNome(clienteDelivery.getNome());
        cliente.setTelefone(clienteDelivery.getTelefone());
        cliente.setEmail(clienteDelivery.getEmail());
        cliente.setCpf(clienteDelivery.getDocumento());
        cliente.setRg("");
        cliente.setLogradouro(clienteDelivery.getLogradouro());
        cliente.setNumero(clienteDelivery.getNumero());
        cliente.setBairro(clienteDelivery.getBairro());
        cliente.setCidade(clienteDelivery.getCidade());
        cliente.setEstado(clienteDelivery.getEstado());
        cliente.setCep(clienteDelivery.getCep());
        cliente.setStatusCliente(1);

        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");
        LocalDateTime now = LocalDateTime.now();
        cliente.setDataCadastro(now.format(dtf));
        cliente.setDataAtualizacao(now.format(dtf));
        cliente.setObservacao(clienteDelivery.getObservacao());

        return clienteController.addCliente(cliente);
    }
}
