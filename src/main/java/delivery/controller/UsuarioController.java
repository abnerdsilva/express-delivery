package delivery.controller;

import delivery.Erro;
import delivery.model.UsuarioDelivery;
import delivery.model.dao.UsuarioDao;
import delivery.repository.UsuarioRepository;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class UsuarioController {
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
            if (usuarioDao == null){
                throw new Exception("usuário não encontrado");
            }
            usuarioDelivery = usuarioDao.usuarioDaoToDelivery();
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new Erro(e.getMessage()));
        }
        return ResponseEntity.status(HttpStatus.OK).body(usuarioDelivery);
    }
}
