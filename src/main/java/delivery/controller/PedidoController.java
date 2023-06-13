package delivery.controller;

import delivery.Erro;
import delivery.model.ClienteDelivery;
import delivery.model.PedidoDelivery;
import delivery.model.PedidoItemDelivery;
import delivery.model.dao.ClienteDao;
import delivery.model.dao.PedidoDao;
import delivery.model.dao.PedidoItemDao;
import delivery.model.dao.ProdutoDao;
import delivery.repository.ClienteRepository;
import delivery.repository.PedidoRepository;
import delivery.repository.ProdutoRepository;
import log.LoggerInFile;
import log.MessageDefault;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.sql.SQLException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.List;

@RestController
public class PedidoController {
    private static PedidoController instance;

    PedidoRepository _pedidoRepository;
    ProdutoRepository _produtoRepository;
    ClienteRepository _clienteRepository;

    private PedidoController() {
        _pedidoRepository = new PedidoRepository();
        _produtoRepository = new ProdutoRepository();
        _clienteRepository = new ClienteRepository();
    }

    public static PedidoController getInstance() {
        if (instance == null) {
            instance = new PedidoController();
        }
        return instance;
    }

    /**
     * trata dados do pedido e solicita salvar no banco de dados
     *
     * @param pedidoDelivery - informações do pedido
     * @return - retorna id do pedido cadastrado
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
    public int savePedido(PedidoDelivery pedidoDelivery) throws SQLException {
        try {
            long idCliente = -99;

            ClienteDao clienteDao = _clienteRepository.loadById(pedidoDelivery.getCliente().getCodCliente());
            if (clienteDao == null || clienteDao.getCodCliente() == 0) {
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

            int orderId = _pedidoRepository.saveOrder(pedido);
            if (orderId <= 0) {
                return -1;
            }

            for (var item : pedidoDelivery.getItens()) {
                if (item.getCodExterno() == null) {
                    LoggerInFile.printError("Produto " + item.getId() + " não possui codigo externo");
                    continue;
                }

                String codProdutoExterno = "0";
                if (!item.getCodExterno().equals("0") && !item.getCodExterno().equals("")) {
                    codProdutoExterno = item.getCodExterno();
                }

                ProdutoDao produto = _produtoRepository.loadById(codProdutoExterno);
                if (produto == null || produto.getCodProduto() == 0) {
                    LoggerInFile.printError("Produto [COD_EXTERNO = " + codProdutoExterno + "] não encontrado");
                    continue;
                }

                PedidoItemDao pedidoItem = new PedidoItemDao();
                pedidoItem.setCodPedido(orderId);
                pedidoItem.setCodProduto(produto.getCodProduto());
                pedidoItem.setQuantidade(item.getQuantidade());
                pedidoItem.setObservacao(item.getObservacao());
                pedidoItem.setVrUnitario(item.getVrUnit());
                pedidoItem.setVrTotal(item.getVrTotal());

                int statusSaveOrderItem = _pedidoRepository.saveOrderItem(pedidoItem);
                if (statusSaveOrderItem <= 0) {
                    LoggerInFile.printError("Erro ao incluir pedido item");
                }
            }

            return orderId;
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return -1;
    }

    /**
     * trata ClienteDelivery para ClienteDao para adicionar cliente no banco de dados
     *
     * @param clienteDelivery - dados do cliente que foram recebidos da integraão
     * @return - retorna id do cliente cadastrado
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
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

        int clientId = Long.valueOf(cliente.getCodCliente()).intValue();
        clientId = _clienteRepository.hasClient(clientId, cliente.getTelefone());
        if (clientId > 0) {
            return clientId;
        }
        return _clienteRepository.save(cliente);
    }

    /**
     * Endpoint para consulta de pedidos do dia atual
     *
     * @return - lista de pedidos
     */
    @RequestMapping("/orders")
    public ResponseEntity getOrders() {
        List<PedidoDelivery> orders = new ArrayList<>();
        List<PedidoDao> pedidoDao = _pedidoRepository.getOrdersFromToday();
        for (var ped : pedidoDao) {
            PedidoDelivery pedidoDelivery = new PedidoDelivery();
            try {
                ClienteDao clienteDao = _clienteRepository.loadById(ped.getCodCliente());

                if (clienteDao == null) {
                    throw new Exception("cliente não encontrado");
                }

                pedidoDelivery.setCodPedido(ped.getCodPedido());
                pedidoDelivery.setCliente(clienteDao.clientDaoToClienteDelivery());
                pedidoDelivery.setDataCriacao(ped.getDataPedido());
                pedidoDelivery.setVrTotal(ped.getVrTotal());
                pedidoDelivery.setVrDesconto(ped.getVrDesconto());
                pedidoDelivery.setVrAdicional(ped.getVrTaxa());
                pedidoDelivery.setObservacao(ped.getObservacao());
                pedidoDelivery.setCodPedidoIntegracao(ped.getCodPedidoIntegracao());
                pedidoDelivery.setOrigem(ped.getOrigem());
                pedidoDelivery.setTipo(ped.getTipoPedido());
                pedidoDelivery.setStatusPedido(ped.getStatusPedido());

            } catch (Exception e) {
                e.printStackTrace();

                return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new Erro(e.getMessage()));
            }

            orders.add(pedidoDelivery);
        }

        return ResponseEntity.status(HttpStatus.OK).body(orders);
    }

    @RequestMapping("/order/{id}")
    public PedidoDelivery getOrderFromId(@PathVariable int id) throws SQLException {
        List<PedidoItemDelivery> itens = new ArrayList<>();
        List<PedidoItemDao> itensDao = _pedidoRepository.loadItensByCode(id);

        for (var item : itensDao) {
            itens.add(item.itemDaoToItemDelivery());
        }

        ClienteDao clienteDao = _clienteRepository.loadById(1);

        PedidoDao pedidoDao = _pedidoRepository.getOrderById(id);

        PedidoDelivery pedidoDelivery = new PedidoDelivery();
        pedidoDelivery.setCodPedido(id);
        pedidoDelivery.setItens(itens);
        pedidoDelivery.setCliente(clienteDao.clientDaoToClienteDelivery());
        pedidoDelivery.setDataCriacao(pedidoDao.getDataPedido());
        pedidoDelivery.setVrTotal(pedidoDao.getVrTotal());
        pedidoDelivery.setVrDesconto(pedidoDao.getVrDesconto());
        pedidoDelivery.setVrAdicional(pedidoDao.getVrTaxa());
        pedidoDelivery.setObservacao(pedidoDao.getObservacao());
        pedidoDelivery.setCodPedidoIntegracao(pedidoDao.getCodPedidoIntegracao());
        pedidoDelivery.setOrigem(pedidoDao.getOrigem());
        pedidoDelivery.setTipo(pedidoDao.getTipoPedido());
        pedidoDelivery.setReferencia("");
        pedidoDelivery.setReferenciaCurta("");
        pedidoDelivery.setStatusPedido(pedidoDao.getStatusPedido());

//        PagamentoDelivery pagamentoDelivery = new PagamentoDelivery();
//        pagamentoDelivery.setTroco(pedidoDao.getVrTroco());
//        pagamentoDelivery.setPrePago(false);
//        pagamentoDelivery.setValor(pedidoDao.getVrTotal());
//        pagamentoDelivery.setTipo(pedidoDao.getFormaPagamento());
//        pagamentoDelivery.setNome(pedidoDao.getFormaPagamento());

//        pedidoDelivery.setPagamento(pagamentoDelivery);

        return pedidoDelivery;
    }

    @RequestMapping("/order/{id}/next")
    public ResponseEntity<?> updateStatusOrder(@PathVariable String id) {
        try {
            PedidoDao pedidoDao = _pedidoRepository.getOrderById(Integer.parseInt(id));
            String orderStatus = "ABERTO";
            switch (pedidoDao.getStatusPedido()) {
                case "ABERTO":
                    orderStatus = "Confirmado";
                    break;
                case "Confirmado":
                    orderStatus = "Despachado";
                    break;
                case "Cancelado":
                case "Concluido":
                    return ResponseEntity.status(HttpStatus.NOT_MODIFIED).body(new Erro("pedido não pode ser atualizado"));
                case "Despachado":
                    orderStatus = "Concluido";
                    break;
            }

            int statusOrder = _pedidoRepository.updateStatusOrder(Integer.parseInt(id), orderStatus);
            if (statusOrder == -1) {
                throw new Exception("pedido não atualizado, tente novamente");
            }
        } catch (Exception e) {
            e.printStackTrace();

            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new Erro(e.getMessage()));
        }

        return ResponseEntity.status(HttpStatus.OK).body(null);
    }

    @RequestMapping("/order/{id}/cancel")
    public ResponseEntity<?> cancelOrder(@PathVariable String id) {
        try {
            PedidoDao pedidoDao = _pedidoRepository.getOrderById(Integer.parseInt(id));
            int statusOrder = _pedidoRepository.updateStatusOrder(Integer.parseInt(id), "CANCELADO");
            if (statusOrder == -1) {
                throw new Exception("pedido não cancelado, tente novamente");
            }
        } catch (Exception e) {
            e.printStackTrace();

            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new Erro(e.getMessage()));
        }

        return ResponseEntity.status(HttpStatus.OK).body(null);
    }
}
