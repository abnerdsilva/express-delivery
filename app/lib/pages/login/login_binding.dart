import 'package:express_delivery/pages/login/login_controller.dart';
import 'package:express_delivery/pages/login/repositories/login_repository.dart';
import 'package:get/get.dart';

class LoginBinding implements Bindings {
  @override
  void dependencies() {
    Get.put<LoginRepository>(LoginRepository(Get.find()));
    Get.put<LoginController>(LoginController());
  }
}
