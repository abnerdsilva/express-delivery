package delivery.repository;

import db.DatabaseConnection;
import delivery.model.dao.BairroDao;
import delivery.repository.interfaces.IBairroRepository;
import log.LoggerInFile;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

public class BairroRepository implements IBairroRepository {
    @Override
    public List<BairroDao> loadAll() throws SQLException {
        String sql = "SELECT * FROM TB_DELIVERY_BAIRRO";

        List<BairroDao> bairros = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                BairroDao bairro = new BairroDao();
                bairro.setId(bd.rs.getString("id_bairro"));
                bairro.setNome(bd.rs.getString("nome"));
                bairro.setVrTaxa(bd.rs.getDouble("vr_taxa"));
                bairro.setStatus(bd.rs.getInt("status_bairro"));

                bairros.add(bairro);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return bairros;
    }

    @Override
    public BairroDao findByCode(String code) throws SQLException {
        String sql = "SELECT * FROM TB_DELIVERY_BAIRRO WHERE ID_BAIRRO=?";

        BairroDao bairro = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, code);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                BairroDao bairroDao = new BairroDao();
                bairroDao.setId(bd.rs.getString("ID_BAIRRO"));
                bairroDao.setNome(bd.rs.getString("NOME"));
                bairroDao.setVrTaxa(bd.rs.getDouble("VR_TAXA"));
                bairroDao.setStatus(bd.rs.getInt("STATUS_BAIRRO"));

                bairro = bairroDao;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return bairro;
    }

    @Override
    public BairroDao findByName(String name) throws SQLException {
        String sql = "SELECT * FROM TB_DELIVERY_BAIRRO WHERE NOME=?";

        BairroDao bairro = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, name);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                BairroDao bairroDao = new BairroDao();
                bairroDao.setId(bd.rs.getString("ID_BAIRRO"));
                bairroDao.setNome(bd.rs.getString("NOME"));
                bairroDao.setVrTaxa(bd.rs.getDouble("VR_TAXA"));
                bairroDao.setStatus(bd.rs.getInt("STATUS_BAIRRO"));

                bairro = bairroDao;
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return bairro;
    }

    @Override
    public String save(BairroDao item) throws SQLException {
        String sql = "INSERT INTO TB_DELIVERY_BAIRRO (ID_BAIRRO, NOME, VR_TAXA, STATUS_BAIRRO) VALUES (?, ?,?,?)";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        var uid = UUID.randomUUID();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, uid.toString());
            bd.st.setString(2, item.getNome());
            bd.st.setDouble(3, item.getVrTaxa());
            bd.st.setInt(4, item.getStatus());

            var ret = bd.st.executeUpdate();
            if (ret > 0) {
                return uid.toString();
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return "-1";
    }

    @Override
    public int update(BairroDao item) throws SQLException {
        String sql = "UPDATE TB_DELIVERY_BAIRRO SET NOME=?, VR_TAXA=?, STATUS_BAIRRO=? WHERE ID_BAIRRO=?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, item.getNome());
            bd.st.setDouble(2, item.getVrTaxa());
            bd.st.setInt(3, item.getStatus());
            bd.st.setString(4, item.getId());

            return bd.st.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }
}
