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
    final orderCompleteTemp = await _orderRepository.getOrderCompleteById(codPedido);
    order.value = orderCompleteTemp;
  }
}
