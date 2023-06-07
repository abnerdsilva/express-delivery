import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/pages/login/login_controller.dart';
import 'package:express_delivery/shared/components/custom_button.dart';
import 'package:express_delivery/shared/components/custom_text_form_field.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class LoginPage extends GetView<LoginController> {
  const LoginPage({Key? key}) : super(key: key);

  static const String route = '/login';

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
              const Text(
                'LOGIN',
                style: TextStyle(
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
                  hintText: 'Usuário',
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
                  hintText: 'Senha',
                  controller: controller.passController,
                  fillColor: ThemeConfig.kThirdSecondaryColor,
                ),
              ),
              const SizedBox(height: 24),
              Container(
                width: MediaQuery.of(context).size.width * .7,
                alignment: Alignment.centerRight,
                child: const Text(
                  'esqueceu a senha?',
                ),
              ),
              const SizedBox(height: 60),
              SizedBox(
                width: MediaQuery.of(context).size.width * .4,
                child: CustomButton(
                  label: 'Entrar',
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
