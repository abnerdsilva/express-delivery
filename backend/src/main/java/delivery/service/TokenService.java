package delivery.service;

import com.auth0.jwt.JWT;
import com.auth0.jwt.algorithms.Algorithm;
import delivery.model.dao.UsuarioDao;
import org.springframework.stereotype.Service;

import java.time.Instant;
import java.time.LocalDateTime;
import java.time.ZoneOffset;

@Service
public class TokenService {

    private static final String SECRET_KEY = "secreta";

    public String generateToken(UsuarioDao usuario) {
        return JWT.create()
                .withIssuer("auth-api")
                .withSubject(usuario.getUsuario())
                .withClaim("id", usuario.getId())
                .withExpiresAt(getExpirationDate())
                .sign(Algorithm.HMAC256(SECRET_KEY));
    }

    private Instant getExpirationDate() {
        return LocalDateTime
                .now()
                .plusHours(2)
                .toInstant(ZoneOffset.of("-03:00"));
    }

    public String validateToken(String token) {
        Algorithm algorithm = Algorithm.HMAC256(SECRET_KEY);
        return JWT.require(algorithm)
                .withIssuer("auth-api")
                .build()
                .verify(token)
                .getSubject();
    }
}
