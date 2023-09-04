import delivery.AppDelivery;
import org.springframework.boot.SpringApplication;

public class Application {

    /**
     * inicia aplicação - verifica permissão de modulo de integração com ifood e impressão
     *
     * @param args - argumentos de inicio do projeto
     */
    public static void main(String[] args) {
        SpringApplication.run(AppDelivery.class, args);
    }
}
