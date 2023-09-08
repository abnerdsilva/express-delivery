package delivery.repository;

import db.DatabaseConnection;
import delivery.model.dao.ProdutoDao;
import delivery.repository.interfaces.IProdutoRepository;
import log.LoggerInFile;

import java.util.ArrayList;
import java.util.List;

public class ProdutoRepository implements IProdutoRepository {
    /**
     * consulta dados do produto de acordo com codigo do produto solicitado
     *
     * @param id - codigo do produto que será consultado
     * @return - retorna informações do produto consultado
     */
    @Override
    public ProdutoDao loadByCode(String id) {
        String sql = "SELECT * FROM TB_PRODUTO WHERE COD_PRODUTO=?";

        ProdutoDao produto = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, id);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                produto = new ProdutoDao();
                produto.setCodProduto(bd.rs.getString("cod_produto"));
                produto.setCodBarras(bd.rs.getString("cod_barras"));
                produto.setNome(bd.rs.getString("nome"));
                produto.setCategoria(bd.rs.getString("categoria"));
                produto.setUnMedida(bd.rs.getString("un_medida"));
                produto.setVrCompra(bd.rs.getDouble("vr_compra"));
                produto.setVrUnitario(bd.rs.getDouble("vr_unitario"));
                produto.setMargemLucro(bd.rs.getDouble("margem_lucro"));
                produto.setLocalizacao(bd.rs.getString("localizacao"));
                produto.setStatusProduto(bd.rs.getInt("status_produto"));
                produto.setDataCadastro(bd.rs.getString("data_cadastro"));
                produto.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                produto.setObservacao(bd.rs.getString("observacao"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return produto;
    }

    @Override
    public ProdutoDao loadByBarCode(String code) {
        String sql = "SELECT * FROM TB_PRODUTO WHERE COD_BARRAS=?";

        ProdutoDao produto = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, code);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                produto = new ProdutoDao();
                produto.setCodProduto(bd.rs.getString("cod_produto"));
                produto.setCodBarras(bd.rs.getString("cod_barras"));
                produto.setNome(bd.rs.getString("nome"));
                produto.setCategoria(bd.rs.getString("categoria"));
                produto.setUnMedida(bd.rs.getString("un_medida"));
                produto.setVrCompra(bd.rs.getDouble("vr_compra"));
                produto.setVrUnitario(bd.rs.getDouble("vr_unitario"));
                produto.setMargemLucro(bd.rs.getDouble("margem_lucro"));
                produto.setLocalizacao(bd.rs.getString("localizacao"));
                produto.setStatusProduto(bd.rs.getInt("status_produto"));
                produto.setDataCadastro(bd.rs.getString("data_cadastro"));
                produto.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                produto.setObservacao(bd.rs.getString("observacao"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return produto;
    }

    @Override
    public ProdutoDao loadById(int id) {
        String sql = "SELECT * FROM TB_PRODUTO WHERE ID=?";

        ProdutoDao produto = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setInt(1, id);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                produto = new ProdutoDao();
                produto.setCodProduto(bd.rs.getString("cod_produto"));
                produto.setCodBarras(bd.rs.getString("cod_barras"));
                produto.setNome(bd.rs.getString("nome"));
                produto.setCategoria(bd.rs.getString("categoria"));
                produto.setUnMedida(bd.rs.getString("un_medida"));
                produto.setVrCompra(bd.rs.getDouble("vr_compra"));
                produto.setVrUnitario(bd.rs.getDouble("vr_unitario"));
                produto.setMargemLucro(bd.rs.getDouble("margem_lucro"));
                produto.setLocalizacao(bd.rs.getString("localizacao"));
                produto.setStatusProduto(bd.rs.getInt("status_produto"));
                produto.setDataCadastro(bd.rs.getString("data_cadastro"));
                produto.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                produto.setObservacao(bd.rs.getString("observacao"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return produto;
    }

    @Override
    public ProdutoDao loadByName(String name) {
        String sql = "SELECT * FROM TB_PRODUTO WHERE NOME=?";

        ProdutoDao produto = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, name);
            bd.rs = bd.st.executeQuery();

            if (bd.rs.next()) {
                produto = new ProdutoDao();
                produto.setCodProduto(bd.rs.getString("cod_produto"));
                produto.setCodBarras(bd.rs.getString("cod_barras"));
                produto.setNome(bd.rs.getString("nome"));
                produto.setCategoria(bd.rs.getString("categoria"));
                produto.setUnMedida(bd.rs.getString("un_medida"));
                produto.setVrCompra(bd.rs.getDouble("vr_compra"));
                produto.setVrUnitario(bd.rs.getDouble("vr_unitario"));
                produto.setMargemLucro(bd.rs.getDouble("margem_lucro"));
                produto.setLocalizacao(bd.rs.getString("localizacao"));
                produto.setStatusProduto(bd.rs.getInt("status_produto"));
                produto.setDataCadastro(bd.rs.getString("data_cadastro"));
                produto.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                produto.setObservacao(bd.rs.getString("observacao"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return produto;
    }

    @Override
    public int lastProductSaved() {
        String sql = "SELECT MAX(ID) AS LAST_ID FROM TB_PRODUTO";

        int lastProduct = 0;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();

            if (bd.rs.next()) {
                lastProduct = bd.rs.getInt(1);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return lastProduct;
    }

    @Override
    public List<ProdutoDao> loadAll() {
        String sql = "SELECT * FROM TB_PRODUTO";

        List<ProdutoDao> products = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery(sql);

            while (bd.rs.next()) {
                ProdutoDao product = new ProdutoDao();
                product.setCodProduto(bd.rs.getString("cod_produto"));
                product.setNome(bd.rs.getString("nome"));
                product.setCodBarras(bd.rs.getString("cod_barras"));
                product.setCategoria(bd.rs.getString("categoria"));
                product.setUnMedida(bd.rs.getString("un_medida"));
                product.setLocalizacao(bd.rs.getString("localizacao"));
                product.setObservacao(bd.rs.getString("observacao"));
                product.setVrCompra(bd.rs.getDouble("vr_compra"));
                product.setVrUnitario(bd.rs.getDouble("vr_unitario"));
                product.setStatusProduto(bd.rs.getInt("status_produto"));
                product.setDataCadastro(bd.rs.getString("data_cadastro"));
                product.setDataAtualizacao(bd.rs.getString("data_atualizacao"));

                products.add(product);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return products;
    }

    @Override
    public int create(ProdutoDao item) {
        String sql = "INSERT INTO TB_PRODUTO (COD_PRODUTO, COD_BARRAS, NOME, UN_MEDIDA, CATEGORIA, LOCALIZACAO," +
                " MARGEM_LUCRO, OBSERVACAO, STATUS_PRODUTO, VR_COMPRA, VR_UNITARIO) VALUES (uuid(),?,?,?,?,?,?,?,?,?,?)";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, item.getCodBarras());
            bd.st.setString(2, item.getNome());
            bd.st.setString(3, item.getUnMedida());
            bd.st.setString(4, item.getCategoria());
            bd.st.setString(5, item.getLocalizacao());
            bd.st.setDouble(6, item.getMargemLucro());
            bd.st.setString(7, item.getObservacao());
            bd.st.setInt(8, item.getStatusProduto());
            bd.st.setDouble(9, item.getVrCompra());
            bd.st.setDouble(10, item.getVrUnitario());

            return bd.st.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }

    @Override
    public int update(ProdutoDao item) {
        String sql = "UPDATE TB_PRODUTO SET NOME=?, UN_MEDIDA=?, CATEGORIA=?," +
                " LOCALIZACAO=?, MARGEM_LUCRO=?, OBSERVACAO=?, STATUS_PRODUTO=?, VR_COMPRA=?, VR_UNITARIO=?," +
                " DATA_ATUALIZACAO=now() WHERE cod_produto = ?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, item.getNome());
            bd.st.setString(2, item.getUnMedida());
            bd.st.setString(3, item.getCategoria());
            bd.st.setString(4, item.getLocalizacao());
            bd.st.setDouble(5, item.getMargemLucro());
            bd.st.setString(6, item.getObservacao());
            bd.st.setInt(7, item.getStatusProduto());
            bd.st.setDouble(8, item.getVrCompra());
            bd.st.setDouble(9, item.getVrUnitario());
            bd.st.setString(10, item.getCodProduto());

            return bd.st.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }
}
