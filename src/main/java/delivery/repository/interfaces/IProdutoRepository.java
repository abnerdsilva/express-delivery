package delivery.repository.interfaces;

import delivery.model.dao.ProdutoDao;

import java.io.IOException;
import java.sql.SQLException;

public interface IProdutoRepository {
    ProdutoDao loadById(int id) throws IOException, SQLException;
}
