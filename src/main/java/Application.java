import delivery.controller.ConfigController;
import ifood.AppIfood;
import log.LoggerInFile;
import log.MessageDefault;

import java.sql.SQLException;

public class Application {
    private final static String itemConfigurationIfood = "INTEGRA_IFOOD";

    private static final ConfigController configController = new ConfigController();

    public static void main(String[] args) {
        LoggerInFile.start();

        try {
            boolean statusIntegration = configController.checkIntegrationPermition(itemConfigurationIfood);
            if (!statusIntegration) {
                System.out.println(MessageDefault.msgAccessIntegrationNotGranted);
                LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationNotGranted);
                return;
            }

            LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationGranted);

            AppIfood.start();
        } catch (SQLException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
            return;
        }
    }
}
