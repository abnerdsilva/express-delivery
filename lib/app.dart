import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/pages/login/login_page.dart';
import 'package:express_delivery/pages/splash_screen/splash_screen_page.dart';
import 'package:flutter/material.dart';

class App extends StatelessWidget {
  const App({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'ExpressDelivery',
      debugShowCheckedModeBanner: false,
      theme: ThemeConfig.appTheme,
      initialRoute: '/',
      routes: {
        '/': (context) => const SplashSreenPage(),
        '/login': (context) => const LoginPage(),
      },
    );
  }
}
