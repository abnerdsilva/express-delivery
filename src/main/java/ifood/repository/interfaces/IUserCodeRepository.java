package ifood.repository.interfaces;

import ifood.model.Token;
import ifood.model.UserCode;

import java.io.IOException;

public interface IUserCodeRepository {
    UserCode postUserCode(String json) throws IOException;

    Token postToken(String json) throws Exception;
}
