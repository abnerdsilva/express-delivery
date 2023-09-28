package delivery.repository.interfaces;

import delivery.model.dao.UsuarioDao;

import java.util.List;

public interface IUsuarioRepository {
    UsuarioDao loadByCode(String code);
    List<UsuarioDao> loadClientsByName(String name);
    UsuarioDao loadByName(String name);
    List<UsuarioDao> loadAll();
    UsuarioDao login(String username, String password);
    UsuarioDao findByLogin(String username);
}
