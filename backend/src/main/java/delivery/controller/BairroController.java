package delivery.controller;

import delivery.Erro;
import delivery.domain.user.BairroDTO;
import delivery.model.dao.BairroDao;
import delivery.repository.BairroRepository;
import jakarta.validation.Valid;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class BairroController {
    private static BairroController instance;

    private BairroRepository bairroRepository;

    public BairroController() {
        bairroRepository = new BairroRepository();
    }

    public static BairroController getInstance() {
        if (instance == null) {
            instance = new BairroController();
        }
        return instance;
    }

    @RequestMapping("/v1/districts")
    public ResponseEntity<?> getBairros() {
        try {
            var bairros = bairroRepository.loadAll();
            return ResponseEntity.status(HttpStatus.OK).body(bairros);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(new Erro(e.getMessage()));
        }
    }

    @PostMapping("/v1/district")
    public ResponseEntity<?> saveDistrict(@RequestBody @Valid BairroDTO data) {
        try {
            if (!data.Id().equals("0")){
                var bairroDao = bairroRepository.findByCode(data.Id());
                if (bairroDao != null) {
                    var bairro = new BairroDao();
                    bairro.setId(data.Id());
                    bairro.setNome(data.Nome());
                    bairro.setVrTaxa(data.VrTaxa());
                    bairro.setStatus(data.Status());

                    var res = bairroRepository.update(bairro);
                    if (res <= 0) {
                        throw new Exception("não foi possivel atualizar o bairro");
                    }
                    return ResponseEntity.status(HttpStatus.OK).build();
                }
            }

            var bairro = new BairroDao();
            bairro.setNome(data.Nome());
            bairro.setVrTaxa(data.VrTaxa());
            bairro.setStatus(data.Status());

            var res = bairroRepository.save(bairro);
            if (res.equals("-1") || res.equals("0")) {
                throw new Exception("não foi possivel cadastrar o bairro");
            }

            var result = bairroRepository.findByCode(res);
            return ResponseEntity.status(HttpStatus.OK).body(result);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).body(new Erro(e.getMessage()));
        }
    }
}
