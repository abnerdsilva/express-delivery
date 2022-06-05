package delivery.repository.interfaces;

import delivery.model.dao.ProdutoDao;

public interface IProdutoRepository {
    ProdutoDao loadById(int id);
}
