package delivery.controller;

import delivery.model.dao.ClienteDao;
import delivery.repository.ClienteRepository;

import java.sql.SQLException;

public class ClienteController {
    private final ClienteRepository clienteRepository = new ClienteRepository();

    long checkClientExists(int idClient) {
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

    public int addCliente(ClienteDao cliente) throws SQLException {
        return clienteRepository.save(cliente);
    }
}
