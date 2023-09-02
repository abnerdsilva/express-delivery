import 'package:express_delivery/app_binding.dart';
import 'package:express_delivery/config/routes.dart';
import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/generated/l10n.dart';
import 'package:express_delivery/pages/splash_screen/splash_screen_page.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
// ignore: depend_on_referenced_packages, implementation_imports
import 'package:flutter_localizations/src/material_localizations.dart';
// ignore: depend_on_referenced_packages, implementation_imports
import 'package:flutter_localizations/src/cupertino_localizations.dart';
// ignore: depend_on_referenced_packages, implementation_imports
import 'package:flutter_localizations/src/widgets_localizations.dart';

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
      supportedLocales: S.delegate.supportedLocales,
      localizationsDelegates: const [
        S.delegate,
        GlobalMaterialLocalizations.delegate,
        GlobalCupertinoLocalizations.delegate,
        GlobalWidgetsLocalizations.delegate,
      ],
    );
  }
}
