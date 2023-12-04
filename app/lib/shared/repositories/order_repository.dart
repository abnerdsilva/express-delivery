import 'dart:developer';

import 'package:express_delivery/config/rest_client.dart';
import 'package:express_delivery/shared/model/order_details_model.dart';
import 'package:express_delivery/shared/repositories/shared_preferences_repository.dart';

class OrderRepository {
  final RestClient restClient;

  OrderRepository(this.restClient);

  Future<List<OrderDetailsModel>> getOrders() async {
    try {
      final response = await restClient.get('/v1/orders?filter=date');
      if (response.hasError) {
        String message = response.bodyString!;

        if (response.statusCode == 403) {
          message = 'Usuário ou senha inválidos';

          final prefs = await SharedPrefsRepository.instance;
          prefs.logout();
          throw Exception('Token expirado, favor logar novamente na aplicação');
        }
        if (response.statusCode == 404) {
          message = 'Erro ao autenticar usuário.';
        }

        throw RestClientException(message, code: response.statusCode);
      }

      if (response.body == null) {
        return [];
      }

      return response.body
          .map<OrderDetailsModel>((e) => OrderDetailsModel.fromMap(e))
          .toList();
    } on RestClientException catch (e) {
      throw RestClientException(e.message, code: e.code);
    } catch (e) {
      log(e.toString());
      throw Exception('Não foi possivel consultar pedidos');
    }
  }

  Future<OrderDetailsModel> getOrderCompleteById(String code) async {
    try {
      final response = await restClient.get('/v1/order/$code');

      if (response.hasError) {
        String message = response.bodyString!;

        if (response.statusCode == 403) {
          message = 'Usuário ou senha inválidos';

          final prefs = await SharedPrefsRepository.instance;
          prefs.logout();
          throw Exception('Token expirado, favor logar novamente na aplicação');
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

  Future<bool> updateOrderStatus(String code) async {
    bool status = false;
    try {
      final response = await restClient.put('/v1/order/$code/next', null);
      if (response.hasError) {
        String message = response.bodyString!;

        if (response.statusCode == 403) {
          message = 'Usuário ou senha inválidos';

          final prefs = await SharedPrefsRepository.instance;
          prefs.logout();
          throw Exception('Token expirado, favor logar novamente na aplicação');
        }
        if (response.statusCode == 404) {
          message = 'Erro ao autenticar usuário.';
        }
        if (response.statusCode == 304) {
          message = 'Pedido já está atualizado';
          // message = response.body['message'];
        }
        throw RestClientException(message, code: response.statusCode);
      }

      status = true;
    } on RestClientException catch (e) {
      throw RestClientException(e.message, code: e.code);
    } catch (e) {
      log(e.toString());
      throw Exception('Não foi possivel consultar pedido completo');
    }
    return status;
  }

  Future<bool> cancelOrder(String code) async {
    bool status = false;
    try {
      final response = await restClient.get('/v1/order/$code/cancel');
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

      status = true;
    } on RestClientException catch (e) {
      throw RestClientException(e.message, code: e.code);
    } catch (e) {
      log(e.toString());
      throw Exception('Não foi possivel consultar pedido completo');
    }
    return status;
  }

  Future<bool> reprintOrder(String code) async {
    bool status = false;
    try {
      final response = await restClient.post('/v1/order/$code/reprint', null);
      if (response.hasError) {
        String message = response.bodyString!;

        if (response.statusCode == 403) {
          message = 'Acesso negado, favor logar novamente na aplicação';

          // final prefs = await SharedPrefsRepository.instance;
          // prefs.logout();
          throw Exception(message);
        }
        if (response.statusCode == 404) {
          message = 'Erro ao autenticar usuário.';
        }
        if (response.statusCode == 304) {
          message = 'Pedido já está atualizado';
          // message = response.body['message'];
        }
        throw RestClientException(message, code: response.statusCode);
      }

      status = true;
    } on RestClientException catch (e) {
      throw RestClientException(e.message, code: e.code);
    } catch (e) {
      log(e.toString());
      throw Exception(e.toString());
    }
    return status;
  }
}
