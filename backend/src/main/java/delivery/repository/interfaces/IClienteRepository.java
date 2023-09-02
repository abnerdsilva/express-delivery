package delivery.repository.interfaces;

import delivery.model.dao.ClienteDao;

import java.sql.SQLException;
import java.util.List;

public interface IClienteRepository {
    List<ClienteDao> loadAll() throws SQLException;

    ClienteDao loadById(int idClient) throws SQLException;

    int loadMaxClientId() throws SQLException;

    int save(ClienteDao client) throws SQLException;
}
