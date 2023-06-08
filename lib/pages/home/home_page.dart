import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/generated/l10n.dart';
import 'package:express_delivery/pages/home/components/orders_widget.dart';
import 'package:express_delivery/pages/home/home_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  static const String route = '/home';

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final _globalKey = GlobalKey();

  late HomeController controller;

  @override
  void initState() {
    super.initState();

    controller = Get.find<HomeController>();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: TabBar(
          controller: controller.tabController,
          labelColor: ThemeConfig.kTextThirdColor,
          labelStyle: const TextStyle(fontSize: 18),
          indicatorSize: TabBarIndicatorSize.label,
          indicatorWeight: 4,
          tabs: [
            Tab(
              icon: Text(S().statusOpened),
            ),
            Tab(
              icon: Text(S().statusClosed),
            ),
          ],
        ),
      ),
      body: SafeArea(
        key: _globalKey,
        child: Container(
          margin: const EdgeInsets.all(16),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 8),
              Expanded(
                child: TabBarView(
                  controller: controller.tabController,
                  children: [
                    Obx(
                      () => controller.ordersOpened.isNotEmpty
                          ? OrdersWidget(orders: controller.ordersOpened)
                          : Center(
                              child: Text(S().noOrders),
                            ),
                    ),
                    Obx(
                      () => controller.ordersClosed.isNotEmpty
                          ? OrdersWidget(orders: controller.ordersClosed)
                          : Center(
                              child: Text(S().noOrders),
                            ),
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          final locale = controller.prefs.localeID ?? 'pt';
          String codeLocale = 'pt';

          setState(() {
            switch (locale) {
              case 'en':
                codeLocale = 'pt';
                break;
              case 'pt':
              default:
                codeLocale = 'en';
                break;
            }

            S.load(Locale(codeLocale));
            controller.changeLanguage(codeLocale);
          });
        },
        child: const Icon(
          Icons.settings_outlined,
          color: Colors.black,
          size: 45,
        ),
      ),
    );
  }
}
