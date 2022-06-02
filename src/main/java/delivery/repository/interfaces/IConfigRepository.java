package delivery.repository.interfaces;

import delivery.model.dao.ConfigDao;

import java.sql.SQLException;
import java.util.List;

public interface IConfigRepository {
    List<ConfigDao> loadAll();

    ConfigDao load(String item) throws SQLException;

    ConfigDao save(ConfigDao config);
}
