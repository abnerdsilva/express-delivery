import 'package:express_delivery/shared/model/order_details_model.dart';
import 'package:get/get.dart';

class OrderDetailsController extends GetxController {
  late OrderDetailsModel order;

  @override
  void onInit() {
    super.onInit();

    order = Get.arguments;
  }
}
