import 'package:get/get.dart';
import 'package:shared_preferences/shared_preferences.dart';

class SharedPrefsRepository {
  static const _userID = '/USER_ID/';
  static const _userNAME = '/USER_NAME/';
  static const _localeID = '/LOCALE_ID/';
  static const _token = '/TOKEN/';

  static SharedPreferences? prefs;
  static SharedPrefsRepository? _instanceRepository;

  SharedPrefsRepository._();

  static Future<SharedPrefsRepository> get instance async {
    prefs ??= await SharedPreferences.getInstance();
    _instanceRepository ??= SharedPrefsRepository._();

    return _instanceRepository!;
  }

  Future<void> registerLocaleId(String id) async {
    await prefs!.setString(_localeID, id);
  }

  String? get localeID => prefs!.getString(_localeID);

  Future<void> registerClienteID(String clientID) async {
    await prefs!.setString(_userID, clientID);
  }

  String? get clienteID => prefs!.getString(_userID);

  Future<void> registerToken(String token) async {
    await prefs!.setString(_token, token);
  }

  String? get token => prefs!.getString(_token);

  Future<void> registerClientName(String name) async {
    await prefs!.setString(_userNAME, name);
  }

  Future<void> logout() async {
    prefs!.clear();
    Get.offAndToNamed('/');
  }
}
