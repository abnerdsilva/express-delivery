package log;

import java.io.IOException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.logging.FileHandler;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

public class LoggerInFile {

    private static final Logger logger = Logger.getLogger("expressDelivery");

    /**
     * inicia e cria arquivo de log
     */
    public static void start() {
        FileHandler fileHandler;
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyyMMdd");
        LocalDateTime now = LocalDateTime.now();
        try {
            fileHandler = new FileHandler("src/main/resources/logDelivery" + now.format(dtf) + ".log", true);
            logger.addHandler(fileHandler);
            SimpleFormatter simpleFormatter = new SimpleFormatter();
            fileHandler.setFormatter(simpleFormatter);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    /**
     * insere informação no arquivo de log
     *
     * @param message - mensagem que será inserida no log
     */
    public static void printInfo(String message) {
        logger.info(message);
    }

    /**
     * insere informação de configuração no arquivo de log
     *
     * @param message - mensagem que será inserida no log
     */
    public static void printConfig(String message) {
        logger.config(message);
    }

    /**
     * insere informação de warning no arquivo de log
     *
     * @param message - mensagem que será inserida no log
     */
    public static void printWarning(String message) {
        logger.warning(message);
    }

    /**
     * insere erro no arquivo de log
     *
     * @param message - mensagem que será inserida no log
     */
    public static void printError(String message) {
        logger.severe(message);
    }
}

