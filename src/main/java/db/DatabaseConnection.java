package db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection {

    private static final String DB_PORT = "1433";
    private static final String DB_USER = "sa";
    private static final String DB_PASS = "Senha@15937";
    private static final String DB_HOST = "ec2-3-90-108-28.compute-1.amazonaws.com"; //localhost
    private static final String DB_NAME = "expressDelivery"; //ExpressDelivery
    private static final String DRIVER = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
    private static final String DRIVER_NAME = "jdbc.Drivers";
    private static final String PATH = "jdbc:sqlserver://" + DB_HOST + ":" + DB_PORT + ";databaseName=" + DB_NAME + "";
    public static Connection connection;

    public static void connect() throws SQLException {
        System.setProperty(DRIVER_NAME, DRIVER);
        connection = DriverManager.getConnection(PATH, DB_USER, DB_PASS);
    }

    public static void disconnect() throws SQLException {
        connection.close();
    }
}
