import 'dart:convert';

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

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'name': name,
      'description': description,
      'unitValue': unitValue,
      'quantity': quantity,
      'totalValue': totalValue,
      'benefit': benefit,
      'tax': tax,
    };
  }

  factory ProductOrder.fromMap(Map<String, dynamic> map) {
    return ProductOrder(
      id: map['id']?.toInt() ?? 0,
      name: map['name'] ?? '',
      description: map['description'] ?? '',
      unitValue: map['unitValue'] ?? 0.0,
      quantity: map['quantity'] ?? 0,
      totalValue: map['totalValue'] ?? 0.0,
      benefit: map['benefit'] ?? 0.0,
      tax: map['tax'] ?? 0.0,
    );
  }

  String toJson() => json.encode(toMap());

  factory ProductOrder.fromJson(String source) => ProductOrder.fromMap(json.decode(source));
}
