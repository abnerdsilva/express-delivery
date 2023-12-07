package delivery.domain.user;

import java.util.ArrayList;

public record OrderDTO(int id, String codPedido, String codCliente, String nome, String statusPedido, String dataPedido,
                       String dataAtualizacao, String dataEntrega, double vrTotal, double vrTaxa, double vrTroco,
                       String logradouro, int numero, String codUsuario, String bairro, String cidade, String estado,
                       String cep, String tipoPedido, String origem, String observacao, String formaPagamento,
                       ArrayList<OrderItemDTO> itens, ClientDTO cliente, PagamentoDTO pagamento) {
}