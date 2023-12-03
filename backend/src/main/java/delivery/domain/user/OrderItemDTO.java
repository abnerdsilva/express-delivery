package delivery.domain.user;

public record OrderItemDTO(String id, String codPedido, String codProduto, String codExterno, String nome, int quantidade,
                           double vrUnitario, double vrTotal, double vrDesconto, double vrAdicional, String observacao,
                           int statusEditar) {
}