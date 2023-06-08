import 'package:express_delivery/generated/l10n.dart';
import 'package:express_delivery/shared/model/order_details_model.dart';
import 'package:flutter/material.dart';

class ProductOrderDetailsWidget extends StatelessWidget {
  final OrderDetailsModel order;
  const ProductOrderDetailsWidget({
    Key? key,
    required this.order,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Row(
          children: [
            Expanded(
              flex: 6,
              child: Text(
                S().items,
                style: const TextStyle(
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            const SizedBox(width: 20),
            Expanded(
              flex: 2,
              child: Text(
                S().quantity,
                textAlign: TextAlign.end,
                style: const TextStyle(
                  fontWeight: FontWeight.bold,
                ),
              ),
            ),
            const SizedBox(width: 20),
            Expanded(
              flex: 3,
              child: Container(
                alignment: Alignment.centerRight,
                child: Text(
                  S().price,
                  style: const TextStyle(
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ),
          ],
        ),
        const SizedBox(height: 4),
        ListView.builder(
          shrinkWrap: true,
          physics: const NeverScrollableScrollPhysics(),
          itemCount: order.itens?.length ?? 0,
          itemBuilder: (context, index) {
            final product = order.itens?[index];
            if (product == null) return Container();

            return Padding(
              padding: const EdgeInsets.all(2.0),
              child: Row(
                children: [
                  Expanded(
                    flex: 6,
                    child: Text(product.name),
                  ),
                  const SizedBox(width: 20),
                  Expanded(
                    flex: 1,
                    child: Container(
                        alignment: Alignment.centerRight,
                        child: Text(
                          product.quantity.toString(),
                          textAlign: TextAlign.end,
                        )),
                  ),
                  const SizedBox(width: 20),
                  Expanded(
                    flex: 3,
                    child: Container(
                      alignment: Alignment.centerRight,
                      child: Text(
                        '${S().priceCode} ${(product.totalValue / double.parse(S().priceExchange)).toStringAsFixed(2)}',
                      ),
                    ),
                  ),
                ],
              ),
            );
          },
        ),
      ],
    );
  }
}
