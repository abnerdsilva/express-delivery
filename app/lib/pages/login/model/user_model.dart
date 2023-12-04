import 'dart:convert';

class UserModel {
  final String id;
  final String username;
  final String type;
  final String status;

  UserModel({
    required this.id,
    required this.username,
    required this.type,
    required this.status,
  });

  Map<String, dynamic> toMap() {
    return {
      'id': id,
      'username': username,
      'type': type,
      'status': status,
    };
  }

  factory UserModel.fromMap(Map<String, dynamic> map) {
    return UserModel(
      id: map['id'] as String,
      username: map['username'] as String,
      type: map['type'] as String,
      status: map['status'] as String,
    );
  }

  String toJson() => json.encode(toMap());

  factory UserModel.fromJson(String source) => UserModel.fromMap(json.decode(source));
}
