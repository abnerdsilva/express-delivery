package ifood;

import ifood.controller.Auth;
import ifood.controller.Event;
import ifood.controller.Order;
import log.LoggerInFile;

public class AppIfood {
    private final static long timeSleepAuthentication = 3600000;
    private final static long timeSleepRepeatAuthentication = 120000;
    private final static long timeSleepEvents = 30000;
    private final static long timeSleepOrders = 30000;
    private final static long timeSleepConfirmationOrders = 50000;
    private final static long timeSleepDispatchOrders = 50000;

    public static boolean statusAuthentication = false;

    /**
     * Inicia integração com modulo do Ifood
     */
    public static void start() {
        new Thread(() -> {
            for (; ; ) {
                try {
//                    Auth.getUserCode();
                    Auth.authStore();
                    statusAuthentication = Auth.statusAuthentication;
                    if (statusAuthentication) {
                        System.out.println("estabelecimento autenticado");
                        LoggerInFile.printInfo("estabelecimento autenticado");
                    } else {
                        System.out.println("não foi possivel autenticar estabelecimento");
                        LoggerInFile.printInfo("não foi possivel autenticar estabelecimento");

                        Thread.sleep(timeSleepRepeatAuthentication);
                        continue;
                    }

                    Thread.sleep(timeSleepAuthentication);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                    LoggerInFile.printError(e.getMessage());
                }
            }
        }).start();

        new Thread(() -> {
            for (; ; ) {
                try {
                    if (statusAuthentication) {
                        System.out.println("loop events");

                        Event.getEventsPolling();
                    }
                    Thread.sleep(timeSleepEvents);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                    LoggerInFile.printError(e.getMessage());
                }
            }
        }).start();

        new Thread(() -> {
            for (; ; ) {
                try {
                    if (statusAuthentication) {
                        System.out.println("loop save orders pending");

                        Order.saveOrdersPending();
                    }
                    Thread.sleep(timeSleepOrders);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                    LoggerInFile.printError(e.getMessage());
                }
            }
        }).start();
    }
}
