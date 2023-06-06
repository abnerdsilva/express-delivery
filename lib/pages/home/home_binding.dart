import 'package:express_delivery/config/rest_client.dart';
import 'package:express_delivery/pages/home/home_controller.dart';
import 'package:express_delivery/shared/repositories/order_repository.dart';
import 'package:get/get.dart';

class HomeBinding extends Bindings {
  @override
  void dependencies() {
    Get.put(RestClient());
    Get.put(OrderRepository(Get.find()));
    Get.put(HomeController(Get.find()));
  }
}
