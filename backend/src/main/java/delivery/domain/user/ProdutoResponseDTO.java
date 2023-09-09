package delivery.domain.user;

public record ProdutoResponseDTO(String codBarras, String nome, String observacao, String localizacao,
                                 String categoria, String unMedida, int statusProduto, double vrCompra,
                                 double vrUnitario, double margemLucro) {
}