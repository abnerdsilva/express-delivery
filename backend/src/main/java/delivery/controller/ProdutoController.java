package delivery.controller;

import delivery.Erro;
import delivery.domain.user.ProdutoResponseDTO;
import delivery.model.dao.ProdutoDao;
import delivery.repository.ProdutoRepository;
import jakarta.validation.Valid;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;

@RestController
public class ProdutoController {

    ProdutoRepository produtoRepository = new ProdutoRepository();

    @GetMapping("/v1/products")
    public ResponseEntity<?> LoadProducts(@RequestParam(value = "name", required = false) String name,
                                          @RequestParam(value = "mode", required = false) String mode) {
        try {
            if (mode != null && mode.equals("lastProduct")) {
                var lastProductId = produtoRepository.lastProductSaved();
                var product = produtoRepository.loadById(lastProductId);
                if (product == null) {
                    return ResponseEntity.noContent().build();
                }
                return ResponseEntity.ok(product);
            }

            if (name != null) {
                var products = new ArrayList<ProdutoDao>();
                var productsTemp = produtoRepository.loadProductsByName(name);
                if (productsTemp != null && productsTemp.size() > 0) {
                    products.addAll(productsTemp);
                }
                return ResponseEntity.ok(products);
            }

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
    public ResponseEntity<?> LoadProducByParam(@RequestParam(value = "name", required = false) String name,
                                               @RequestParam(value = "mode", required = false) String mode) {
        try {
            if (mode != null && mode.equals("lastProduct")) {
                var lastProductId = produtoRepository.lastProductSaved();
                var product = produtoRepository.loadById(lastProductId);
                if (product == null) {
                    return ResponseEntity.noContent().build();
                }
                return ResponseEntity.ok(product);
            }

            if (name != null) {
                var product = produtoRepository.loadProductByName(name);
                return ResponseEntity.ok(product);
            }
        } catch (Exception e) {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.badRequest().build();
    }

    @PostMapping("/v1/product")
    public ResponseEntity<?> createProduct(@RequestBody @Valid ProdutoResponseDTO data) {
        try {
            var productExists = produtoRepository.loadByBarCode(data.codBarras());
            if (productExists != null) {
                return ResponseEntity.status(HttpStatus.CONFLICT).body(new Erro("product already exists"));
            }

            var productTemp = new ProdutoDao();
            productTemp.setCodBarras(data.codBarras());
            productTemp.setNome(data.nome());
            productTemp.setObservacao(data.observacao());
            productTemp.setLocalizacao(data.localizacao());
            productTemp.setCategoria(data.categoria());
            productTemp.setStatusProduto(data.statusProduto());
            productTemp.setVrUnitario(data.vrUnitario());
            productTemp.setVrCompra(data.vrCompra());
            productTemp.setUnMedida(data.unMedida());
            productTemp.setMargemLucro(data.margemLucro());

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
            productTemp.setCodBarras(data.codBarras());
            productTemp.setNome(data.nome());
            productTemp.setObservacao(data.observacao());
            productTemp.setLocalizacao(data.localizacao());
            productTemp.setCategoria(data.categoria());
            productTemp.setStatusProduto(data.statusProduto());
            productTemp.setVrUnitario(data.vrUnitario());
            productTemp.setVrCompra(data.vrCompra());
            productTemp.setUnMedida(data.unMedida());
            productTemp.setMargemLucro(data.margemLucro());

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
