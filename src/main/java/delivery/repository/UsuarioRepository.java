package delivery.repository;

import db.DatabaseConnection;
import delivery.model.dao.UsuarioDao;
import delivery.repository.interfaces.IUsuarioRepository;
import log.LoggerInFile;

public class UsuarioRepository implements IUsuarioRepository {
    private final DatabaseConnection bd;

    public UsuarioRepository() {
        bd = new DatabaseConnection();
    }

    @Override
    public UsuarioDao login(String username, String password) {
        String sql = "SELECT * FROM TB_USUARIO WHERE USUARIO=? AND SENHA=?";

        UsuarioDao usuarioDao = null;

        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, username);
            bd.st.setString(2, password);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                usuarioDao = new UsuarioDao();
                usuarioDao.setId(bd.rs.getInt("ID_USER"));
                usuarioDao.setUsuario(bd.rs.getString("USUARIO"));
                usuarioDao.setTipoUsuario(bd.rs.getString("TIPO_USUARIO"));
                usuarioDao.setStatusUsuario(bd.rs.getByte("STATUS_USUARIO"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return usuarioDao;
    }
}
