package delivery.controller;

import delivery.model.dao.ConfigDao;
import delivery.repository.ConfigRepository;

import java.sql.SQLException;
import java.util.List;

public class ConfigController {
    public final String permitionGrantedIntegrationIfood = "SIM";
    public String statusIntegrationIfood = "";

    ConfigRepository configRepository = new ConfigRepository();

    public boolean checkIntegrationPermition(String integration) throws SQLException {
        ConfigDao config = configRepository.load(integration);
        if (config != null) {
            if (config.getFlag1().equals(permitionGrantedIntegrationIfood)) {
                statusIntegrationIfood = config.getFlag1();
                System.out.println(config);
                return true;
            }
        }
        return false;
    }

    public List<ConfigDao> loadConfigurations() {
        return configRepository.loadAll();
    }
}
