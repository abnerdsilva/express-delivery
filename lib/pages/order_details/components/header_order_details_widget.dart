import 'package:express_delivery/generated/l10n.dart';
import 'package:express_delivery/shared/model/order_details_model.dart';
import 'package:flutter/material.dart';

class HeaderOrderDetailsWidget extends StatelessWidget {
  final OrderDetailsModel order;
  const HeaderOrderDetailsWidget({super.key, required this.order});

  static const statusCancelled = 'CANCELADO';
  static const statusConcluded = 'CONCLUIDO';
  static const statusOpened = 'ABERTO';

  String convertDateBR(String value) {
    return '${value.substring(8, 10)}/${value.substring(5, 7)}/${value.substring(0, 4)} ${value.substring(11, 13)}:${value.substring(14, 16)}';
  }

  Color setStatusColor(String color) {
    late Color orderStatusColor;
    switch (order.statusPedido.toUpperCase()) {
      case statusOpened:
        orderStatusColor = const Color(0xff3D7BC3);
        break;
      case statusConcluded:
        orderStatusColor = const Color(0xff72AE42);
        break;
      case statusCancelled:
        orderStatusColor = const Color(0xffA65454);
        break;
      default:
        orderStatusColor = const Color(0xffC39D3D);
        break;
    }
    return orderStatusColor;
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Center(
          child: Text(
            S().orderDetails,
            style: const TextStyle(fontSize: 18),
          ),
        ),
        const SizedBox(height: 4),
        const Divider(
          color: Colors.white60,
          thickness: 4,
          indent: 30,
          endIndent: 30,
        ),
        const SizedBox(height: 12),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Text(
              S().orderCreatedAtDescription,
              style: const TextStyle(fontWeight: FontWeight.bold),
            ),
            Text(
              S().orderStatusDescription,
              style: const TextStyle(fontWeight: FontWeight.bold),
            ),
          ],
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Text(
              order.dataPedido.isEmpty ? '' : convertDateBR(order.dataPedido),
            ),
            Container(
              decoration: BoxDecoration(
                color: setStatusColor(order.statusPedido),
              ),
              child: Text(
                '${order.statusPedido} - VERIFICAR',
                style: const TextStyle(fontSize: 16),
              ),
            ),
          ],
        ),
        const SizedBox(height: 16),
        Row(
          children: [
            Expanded(
              flex: 2,
              child: Container(
                alignment: Alignment.centerRight,
                child: Text(
                  '${S().client}:',
                  style: const TextStyle(
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ),
            const SizedBox(width: 20),
            Expanded(
              flex: 4,
              child: Text(order.client?.name ?? ''),
            ),
          ],
        ),
        Row(
          children: [
            Expanded(
              flex: 2,
              child: Container(
                alignment: Alignment.centerRight,
                child: Text(
                  '${S().address}:',
                  style: const TextStyle(
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ),
            const SizedBox(width: 20),
            Expanded(
              flex: 4,
              child: Text(
                  '${order.client?.address ?? ''}, ${order.client?.addressNumber ?? ''}'),
            ),
          ],
        ),
        Row(
          children: [
            Expanded(
              flex: 2,
              child: Container(
                alignment: Alignment.centerRight,
                child: Text(
                  '${S().neighborhood}:',
                  style: const TextStyle(
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ),
            const SizedBox(width: 20),
            Expanded(
              flex: 4,
              child: Text(order.client?.neighborhood ?? ''),
            ),
          ],
        ),
        Row(
          children: [
            Expanded(
              flex: 2,
              child: Container(
                alignment: Alignment.centerRight,
                child: Text(
                  '${S().complement}:',
                  style: const TextStyle(
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ),
            const SizedBox(width: 20),
            Expanded(
              flex: 4,
              child: Text(order.client?.complement ?? ''),
            ),
          ],
        ),
      ],
    );
  }
}
