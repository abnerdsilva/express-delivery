package delivery.controller;

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
                    LoggerInFile.printError("Produto não possui codigo externo");
                    continue;
                }

                int codProdutoExterno = Integer.parseInt(item.getCodExterno());

                ProdutoDao produto = _produtoRepository.loadById(codProdutoExterno);
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
        if (clientId > 0){
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
    public List<PedidoDao> getOrders() {
        return _pedidoRepository.getAll();
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

//        PagamentoDelivery pagamentoDelivery = new PagamentoDelivery();
//        pagamentoDelivery.setTroco(pedidoDao.getVrTroco());
//        pagamentoDelivery.setPrePago(false);
//        pagamentoDelivery.setValor(pedidoDao.getVrTotal());
//        pagamentoDelivery.setTipo(pedidoDao.getFormaPagamento());
//        pagamentoDelivery.setNome(pedidoDao.getFormaPagamento());

//        pedidoDelivery.setPagamento(pagamentoDelivery);

        return pedidoDelivery;
    }
}
