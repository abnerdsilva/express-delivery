import 'package:express_delivery/shared/model/order_details.dart';
import 'package:get/get.dart';

class OrderDetailsController extends GetxController {
  late OrderDetails order;

  @override
  void onInit() {
    super.onInit();

    order = Get.arguments;
  }
}
