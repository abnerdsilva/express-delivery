import 'package:express_delivery/shared/components/order_model.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class HomeController extends GetxController with GetSingleTickerProviderStateMixin {
  late TabController tabController;

  RxList<OrderModel> orders = <OrderModel>[].obs;

  @override
  void onInit() {
    tabController = TabController(length: 2, vsync: this);
    super.onInit();

    orders.value = List.generate(
      30,
      (index) => OrderModel(
        clientId: index + 1,
        clientName: 'Nome cliente ${index + 1}',
        id: index + 1,
      ),
    );
  }
}
