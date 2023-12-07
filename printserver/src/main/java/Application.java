import imprime.controller.ImprimeController;
import log.LoggerInFile;

public class Application {

    public static void main(String[] args) {
        LoggerInFile.start();

        ImprimeController _imprimeController = new ImprimeController();
        _imprimeController.getOrders();
    }
}
