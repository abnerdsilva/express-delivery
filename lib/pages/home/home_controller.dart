import 'dart:async';
import 'dart:math';

import 'package:express_delivery/shared/model/order_details_model.dart';
import 'package:express_delivery/shared/model/product_order.dart';
import 'package:express_delivery/shared/repositories/order_repository.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class HomeController extends GetxController with GetSingleTickerProviderStateMixin {
  late TabController tabController;

  late OrderRepository _orderRepository;

  HomeController(OrderRepository orderRepository) {
    _orderRepository = orderRepository;
  }

  RxList<ProductOrder> itensOrder = <ProductOrder>[].obs;
  RxList<OrderDetailsModel> orders = <OrderDetailsModel>[].obs;
  RxList<OrderDetailsModel> ordersOpened = <OrderDetailsModel>[].obs;
  RxList<OrderDetailsModel> ordersClosed = <OrderDetailsModel>[].obs;

  @override
  void onInit() {
    tabController = TabController(length: 2, vsync: this);
    super.onInit();

    loopGetOrders();

    itensOrder.value = List.generate(6, (index) {
      final unitValue = Random().nextDouble();
      final quantity = Random().nextInt(10);
      return ProductOrder(
        id: 0,
        name: 'Produto ${index + 1}',
        unitValue: unitValue,
        quantity: quantity,
        totalValue: unitValue * quantity,
        benefit: 0.0,
        tax: 0.0,
      );
    });
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
    for(var el in orders){
      if (el.statusPedido.toUpperCase() == 'CANCELADO' || el.statusPedido.toUpperCase() == 'CONCLUIDO') {
        ordersClosed.add(el);
      } else {
        ordersOpened.add(el);
      }
    }
  }
}
