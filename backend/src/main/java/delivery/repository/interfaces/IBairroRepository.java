package delivery.repository.interfaces;

import delivery.model.dao.BairroDao;

import java.sql.SQLException;
import java.util.List;

public interface IBairroRepository {
    List<BairroDao> loadAll() throws SQLException;

    BairroDao findByCode(String code) throws SQLException;

    BairroDao findByName(String name) throws SQLException;

    String save(BairroDao item) throws SQLException;

    int update(BairroDao item) throws SQLException;
}
