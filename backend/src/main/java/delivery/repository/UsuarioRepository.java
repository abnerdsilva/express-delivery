package delivery.repository;

import db.DatabaseConnection;
import delivery.model.dao.UsuarioDao;
import delivery.repository.interfaces.IUsuarioRepository;
import log.LoggerInFile;

import java.util.ArrayList;
import java.util.List;

public class UsuarioRepository implements IUsuarioRepository {
    private final DatabaseConnection bd;

    public UsuarioRepository() {
        bd = new DatabaseConnection();
    }

    @Override
    public UsuarioDao loadByCode(String code) {
        String sql = "SELECT * FROM TB_USUARIO WHERE ID_USER=?";

        UsuarioDao usuario = null;

        try {
            bd.getConnection();
            bd.st = bd.connection.prepareStatement(sql);

            bd.st.setString(1, code);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                usuario = new UsuarioDao();
                usuario.setId(bd.rs.getString("ID_USER"));
                usuario.setUsuario(bd.rs.getString("USUARIO"));
                usuario.setStatusUsuario(bd.rs.getInt("STATUS_USUARIO"));
                usuario.setTipoUsuario(bd.rs.getString("TIPO_USUARIO"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return usuario;
    }

    @Override
    public List<UsuarioDao> loadClientsByName(String name) {
        String sql = "SELECT * FROM TB_USUARIO WHERE USUARIO like '%" + name + "%'";

        List<UsuarioDao> users = new ArrayList<>();;

        try {
            bd.getConnection();
            bd.st = bd.connection.prepareStatement(sql);

            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                UsuarioDao user = new UsuarioDao();
                user.setId(bd.rs.getString("ID_USER"));
                user.setUsuario(bd.rs.getString("USUARIO"));
                user.setStatusUsuario(bd.rs.getInt("STATUS_USUARIO"));
                user.setTipoUsuario(bd.rs.getString("TIPO_USUARIO"));

                users.add(user);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return users;
    }

    @Override
    public UsuarioDao loadByName(String name) {
        String sql = "SELECT * FROM TB_USUARIO WHERE USUARIO=?";

        UsuarioDao usuario = null;

        try {
            bd.getConnection();
            bd.st = bd.connection.prepareStatement(sql);

            bd.st.setString(1, name);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                usuario = new UsuarioDao();
                usuario.setId(bd.rs.getString("ID_USER"));
                usuario.setUsuario(bd.rs.getString("USUARIO"));
                usuario.setStatusUsuario(bd.rs.getInt("STATUS_USUARIO"));
                usuario.setTipoUsuario(bd.rs.getString("TIPO_USUARIO"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return usuario;
    }

    @Override
    public List<UsuarioDao> loadAll() {
        String sql = "SELECT * FROM TB_USUARIO";

        List<UsuarioDao> users = new ArrayList<>();;

        try {
            bd.getConnection();
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();

            while (bd.rs.next()) {
                UsuarioDao user = new UsuarioDao();
                user.setId(bd.rs.getString("ID_USER"));
                user.setUsuario(bd.rs.getString("USUARIO"));
                user.setStatusUsuario(bd.rs.getInt("STATUS_USUARIO"));
                user.setTipoUsuario(bd.rs.getString("TIPO_USUARIO"));

                users.add(user);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return users;
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
                usuarioDao = new UsuarioDao();
                usuarioDao.setId(bd.rs.getString(1));
                usuarioDao.setUsuario(bd.rs.getString(2));
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
        String sql = "INSERT INTO TB_USUARIO (ID_USER, USUARIO, SENHA, TIPO_USUARIO, STATUS_USUARIO) VALUES (?,?,?,?,?)";

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
