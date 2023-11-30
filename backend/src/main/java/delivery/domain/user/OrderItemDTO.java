package delivery.domain.user;

public record OrderItemDTO(String CodPedido, String CodProduto, String CodExterno, String Nome, int Quantidade,
                           double VrUnitario, double VrTotal, double VrDesconto, double VrAdicional, String Observacao,
                           int StatusEditar) {
}