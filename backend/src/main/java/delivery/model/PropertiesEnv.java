package delivery.model;

import io.github.cdimascio.dotenv.Dotenv;

public class PropertiesEnv {

    private static String port;
    private static String username;
    private static String password;
    private static String hostname;
    private static String database;

    public static String getPort() {
        return port;
    }

    public static void setPort(String port) {
        PropertiesEnv.port = port;
    }

    public static String getUsername() {
        return username;
    }

    public static void setUsername(String username) {
        PropertiesEnv.username = username;
    }

    public static String getPassword() {
        return password;
    }

    public static void setPassword(String password) {
        PropertiesEnv.password = password;
    }

    public static String getHostname() {
        return hostname;
    }

    public static void setHostname(String hostname) {
        PropertiesEnv.hostname = hostname;
    }

    public static String getDatabase() {
        return database;
    }

    public static void setDatabase(String database) {
        PropertiesEnv.database = database;
    }

    /**
     * inicia e classe de consulta de propriedades no arquivo .env
     */
    public static void start() {
        Dotenv dotenv;
        dotenv = Dotenv.configure().load();

        setPort(dotenv.get("SPRING_DATABASE_PORT"));
        setPassword(dotenv.get("SPRING_DATABASE_PASS"));
        setUsername(dotenv.get("SPRING_DATABASE_USER"));
        setHostname(dotenv.get("SPRING_DATABASE_HOST"));
        setDatabase(dotenv.get("SPRING_DATABASE_NAME"));
    }
}