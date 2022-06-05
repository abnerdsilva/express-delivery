package delivery.repository.interfaces;

import delivery.model.dao.ConfigDao;

import java.sql.SQLException;

public interface IConfigRepository {
    ConfigDao load(String item) throws SQLException;
}
