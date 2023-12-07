package imprime.repository;

import com.google.gson.Gson;
import imprime.model.Token;
import log.LoggerInFile;
import okhttp3.*;

import java.io.IOException;


public class LoginRepository implements ILoginRepository {

    private final OkHttpClient client = new OkHttpClient();

    private final String URL_BASE_API = "http://localhost:8080";
//    private final String URL_BASE_API = "http://68.183.49.109:8080";

    public String auth() {
        MediaType mediaType = MediaType.parse("application/json");
        RequestBody body = RequestBody.create(mediaType, "{\"username\":\"admin\",\"password\":\"123\"}");

        Request request = new Request.Builder()
                .url(URL_BASE_API + "/auth/login2")
                .method("POST", body)
                .addHeader("Content-Type", "application/json")
                .build();

        Gson gson = new Gson();
        ResponseBody responseBody;
        try {
            Response response = client.newCall(request).execute();
            responseBody = response.body();

            System.out.println(response);
            System.out.println(response.code());
            System.out.println(response.body());

            if (response.code() != 200) {
                if (response.code() != 204) {
                    LoggerInFile.printError(responseBody.string());
                }
                return "-1";
            }
        } catch (IOException e) {
            LoggerInFile.printError(e.getMessage());
            return "-1";
        }

        try {
            Token token = gson.fromJson(responseBody.string(), Token.class);
            return token.getToken();
        } catch (IOException e) {
            e.printStackTrace();
        }

        return "-1";
    }
}
