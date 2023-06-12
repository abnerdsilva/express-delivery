import 'package:express_delivery/config/rest_client.dart';
import 'package:get/get.dart';

class AppBinding implements Bindings {
  @override
  void dependencies() {
    Get.put<RestClient>(RestClient());
  }
}
