package db;

import log.LoggerInFile;

import java.sql.*;

public class DatabaseConnection {

    private final String MSG_ERRO_DRIVER_NAO_ENCONTRADO = "Driver não encontrado";
    private final String MSG_ERRO_FALHA_CONEXAO = "Falha na conexão";

    private final String DB_PORT = "1433";
    private final String DB_USER = "sa";
    private final String DB_PASS = "241180";
    private final String DB_HOST = "localhost";
    private final String DB_NAME = "express";
    private final String DRIVER = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
    private final String PATH = "jdbc:sqlserver://" + DB_HOST + ":" + DB_PORT + ";databaseName=" + DB_NAME + "";

    public Connection connection;
    public PreparedStatement st = null;
    public ResultSet rs = null;

    /**
     * Abre uma conexão com o banco de dados a partir dos dados definidos acima
     *
     * @return - true em caso de sucesso ou false caso contrário
     */
    public boolean getConnection() {
        boolean status = false;
        try {
            Class.forName(DRIVER);
            connection = DriverManager.getConnection(PATH, DB_USER, DB_PASS);
            status = true;
        } catch (ClassNotFoundException erro) {
            System.out.println(MSG_ERRO_DRIVER_NAO_ENCONTRADO);
            LoggerInFile.printError(erro.getMessage());
        } catch (SQLException erro) {
            System.out.println(MSG_ERRO_FALHA_CONEXAO + ": " + erro.getMessage());
            LoggerInFile.printError(erro.getMessage());
        }
        return status;
    }

    /**
     * Encerra a conexão com o banco de dados
     */
    public void close() {
        try {
            if (rs != null) rs.close();
            if (st != null) st.close();
            if (connection != null) {
                connection.close();
            }
        } catch (SQLException erro) {
            LoggerInFile.printError(erro.getMessage());
        }
    }
}
