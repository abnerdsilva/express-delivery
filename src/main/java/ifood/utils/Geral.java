package ifood.utils;

import okhttp3.MediaType;

public class Geral {

    public static final MediaType JSON = MediaType.parse("application/x-www-form-urlencoded; charset=utf-8");
    public static final MediaType JSON_APPLICATION = MediaType.parse("application/json");
    public static final String URL_BASE_IFOOD = "https://merchant-api.ifood.com.br";

    public static String accessToken = "";
}
