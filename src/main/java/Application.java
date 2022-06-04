import delivery.controller.ConfigController;
import delivery.controller.ImprimeController;
import ifood.AppIfood;
import log.LoggerInFile;
import log.MessageDefault;

import java.sql.SQLException;

public class Application {
    private static final ConfigController configController = new ConfigController();
    private static final ImprimeController imprimeController = new ImprimeController();

    public static void main(String[] args) {
        LoggerInFile.start();

        try {
            boolean statusIntegration = configController.checkIntegrationPermition();
            if (!statusIntegration) {
                System.out.println(MessageDefault.msgAccessIntegrationNotGranted);
                LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationNotGranted);
                return;
            } else {
                LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationGranted);
                AppIfood.start();
            }

            boolean permiteModuloImpressao = configController.checkPrinterPermition();
            if (!permiteModuloImpressao) {
                System.out.println(MessageDefault.msgAccessIntegrationNotGranted);
                LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationNotGranted);
                return;
            } else {
                LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationGranted);
                imprimeController.startPrinter();
            }
        } catch (SQLException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
            return;
        }
    }
}
