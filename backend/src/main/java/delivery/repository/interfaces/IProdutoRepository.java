package delivery.repository.interfaces;

import delivery.model.dao.ProdutoDao;

import java.util.List;

public interface IProdutoRepository {
    ProdutoDao loadByCode(String code);
    ProdutoDao loadByBarCode(String code);
    ProdutoDao loadById(int id);
    List<ProdutoDao> loadProductsByName(String name);
    ProdutoDao loadProductByName(String name);
    int lastProductSaved();
    List<ProdutoDao> loadAll();
    int create(ProdutoDao item);
    int update(ProdutoDao item);
}
