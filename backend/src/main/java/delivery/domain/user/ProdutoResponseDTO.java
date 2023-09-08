package delivery.domain.user;

public record ProdutoResponseDTO(String cod_barras, String nome, String observacao, String localizacao,
                                 String categoria, String un_medida, int status_produto, double vr_compra,
                                 double vr_unitario, double margem_lucro) {
}