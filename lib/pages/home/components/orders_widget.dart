import 'package:express_delivery/pages/order_details/order_details_page.dart';
import 'package:express_delivery/shared/model/order_details_model.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class OrdersWidget extends StatelessWidget {
  final List<OrderDetailsModel> orders;

  const OrdersWidget({Key? key, required this.orders}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      itemCount: orders.length,
      shrinkWrap: true,
      itemBuilder: (context, index) {
        final item = orders[index];
        return ListTile(
          title: Text(item.client!.name),
          subtitle: Text(item.client!.address),
          leading: Text(item.codPedido.toString()),
          trailing: Text(item.statusPedido),
          onTap: () {
            Get.toNamed(OrderDetailsPage.route, arguments: item);
          },
        );
      },
    );
  }
}
