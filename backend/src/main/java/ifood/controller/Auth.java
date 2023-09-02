package ifood.controller;

import ifood.model.Token;
import ifood.model.UserCode;
import ifood.model.dao.ConfigDao;
import ifood.repository.UserCodeRepository;
import ifood.utils.Geral;
import log.LoggerInFile;

import java.sql.Timestamp;

/**
 * Classe Auth - usada para autenticação e geração de acessToken
 */
public class Auth {

    private final static String CLIENT_ID = "7b6c419a-8c90-497a-a673-cc0ffc27142a";
    private final static String CLIENT_SECRET = "9ufbzsfw86ievbguxdyzfy1xp3bayf53j5blnd6l2pcilrc3o4kh3kyxuvs6almc4f3m32sh34gxzmpm6xpkcl957s29kuk7uvq";
    private final static String GRANT_TYPE_REFRESH_TOKEN = "refresh_token";
    private final static String ALLOW_INTEGRATION_IFOOD = "SIM";

    private final static UserCodeRepository userCodeRepository = new UserCodeRepository();
    public static boolean statusAuthentication = false;

    /**
     * gera dados da empresa para associar com loja do cliente
     * obs.: precisa informar userCode gerado no endpoint na plataforma do Ifood
     * e gerar uma chave authorizationCode que deve salvar no banco de dados para
     * usar na geração de accessToken
     */
    public static void getUserCode() {
        try {
            final String credential = "clientId=" + CLIENT_ID;
            UserCode userCode = userCodeRepository.postUserCode(credential);
            System.out.println(userCode);

            Timestamp timestamp = new Timestamp(System.currentTimeMillis());
            long expiresIn = timestamp.getTime() + userCode.getExpiresIn();
            userCodeRepository.saveConfigUserCode(userCode.getUserCode(), userCode.getAuthorizationCodeVerifier(), expiresIn);
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        }
    }

    /**
     * realiza autenticação da loja junto ao Ifood e gera accessToken e refreshToken
     * para usar nos endpoints
     */
    public static void authStore() {
        try {
            ConfigDao config = userCodeRepository.findConfigUserCode();
            ConfigDao configToken = userCodeRepository.findConfigToken();

            if (!config.getFlag1().equals(ALLOW_INTEGRATION_IFOOD)) {
                System.out.println("Uso não permitido da integração");
                LoggerInFile.printWarning("Uso não permitido da integração");
                return;
            }

            String jsonBody = "grantType=" + configToken.getFlag1()
                    + "&clientId=" + CLIENT_ID
                    + "&clientSecret=" + CLIENT_SECRET
                    + "&authorizationCode=" + config.getFlag2()
                    + "&authorizationCodeVerifier=" + config.getFlag3();

            if (configToken.getFlag1().equals(GRANT_TYPE_REFRESH_TOKEN)) {
                jsonBody += "&accessToken=" + configToken.getFlag2()
                        + "&refreshToken=" + configToken.getFlag3();
            }

            Token response = userCodeRepository.postToken(jsonBody);
            if (response.getError() != null || response.getAccessToken() == null) {
                return;
            }

            boolean statusSaveConfigToken = userCodeRepository.saveConfigToken(GRANT_TYPE_REFRESH_TOKEN, response.getAccessToken(), response.getRefreshToken());
            if (statusSaveConfigToken) {
                statusAuthentication = true;

                Geral.accessToken = "Bearer " + response.getAccessToken();
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printInfo(e.getMessage());
        }
    }
}
