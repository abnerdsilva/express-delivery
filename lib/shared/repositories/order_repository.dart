import 'dart:developer';

import 'package:express_delivery/config/rest_client.dart';
import 'package:express_delivery/shared/model/order_details_model.dart';

class OrderRepository {
  final RestClient restClient;

  OrderRepository(this.restClient);

  Future<List<OrderDetailsModel>> getOrders() async {
    try {
      final response = await restClient.get('/orders');

      if (response.hasError) {
        String message = response.bodyString!;

        if (response.statusCode == 403) {
          message = 'Usuário ou senha inválidos';
        }
        if (response.statusCode == 404) {
          message = 'Erro ao autenticar usuário.';
        }

        throw RestClientException(message, code: response.statusCode);
      }

      if (response.body == null) {
        return [];
      }

      return response.body.map<OrderDetailsModel>((e) => OrderDetailsModel.fromMap(e)).toList();
    } on RestClientException catch (e) {
      throw RestClientException(e.message, code: e.code);
    } catch (e) {
      log(e.toString());
        throw Exception('Não foi possivel consultar pedidos');
    }
  }

  Future<OrderDetailsModel> getOrderCompleteById(int code) async {
    try {
      final response = await restClient.get('/order/$code');

      if (response.hasError) {
        String message = response.bodyString!;

        if (response.statusCode == 403) {
          message = 'Usuário ou senha inválidos';
        }
        if (response.statusCode == 404) {
          message = 'Erro ao autenticar usuário.';
        }

        throw RestClientException(message, code: response.statusCode);
      }

      return OrderDetailsModel.fromMap(response.body);
    } on RestClientException catch (e) {
      throw RestClientException(e.message, code: e.code);
    } catch (e) {
      log(e.toString());
      throw Exception('Não foi possivel consultar pedido completo');
    }
  }
}
