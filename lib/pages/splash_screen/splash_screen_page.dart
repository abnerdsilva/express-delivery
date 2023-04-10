import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/pages/login/login_page.dart';
import 'package:flutter/material.dart';

class SplashSreenPage extends StatefulWidget {
  const SplashSreenPage({Key? key}) : super(key: key);

  static const String route = '/';

  @override
  State<SplashSreenPage> createState() => _SplashSreenPageState();
}

class _SplashSreenPageState extends State<SplashSreenPage> {
  @override
  void initState() {
    super.initState();

    Future.delayed(const Duration(seconds: 3), () {
      Navigator.pushNamedAndRemoveUntil(context, LoginPage.route, (route) => false);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: ThemeConfig.backgroundColor,
      body: Center(
        child: Image.asset('assets/images/logo.png'),
      ),
    );
  }
}
