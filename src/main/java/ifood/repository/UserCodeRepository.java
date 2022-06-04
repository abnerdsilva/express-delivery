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
import java.sql.SQLException;
import java.sql.Statement;

import static ifood.utils.Geral.JSON;
import static ifood.utils.Geral.URL_BASE_IFOOD;

public class UserCodeRepository implements IUserCodeRepository {

    private final OkHttpClient client = new OkHttpClient();

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

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(insertSql, Statement.RETURN_GENERATED_KEYS);

            bd.st.execute();
            bd.rs = bd.st.getGeneratedKeys();

            while (bd.rs.next()) {
                System.out.println("Generated: " + bd.rs.getString(1));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }
    }

    public boolean saveConfigToken(String grantType, String accessToken, String refresToken) throws SQLException {
        String insertSql = "UPDATE TB_CONFIGURACAO SET "
                + "FLAG1='" + grantType + "', "
                + "FLAG2='" + accessToken + "', "
                + "FLAG3='" + refresToken + "' "
                + "WHERE ITEM = 'INTEGRA_IFOOD_TOKEN'";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(insertSql, Statement.RETURN_GENERATED_KEYS);

            bd.st.execute();
            bd.rs = bd.st.getGeneratedKeys();

            while (bd.rs.next()) {
                System.out.println("Generated: " + bd.rs.getString(1));
            }

            return true;
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return false;
    }

    public ConfigDao findConfigUserCode() throws SQLException {
        String sql = "SELECT * FROM TB_CONFIGURACAO WHERE ITEM = 'INTEGRA_IFOOD'";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        ConfigDao config = null;

        try {
            bd.st = bd.connection.prepareStatement(sql);
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

    public ConfigDao findConfigToken() throws SQLException {
        String sql = "SELECT * FROM TB_CONFIGURACAO WHERE ITEM = 'INTEGRA_IFOOD_TOKEN'";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        ConfigDao config = null;

        try {
            bd.st = bd.connection.prepareStatement(sql);
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
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return config;
    }
}
