import 'package:express_delivery/config/theme_config.dart';
import 'package:express_delivery/pages/order_details/order_details_page.dart';
import 'package:express_delivery/shared/model/order_details_model.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class OrdersWidget extends StatelessWidget {
  final List<OrderDetailsModel> orders;

  const OrdersWidget({Key? key, required this.orders}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ListView.builder(
      itemCount: orders.length,
      shrinkWrap: true,
      itemBuilder: (context, index) {
        final item = orders[index];

        String btnTitle = '';
        late Color btnTitleColor;
        switch (item.statusPedido.toUpperCase()) {
          case 'ABERTO':
            btnTitle = 'PREPARANDO PEDIDO';
            btnTitleColor = const Color(0xff3D7BC3);
            break;
          case 'FECHADO':
            btnTitle = 'PEDIDO FINALIZADO';
            btnTitleColor = const Color(0xff72AE42);
            break;
          case 'CANCELADO':
            btnTitle = 'PEDIDO CANCELADO';
            btnTitleColor = const Color(0xffA65454);
            break;
          default:
            btnTitle = 'AGUARDANDO CONFIRMAÇÃO';
            btnTitleColor = const Color(0xffC39D3D);
            break;
        }

        return InkWell(
          onTap: () => Get.toNamed(OrderDetailsPage.route, arguments: item),
          child: Card(
            color: ThemeConfig.kThirdSecondaryColor,
            margin: const EdgeInsets.symmetric(vertical: 4),
            child: Padding(
              padding: const EdgeInsets.all(8.0),
              child: Column(
                children: [
                  Stack(
                    children: [
                      Align(
                        alignment: AlignmentDirectional.topStart,
                        child: Container(
                          padding: const EdgeInsets.all(1.5),
                          decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(20.0),
                            color: Colors.white,
                          ),
                          child: const Icon(
                            Icons.add,
                            color: ThemeConfig.kTextFourtyColor,
                          ),
                        ),
                      ),
                      Align(
                        alignment: Alignment.center,
                        child: Text(
                          'PEDIDO Nº ${item.codPedido}',
                          style: const TextStyle(
                            fontSize: 20,
                            color: ThemeConfig.kTextFourtyColor,
                          ),
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 12),
                  Text(
                    item.client!.name,
                    style: const TextStyle(
                      color: ThemeConfig.kTextPrimaryColor,
                      // fontWeight: FontWeight.bold,
                      fontSize: 16,
                    ),
                  ),
                  Text(
                    '${item.client!.address}, ${item.client!.addressNumber} - ${item.client!.neighborhood}',
                    style: const TextStyle(
                      color: ThemeConfig.kTextPrimaryColor,
                      fontSize: 16,
                      // fontWeight: FontWeight.bold,
                    ),
                  ),
                  const SizedBox(height: 12),
                  TextButton(
                    onPressed: () => Get.toNamed(OrderDetailsPage.route, arguments: item),
                    child: Container(
                      width: MediaQuery.of(context).size.width * .6,
                      alignment: Alignment.center,
                      padding: const EdgeInsets.symmetric(vertical: 4),
                      decoration: BoxDecoration(
                        color: btnTitleColor,
                        borderRadius: BorderRadius.circular(20),
                      ),
                      child: Text(
                        btnTitle,
                        style: const TextStyle(
                          fontSize: 14,
                          color: ThemeConfig.kTextThirdColor,
                        ),
                      ),
                    ),
                  )
                ],
              ),
            ),
          ),
        );
      },
    );
  }
}
