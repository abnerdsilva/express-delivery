package imprime.repository;

import com.google.gson.Gson;
import imprime.model.PedidoDelivery;
import log.LoggerInFile;
import okhttp3.*;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class EventsRepository implements IEventsRepository {

    private final OkHttpClient client = new OkHttpClient();

    private final String URL_BASE_API = "http://localhost:8080";
//    private final String URL_BASE_API = "http://68.183.49.109:8080";

    @Override
    public List<PedidoDelivery> getEvents(String token) {
        final String url = URL_BASE_API + "/v1/orders/print";
        Request request = new Request.Builder()
                .url(url)
                .header("Authorization", token)
                .build();

        Gson gson = new Gson();
        ResponseBody responseBody;

        try {
            Response response = client.newCall(request).execute();
            responseBody = response.body();

            if (response.code() != 200) {
                if (response.code() != 204) {
                    LoggerInFile.printError(responseBody.string());
                }
                return new ArrayList<>();
            }
        } catch (IOException e) {
            LoggerInFile.printError(e.getMessage());
            return new ArrayList<>();
        }

        String resp = null;
        try {
            resp = responseBody.string();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        System.out.println(resp);

        PedidoDelivery[] events = gson.fromJson(resp, PedidoDelivery[].class);
        return new ArrayList<>(Arrays.asList(events));
    }

    @Override
    public boolean setOrderPrinted(String code, String token) {
        MediaType mediaType = MediaType.parse("application/json");
        RequestBody body = RequestBody.create(mediaType, "");

        final String url = URL_BASE_API + "/v1/order/" + code + "/printed";
        Request request = new Request.Builder()
                .url(url)
                .method("POST", body)
                .header("Authorization", token)
                .build();

        Gson gson = new Gson();
        ResponseBody responseBody;

        try {
            Response response = client.newCall(request).execute();
            responseBody = response.body();

            if (response.code() != 200) {
                if (response.code() != 204) {
                    LoggerInFile.printError(responseBody.string());
                }
                return false;
            }
        } catch (IOException e) {
            LoggerInFile.printError(e.getMessage());
            return false;
        }

        return true;
    }
}
