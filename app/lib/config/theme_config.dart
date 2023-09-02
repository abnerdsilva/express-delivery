import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';

class ThemeConfig {
  ThemeConfig._();

  static final appTheme = ThemeData(
    primaryColor: kPrimaryColor,
    primarySwatch: kToDark,
    canvasColor: kSecondaryColor,
    fontFamily: GoogleFonts.lato().fontFamily,
    backgroundColor: backgroundColor,
  );

  static const kPrimaryColor = Color(0xFFC13C53);
  static const kSecondaryColor = Color(0xFFEAF0F5);
  static const kThirdSecondaryColor = Color(0xFFD4D4D4);

  static const backgroundColor = Color(0xFFf0f0f0);

  static const MaterialColor kToDark = MaterialColor(
    0xFFC33D55,
    <int, Color>{
      50: Color(0xFFC13C53),
      100: Color(0xFFC13C53),
      200: Color(0xFFC13C53),
      300: Color(0xFFC33D55),
      500: Color(0xFFC33D55),
      600: Color(0xFFC33D55),
      700: Color(0xFFC33D55),
    },
  );

  static const kTextPrimaryColor = Color(0xff000000);
  static const kTextSecundaryColor = Colors.grey;
  static const kTextThirdColor = Colors.white;
  static const kTextFourtyColor = Color(0xFF6C6C6C);
}
