package delivery.domain.user;

public record PagamentoDTO(String nome, double valor, String tipo, double troco, boolean prePago) {
}