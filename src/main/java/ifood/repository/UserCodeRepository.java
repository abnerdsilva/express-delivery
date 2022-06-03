package ifood.repository;

import com.google.gson.Gson;
import db.DatabaseConnection;
import ifood.model.Token;
import ifood.model.UserCode;
import ifood.model.dao.ConfigDao;
import ifood.repository.interfaces.IUserCodeRepository;
import log.LoggerInFile;
import okhttp3.*;

import java.io.IOException;
import java.sql.Connection;
import java.sql.*;

import static ifood.utils.Geral.JSON;
import static ifood.utils.Geral.URL_BASE_IFOOD;

public class UserCodeRepository implements IUserCodeRepository {

    private final OkHttpClient client = new OkHttpClient();
    private ResultSet resultSet;
    private Connection connection;

    @Override
    public UserCode postUserCode(String json) throws IOException {
        final String url = URL_BASE_IFOOD + "/authentication/v1.0/oauth/userCode";
        RequestBody body = RequestBody.create(json, JSON);
        Request request = new Request.Builder()
                .url(url)
                .post(body)
                .build();

        Gson gson = new Gson();
        Response response = client.newCall(request).execute();
        ResponseBody responseBody = response.body();

        if (response.code() != 200) {
            LoggerInFile.printError(responseBody.string());
            return new UserCode();
        }

        return gson.fromJson(responseBody.string(), UserCode.class);
    }

    @Override
    public Token postToken(String json) throws IOException {
        final String url = URL_BASE_IFOOD + "/authentication/v1.0/oauth/token";
        RequestBody body = RequestBody.create(json, JSON);
        Request request = new Request.Builder()
                .url(url)
                .post(body)
                .build();

        final Gson gson = new Gson();
        final Response response = client.newCall(request).execute();
        final ResponseBody responseBody = response.body();

        if (response.code() != 200) {
            LoggerInFile.printError(responseBody.string());
            return new Token();
        }

        return gson.fromJson(responseBody.string(), Token.class);
    }

    public void saveConfigUserCode(String userCode, String authCodeVerifier, long expiresIn) throws SQLException {
        String insertSql = "UPDATE TB_CONFIGURACAO SET "
                + "FLAG2='" + userCode + "', "
                + "FLAG3='" + authCodeVerifier + "', "
                + "FLAG4='" + expiresIn + "' "
                + "WHERE  ITEM = 'INTEGRA_IFOOD'";

        ResultSet resultSet;
        DatabaseConnection.connect();
        connection = DatabaseConnection.connection;
        try {
            PreparedStatement prepsInsertProduct = connection.prepareStatement(insertSql, Statement.RETURN_GENERATED_KEYS);

            prepsInsertProduct.execute();
            resultSet = prepsInsertProduct.getGeneratedKeys();

            while (resultSet.next()) {
                System.out.println("Generated: " + resultSet.getString(1));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }
    }

    public boolean saveConfigToken(String grantType, String accessToken, String refresToken) throws SQLException {
        String insertSql = "UPDATE TB_CONFIGURACAO SET "
                + "FLAG1='" + grantType + "', "
                + "FLAG2='" + accessToken + "', "
                + "FLAG3='" + refresToken + "' "
                + "WHERE ITEM = 'INTEGRA_IFOOD_TOKEN'";

        ResultSet resultSet;
        DatabaseConnection.connect();
        connection = DatabaseConnection.connection;
        try {
            PreparedStatement prepsInsertProduct = connection.prepareStatement(insertSql, Statement.RETURN_GENERATED_KEYS);

            prepsInsertProduct.execute();
            resultSet = prepsInsertProduct.getGeneratedKeys();

            while (resultSet.next()) {
                System.out.println("Generated: " + resultSet.getString(1));
            }

            return true;
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }

        return false;
    }

    public ConfigDao findConfigUserCode() throws SQLException {
        String sql = "SELECT * FROM TB_CONFIGURACAO WHERE ITEM = 'INTEGRA_IFOOD'";

        DatabaseConnection.connect();
        connection = DatabaseConnection.connection;

        ConfigDao config = null;

        try {
            Statement stmt = connection.createStatement();
            resultSet = stmt.executeQuery(sql);
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
        }

        return config;
    }

    public ConfigDao findConfigToken() throws SQLException {
        String sql = "SELECT * FROM TB_CONFIGURACAO WHERE ITEM = 'INTEGRA_IFOOD_TOKEN'";

        DatabaseConnection.connect();
        connection = DatabaseConnection.connection;

        ConfigDao config = null;

        try {
            Statement stmt = connection.createStatement();
            resultSet = stmt.executeQuery(sql);
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
        }

        return config;
    }
}
