import 'dart:developer';

import 'package:dropdown_button2/dropdown_button2.dart';
import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/generated/l10n.dart';
import 'package:express_delivery/pages/login/login_page.dart';
import 'package:express_delivery/pages/settings/components/menu_item.dart';
import 'package:express_delivery/shared/components/custom_app_bar.dart';
import 'package:express_delivery/shared/repositories/shared_preferences_repository.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class SettingsPage extends StatefulWidget {
  const SettingsPage({super.key});

  static const String route = '/settings';

  @override
  State<SettingsPage> createState() => _SettingsPageState();
}

class _SettingsPageState extends State<SettingsPage> {
  final List<String> items = [
    'Portugues - PT_BR',
    'Inglês - EU',
  ];

  String languageSelected = 'pt';

  MenuItemModel? itemSelected;

  Future<void> setLanguageLocale(MenuItemModel item) async {
    itemSelected = item;

    SharedPrefsRepository prefs = await SharedPrefsRepository.instance;

    setState(() {
      switch (itemSelected!.code) {
        case 'pt':
          languageSelected = 'pt';
          break;
        case 'en':
        default:
          languageSelected = 'en';
          break;
      }

      S.load(Locale(languageSelected));
      prefs.registerLocaleId(languageSelected);
    });
  }

  Future<void> initLanguage() async {
    SharedPrefsRepository prefs = await SharedPrefsRepository.instance;
    final localeID = prefs.localeID ?? 'pt';
    setState(() {
      itemSelected = MenuItems.getMenuItem(localeID);
    });
  }

  Future<void> logout() async {
    final prefs = await SharedPrefsRepository.instance;
    prefs.logout();

    Get.offAllNamed(LoginPage.route);
  }

  @override
  void initState() {
    super.initState();

    initLanguage();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: CustomAppBar(
        title: S().settings,
      ),
      body: SafeArea(
        child: Container(
          margin: const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
          padding: const EdgeInsets.symmetric(vertical: 8.0, horizontal: 16.0),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(10),
            color: ThemeConfig.kThirdSecondaryColor,
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              const SizedBox(height: 8),
              Container(
                width: 150,
                height: 150,
                padding: const EdgeInsets.all(20),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(75),
                  color: ThemeConfig.kSecondaryColor,
                ),
                child: Image.asset(
                  'assets/images/logosemfundo.png',
                  alignment: Alignment.center,
                  fit: BoxFit.fill,
                ),
              ),
              const SizedBox(height: 16),
              const Text(
                'NOME RESTAURANTE',
                style: TextStyle(fontSize: 22),
              ),
              const SizedBox(height: 4),
              const Divider(
                color: Colors.white60,
                thickness: 4,
                indent: 30,
                endIndent: 30,
              ),
              const SizedBox(height: 16),
              Text(
                S().language.toUpperCase(),
                style: const TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 18,
                ),
              ),
              const SizedBox(height: 8),
              DropdownButtonHideUnderline(
                child: DropdownButton2(
                  hint: itemSelected == null
                      ? Text(
                          'Select Item',
                          style: TextStyle(
                            fontSize: 14,
                            color: Theme.of(context).hintColor,
                          ),
                        )
                      : null,
                  items: [
                    ...MenuItems.items.map(
                      (item) => DropdownMenuItem<MenuItemModel>(
                        value: item,
                        child: MenuItems.buildItem(item),
                      ),
                    ),
                  ],
                  value: itemSelected,
                  onChanged: (value) {
                    final t = value as MenuItemModel;
                    log(t.text);
                    setLanguageLocale(t);
                  },
                  buttonStyleData: const ButtonStyleData(
                    height: 40,
                    width: 140,
                  ),
                  menuItemStyleData: const MenuItemStyleData(
                    height: 40,
                  ),
                ),
              ),
              const SizedBox(height: 16),
              const Divider(
                color: Colors.white60,
                thickness: 4,
                indent: 30,
                endIndent: 30,
              ),
              const SizedBox(height: 16),
              Text(
                S().support.toUpperCase(),
                style: const TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 18,
                ),
              ),
              const SizedBox(height: 22),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Expanded(
                    flex: 2,
                    child: Text(
                      '${S().phone}:',
                      style: const TextStyle(fontWeight: FontWeight.bold),
                    ),
                  ),
                  const Text('(19) 98325-5269'),
                ],
              ),
              const SizedBox(height: 16),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Expanded(
                    flex: 4,
                    child: Text(
                      '${S().email}:',
                      style: const TextStyle(fontWeight: FontWeight.bold),
                    ),
                  ),
                  const Text('expressdelivery@gmail.com'),
                ],
              ),
              const SizedBox(height: 16),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Expanded(
                    flex: 2,
                    child: Text(
                      '${S().address}:',
                      style: const TextStyle(fontWeight: FontWeight.bold),
                    ),
                  ),
                  const Expanded(
                    flex: 4,
                    child: Text(
                      'Rua 7 de Setembro, 255 - Indaiatuba/SP asdfasf asdfsadf asdfsf',
                      textAlign: TextAlign.end,
                    ),
                  ),
                ],
              ),
              Expanded(child: Container()),
              ElevatedButton(
                onPressed: () => logout(),
                style: ButtonStyle(
                    backgroundColor: MaterialStateColor.resolveWith(
                        (states) => Colors.black)),
                child: Container(
                  width: MediaQuery.of(context).size.width * .7,
                  alignment: Alignment.center,
                  child: Text(
                    S().logout,
                    style: const TextStyle(
                      color: ThemeConfig.kTextThirdColor,
                      fontSize: 18,
                    ),
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
