import delivery.AppDelivery;
import delivery.model.PropertiesEnv;
import delivery.controller.ConfigController;
import delivery.controller.ImprimeController;
import ifood.AppIfood;
import log.LoggerInFile;
import log.MessageDefault;
import org.springframework.boot.SpringApplication;

import java.sql.SQLException;

public class Application {
    private static final ConfigController configController = new ConfigController();
    private static final ImprimeController imprimeController = new ImprimeController();

    /**
     * inicia aplicação - verifica permissão de modulo de integração com ifood e impressão
     *
     * @param args - argumentos de inicio do projeto
     */
    public static void main(String[] args) {
        LoggerInFile.start();

        PropertiesEnv.start();

        try {
            boolean statusIntegration = configController.checkIntegrationPermition();
            if (!statusIntegration) {
                System.out.println(MessageDefault.msgAccessIntegrationNotGranted);
                LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationNotGranted);
            } else {
                LoggerInFile.printInfo(MessageDefault.msgAccessIntegrationGranted);
                AppIfood.start();
            }

            boolean permiteModuloImpressao = configController.checkPrinterPermition();
            if (!permiteModuloImpressao) {
                System.out.println(MessageDefault.msgAccessPrnterNotGranted);
                LoggerInFile.printInfo(MessageDefault.msgAccessPrnterNotGranted);
            } else {
                LoggerInFile.printInfo(MessageDefault.msgAccessrPrinterGranted);
                imprimeController.startPrinter();
            }

            boolean webserverPermition = configController.checkWebserverPermition();
            System.out.println(webserverPermition);
            System.out.println("-------*********");
            if (!webserverPermition) {
                System.out.println(MessageDefault.msgAccessWebserverNotGranted);
                LoggerInFile.printInfo(MessageDefault.msgAccessWebserverNotGranted);
            } else {
                LoggerInFile.printInfo(MessageDefault.msgAccessrWebserverGranted);

                SpringApplication.run(AppDelivery.class, args);
            }

        } catch (SQLException e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }
    }
}
