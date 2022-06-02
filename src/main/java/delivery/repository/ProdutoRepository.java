package delivery.repository;

import db.DatabaseConnection;
import log.LoggerInFile;
import delivery.model.dao.ProdutoDao;
import delivery.repository.interfaces.IProdutoRepository;

import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class ProdutoRepository implements IProdutoRepository {
    private ResultSet resultSet;
    private Connection connection;

    @Override
    public ProdutoDao loadById(int id) throws IOException, SQLException {
        String sql = "SELECT * FROM TB_PRODUTO WHERE COD_PRODUTO=?";

        ProdutoDao produto = null;

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            PreparedStatement stmt = connection.prepareStatement(sql);
            stmt.setInt(1, id);
            resultSet = stmt.executeQuery();
            if (resultSet.next()) {
                produto = new ProdutoDao();
                produto.setCodProduto(resultSet.getInt(1));
                produto.setCodBarras(resultSet.getString(2));
                produto.setNome(resultSet.getString(3));
                produto.setCategoria(resultSet.getString(4));
                produto.setUnMedida(resultSet.getString(5));
                produto.setVrCompra(resultSet.getDouble(6));
                produto.setVrUnitario(resultSet.getDouble(7));
                produto.setMargemLucro(resultSet.getDouble(8));
                produto.setLocalizacao(resultSet.getString(9));
                produto.setStatusProduto(resultSet.getInt(10));
                produto.setDataCadastro(resultSet.getString(11));
                produto.setDataAtualizacao(resultSet.getString(12));
                produto.setObservacao(resultSet.getString(13));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            DatabaseConnection.disconnect();
        }

        return produto;
    }
}
