import 'dart:developer';

import 'package:express_delivery/config/rest_client.dart';
import 'package:express_delivery/generated/l10n.dart';
import 'package:express_delivery/shared/model/order_details_model.dart';
import 'package:express_delivery/shared/model/product_order.dart';
import 'package:express_delivery/shared/repositories/order_repository.dart';
import 'package:get/get.dart';

class OrderDetailsController extends GetxController {
  late OrderRepository _orderRepository;

  RxList<ProductOrder> itensOrder = <ProductOrder>[].obs;
  Rx<OrderDetailsModel> order = OrderDetailsModel(
    codPedido: 0,
    observacao: '',
    dataPedido: '',
    statusPedido: '',
    codCliente: 0,
    tipoPedido: '',
    origem: '',
    formaPagamento: '',
    vrTotal: 0.0,
    agendado: false,
    vrAdicional: 0.0,
    vrDesconto: 0.0,
    vrTroco: 0.0,
  ).obs;

  @override
  void onInit() {
    _orderRepository = OrderRepository(Get.find());

    super.onInit();

    final OrderDetailsModel orderTemp = Get.arguments;

    findOrderById(orderTemp.codPedido);
  }

  Future<void> findOrderById(int codPedido) async {
    try {
      final orderCompleteTemp =
          await _orderRepository.getOrderCompleteById(codPedido);
      order.value = orderCompleteTemp;
    } catch (e) {
      log(e.toString());
    }
  }

  Future<void> updateOrderStatus(int codPedido) async {
    try {
      final status = await _orderRepository.updateOrderStatus(codPedido);
      if (status) {
        await findOrderById(codPedido);

        Get.snackbar(S().success, S().successOrderUpdated);
      }
    } on RestClientException catch (e) {
      Get.snackbar(S().ops, e.message);
      log(e.message);
    } on Exception catch (e) {
      Get.snackbar(
        S().ops,
        S().notPossibleUpdateStatusOrderVerifyWithAdministrator,
      );
      log(e.toString());
    }
  }

  Future<void> cancelOrder(int codPedido) async {
    try {
      final status = await _orderRepository.cancelOrder(codPedido);
      if (status) {
        await findOrderById(codPedido);

        Get.snackbar(S().success, S().successOrderCancelled);
      }
    } on RestClientException catch (e) {
      Get.snackbar(S().ops, e.message);
      log(e.message);
    } on Exception catch (e) {
      Get.snackbar(
        S().ops,
        S().notPossibleCancelOrderVerifyWithAdministrator,
      );
      log(e.toString());
    }
  }

  Future<void> reprintOrder(String code) async {
    try {
      final status = await _orderRepository.reprintOrder(code);
      if (status) {
        Get.snackbar(S().success, S().successOrderUpdated);
      } else {
        Get.snackbar(S().error, 'Falha ao reimprimir pedido');
      }
    } catch (e) {
      log(e.toString());
    }
  }
}
