package delivery.repository.interfaces;

import delivery.model.dao.UsuarioDao;

public interface IUsuarioRepository {
    UsuarioDao login(String username, String password);
    UsuarioDao findByLogin(String username);
}
