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
                usuarioDao.setId(bd.rs.getString(1));
                usuarioDao.setUsuario(bd.rs.getString(2));
                usuarioDao.setSenha(bd.rs.getString(3));
                usuarioDao.setTipoUsuario(bd.rs.getString(4));
                usuarioDao.setStatusUsuario(bd.rs.getByte(5));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return usuarioDao;
    }

    @Override
    public UsuarioDao findByLogin(String username) {
        String sql = "SELECT * FROM TB_USUARIO WHERE USUARIO=?";

        UsuarioDao usuarioDao = null;

        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, username);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                System.out.println(bd.rs);
                usuarioDao = new UsuarioDao();
                usuarioDao.setId(bd.rs.getString(1));
                usuarioDao.setUsuario(bd.rs.getString(2));
                usuarioDao.setSenha(bd.rs.getString(3));
                usuarioDao.setTipoUsuario(bd.rs.getString(4));
                usuarioDao.setStatusUsuario(bd.rs.getByte(5));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return usuarioDao;
    }

    public int save(UsuarioDao user) {
        String sql = "SET IDENTITY_INSERT TB_USUARIO ON INSERT INTO TB_USUARIO (ID_USER, USUARIO, SENHA, TIPO_USUARIO, STATUS_USUARIO) VALUES (?,?,?,?,?)SET IDENTITY_INSERT TB_USUARIO OFF";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();
        try {
            bd.connection.beginRequest();
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, user.getId());
            bd.st.setString(2, user.getUsuario());
            bd.st.setString(3, user.getSenha());
            bd.st.setString(4, user.getTipoUsuario());
            bd.st.setInt(5, user.getStatusUsuario());
            int resultInsert = bd.st.executeUpdate();
            if (resultInsert > 0) {
                return 1;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }

    public int update(UsuarioDao user) {
        String sql = "UPDATE TB_USUARIO SET USUARIO=?, SENHA=?, TIPO_USUARIO=?, STATUS_USUARIO=? WHERE ID_USER=?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();
        try {
            bd.connection.beginRequest();
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, user.getUsuario());
            bd.st.setString(2, user.getSenha());
            bd.st.setString(3, user.getTipoUsuario());
            bd.st.setInt(4, user.getStatusUsuario());
            bd.st.setString(5, user.getId());
            int resultInsert = bd.st.executeUpdate();
            if (resultInsert > 0) {
                return 1;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }
}
