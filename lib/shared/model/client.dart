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
}
