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
              const SizedBox(height: 16),
              SizedBox(
                width: MediaQuery.of(context).size.width * .7,
                child: CustomTextFormField(
                  radiusBorder: 10,
                  heightWithLabel: 70,
                  height: 40,
                  label: 'Usuário',
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
                  label: 'Senha',
                  controller: controller.passController,
                ),
              ),
              const SizedBox(height: 24),
              SizedBox(
                width: MediaQuery.of(context).size.width * .7,
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    const Text(
                      'Esqueci minha senha',
                      style: TextStyle(color: Colors.red),
                    ),
                    CustomButton(
                      label: 'Entrar',
                      alignment: Alignment.center,
                      width: 80,
                      fontSize: 16,
                      onClick: () => controller.login(),
                    ),
                  ],
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
