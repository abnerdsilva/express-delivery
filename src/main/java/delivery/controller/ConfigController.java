package delivery.controller;

import delivery.model.dao.ConfigDao;
import delivery.repository.ConfigRepository;

import java.sql.SQLException;
import java.util.List;

public class ConfigController {
    public final String permitionGranted = "SIM";
    public String statusIntegrationIfood = "";
    private final static String itemConfigurationIfood = "INTEGRA_IFOOD";

    private String CONFIG_MODULO_IMPRESSAO = "MODULO_IMPRESSAO";
    public String statusModuloImpressao = "";
    public String NOME_IMPRESSORA = "";

    ConfigRepository configRepository = new ConfigRepository();

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

    public List<ConfigDao> loadConfigurations() {
        return configRepository.loadAll();
    }
}
