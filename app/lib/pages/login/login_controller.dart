import 'dart:developer';

import 'package:express_delivery/config/rest_client.dart';
import 'package:express_delivery/pages/home/home_page.dart';
import 'package:express_delivery/pages/login/repositories/login_repository.dart';
import 'package:express_delivery/shared/repositories/shared_preferences_repository.dart';
import 'package:flutter/cupertino.dart';
import 'package:get/get.dart';

class LoginController extends GetxController {
  TextEditingController userController = TextEditingController();
  TextEditingController passController = TextEditingController();

  late LoginRepository loginRepository;

  LoginController() {
    loginRepository = LoginRepository(Get.find());
  }

  Future<void> login() async {
    if (userController.text.isEmpty || passController.text.isEmpty) {
      Get.snackbar('Login', 'Usuário e/ou senha inválido');
      return;
    }

    try {
      final user =
          await loginRepository.login(userController.text, passController.text);
      if (user.id == 0) {
        Get.snackbar('Ops', 'Usuário e/ou senha inválido(s)');
        return;
      }
      final prefs = await SharedPrefsRepository.instance;
      prefs.registerClienteID(user.id.toString());
      prefs.registerClientName(user.username);

      Get.offAndToNamed(HomePage.route);
    } on RestClientException catch (e) {
      log(e.toString());
      Get.snackbar('Erro', e.message);
    } catch (e) {
      log(e.toString());
      Get.snackbar('Ops', e.toString());
    }
  }
}
