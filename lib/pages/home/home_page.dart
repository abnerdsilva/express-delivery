import 'package:express_delivery/pages/home/components/orders_widget.dart';
import 'package:express_delivery/pages/home/home_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class HomePage extends GetView<HomeController> {
  HomePage({Key? key}) : super(key: key);

  static const String route = '/home';

  final _globalKey = GlobalKey();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        key: _globalKey,
        child: Container(
          margin: const EdgeInsets.all(16),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 16),
              const Center(
                child: Text(
                  'Pedidos do dia',
                  style: TextStyle(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
              const SizedBox(height: 8),
              TabBar(
                controller: controller.tabController,
                labelColor: Colors.black,
                indicator: BoxDecoration(
                  borderRadius: BorderRadius.circular(50), // Creates border
                  color: Colors.grey,
                ),
                //
                tabs: const [
                  Tab(icon: Text('Aberto')),
                  Tab(icon: Text('Fechado')),
                ],
              ),
              Expanded(
                child: TabBarView(
                  controller: controller.tabController,
                  children: [
                    Obx(
                      () => controller.ordersOpened.isNotEmpty
                          ? OrdersWidget(orders: controller.ordersOpened)
                          : const Center(
                              child: Text('Nenhum item'),
                            ),
                    ),
                    Obx(
                      () => controller.ordersClosed.isNotEmpty
                          ? OrdersWidget(orders: controller.ordersClosed)
                          : const Center(
                              child: Text('Nenhum item'),
                            ),
                    ),
                  ],
                ),
              ),

              // const SizedBox(height: 8),
              // const Divider(),
              // const SizedBox(height: 8),
              // //   const Text(
              //     'Fechado',
              //     style: TextStyle(
              //       fontSize: 18,
              //       color: Colors.red,
              //     ),
              //   ),
              //
            ],
          ),
        ),
      ),
    );
  }
}
