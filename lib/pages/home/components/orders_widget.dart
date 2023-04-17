import 'package:express_delivery/pages/home/home_controller.dart';
import 'package:express_delivery/pages/order_details/order_details_page.dart';
import 'package:express_delivery/shared/model/order_details.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class OrdersWidget extends GetView<HomeController> {
  final String title;

  const OrdersWidget({Key? key, required this.title}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      itemCount: controller.orders.length,
      shrinkWrap: true,
      itemBuilder: (context, index) {
        final item = controller.orders[index];
        return ListTile(
          title: Text(item.client.name),
          subtitle: Text(item.client.address),
          leading: Text(item.id.toString()),
          trailing: title == 'Aberto' ? const Text('aberto') : const Text('fechado'),
          onTap: () {
            Get.toNamed(OrderDetailsPage.route, arguments: item);
          },
        );
      },
    );
  }
}
