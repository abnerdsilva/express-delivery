package delivery.controller;

import delivery.Erro;
import delivery.domain.user.AuthenticationDTO;
import delivery.domain.user.ErrorResponseDTO;
import delivery.domain.user.LoginResponseDTO;
import delivery.domain.user.RegisterDTO;
import delivery.model.UsuarioDelivery;
import delivery.model.dao.UsuarioDao;
import delivery.repository.UsuarioRepository;
import delivery.service.TokenService;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.bind.annotation.*;

import java.util.UUID;

@RestController
public class UsuarioController {

    @Autowired
    private AuthenticationManager authenticationManager;

    @Autowired
    private TokenService tokenService;

    private static UsuarioController instance;

    UsuarioRepository usuarioRepository;

    private UsuarioController() {
        usuarioRepository = new UsuarioRepository();
    }

    public static UsuarioController getInstance() {
        if (instance == null) {
            instance = new UsuarioController();
        }
        return instance;
    }

    @RequestMapping(value = "/auth/login", method = RequestMethod.POST)
    public ResponseEntity<?> login(@RequestParam(name = "username") String user, @RequestParam(name = "password") String pass) {
        UsuarioDelivery usuarioDelivery;
        try {
            UsuarioDao usuarioDao = usuarioRepository.login(user, pass);
            if (usuarioDao == null) {
                throw new Exception("usuário não encontrado");
            }
            usuarioDelivery = usuarioDao.usuarioDaoToDelivery();
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new Erro(e.getMessage()));
        }
        return ResponseEntity.status(HttpStatus.OK).body(usuarioDelivery);
    }

    @PostMapping("/auth/login2")
    public ResponseEntity login(@RequestBody @Valid AuthenticationDTO data) {
        try {
            var authenticationToken = new UsernamePasswordAuthenticationToken(data.username(), data.password());
            var auth = this.authenticationManager.authenticate(authenticationToken);
            var usuario = (UsuarioDao) auth.getPrincipal();
            var token = tokenService.generateToken(usuario);
            System.out.println(auth.getPrincipal());
            return ResponseEntity.ok(new LoginResponseDTO(token));
        } catch (UsernameNotFoundException e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.UNAUTHORIZED).body(new ErrorResponseDTO(e.getMessage()));
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.badRequest().body(new ErrorResponseDTO(e.getMessage()));
        }
    }

    @PostMapping("/auth/register")
    public ResponseEntity register(@RequestBody @Valid RegisterDTO data) {
        if (this.usuarioRepository.findByLogin(data.username()) != null) {
            return ResponseEntity.badRequest().build();
        }

        var encryptedPassword = new BCryptPasswordEncoder().encode(data.password());
        var uid = UUID.randomUUID();
        var newUser = new UsuarioDao(uid.toString(), data.username(), encryptedPassword, data.role(), 1);

        var userCreated = usuarioRepository.save(newUser);
        if (userCreated != 1) {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.ok().build();
    }
}
