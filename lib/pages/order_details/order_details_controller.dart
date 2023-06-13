import 'dart:developer';

import 'package:express_delivery/config/rest_client.dart';
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

        Get.snackbar('Sucesso', 'Pedido atualizado com sucesso');
      }
    } on RestClientException catch (e) {
      Get.snackbar('Ops', e.message);
      log(e.message);
    } on Exception catch (e) {
      Get.snackbar('Ops',
          "Não foi possivel atualizar o status do pedido, entre em contato com o administrador");
      log(e.toString());
    }
  }

  Future<void> cancelOrder(int codPedido) async {
    try {
      final status = await _orderRepository.cancelOrder(codPedido);
      if (status) {
        await findOrderById(codPedido);

        Get.snackbar('Sucesso', 'Pedido cancelado com sucesso');
      }
    } on RestClientException catch (e) {
      Get.snackbar('Ops', e.message);
      log(e.message);
    } on Exception catch (e) {
      Get.snackbar('Ops',
          "Não foi possivel cancelar o pedido, entre em contato com o administrador");
      log(e.toString());
    }
  }
}
