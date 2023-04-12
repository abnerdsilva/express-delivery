class OrderModel {
  final int id;
  final int clientId;
  final String clientName;
  final DateTime? createdAt;
  final double totalValue;

  OrderModel({
    required this.clientId,
    required this.clientName,
    this.createdAt,
    this.totalValue = 0.0,
    required this.id,
  });
}
