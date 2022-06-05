package delivery.controller;

import delivery.model.dao.ClienteDao;
import delivery.repository.ClienteRepository;

import java.sql.SQLException;

public class ClienteController {
    private final ClienteRepository clienteRepository = new ClienteRepository();

    /**
     * verifica se cliente informado existe
     *
     * @param idClient - codigo do cliente
     * @return -
     */
    public long checkClientExists(int idClient) {
        try {
            ClienteDao cliente = clienteRepository.loadById(idClient);
            if (cliente != null) {
                return cliente.getCodCliente();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        return -1;
    }

    /**
     * solicita salvar cliente no banco de dados
     *
     * @param cliente - dados do cliente
     * @return - retorna id do cliente que foi salvo
     * @throws SQLException - retorna exceção quando ocorre erro
     */
    public int addCliente(ClienteDao cliente) throws SQLException {
        return clienteRepository.save(cliente);
    }
}
