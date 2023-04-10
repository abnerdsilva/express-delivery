import 'package:express_delivery/app_binding.dart';
import 'package:express_delivery/config/routes.dart';
import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/pages/splash_screen/splash_screen_page.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class App extends StatelessWidget {
  const App({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GetMaterialApp(
      title: 'ExpressDelivery',
      debugShowCheckedModeBanner: false,
      theme: ThemeConfig.appTheme,
      home: const SplashSreenPage(),
      initialBinding: AppBinding(),
      getPages: RoutesConfig.routes,
    );
  }
}
