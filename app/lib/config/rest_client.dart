import 'package:get/get.dart';

class RestClient extends GetConnect {
  final String _url = 'http://192.168.10.110:8080';

  @override
  Future<void> onInit() async {
    httpClient.baseUrl = _url;
    httpClient.timeout = const Duration(seconds: 20);

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
