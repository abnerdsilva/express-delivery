package ifood.repository.interfaces;

import ifood.model.Token;
import ifood.model.UserCode;
import ifood.model.dao.ConfigDao;

import java.io.IOException;

public interface IUserCodeRepository {
    UserCode postUserCode(String json) throws IOException;

    Token postToken(String json) throws Exception;

    void saveConfigUserCode(String userCode, String authCodeVerifier, long expiresIn);

    boolean saveConfigToken(String grantType, String accessToken, String refresToken);

    ConfigDao findConfigUserCode();

    ConfigDao findConfigToken();
}
