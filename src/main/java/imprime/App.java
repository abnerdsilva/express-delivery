package imprime;

import javax.print.PrintException;

public class App {
    public static void main(String[] args) {
        Impressora impressora = new Impressora();
        try {
            impressora.imprime("teste");
        } catch (PrintException e) {
            e.printStackTrace();
        }
    }
}
