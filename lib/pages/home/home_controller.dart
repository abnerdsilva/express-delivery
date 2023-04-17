import 'dart:math';

import 'package:express_delivery/shared/model/client.dart';
import 'package:express_delivery/shared/model/order_details.dart';
import 'package:express_delivery/shared/model/product_order.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class HomeController extends GetxController with GetSingleTickerProviderStateMixin {
  late TabController tabController;

  RxList<ProductOrder> itensOrder = <ProductOrder>[].obs;
  RxList<OrderDetails> orders = <OrderDetails>[].obs;

  @override
  void onInit() {
    tabController = TabController(length: 2, vsync: this);
    super.onInit();

    // orders.value = List.generate(
    //   30,
    //   (index) => OrderModel(
    //     clientId: index + 1,
    //     clientName: 'Nome cliente ${index + 1}',
    //     id: index + 1,
    //   ),
    // );

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

    orders.value = List.generate(11, (index) {
      return OrderDetails(
        id: index,
        status: 'Aberto',
        dataPedido: '2023-04-15 12:36:70',
        client: Client(
          id: 214,
          name: 'Cliente $index',
          address: 'Rua Xpto',
          addressNumber: '97',
          city: 'Indaiatuba',
          neighborhood: 'Bairro do cliente',
          postalCode: '13330-000',
        ),
        itens: itensOrder,
      );
    });
  }
}
