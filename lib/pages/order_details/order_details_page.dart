import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/generated/l10n.dart';
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
                    '${S().order} ${S().orderID} ${controller.order.value.codPedido}',
                    style: const TextStyle(
                      fontSize: 22,
                      color: ThemeConfig.kTextThirdColor,
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
        toolbarHeight: 90,
      ),
      body: SingleChildScrollView(
        child: SafeArea(
          child: Container(
            color: ThemeConfig.kThirdSecondaryColor,
            margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
            padding: const EdgeInsets.all(8.0),
            child: Obx(
              () => Column(
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
                  const SizedBox(height: 16),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        controller.order.value.dataPedido.toString(),
                        style: const TextStyle(fontSize: 16),
                      ),
                      Text(
                        controller.order.value.statusPedido,
                        style: const TextStyle(fontSize: 16),
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
                            '${S().clientName}:',
                            style: const TextStyle(
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(width: 20),
                      Expanded(
                        flex: 4,
                        child: Text(controller.order.value.client?.name ?? ''),
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
                            '${S().clientAddress}:',
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
                            '${controller.order.value.client?.address ?? ''}, ${controller.order.value.client?.addressNumber ?? ''}'),
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
                            '${S().clientNeighborhood}:',
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
                            controller.order.value.client?.neighborhood ?? ''),
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
                            '${S().clientComplement}:',
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
                            controller.order.value.client?.complement ?? ''),
                      ),
                    ],
                  ),
                  const SizedBox(height: 4),
                  const Divider(
                    color: Colors.white60,
                    thickness: 4,
                    indent: 30,
                    endIndent: 30,
                  ),
                  const SizedBox(height: 16),
                  Row(
                    children: [
                      Expanded(
                        flex: 6,
                        child: Text(
                          S().items,
                          style: const TextStyle(
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      const SizedBox(width: 20),
                      Expanded(
                        flex: 2,
                        child: Text(
                          S().quantity,
                          textAlign: TextAlign.end,
                          style: const TextStyle(
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      const SizedBox(width: 20),
                      Expanded(
                        flex: 3,
                        child: Container(
                          alignment: Alignment.centerRight,
                          child: Text(
                            S().price,
                            style: const TextStyle(
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 4),
                  ListView.builder(
                    shrinkWrap: true,
                    physics: const NeverScrollableScrollPhysics(),
                    itemCount: controller.order.value.itens?.length ?? 0,
                    itemBuilder: (context, index) {
                      final product = controller.order.value.itens?[index];
                      if (product == null) return Container();

                      return Padding(
                        padding: const EdgeInsets.all(2.0),
                        child: Row(
                          children: [
                            Expanded(
                              flex: 6,
                              child: Text(product.name),
                            ),
                            const SizedBox(width: 20),
                            Expanded(
                              flex: 1,
                              child: Container(
                                  alignment: Alignment.centerRight,
                                  child: Text(
                                    product.quantity.toString(),
                                    textAlign: TextAlign.end,
                                  )),
                            ),
                            const SizedBox(width: 20),
                            Expanded(
                              flex: 3,
                              child: Container(
                                alignment: Alignment.centerRight,
                                child: Text(
                                  '${S().priceCode} ${(product.totalValue / double.parse(S().priceExchange)).toStringAsFixed(2)}',
                                ),
                              ),
                            ),
                          ],
                        ),
                      );
                    },
                  ),
                  const SizedBox(height: 4),
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
                        '${S().priceCode} ${(controller.order.value.vrTotal / double.parse(S().priceExchange)).toStringAsFixed(2)}',
                        style: const TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 12),
                  const Divider(),
                  const SizedBox(height: 12),
                  Row(
                    children: [
                      Expanded(
                        child: Text(
                          S().paymentForm,
                          style: const TextStyle(
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      const SizedBox(width: 20),
                      const Text('VERIFICAR'),
                    ],
                  ),
                  const SizedBox(height: 12),
                  const Divider(),
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
                  const SizedBox(height: 12),
                  Align(
                    alignment: Alignment.centerRight,
                    child: ElevatedButton(
                      onPressed: () {},
                      style: ButtonStyle(
                        backgroundColor: MaterialStateColor.resolveWith(
                            (states) => Colors.redAccent),
                      ),
                      child: Text(S().ready),
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
