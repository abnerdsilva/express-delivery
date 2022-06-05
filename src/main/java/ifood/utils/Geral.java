package ifood.utils;

import okhttp3.MediaType;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.TimeZone;

public class Geral {

    public static final MediaType JSON = MediaType.parse("application/x-www-form-urlencoded; charset=utf-8");
    public static final MediaType JSON_APPLICATION = MediaType.parse("application/json");
    public static final String URL_BASE_IFOOD = "https://merchant-api.ifood.com.br";

    public static String accessToken = "";

    public static String formateDateToLocal(String data) {
        SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        formatter.setTimeZone(TimeZone.getTimeZone("UTC-3"));

        Date date = null;
        try {
            date = formatter.parse(data.replaceAll("T", " ").substring(0, 19));
        } catch (ParseException e) {
            e.printStackTrace();
        }

        if (date.getHours() > 20)
            date.setDate(date.getDay() - 1);

        date.setHours(date.getHours() - 3);

        return formatter.format(date);
    }
}
