package delivery.controller;

import delivery.Erro;
import delivery.domain.user.ClientDTO;
import delivery.model.dao.ClienteDao;
import delivery.repository.ClienteRepository;
import jakarta.validation.Valid;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;

@RestController
public class ClienteController {
    private final ClienteRepository clienteRepository = new ClienteRepository();

    @GetMapping("/v1/clients")
    public ResponseEntity<?> LoadClients(@RequestParam(value = "name", required = false) String name,
                                         @RequestParam(value = "phone", required = false) String phone) {
        try {
            if (phone != null && !phone.equals("")) {
                var clients = new ArrayList<ClienteDao>();
                var clientsTemp = clienteRepository.loadClientsByPhone(phone);
                if (clientsTemp != null && clientsTemp.size() > 0) {
                    clients.addAll(clientsTemp);
                }
                return ResponseEntity.ok(clients);
            }

            if (name != null && !name.equals("")) {
                var clients = new ArrayList<ClienteDao>();
                var clientsTemp = clienteRepository.loadClientsByName(name);
                if (clientsTemp != null && clientsTemp.size() > 0) {
                    clients.addAll(clientsTemp);
                }
                return ResponseEntity.ok(clients);
            }

            var clients = clienteRepository.loadAll();
            return ResponseEntity.ok(clients);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/v1/client/{uid}")
    public ResponseEntity<?> LoadById(@PathVariable("uid") String code) {
        try {
            var client = clienteRepository.loadByCode(code);
            if (client == null) {
                return ResponseEntity.noContent().build();
            }
            return ResponseEntity.ok(client);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @PostMapping("/v1/client")
    public ResponseEntity<?> createClient(@RequestBody @Valid ClientDTO data) {
        try {
            var clientExists = clienteRepository.hasClient("", data.telefone());
            if (!clientExists.equals("-1")) {
                return ResponseEntity.status(HttpStatus.CONFLICT).body(new Erro("client phone already exists"));
            }

            var clientTemp = new ClienteDao();
            clientTemp.setNome(data.nome());
            clientTemp.setObservacao(data.observacao());
            clientTemp.setTelefone(data.telefone());
            clientTemp.setBairro(data.bairro());
            clientTemp.setCep(data.cep());
            clientTemp.setCidade(data.cidade());
            clientTemp.setStatusCliente(data.status());
            clientTemp.setEmail(data.email());
            clientTemp.setEstado(data.estado());
            clientTemp.setLogradouro(data.logradouro());
            clientTemp.setNumero(data.numero());
            clientTemp.setCpf(data.cpf());
            clientTemp.setRg(data.rg());

            var clientId = clienteRepository.create(clientTemp);
            if (clientId == -1) {
                return ResponseEntity.badRequest().build();
            }

            var client = clienteRepository.loadById(clientId);
            return ResponseEntity.ok(client);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @PutMapping("/v1/client/{uid}")
    public ResponseEntity<?> update(@RequestBody @Valid ClientDTO data,
                                    @PathVariable("uid") String code) {
        try {
            var productExists = clienteRepository.loadByCode(code);
            if (productExists == null) {
                return ResponseEntity.badRequest().body(new Erro("client not found"));
            }

            var clientTemp = new ClienteDao();
            clientTemp.setCodCliente(code);
            clientTemp.setNome(data.nome());
            clientTemp.setObservacao(data.observacao());
            clientTemp.setTelefone(data.telefone());
            clientTemp.setBairro(data.bairro());
            clientTemp.setCep(data.cep());
            clientTemp.setCidade(data.cidade());
            clientTemp.setStatusCliente(data.status());
            clientTemp.setEmail(data.email());
            clientTemp.setEstado(data.estado());
            clientTemp.setLogradouro(data.logradouro());
            clientTemp.setNumero(data.numero());
            clientTemp.setCpf(data.cpf());
            clientTemp.setRg(data.rg());

            var clientId = clienteRepository.update(clientTemp);
            if (clientId == -1) {
                return ResponseEntity.badRequest().build();
            }
            var product = clienteRepository.loadByCode(clientTemp.getCodCliente());
            return ResponseEntity.ok(product);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }
}
