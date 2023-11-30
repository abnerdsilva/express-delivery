package delivery.controller;

import delivery.Erro;
import delivery.domain.user.OrderDTO;
import delivery.domain.user.OrderItemDTO;
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
import jakarta.validation.Valid;
import log.LoggerInFile;
import log.MessageDefault;
import org.jetbrains.annotations.NotNull;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

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
    public int savePedidoIntegracao(PedidoDelivery pedidoDelivery) throws SQLException {
        try {
            ClienteDao clienteDao = _clienteRepository.loadByCode(pedidoDelivery.getCliente().getCodCliente());
            if (clienteDao == null || clienteDao.getCodCliente().equals("")) {
                var idCliente = addCliente(pedidoDelivery.getCliente());
                if (idCliente.equals("-1")) {
                    LoggerInFile.printError(MessageDefault.msgErrorAddClient);
                    return -1;
                }
            }

            clienteDao = _clienteRepository.loadByCode(pedidoDelivery.getCliente().getCodCliente());

            PedidoDao pedido = new PedidoDao();
            pedido.setDataPedido(pedidoDelivery.getDataCriacao());
            pedido.setBairro(pedidoDelivery.getCliente().getBairro());
            pedido.setLogradouro(pedidoDelivery.getCliente().getLogradouro());
            pedido.setEstado(pedidoDelivery.getCliente().getEstado());
            pedido.setNumero(pedidoDelivery.getCliente().getNumero());
            pedido.setCidade(pedidoDelivery.getCliente().getCidade());
            pedido.setCep(Integer.toString(pedidoDelivery.getCliente().getCep()));
            pedido.setDataPedido(pedidoDelivery.getDataCriacao());
            pedido.setCodCliente(clienteDao.getCodCliente());
            pedido.setDataEntrega(pedidoDelivery.getDataEntrega());
            pedido.setFormaPagamento(pedidoDelivery.getPagamento().getNome() + "-" + pedidoDelivery.getPagamento().getTipo());
            pedido.setTipoPedido(pedidoDelivery.getTipo());
            pedido.setOrigem(pedidoDelivery.getOrigem());
            pedido.setVrTaxa(pedidoDelivery.getVrAdicional());
            pedido.setVrTotal(pedidoDelivery.getVrTotal());
            pedido.setVrDesconto(pedidoDelivery.getVrDesconto());
            pedido.setVrTroco(pedidoDelivery.getVrTroco());
            pedido.setCodPedidoIntegracao(pedidoDelivery.getCodPedidoIntegracao());

            String observacao = pedidoDelivery.getObservacao();
            if (pedidoDelivery.isAgendado()) {
                observacao += "\n [AGENDADO]: " + pedidoDelivery.getDataEntrega();
            }
            if (pedidoDelivery.getPagamento().isPrePago()) {
                observacao += "\n [PAGAMENTO JÁ REALIZADO]";
            }

            pedido.setObservacao(observacao);

            var orderUid = _pedidoRepository.saveOrder(pedido);
            if (orderUid.equals("-1")) {
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

                ProdutoDao produto = _produtoRepository.loadByCode(codProdutoExterno);
                if (produto == null || produto.getCodProduto().equals("0")) {
                    LoggerInFile.printError("Produto [COD_EXTERNO = " + codProdutoExterno + "] não encontrado");
                    continue;
                }

                PedidoItemDao pedidoItem = new PedidoItemDao();
                pedidoItem.setCodPedido(orderUid);
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

            var orderSaved = _pedidoRepository.getOrderByCode(orderUid);

            return orderSaved.getId();
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
    private String addCliente(ClienteDelivery clienteDelivery) throws SQLException {
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

        var clientId = cliente.getCodCliente();
        clientId = _clienteRepository.hasClient(clientId, cliente.getTelefone());
        if (!clientId.equals("-1")) {
            return clientId;
        }
        var clientIdTemp = _clienteRepository.create(cliente);
        var client = _clienteRepository.loadById(clientIdTemp);
        return client.getCodCliente();
    }

    /**
     * Endpoint para consulta de pedidos do dia atual
     *
     * @return - lista de pedidos
     */
    @RequestMapping("/v1/orders")
    public ResponseEntity<?> getOrders(@RequestParam(value = "filter", required = false) String filter) {
        List<PedidoDelivery> orders = new ArrayList<>();
        List<OrderDTO> ordersDto = new ArrayList<>();
        List<PedidoDao> pedidoDao = new ArrayList<>();

        if (filter == null)
            filter = "";

        if (filter == null || filter.isEmpty()) {
            pedidoDao = _pedidoRepository.findAll();
        } else if (filter.equals("mobile")) {
            pedidoDao = _pedidoRepository.getOrdersFromToday();
        } else if (filter.equals("date")) {
            DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy-MM-dd");
            var today = LocalDateTime.now().format(dtf);
            var tomorow = LocalDateTime.now().plusDays(1).format(dtf);

            pedidoDao = _pedidoRepository.findAllByDate(today, tomorow);
        } else if (filter.equals("lastOrder")) {
            var orderId = _pedidoRepository.loadMaxOrder();
            if (orderId == 0) orderId = 1;
            var order = _pedidoRepository.getOrderById(orderId);
            if (order != null) {
                pedidoDao.add(order);
            }
        } else if (filter.equals("integracao")) {
            var orderId = _pedidoRepository.loadMaxOrder();
            if (orderId > 0) {
                var order = _pedidoRepository.getOrderById(orderId);
                pedidoDao.add(order);
            }
        }

        if (!filter.equals("date")) {
            for (var ped : pedidoDao) {
                PedidoDelivery pedidoDelivery = new PedidoDelivery();
                try {
                    ClienteDao clienteDao = _clienteRepository.loadByCode(ped.getCodCliente());

                    if (clienteDao == null) {
                        throw new Exception("cliente não encontrado");
                    }

                    pedidoDelivery.setId(ped.getId());
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

                List<PedidoItemDelivery> itensDelivery = new ArrayList<>();
                List<PedidoItemDao> itensDao = _pedidoRepository.loadItensByCode(ped.getCodPedido());

                for (var item : itensDao) {
                    itensDelivery.add(item.itemDaoToItemDelivery());
                }

                pedidoDelivery.setItens(itensDelivery);

                orders.add(pedidoDelivery);
            }
        } else {
            for (var ped : pedidoDao) {
                var itensListDto = new ArrayList<OrderItemDTO>();

                List<PedidoItemDao> itensDao = _pedidoRepository.loadItensByCode(ped.getCodPedido());
                for (var it : itensDao) {
                    var temp = new OrderItemDTO(it.getCodPedido(), it.getCodProduto(), it.getCodExterno(), it.getNome(),
                            it.getQuantidade(), it.getVrUnitario(), it.getVrTotal(), 0.0, 0.0,
                            it.getObservacao(), 0);

                    itensListDto.add(temp);
                }

                var ord = new OrderDTO(ped.getId(), ped.getCodPedido(), ped.getCodCliente(),
                        ped.getCliente().getNome(), ped.getStatusPedido(), ped.getDataPedido(),
                        ped.getDataAtualizacao(), ped.getDataEntrega(), ped.getVrTotal(),
                        ped.getVrTaxa(), ped.getVrTroco(), ped.getLogradouro(), ped.getNumero(),
                        ped.getCodUsuario(), ped.getBairro(), ped.getCidade(), ped.getEstado(),
                        ped.getCep(), ped.getTipoPedido(), ped.getOrigem(), ped.getObservacao(),
                        ped.getFormaPagamento(), itensListDto);

                ordersDto.add(ord);
            }
        }

        if (filter.equals("lastOrder")) {
            if (!orders.isEmpty()) {
                return ResponseEntity.status(HttpStatus.OK).body(orders.get(0));
            } else {
                return ResponseEntity.status(HttpStatus.OK).build();
            }
        } else if (filter.equals("date")) {
            return ResponseEntity.status(HttpStatus.OK).body(ordersDto);
        } else {
            return ResponseEntity.status(HttpStatus.OK).body(orders);
        }
    }

    @RequestMapping("/v1/order/{id}")
    public PedidoDelivery getOrderFromId(@PathVariable String id) throws SQLException {
        List<PedidoItemDelivery> itens = new ArrayList<>();
        List<PedidoItemDao> itensDao = _pedidoRepository.loadItensByCode(id);

        for (var item : itensDao) {
            itens.add(item.itemDaoToItemDelivery());
        }

        PedidoDao pedidoDao = _pedidoRepository.getOrderByCode(id);

        ClienteDao clienteDao = _clienteRepository.loadByCode(pedidoDao.getCodCliente());

        PedidoDelivery pedidoDelivery = new PedidoDelivery();
        pedidoDelivery.setCodPedido(id);
        pedidoDelivery.setItens(itens);
        pedidoDelivery.setCliente(clienteDao.clientDaoToClienteDelivery());
        pedidoDelivery.setDataCriacao(pedidoDao.getDataPedido());
        pedidoDelivery.setVrTotal(pedidoDao.getVrTotal());
        pedidoDelivery.setVrTroco(pedidoDao.getVrTroco());
        pedidoDelivery.setVrDesconto(pedidoDao.getVrDesconto());
        pedidoDelivery.setVrAdicional(pedidoDao.getVrTaxa());
        pedidoDelivery.setObservacao(pedidoDao.getObservacao());
        pedidoDelivery.setCodPedidoIntegracao(pedidoDao.getCodPedidoIntegracao());
        pedidoDelivery.setOrigem(pedidoDao.getOrigem());
        pedidoDelivery.setTipo(pedidoDao.getTipoPedido());
        pedidoDelivery.setReferencia("");
        pedidoDelivery.setReferenciaCurta("");
        pedidoDelivery.setStatusPedido(pedidoDao.getStatusPedido());

        PagamentoDelivery pagamentoDelivery = new PagamentoDelivery();
        pagamentoDelivery.setTroco(pedidoDao.getVrTroco());
        pagamentoDelivery.setPrePago(false);
        pagamentoDelivery.setValor(pedidoDao.getVrTotal());
        pagamentoDelivery.setTipo(pedidoDao.getFormaPagamento());
        pagamentoDelivery.setNome(pedidoDao.getFormaPagamento());

        pedidoDelivery.setCliente(clienteDao.clientDaoToClienteDelivery());

        pedidoDelivery.setPagamento(pagamentoDelivery);

        return pedidoDelivery;
    }

    @RequestMapping("/v1/order/{id}/next")
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

    @RequestMapping("/v1/order/{id}/cancel")
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

    @PostMapping("/v1/order")
    public ResponseEntity<?> saveOrder(@RequestBody @Valid OrderDTO data) {
        try {
            var cliente = _clienteRepository.loadByCode(data.codCliente());

            var orderConverted = convertPedidoDelivery(data, cliente);

            var orderUidSaved = _pedidoRepository.saveOrder(orderConverted);
            if (orderUidSaved == null || orderUidSaved.equals("-1")) {
                throw new RuntimeException("falha ao salvar pedido");
            }

            for (var item : data.itens()) {
                var orderItem = convertPedidoItem(item);
                orderItem.setCodPedido(orderUidSaved);

                var orderItemSaved = _pedidoRepository.saveOrderItem(orderItem);
                if (orderItemSaved == -1) {
                    throw new RuntimeException("falha ao salvar item do pedido");
                }
            }

            var order = _pedidoRepository.getOrderByCode(orderUidSaved);
            var itens = _pedidoRepository.loadItensByCode(orderUidSaved);

            var itensListDto = new ArrayList<OrderItemDTO>();

            for (var it : itens) {
                var temp = new OrderItemDTO(it.getCodPedido(), it.getCodProduto(), it.getCodExterno(), it.getNome(),
                        it.getQuantidade(), it.getVrUnitario(), it.getVrTotal(), 0.0, 0.0,
                        it.getObservacao(), 0);

                itensListDto.add(temp);
            }

            var ord = new OrderDTO(order.getId(), order.getCodPedido(), order.getCodCliente(),
                    cliente.getNome(), order.getStatusPedido(), order.getDataPedido(),
                    order.getDataAtualizacao(), order.getDataEntrega(), order.getVrTotal(),
                    order.getVrTaxa(), order.getVrTroco(), order.getLogradouro(), order.getNumero(),
                    order.getCodUsuario(), order.getBairro(), order.getCidade(), order.getEstado(),
                    order.getCep(), order.getTipoPedido(), order.getOrigem(), order.getObservacao(),
                    order.getFormaPagamento(), itensListDto);

            return ResponseEntity.status(HttpStatus.OK).body(ord);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new Erro(e.getMessage()));
        }
    }

    @NotNull
    private static PedidoDao convertPedidoDelivery(OrderDTO data, ClienteDao cliente) {
        var pedido = new PedidoDao();
        pedido.setCodPedido(data.codPedido());
        pedido.setStatusPedido(data.statusPedido());
        pedido.setObservacao(data.observacao());
        pedido.setVrDesconto(0.0);
        pedido.setVrTaxa(data.vrTaxa());
        pedido.setVrTotal(data.vrTotal());
        pedido.setVrTroco(data.vrTroco());
        pedido.setCodPedidoIntegracao("");
        pedido.setOrigem(data.origem());
        pedido.setFormaPagamento(data.formaPagamento());
        pedido.setTipoPedido(data.tipoPedido());
        pedido.setCliente(cliente);
        pedido.setDataPedido(data.dataPedido());
        pedido.setLogradouro(data.logradouro());
        pedido.setNumero(data.numero());
        pedido.setEstado(data.estado());
        pedido.setCidade(data.cidade());
        pedido.setCep(data.cep());
        pedido.setBairro(data.bairro());
        pedido.setCodUsuario(data.codUsuario());
        return pedido;
    }

    @NotNull
    private static PedidoItemDao convertPedidoItem(OrderItemDTO item) {
        var codExterno = item.CodExterno() == null ? "" : item.CodExterno();

        var orderItem = new PedidoItemDao();
        orderItem.setCodProduto(item.CodProduto());
        orderItem.setNome(item.Nome());
        orderItem.setCodExterno(codExterno);
        orderItem.setQuantidade(item.Quantidade());
        orderItem.setObservacao(item.Observacao());
        orderItem.setVrTotal(item.VrTotal());
        orderItem.setVrUnitario(item.VrUnitario());
        return orderItem;
    }
}
