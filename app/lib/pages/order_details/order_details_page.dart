import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/generated/l10n.dart';
import 'package:express_delivery/pages/order_details/components/header_order_details_widget.dart';
import 'package:express_delivery/pages/order_details/components/product_order_details_widget.dart';
import 'package:express_delivery/pages/order_details/order_details_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class OrderDetailsPage extends GetView<OrderDetailsController> {
  const OrderDetailsPage({Key? key}) : super(key: key);

  static const String route = '/details';

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        automaticallyImplyLeading: false,
        flexibleSpace: SizedBox(
          height: double.infinity,
          child: Stack(
            alignment: Alignment.bottomCenter,
            children: [
              const Align(
                alignment: Alignment.centerLeft,
                child: BackButton(color: Colors.white),
              ),
              Padding(
                padding: const EdgeInsets.only(bottom: 10),
                child: Obx(
                  () => Text(
                    '${S().order} ${S().orderID} ${controller.order.value.id}',
                    style: const TextStyle(
                      fontSize: 22,
                      color: ThemeConfig.kTextThirdColor,
                    ),
                  ),
                ),
              ),
              Obx(
                () => controller.order.value.statusPedido.toUpperCase() == 'CONFIRMADO'
                    ? Align(
                        alignment: Alignment.centerRight,
                        child: IconButton(
                          onPressed: () => controller.reprintOrder(
                            controller.order.value.codPedido,
                          ),
                          icon: const Icon(
                            Icons.print,
                            color: ThemeConfig.kTextThirdColor,
                          ),
                        ),
                      )
                    : Container(),
              ),
            ],
          ),
        ),
        toolbarHeight: 90,
      ),
      body: SafeArea(
        child: Container(
          margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
          padding: const EdgeInsets.all(8.0),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(10),
            color: ThemeConfig.kThirdSecondaryColor,
          ),
          child: Obx(
            () {
              final vrTotal = controller.order.value.vrTotal +
                  controller.order.value.vrAdicional -
                  controller.order.value.vrDesconto;

              return Column(
                children: [
                  HeaderOrderDetailsWidget(order: controller.order.value),
                  const SizedBox(height: 4),
                  const Divider(
                    color: Colors.white60,
                    thickness: 4,
                    indent: 30,
                    endIndent: 30,
                  ),
                  const SizedBox(height: 16),
                  ProductOrderDetailsWidget(
                    order: controller.order.value,
                  ),
                  const SizedBox(height: 12),
                  const Divider(
                    color: Colors.white60,
                    thickness: 4,
                    indent: 30,
                    endIndent: 30,
                  ),
                  const SizedBox(height: 16),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: [
                      const Text(
                        'SubTotal:',
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      const SizedBox(width: 20),
                      Text(
                        '${S().priceCode} ${(controller.order.value.vrTotal / double.parse(S().priceExchange)).toStringAsFixed(2)}',
                        style: const TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: [
                      const Text(
                        'Troco:',
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      const SizedBox(width: 20),
                      Text(
                        '${S().priceCode} ${(controller.order.value.vrTroco / double.parse(S().priceExchange)).toStringAsFixed(2)}',
                        style: const TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: [
                      const Text(
                        'Taxa:',
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      const SizedBox(width: 20),
                      Text(
                        '${S().priceCode} ${(controller.order.value.vrAdicional / double.parse(S().priceExchange)).toStringAsFixed(2)}',
                        style: const TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: [
                      const Text(
                        'TOTAL:',
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      const SizedBox(width: 20),
                      Text(
                        '${S().priceCode} ${(vrTotal / double.parse(S().priceExchange)).toStringAsFixed(2)}',
                        style: const TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 22),
                  Row(
                    children: [
                      Expanded(
                        child: Text(
                          S().paymentType,
                          style: const TextStyle(
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      const SizedBox(width: 20),
                      Text(controller.order.value.formaPagamento),
                    ],
                  ),
                  const SizedBox(height: 12),
                  Align(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      '${S().observation}:',
                      style: const TextStyle(
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ),
                  Container(
                    margin: const EdgeInsets.only(top: 4),
                    alignment: Alignment.centerLeft,
                    child: Text(controller.order.value.observacao),
                  ),
                  const SizedBox(height: 12),
                  const Divider(),
                  Expanded(child: Container()),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      controller.order.value.statusPedido.toUpperCase() == 'ABERTO' ||
                              controller.order.value.statusPedido.toUpperCase() == 'CONFIRMADO' ||
                              controller.order.value.statusPedido.toUpperCase() == 'DESPACHADO'
                          ? Align(
                              alignment: Alignment.centerRight,
                              child: ElevatedButton(
                                onPressed: () => controller.cancelOrder(
                                  controller.order.value.codPedido,
                                ),
                                style: ButtonStyle(
                                  backgroundColor: MaterialStateColor.resolveWith((states) => Colors.redAccent),
                                ),
                                child: Padding(
                                  padding: const EdgeInsets.symmetric(
                                    vertical: 8.0,
                                    horizontal: 24.0,
                                  ),
                                  child: Text(
                                    S().cancel,
                                  ),
                                ),
                              ),
                            )
                          : Container(),
                      controller.order.value.statusPedido.toUpperCase() != 'CANCELADO' &&
                              controller.order.value.statusPedido.toUpperCase() != 'CONCLUIDO'
                          ? Align(
                              alignment: Alignment.centerRight,
                              child: ElevatedButton(
                                onPressed: () => controller.updateOrderStatus(
                                  controller.order.value.codPedido,
                                ),
                                style: ButtonStyle(
                                  backgroundColor: MaterialStateColor.resolveWith((states) => Colors.blueAccent),
                                ),
                                child: Padding(
                                  padding: const EdgeInsets.symmetric(
                                    vertical: 8.0,
                                    horizontal: 24.0,
                                  ),
                                  child: Text(
                                    controller.order.value.statusPedido.toUpperCase() == 'ABERTO'
                                        ? S().confirm
                                        : controller.order.value.statusPedido.toUpperCase() == 'CONFIRMADO'
                                            ? S().dispatch
                                            : controller.order.value.statusPedido.toUpperCase() == 'DESPACHADO'
                                                ? S().conclude
                                                : '',
                                  ),
                                ),
                              ),
                            )
                          : Container(),
                    ],
                  ),
                ],
              );
            },
          ),
        ),
      ),
    );
  }
}
