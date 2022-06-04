package delivery.repository;

import db.DatabaseConnection;
import delivery.model.dao.ConfigDao;
import delivery.repository.interfaces.IConfigRepository;
import log.LoggerInFile;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ConfigRepository implements IConfigRepository {
    @Override
    public List<ConfigDao> loadAll() {
        String sql = "SELECT * FROM TB_CONFIGURACAO";

        List<ConfigDao> configurations = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery(sql);
            while (bd.rs.next()) {
                ConfigDao config = new ConfigDao();
                config.setItem(bd.rs.getString(1));
                config.setFlag1(bd.rs.getString(2));
                config.setFlag2(bd.rs.getString(3));
                config.setFlag3(bd.rs.getString(4));
                config.setFlag4(bd.rs.getString(5));
                config.setFlag5(bd.rs.getString(6));

                configurations.add(config);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return configurations;
    }

    @Override
    public ConfigDao load(String item) throws SQLException {
        String sql = "SELECT * FROM TB_CONFIGURACAO WHERE ITEM=?";

        ConfigDao config = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, item);
            bd.rs = bd.st.executeQuery();
            while (bd.rs.next()) {
                config = new ConfigDao();
                config.setCodConfiguracao(bd.rs.getInt(1));
                config.setItem(bd.rs.getString(2));
                config.setFlag1(bd.rs.getString(3));
                config.setFlag2(bd.rs.getString(4));
                config.setFlag3(bd.rs.getString(5));
                config.setFlag4(bd.rs.getString(6));
                config.setFlag5(bd.rs.getString(7));
            }
            bd.st.close();
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return config;
    }

    @Override
    public ConfigDao save(ConfigDao config) {
        return null;
    }
}
