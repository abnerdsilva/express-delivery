package delivery.repository.interfaces;

import delivery.model.dao.ClienteDao;

import java.sql.SQLException;
import java.util.List;

public interface IClienteRepository {
    List<ClienteDao> loadAll() throws SQLException;

    ClienteDao loadByCode(String code) throws SQLException;

    ClienteDao loadByPhone(String phone) throws SQLException;

    ClienteDao loadById(int id) throws SQLException;

    List<ClienteDao> loadClientsByPhone(String phone);

    List<ClienteDao> loadClientsByName(String name);

    int loadMaxClientId() throws SQLException;

    int create(ClienteDao client) throws SQLException;

    int update(ClienteDao client) throws SQLException;
}
