import 'dart:developer';

import 'package:express_delivery/config/rest_client.dart';
import 'package:express_delivery/pages/login/repositories/i_login_repository.dart';
import 'package:express_delivery/pages/login/model/user_model.dart';
import 'package:express_delivery/shared/repositories/shared_preferences_repository.dart';

class LoginRepository implements ILoginRepostiory {
  final RestClient restClient;

  LoginRepository(this.restClient);

  @override
  Future<UserModel> login(String id) async {
    try {
      final response = await restClient.get('/v1/user/$id');
      if (response.hasError) {
        String message = response.bodyString!;

        if (response.statusCode == 403 || response.statusCode == 404) {
          message = 'Usuário ou senha inválidos';
        }

        throw RestClientException(message, code: response.statusCode);
      }

      if (response.body == null) {
        return UserModel(
          id: '',
          username: '',
          status: '',
          type: '',
        );
      }

      return UserModel.fromMap(response.body);
    } on RestClientException catch (e) {
      throw RestClientException(e.message, code: e.code);
    } catch (e) {
      log(e.toString());
      throw Exception('Não foi possivel consultar pedidos');
    }
  }

  @override
  Future<String> auth(String username, String password) async {
    try {
      final response = await restClient.post('/auth/login2', {
        'username': username,
        'password': password,
      });

      if (response.hasError) {
        String message = response.bodyString!;

        if (response.statusCode == 403 || response.statusCode == 404) {
          message = 'Usuário ou senha inválidos';
        }

        throw RestClientException(message, code: response.statusCode);
      }

      if (response.body == null) {
        return "";
      }

      final prefs = await SharedPrefsRepository.instance;
      prefs.registerToken(response.body['token']);

      return response.body['token'];
    } on RestClientException catch (e) {
      throw RestClientException(e.message, code: e.code);
    } catch (e) {
      log(e.toString());
      throw Exception('Não foi possivel consultar pedidos');
    }
  }
}
