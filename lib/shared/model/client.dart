import 'dart:convert';

class Client {
  final int id;
  final String name;
  final String address;
  final String addressNumber;
  final String neighborhood;
  final String city;
  final String postalCode;
  final String? complement;

  Client({
    required this.id,
    required this.name,
    required this.address,
    required this.addressNumber,
    required this.neighborhood,
    required this.city,
    required this.postalCode,
    this.complement,
  });

  Map<String, dynamic> toMap() {
    return {
      'codCliente': id,
      'nome': name,
      'logradouro': address,
      'numero': addressNumber,
      'bairro': neighborhood,
      'cidade': city,
      'cep': postalCode,
      'observacao': complement,
    };
  }

  factory Client.fromMap(Map<String, dynamic> map) {
    return Client(
      id: map['codCliente']?.toInt() ?? 0,
      name: map['nome'] ?? '',
      address: map['logradouro'] ?? '',
      addressNumber: map['numero'].toString() ?? '',
      neighborhood: map['bairro'] ?? '',
      city: map['cidade'] ?? '',
      postalCode: map['cep'].toString() ?? '',
      complement: map['observacao'] ?? '',
    );
  }

  String toJson() => json.encode(toMap());

  factory Client.fromJson(String source) => Client.fromMap(json.decode(source));
}
