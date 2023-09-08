package delivery.controller;

import delivery.Erro;
import delivery.domain.user.ProdutoResponseDTO;
import delivery.model.dao.ProdutoDao;
import delivery.repository.ProdutoRepository;
import jakarta.validation.Valid;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
public class ProdutoController {

    ProdutoRepository produtoRepository = new ProdutoRepository();

    @GetMapping("/v1/products")
    public ResponseEntity<?> LoadAll() {
        try {
            var products = produtoRepository.loadAll();
            return ResponseEntity.ok(products);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/v1/product/{uid}")
    public ResponseEntity<?> LoadById(@PathVariable("uid") String code) {
        try {
            var product = produtoRepository.loadByCode(code);
            if (product == null) {
                return ResponseEntity.noContent().build();
            }
            return ResponseEntity.ok(product);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @GetMapping("/v1/product")
    public ResponseEntity<?> LoadByParam(@RequestParam(value = "name", required = false) String name,
                                         @RequestParam(value = "mode", required = false) String mode) {
        try {
            ProdutoDao product = null;

            if (mode != null && mode.equals("lastProduct")) {
                var lastProductId = produtoRepository.lastProductSaved();
                product = produtoRepository.loadById(lastProductId);
            }

            if (name != null) {
                product = produtoRepository.loadByName(name);
            }

            if (product == null) {
                return ResponseEntity.noContent().build();
            }
            return ResponseEntity.ok(product);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @PostMapping("/v1/product")
    public ResponseEntity<?> createProduct(@RequestBody @Valid ProdutoResponseDTO data) {
        try {
            var productExists = produtoRepository.loadByBarCode(data.cod_barras());
            if (productExists != null) {
                return ResponseEntity.status(HttpStatus.CONFLICT).build();
            }

            var productTemp = new ProdutoDao();
            productTemp.setCodBarras(data.cod_barras());
            productTemp.setNome(data.nome());
            productTemp.setObservacao(data.observacao());
            productTemp.setLocalizacao(data.localizacao());
            productTemp.setCategoria(data.categoria());
            productTemp.setStatusProduto(data.status_produto());
            productTemp.setVrUnitario(data.vr_unitario());
            productTemp.setVrCompra(data.vr_compra());
            productTemp.setUnMedida(data.un_medida());
            productTemp.setMargemLucro(data.margem_lucro());

            var productId = produtoRepository.create(productTemp);
            if (productId == -1) {
                return ResponseEntity.badRequest().build();
            }
            var product = produtoRepository.loadByBarCode(productTemp.getCodBarras());
            return ResponseEntity.ok(product);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }

    @PutMapping("/v1/product/{uid}")
    public ResponseEntity<?> update(@RequestBody @Valid ProdutoResponseDTO data,
                                    @PathVariable("uid") String code) {
        try {
            var productExists = produtoRepository.loadByCode(code);
            if (productExists == null) {
                return ResponseEntity.badRequest().body(new Erro("product not found"));
            }

            var productTemp = new ProdutoDao();
            productTemp.setCodProduto(code);
            productTemp.setCodBarras(data.cod_barras());
            productTemp.setNome(data.nome());
            productTemp.setObservacao(data.observacao());
            productTemp.setLocalizacao(data.localizacao());
            productTemp.setCategoria(data.categoria());
            productTemp.setStatusProduto(data.status_produto());
            productTemp.setVrUnitario(data.vr_unitario());
            productTemp.setVrCompra(data.vr_compra());
            productTemp.setUnMedida(data.un_medida());
            productTemp.setMargemLucro(data.margem_lucro());

            var productId = produtoRepository.update(productTemp);
            if (productId == -1) {
                return ResponseEntity.badRequest().build();
            }
            var product = produtoRepository.loadByBarCode(productTemp.getCodBarras());
            return ResponseEntity.ok(product);
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }
    }
}
