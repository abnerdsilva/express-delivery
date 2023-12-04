import 'package:express_delivery/shared/repositories/shared_preferences_repository.dart';
import 'package:get/get.dart';
import 'package:get/get_connect/http/src/request/request.dart';
import 'package:jwt_decoder/jwt_decoder.dart';

class RestClient extends GetConnect {
  final String _url = 'http://192.168.0.97:8080';

  String _token = '';

  @override
  Future<void> onInit() async {
    httpClient.baseUrl = _url;
    httpClient.timeout = const Duration(seconds: 30);

    final prefs = await SharedPrefsRepository.instance;

    httpClient.addRequestModifier((Request request) {
      _token = prefs.token ?? '';

      if (_token.isNotEmpty) {
        if (JwtDecoder.isExpired(_token)) {
          _token = '';
          prefs.registerToken('');
          prefs.logout();

          return request;
        }

        request.headers['Authorization'] = 'Bearer $_token';
      }
      return request;
    });

    super.onInit();
  }
}

class RestClientException implements Exception {
  final int? code;
  final String message;

  RestClientException(this.message, {this.code});

  @override
  String toString() => 'Erro: $message';
}
