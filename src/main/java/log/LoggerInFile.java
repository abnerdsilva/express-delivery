package log;

import java.io.IOException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.logging.FileHandler;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;

public class LoggerInFile {

    private static final Logger logger = Logger.getLogger("expressDelivery");

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

    public static void printInfo(String message) {
        logger.info(message);
    }

    public static void printConfig(String message) {
        logger.config(message);
    }

    public static void printWarning(String message) {
        logger.warning(message);
    }

    public static void printError(String message) {
        logger.severe(message);
    }
}

