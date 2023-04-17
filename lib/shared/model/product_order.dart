
class ProductOrder {
  final int id;
  final String name;
  final String? description;
  final double unitValue;
  final int quantity;
  final double totalValue;
  final double benefit;
  final double tax;

  ProductOrder({
    required this.id,
    required this.name,
    this.description,
    required this.unitValue,
    required this.quantity,
    required this.totalValue,
    required this.benefit,
    required this.tax,
  });
}
