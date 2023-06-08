import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/generated/l10n.dart';
import 'package:express_delivery/pages/login/login_controller.dart';
import 'package:express_delivery/shared/components/custom_button.dart';
import 'package:express_delivery/shared/components/custom_text_form_field.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  static const String route = '/login';

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  late LoginController controller;

  @override
  void initState() {
    super.initState();

    controller = Get.find<LoginController>();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Center(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Image.asset('assets/images/logosemfundo.png'),
              const SizedBox(height: 24),
              Text(
                S().login.toUpperCase(),
                style: const TextStyle(
                  fontSize: 22,
                  color: ThemeConfig.kPrimaryColor,
                ),
              ),
              const SizedBox(height: 32),
              SizedBox(
                width: MediaQuery.of(context).size.width * .7,
                child: CustomTextFormField(
                  radiusBorder: 10,
                  heightWithLabel: 70,
                  height: 40,
                  hintText: S().username,
                  fillColor: ThemeConfig.kThirdSecondaryColor,
                  controller: controller.userController,
                ),
              ),
              const SizedBox(height: 12),
              SizedBox(
                width: MediaQuery.of(context).size.width * .7,
                child: CustomTextFormField(
                  radiusBorder: 10,
                  heightWithLabel: 70,
                  height: 40,
                  obscureText: true,
                  hintText: S().password,
                  controller: controller.passController,
                  fillColor: ThemeConfig.kThirdSecondaryColor,
                ),
              ),
              const SizedBox(height: 24),
              Container(
                width: MediaQuery.of(context).size.width * .7,
                alignment: Alignment.centerRight,
                child: Text(
                  S().forgotPassword,
                ),
              ),
              const SizedBox(height: 60),
              SizedBox(
                width: MediaQuery.of(context).size.width * .4,
                child: CustomButton(
                  label: S().login,
                  alignment: Alignment.center,
                  width: 80,
                  fontSize: 16,
                  onClick: () => controller.login(),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
