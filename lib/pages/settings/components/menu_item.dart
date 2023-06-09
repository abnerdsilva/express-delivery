import 'package:flutter/material.dart';

class MenuItemModel {
  final String text;
  final String image;
  final String code;

  const MenuItemModel({
    required this.text,
    required this.image,
    required this.code,
  });
}

class MenuItems {
  static const List<MenuItemModel> items = [
    MenuItemModel(
      text: 'Brasil',
      image: 'assets/images/brasil.png',
      code: 'pt',
    ),
    MenuItemModel(
      text: 'EUA',
      image: 'assets/images/eua.png',
      code: 'en',
    ),
  ];

  static Widget buildItem(MenuItemModel item) {
    return Row(
      children: [
        Image.asset(
          item.image,
        ),
        const SizedBox(
          width: 10,
        ),
        Text(
          item.text,
          style: const TextStyle(
            color: Colors.black,
          ),
        ),
      ],
    );
  }

  static MenuItemModel getMenuItem(String code) {
    return items.firstWhere((element) => code == element.code);
  }
}
