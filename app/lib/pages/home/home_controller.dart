import 'dart:async';

import 'package:express_delivery/shared/model/order_details_model.dart';
import 'package:express_delivery/shared/repositories/order_repository.dart';
import 'package:express_delivery/shared/repositories/shared_preferences_repository.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class HomeController extends GetxController
    with GetSingleTickerProviderStateMixin {
  late TabController tabController;

  late OrderRepository _orderRepository;

  HomeController(OrderRepository orderRepository) {
    _orderRepository = orderRepository;
  }

  final statusCancelled = 'CANCELADO';
  final statusConcluded = 'CONCLUIDO';

  RxList<OrderDetailsModel> orders = <OrderDetailsModel>[].obs;
  RxList<OrderDetailsModel> ordersOpened = <OrderDetailsModel>[].obs;
  RxList<OrderDetailsModel> ordersClosed = <OrderDetailsModel>[].obs;

  late SharedPrefsRepository prefs;

  @override
  Future<void> onInit() async {
    tabController = TabController(length: 2, vsync: this);
    prefs = await SharedPrefsRepository.instance;

    super.onInit();

    loopGetOrders();
  }

  Future<void> loopGetOrders() async {
    await findOrders();

    Timer.periodic(const Duration(seconds: 40), (timer) async {
      await findOrders();
    });
  }

  Future<void> findOrders() async {
    final ordersTemp = await _orderRepository.getOrders();
    orders.clear();
    ordersClosed.clear();
    ordersOpened.clear();
    orders.addAll(ordersTemp);
    for (var el in orders) {
      if (el.statusPedido.toUpperCase() == statusCancelled ||
          el.statusPedido.toUpperCase() == statusConcluded) {
        ordersClosed.add(el);
      } else {
        ordersOpened.add(el);
      }
    }
  }

  Future<void> changeLanguage(String lang) async {
    await prefs.registerLocaleId(lang);
  }
}
