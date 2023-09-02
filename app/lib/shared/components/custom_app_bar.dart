import 'package:express_delivery/config/theme_config.dart';
import 'package:flutter/material.dart';

class CustomAppBar extends StatelessWidget implements PreferredSizeWidget {
  final String? title;
  final double height;
  final Widget? child;
  final VoidCallback? onPressed;

  const CustomAppBar({
    super.key,
    this.title,
    this.height = 90,
    this.child,
    this.onPressed,
  });

  @override
  Widget build(BuildContext context) {
    return PreferredSize(
      preferredSize: Size.fromHeight(height),
      child: AppBar(
        automaticallyImplyLeading: false,
        flexibleSpace: child ??
            SizedBox(
              height: double.infinity,
              child: Stack(
                alignment: Alignment.bottomCenter,
                children: [
                  Align(
                    alignment: Alignment.centerLeft,
                    child: BackButton(
                      color: Colors.white,
                      onPressed: onPressed,
                    ),
                  ),
                  title == null
                      ? Container()
                      : Padding(
                          padding: const EdgeInsets.only(bottom: 10),
                          child: Text(
                            title!,
                            style: const TextStyle(
                              fontSize: 22,
                              color: ThemeConfig.kTextThirdColor,
                            ),
                          ),
                        ),
                ],
              ),
            ),
        toolbarHeight: height,
      ),
    );
  }

  @override
  Size get preferredSize => Size.fromHeight(height);
}
