package delivery.controller;

import delivery.Erro;
import delivery.domain.user.*;
import delivery.model.UsuarioDelivery;
import delivery.model.dao.UsuarioDao;
import delivery.repository.UsuarioRepository;
import delivery.service.TokenService;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
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

    @GetMapping("/v1/users")
    public ResponseEntity<?> LoadUsers(@RequestParam(value = "name", required = false) String name) {
        try {
            var clients = new ArrayList<UsuarioDelivery>();

            if (name != null && !name.isEmpty()) {
                var usersTemp = usuarioRepository.loadClientsByName(name);
                if (usersTemp != null && !usersTemp.isEmpty()) {
                    for (var user: usersTemp) {
                        clients.add(user.usuarioDaoToDelivery());
                    }
                }
                return ResponseEntity.ok(clients);
            }

            var temp = usuarioRepository.loadAll();
            for (var user: temp) {
                clients.add(user.usuarioDaoToDelivery());
            }
            return ResponseEntity.ok(clients);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/v1/user/{uid}")
    public ResponseEntity<?> LoadById(@PathVariable("uid") String code) {
        try {
            var user = usuarioRepository.loadByCode(code);
            if (user == null) {
                return ResponseEntity.noContent().build();
            }
            return ResponseEntity.ok(user.usuarioDaoToDelivery());
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/v1/user")
    public ResponseEntity<?> LoadUser(@RequestParam(value = "name", required = false) String name) {
        try {
            if (name != null && !name.isEmpty()) {
                var client = usuarioRepository.loadByName(name);
                if (client == null) {
                    return ResponseEntity.noContent().build();
                }
                return ResponseEntity.ok(client.usuarioDaoToDelivery());
            }
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.badRequest().build();
    }

    @PutMapping("/v1/user/{uid}")
    public ResponseEntity<?> update(@RequestBody @Valid UserDTO data,
                                    @PathVariable("uid") String code) {
        try {
            var userExists = usuarioRepository.loadByCode(code);
            if (userExists == null) {
                return ResponseEntity.badRequest().body(new Erro("user not found"));
            }

            var passwordMatches = new BCryptPasswordEncoder().matches(data.currentPassword(), userExists.getSenha());
            if (!passwordMatches) {
                return ResponseEntity.badRequest().body(new Erro("usuário e/ou senha inválido"));
            }

            int status = 0;
            if(data.status().equals("ATIVO")){
                status=1;
            }

            var encryptedPassword = new BCryptPasswordEncoder().encode(data.password());

            var userTemp = new UsuarioDao();
            userTemp.setId(code);
            userTemp.setUsuario(data.username());
            userTemp.setStatusUsuario(status);
            userTemp.setTipoUsuario(data.type());
            userTemp.setSenha(encryptedPassword);

            var userId = usuarioRepository.update(userTemp);
            if (userId == -1) {
                return ResponseEntity.badRequest().build();
            }
            var product = usuarioRepository.loadByCode(userTemp.getId());
            return ResponseEntity.ok(product.usuarioDaoToDelivery());
        } catch (Exception e) {
            return ResponseEntity.badRequest().body(new Erro(e.getMessage()));
        }
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
    public ResponseEntity<?> login(@RequestBody @Valid AuthenticationDTO data) {
        try {
//            var authenticationToken = new UsernamePasswordAuthenticationToken(data.username(), data.password());
//            var auth = this.authenticationManager.authenticate(authenticationToken);
//            var usuario = (UsuarioDao) auth.getPrincipal();
//            var token = tokenService.generateToken(usuario);
//            System.out.println(auth.getPrincipal());
            UsuarioDao user = usuarioRepository.findByLogin(data.username());
            var token = tokenService.generateToken(user);

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
    public ResponseEntity<?> register(@RequestBody @Valid RegisterDTO data) {
        if (this.usuarioRepository.findByLogin(data.username()) != null) {
            return ResponseEntity.badRequest().build();
        }

        var encryptedPassword = new BCryptPasswordEncoder().encode(data.password());
        var uid = UUID.randomUUID();
        var newUser = new UsuarioDao(uid.toString(), data.username(), encryptedPassword, data.type(), 1);

        var userCreated = usuarioRepository.save(newUser);
        if (userCreated != 1) {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.ok().build();
    }
}
