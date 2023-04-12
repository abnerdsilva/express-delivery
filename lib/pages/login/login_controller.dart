import 'package:express_delivery/pages/home/home_page.dart';
import 'package:flutter/cupertino.dart';
import 'package:get/get.dart';

class LoginController extends GetxController {
  TextEditingController userController = TextEditingController();
  TextEditingController passController = TextEditingController();
  
  void login(){
    // if (userController.text.isEmpty || passController.text.isEmpty) {
    //   Get.snackbar('Login', 'Usuário e/ou senha inválido');
    //   return;
    // }

    Get.offAndToNamed(HomePage.route);
  }
}