package delivery.domain.user;

public record UserDTO(String username, String currentPassword, String password, String type, String status) {
}
