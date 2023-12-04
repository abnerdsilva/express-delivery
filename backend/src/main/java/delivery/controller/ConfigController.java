package delivery.controller;

import delivery.Erro;
import delivery.model.dao.ConfigDao;
import delivery.repository.ConfigRepository;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.sql.SQLException;

@RestController
public class ConfigController {
    public final String permitionGranted = "SIM";
    public String statusIntegrationIfood = "";
    private final static String itemConfigurationIfood = "INTEGRA_IFOOD";

    private final String CONFIG_MODULO_IMPRESSAO = "MODULO_IMPRESSAO";
    public String statusModuloImpressao = "";
    public String NOME_IMPRESSORA = "";

    private final String CONFIG_USA_WEBSERVER = "USA_WEBSERVER";
    public String statusWebserverPermition = "";

    ConfigRepository configRepository = new ConfigRepository();

    /**
     * verifica permissão de uso do modulo de integração com ifood
     *
     * @return - retorna status da permissão de integração
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
    public boolean checkIntegrationPermition() throws SQLException {
        ConfigDao config = configRepository.load(itemConfigurationIfood);
        if (config != null) {
            if (config.getFlag1().equals(permitionGranted)) {
                statusIntegrationIfood = config.getFlag1();
                System.out.println(config);
                return true;
            }
        }
        return false;
    }

    /**
     * verifica permissão de uso do modulo de integração com ifood
     *
     * @return - retorna status da permissão do modulo de impressão
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
    public boolean checkPrinterPermition() throws SQLException {
        boolean ret = false;
        ConfigDao config = configRepository.load(CONFIG_MODULO_IMPRESSAO);
        if (config != null) {
            if (config.getFlag1().equals(permitionGranted)) {
                statusModuloImpressao = config.getFlag1();
                NOME_IMPRESSORA = config.getFlag2();
                ret = true;
            }
        }
        return ret;
    }

    public boolean checkWebserverPermition() throws SQLException {
        ConfigDao config = configRepository.load(CONFIG_USA_WEBSERVER);
        if (config != null) {
            if (config.getFlag1().equals(permitionGranted)) {
                statusWebserverPermition = config.getFlag1();
                return true;
            }
        }
        return false;
    }

    @RequestMapping(value = "/v1/privacy", method = RequestMethod.GET)
    public ResponseEntity<?> getTermsPrivacy() throws SQLException {
        var data = configRepository.load("TERMOS_PRIVACIDADE");
        if (data == null) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new Erro("Configuração não encontrada"));
        }

        return ResponseEntity.status(HttpStatus.OK).body(data);
    }

    @RequestMapping(value = "/v1/privacy/{user}", method = RequestMethod.POST)
    public ResponseEntity<?> setTermsPrivacy(@PathVariable String user) throws SQLException {
        var data = configRepository.load("TERMOS_PRIVACIDADE");
        if (data != null) {
            return ResponseEntity.status(HttpStatus.ALREADY_REPORTED).body(data);
        }

        var isSaved = configRepository.save(user);
        if (isSaved <= 0) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new Erro("Falha ao salvar política"));
        }

        data = configRepository.load("TERMOS_PRIVACIDADE");
        if (data == null) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new Erro("Configuração não encontrada"));
        }

        return ResponseEntity.status(HttpStatus.OK).body(data);
    }
}
