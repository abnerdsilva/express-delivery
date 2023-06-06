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
      'nome': name,
      'observacao': description,
      'vrUnit': unitValue,
      'quantidade': quantity,
      'vrTotal': totalValue,
      'vrDesconto': benefit,
      'vrAdicional': tax,
    };
  }

  factory ProductOrder.fromMap(Map<String, dynamic> map) {
    return ProductOrder(
      id: map['id']?.toInt() ?? 0,
      name: map['nome'] ?? '',
      description: map['observacao'] ?? '',
      unitValue: map['vrUnit'] ?? 0.0,
      quantity: map['quantidade'] ?? 0,
      totalValue: map['vrTotal'] ?? 0.0,
      benefit: map['vrDesconto'] ?? 0.0,
      tax: map['vrAdicional'] ?? 0.0,
    );
  }

  String toJson() => json.encode(toMap());

  factory ProductOrder.fromJson(String source) => ProductOrder.fromMap(json.decode(source));
}
