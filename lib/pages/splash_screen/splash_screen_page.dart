import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/generated/l10n.dart';
import 'package:express_delivery/pages/login/login_page.dart';
import 'package:express_delivery/shared/repositories/shared_preferences_repository.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

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

    Future.delayed(const Duration(seconds: 3), () async {
      final prefs = await SharedPrefsRepository.instance;
      final locale = prefs.localeID ?? 'pt';

      // setState(() {
      switch (locale) {
        case 'pt':
          S.load(const Locale('pt'));
          prefs.registerLocaleId('pt');
          break;
        case 'en':
          S.load(const Locale('en'));
          prefs.registerLocaleId('en');
          break;
        default:
          S.load(const Locale('pt'));
          prefs.registerLocaleId('pt');
          break;
      }
      // });

      Get.offAndToNamed(LoginPage.route);
      // ignore: use_build_context_synchronously
      // Navigator.pushNamedAndRemoveUntil(
      //   context,
      //   LoginPage.route,
      //   (route) => false,
      // );
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
