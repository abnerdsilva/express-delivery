package delivery.domain.user;

public record ClientDTO(String codCliente, String nome, String telefone, String email, String cpf, String rg,
                        String logradouro, int numero, String bairro, String cidade, String estado, int cep,
                        int statusCliente, String observacao) {
}
