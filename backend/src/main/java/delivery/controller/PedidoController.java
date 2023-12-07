package delivery.controller;

import delivery.Erro;
import delivery.domain.user.ClientDTO;
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
            pedido.setDataPedido(pedidoDelivery.getDataPedido());
            pedido.setBairro(pedidoDelivery.getCliente().getBairro());
            pedido.setLogradouro(pedidoDelivery.getCliente().getLogradouro());
            pedido.setEstado(pedidoDelivery.getCliente().getEstado());
            pedido.setNumero(pedidoDelivery.getCliente().getNumero());
            pedido.setCidade(pedidoDelivery.getCliente().getCidade());
            pedido.setCep(Integer.toString(pedidoDelivery.getCliente().getCep()));
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
                pedidoItem.setVrUnitario(item.getVrUnitario());
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
    public ResponseEntity<?> getOrders(@RequestParam(value = "filter", required = false) String filter,
                                       @RequestParam(value = "status", required = false) String status,
                                       @RequestParam(value = "dataInicio", required = false) String dataInicio,
                                       @RequestParam(value = "dataFim", required = false) String dataFim,
                                       @RequestParam(value = "id", required = false) String id) throws SQLException {
//        List<PedidoDelivery> orders = new ArrayList<>();
        List<OrderDTO> orders = new ArrayList<>();
        List<PedidoDao> pedidoDao = new ArrayList<>();

        if (filter == null)
            filter = "";
        if (status == null)
            status = "";
        if (dataFim == null)
            dataFim = "";
        if (dataInicio == null)
            dataInicio = "";
        if (id == null)
            id = "0";

        if (!status.isEmpty() && Integer.parseInt(id) > 0) {
            pedidoDao = _pedidoRepository.getOrdersByIdAndStatus(status, Integer.parseInt(id));
        } else if (!dataInicio.isEmpty() && !dataFim.isEmpty()) {
            pedidoDao = _pedidoRepository.findAllByDateAndStatus(dataInicio, dataFim, status);
        } else if (!status.isEmpty()) {
            pedidoDao = _pedidoRepository.getOrdersByStatus(status);
        } else if (filter.isEmpty()) {
            pedidoDao = _pedidoRepository.findAll();
        } else if (filter.equals("mobile")) {
            pedidoDao = _pedidoRepository.getOrdersFromToday();
        } else if (filter.equals("date")) {
//            DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy-MM-dd");
//            var today = LocalDateTime.now().format(dtf);
//            var tomorow = LocalDateTime.now().plusDays(1).format(dtf);

            pedidoDao = _pedidoRepository.getOrdersFromToday();
        } else if (filter.equals("lastOrder")) {
            var lastOrder = _pedidoRepository.loadMaxOrder();
            if (lastOrder != null) {
                pedidoDao.add(lastOrder);
            }
        } else if (filter.equals("integracao")) {
            var lastOrder = _pedidoRepository.loadMaxOrder();
            if (lastOrder != null) {
                pedidoDao.add(lastOrder);
            }
        }

        for (var ped : pedidoDao) {
            var itensListDto = new ArrayList<OrderItemDTO>();

            List<PedidoItemDao> itensDao = _pedidoRepository.loadItensByCode(ped.getCodPedido());
            for (var it : itensDao) {
                var temp = convertPedidoItenDaoToOrderItemDTO(it);
                itensListDto.add(temp);
            }

//            var client = _clienteRepository.loadByCode(ped.getCodCliente());
            var clientDto = convertClienteDaoToClientDTO(ped.getCliente());
            var ord = convertPedidoDaoToOrderDto(ped, itensListDto, clientDto);

            orders.add(ord);
        }

        if (filter.equals("lastOrder")) {
            if (!orders.isEmpty()) {
                return ResponseEntity.status(HttpStatus.OK).body(orders.get(0));
            } else {
                return ResponseEntity.status(HttpStatus.OK).build();
            }
//        } else if (!filter.equals("date") || (dataInicio.isEmpty() && dataFim.isEmpty())) {
//            return ResponseEntity.status(HttpStatus.OK).body(orders);
        } else {
            return ResponseEntity.status(HttpStatus.OK).body(orders);
        }
    }

    @RequestMapping("/v1/orders/print")
    public ResponseEntity<?> getOrdersToPrint() throws SQLException {
        List<OrderDTO> orders = new ArrayList<>();
        List<PedidoDao> pedidoDao = _pedidoRepository.getPedidosParaImprimir();

        for (var ped : pedidoDao) {
            var itensListDto = new ArrayList<OrderItemDTO>();

            List<PedidoItemDao> itensDao = _pedidoRepository.loadItensByCode(ped.getCodPedido());
            for (var it : itensDao) {
                var temp = convertPedidoItenDaoToOrderItemDTO(it);
                itensListDto.add(temp);
            }

            var clientDto = convertClienteDaoToClientDTO(ped.getCliente());
            var ord = convertPedidoDaoToOrderDto(ped, itensListDto, clientDto);

            orders.add(ord);
        }

        return ResponseEntity.status(HttpStatus.OK).body(orders);
    }

    @RequestMapping(value = "/v1/order/{id}", method = RequestMethod.GET)
    public ResponseEntity<?> getOrderFromId(@PathVariable String id) throws SQLException {
        List<PedidoItemDelivery> itens = new ArrayList<>();
        List<PedidoItemDao> itensDao = _pedidoRepository.loadItensByCode(id);

        for (var item : itensDao) {
            itens.add(item.itemDaoToItemDelivery());
        }

        PedidoDao pedidoDao = _pedidoRepository.getOrderByCode(id);

        ClienteDao clienteDao = _clienteRepository.loadByCode(pedidoDao.getCodCliente());

        PedidoDelivery pedidoDelivery = new PedidoDelivery();
        pedidoDelivery.setId(pedidoDao.getId());
        pedidoDelivery.setCodPedido(pedidoDao.getCodPedido());
        pedidoDelivery.setItens(itens);
        pedidoDelivery.setCliente(clienteDao.clientDaoToClienteDelivery());
        pedidoDelivery.setDataPedido(pedidoDao.getDataPedido());
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

        return ResponseEntity.status(HttpStatus.OK).body(pedidoDelivery);
    }

    @RequestMapping("/v1/order/{id}/next")
    public ResponseEntity<?> updateStatusOrder(@PathVariable String id) {
        try {
            PedidoDao pedidoDao = _pedidoRepository.getOrderByCode(id);
            if (pedidoDao.getId() <= 0) {
                throw new Exception("pedido não encontrado, tente novamente");
            }

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

            int statusOrder = _pedidoRepository.updateStatusOrder(pedidoDao.getId(), orderStatus);
            if (statusOrder == -1) {
                throw new Exception("pedido não atualizado, tente novamente");
            }
        } catch (Exception e) {
            e.printStackTrace();

            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new Erro(e.getMessage()));
        }

        return ResponseEntity.status(HttpStatus.OK).body(null);
    }

    @RequestMapping(value = "/v1/order/{id}/printed", method = RequestMethod.POST)
    public ResponseEntity<?> setOrderPrinted(@PathVariable String id) {
        try {
            PedidoDao pedidoDao = _pedidoRepository.getOrderByCode(id);
            if (pedidoDao.getId() <= 0) {
                throw new Exception("pedido não encontrado, tente novamente");
            }

            int statusOrder = _pedidoRepository.updateOrderPrinted(id);
            if (statusOrder == -1) {
                throw new Exception("pedido não atualizado, tente novamente");
            }
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new Erro(e.getMessage()));
        }

        return ResponseEntity.status(HttpStatus.OK).body(null);
    }

    @RequestMapping(value = "/v1/order/{id}", method = RequestMethod.PUT)
    public ResponseEntity<?> updateOrder(@PathVariable int id, @RequestBody @Valid OrderDTO data) {
        try {
            var cliente = _clienteRepository.loadByCode(data.codCliente());

            var orderConverted = convertPedidoDelivery(data, cliente);

            int statusOrder = _pedidoRepository.updateOrder(orderConverted);
            if (statusOrder == -1) {
                throw new Exception("pedido não atualizado, tente novamente");
            }

            for (var item : data.itens()) {
                var orderItem = convertPedidoItem(item);
                orderItem.setCodPedido(data.codPedido());

                statusOrder = _pedidoRepository.saveOrderItem(orderItem);
                if (statusOrder == -1) {
                    throw new Exception("pedido não atualizado, tente novamente");
                }
            }

            if (!data.itens().isEmpty()) {
                _pedidoRepository.setOrderToPrint(orderConverted.getCodPedido());
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
            PedidoDao pedidoDao = _pedidoRepository.getOrderByCode(id);
            if (pedidoDao.getId() <= 0) {
                throw new Exception("pedido não encontrado, tente novamente");
            }

            int statusOrder = _pedidoRepository.updateStatusOrder(pedidoDao.getId(), "CANCELADO");
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
                var itemDTO = convertPedidoItenDaoToOrderItemDTO(it);
                itensListDto.add(itemDTO);
            }

            var clientDTO = convertClienteDaoToClientDTO(order.getCliente());
            var ord = convertPedidoDaoToOrderDto(order, itensListDto, clientDTO);

            _pedidoRepository.setOrderToPrint(ord.codPedido());

            return ResponseEntity.status(HttpStatus.OK).body(ord);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new Erro(e.getMessage()));
        }
    }

    @PostMapping("/v1/order/{code}/reprint")
    public ResponseEntity<?> printOrder(@PathVariable String code) throws SQLException {
//        List<PedidoItemDelivery> itens = new ArrayList<>();
//        List<PedidoItemDao> itensDao = _pedidoRepository.loadItensByCode(code);
//
//        for (var item : itensDao) {
//            itens.add(item.itemDaoToItemDelivery());
//        }
//
//        PedidoDao pedidoDao = _pedidoRepository.getOrderByCode(code);
//
//        ClienteDao clienteDao = _clienteRepository.loadByCode(pedidoDao.getCodCliente());
//
//        PedidoDelivery pedidoDelivery = new PedidoDelivery();
//        pedidoDelivery.setId(pedidoDao.getId());
//        pedidoDelivery.setCodPedido(pedidoDao.getCodPedido());
//        pedidoDelivery.setItens(itens);
//        pedidoDelivery.setCliente(clienteDao.clientDaoToClienteDelivery());
//        pedidoDelivery.setDataPedido(pedidoDao.getDataPedido());
//        pedidoDelivery.setVrTotal(pedidoDao.getVrTotal());
//        pedidoDelivery.setVrTroco(pedidoDao.getVrTroco());
//        pedidoDelivery.setVrDesconto(pedidoDao.getVrDesconto());
//        pedidoDelivery.setVrAdicional(pedidoDao.getVrTaxa());
//        pedidoDelivery.setObservacao(pedidoDao.getObservacao());
//        pedidoDelivery.setCodPedidoIntegracao(pedidoDao.getCodPedidoIntegracao());
//        pedidoDelivery.setOrigem(pedidoDao.getOrigem());
//        pedidoDelivery.setTipo(pedidoDao.getTipoPedido());
//        pedidoDelivery.setReferencia("");
//        pedidoDelivery.setReferenciaCurta("");
//        pedidoDelivery.setStatusPedido(pedidoDao.getStatusPedido());
//
//        PagamentoDelivery pagamentoDelivery = new PagamentoDelivery();
//        pagamentoDelivery.setTroco(pedidoDao.getVrTroco());
//        pagamentoDelivery.setPrePago(false);
//        pagamentoDelivery.setValor(pedidoDao.getVrTotal());
//        pagamentoDelivery.setTipo(pedidoDao.getFormaPagamento());
//        pagamentoDelivery.setNome(pedidoDao.getFormaPagamento());
//
//        pedidoDelivery.setCliente(clienteDao.clientDaoToClienteDelivery());
//
//        pedidoDelivery.setPagamento(pagamentoDelivery);
//
//        var orderPrinted = ImprimeController.imprimePedido(pedidoDelivery);
//        if (!orderPrinted) {
//            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new Erro("Falha ao imprimir pedido"));
//        }

        var status = _pedidoRepository.setOrderToPrint(code);
        if (status <= 0)
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new Erro("falha ao enviar para impressão"));

        return ResponseEntity.status(HttpStatus.OK).build();
    }

    @NotNull
    private static PedidoDao convertPedidoDelivery(OrderDTO data, ClienteDao cliente) {
        var pedido = new PedidoDao();
        pedido.setId(data.id());
        pedido.setCodCliente(data.codCliente());
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
        var codExterno = item.codExterno() == null ? "" : item.codExterno();

        var orderItem = new PedidoItemDao();
        orderItem.setCodPedidoItem(item.id());
        orderItem.setCodPedido(item.codPedido());
        orderItem.setCodProduto(item.codProduto());
        orderItem.setNome(item.nome());
        orderItem.setCodExterno(codExterno);
        orderItem.setQuantidade(item.quantidade());
        orderItem.setObservacao(item.observacao());
        orderItem.setVrTotal(item.vrTotal());
        orderItem.setVrUnitario(item.vrUnitario());
        return orderItem;
    }

    @NotNull
    private static OrderDTO convertPedidoDaoToOrderDto(PedidoDao ped, ArrayList<OrderItemDTO> itensListDto, ClientDTO cliente) {
        return new OrderDTO(ped.getId(), ped.getCodPedido(), ped.getCodCliente(),
                ped.getCliente().getNome(), ped.getStatusPedido(), ped.getDataPedido(),
                ped.getDataAtualizacao(), ped.getDataEntrega(), ped.getVrTotal(),
                ped.getVrTaxa(), ped.getVrTroco(), ped.getLogradouro(), ped.getNumero(),
                ped.getCodUsuario(), ped.getBairro(), ped.getCidade(), ped.getEstado(),
                ped.getCep(), ped.getTipoPedido(), ped.getOrigem(), ped.getObservacao(),
                ped.getFormaPagamento(), itensListDto, cliente);
    }

    @NotNull
    private static ClientDTO convertClienteDaoToClientDTO(ClienteDao client) {
        return new ClientDTO(client.getCodCliente(), client.getNome(), client.getTelefone(),
                client.getEmail(), client.getCpf(), client.getRg(), client.getLogradouro(), client.getNumero(),
                client.getBairro(), client.getCidade(), client.getEstado(), client.getCep(),
                client.getStatusCliente(), client.getObservacao());
    }

    @NotNull
    private static OrderItemDTO convertPedidoItenDaoToOrderItemDTO(PedidoItemDao item) {
        return new OrderItemDTO(item.getCodPedidoItem(), item.getCodPedido(), item.getCodProduto(),
                item.getCodExterno(), item.getNome(), item.getQuantidade(), item.getVrUnitario(),
                item.getVrTotal(), 0.0, 0.0, item.getObservacao(), item.getStatusEditar());
    }
}
