import 'package:express_delivery/pages/home/home_binding.dart';
import 'package:express_delivery/pages/home/home_page.dart';
import 'package:express_delivery/pages/login/login_binding.dart';
import 'package:express_delivery/pages/login/login_page.dart';
import 'package:express_delivery/pages/splash_screen/splash_screen_page.dart';
import 'package:get/get.dart';

class RoutesConfig {
  static final routes = [
    GetPage(
      name: SplashSreenPage.route,
      page: () => const SplashSreenPage(),
    ),
    GetPage(
      name: LoginPage.route,
      page: () => const LoginPage(),
      binding: LoginBinding(),
    ),
    GetPage(
      name: HomePage.route,
      page: () => HomePage(),
      binding: HomeBinding(),
    ),
  ];
}
