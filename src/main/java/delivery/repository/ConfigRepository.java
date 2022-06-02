package delivery.repository;

import db.DatabaseConnection;
import log.LoggerInFile;
import delivery.model.dao.ConfigDao;
import delivery.repository.interfaces.IConfigRepository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ConfigRepository implements IConfigRepository {
    private ResultSet resultSet;
    private Connection connection;
    private PreparedStatement stmt;

    @Override

    public List<ConfigDao> loadAll() {
        String sql = "SELECT * FROM TB_CONFIGURACAO";

        List<ConfigDao> configurations = new ArrayList<>();

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            PreparedStatement stmt = connection.prepareStatement(sql);
            resultSet = stmt.executeQuery(sql);
            while (resultSet.next()) {
                ConfigDao config = new ConfigDao();
                config.setItem(resultSet.getString(1));
                config.setFlag1(resultSet.getString(2));
                config.setFlag2(resultSet.getString(3));
                config.setFlag3(resultSet.getString(4));
                config.setFlag4(resultSet.getString(5));
                config.setFlag5(resultSet.getString(6));

                configurations.add(config);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return configurations;
    }

    @Override
    public ConfigDao load(String item) throws SQLException {
        String sql = "SELECT * FROM TB_CONFIGURACAO WHERE ITEM=?";

        ConfigDao config = null;

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            stmt = connection.prepareStatement(sql);
            stmt.setString(1, item);
            resultSet = stmt.executeQuery();
            while (resultSet.next()) {
                config = new ConfigDao();
                config.setCodConfiguracao(resultSet.getInt(1));
                config.setItem(resultSet.getString(2));
                config.setFlag1(resultSet.getString(3));
                config.setFlag2(resultSet.getString(4));
                config.setFlag3(resultSet.getString(5));
                config.setFlag4(resultSet.getString(6));
                config.setFlag5(resultSet.getString(7));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            DatabaseConnection.disconnect();
            stmt.close();
        }

        return config;
    }

    @Override
    public ConfigDao save(ConfigDao config) {
        return null;
    }
}
