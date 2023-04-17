import 'package:express_delivery/shared/model/client.dart';
import 'package:express_delivery/shared/model/product_order.dart';

class OrderDetails {
  final int id;
  final String? observacao;
  final String? formaPagamento;
  final String? dataPedido;
  final String status;
  final Client client;
  final List<ProductOrder> itens;

  OrderDetails({
    required this.id,
    this.observacao,
    this.formaPagamento,
    this.dataPedido,
    required this.status,
    required this.client,
    required this.itens,
  });
}
