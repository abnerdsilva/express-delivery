package delivery.repository;

import db.DatabaseConnection;
import delivery.model.dao.ProdutoDao;
import delivery.repository.interfaces.IProdutoRepository;
import log.LoggerInFile;

public class ProdutoRepository implements IProdutoRepository {
    /**
     * consulta dados do produto de acordo com codigo do produto solicitado
     *
     * @param id - codigo do produto que será consultado
     * @return - retorna informações do produto consultado
     */
    @Override
    public ProdutoDao loadById(String id) {
        String sql = "SELECT * FROM TB_PRODUTO WHERE COD_PRODUTO=?";
        if (id.equals("") || id.equals("0")) {
            sql = "SELECT * FROM TB_PRODUTO WHERE COD_BARRAS=?";
        }

        ProdutoDao produto = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, id);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                produto = new ProdutoDao();
                produto.setCodProduto(bd.rs.getInt(1));
                produto.setCodBarras(bd.rs.getString(2));
                produto.setNome(bd.rs.getString(3));
                produto.setCategoria(bd.rs.getString(4));
                produto.setUnMedida(bd.rs.getString(5));
                produto.setVrCompra(bd.rs.getDouble(6));
                produto.setVrUnitario(bd.rs.getDouble(7));
                produto.setMargemLucro(bd.rs.getDouble(8));
                produto.setLocalizacao(bd.rs.getString(9));
                produto.setStatusProduto(bd.rs.getInt(10));
                produto.setDataCadastro(bd.rs.getString(11));
                produto.setDataAtualizacao(bd.rs.getString(12));
                produto.setObservacao(bd.rs.getString(13));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return produto;
    }
}
