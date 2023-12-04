import 'package:express_delivery/pages/login/model/user_model.dart';

abstract class ILoginRepostiory {
  Future<UserModel> login(String id);
  Future<String> auth(String username, String password);
}
