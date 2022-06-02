package delivery.repository;

import db.DatabaseConnection;
import log.LoggerInFile;
import delivery.model.dao.ClienteDao;
import delivery.repository.interfaces.IClienteRepository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ClienteRepository implements IClienteRepository {
    private ResultSet resultSet;
    private Connection connection;

    @Override
    public List<ClienteDao> loadAll() throws SQLException {
        String sql = "SELECT * FROM TB_CLIENTE";

        List<ClienteDao> clientes = new ArrayList<>();

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            PreparedStatement stmt = connection.prepareStatement(sql);
            resultSet = stmt.executeQuery(sql);
            while (resultSet.next()) {
                ClienteDao cliente = new ClienteDao();
                cliente.setCodCliente(resultSet.getInt("cod_cliente"));
                cliente.setNome(resultSet.getString("nome"));
                cliente.setTelefone(resultSet.getString("telefone"));
                cliente.setEmail(resultSet.getString("email"));
                cliente.setCpf(resultSet.getString("cpf"));
                cliente.setRg(resultSet.getString("rg"));
                cliente.setLogradouro(resultSet.getString("logradouro"));
                cliente.setNumero(resultSet.getInt("numero"));
                cliente.setBairro(resultSet.getString("bairro"));
                cliente.setCidade(resultSet.getString("cidade"));
                cliente.setEstado(resultSet.getString("estado"));
                cliente.setCep(resultSet.getInt("cep"));
                cliente.setStatusCliente(resultSet.getInt("status_cliente"));
                cliente.setDataCadastro(resultSet.getString("data_cadastro"));
                cliente.setDataAtualizacao(resultSet.getString("data_atualizacao"));
                cliente.setObservacao(resultSet.getString("observacao"));

                clientes.add(cliente);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            DatabaseConnection.disconnect();
        }

        return clientes;
    }

    @Override
    public ClienteDao loadById(int idClient) throws SQLException {
        String sql = "SELECT * FROM TB_CLIENTE WHERE COD_CLIENTE=?";

        ClienteDao cliente = null;

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            PreparedStatement stmt = connection.prepareStatement(sql);
            stmt.setInt(1, idClient);
            resultSet = stmt.executeQuery();
            while (resultSet.next()) {
                cliente = new ClienteDao();
                cliente.setCodCliente(resultSet.getInt(1));
                cliente.setNome(resultSet.getString(2));
                cliente.setTelefone(resultSet.getString(3));
                cliente.setEmail(resultSet.getString(4));
                cliente.setCpf(resultSet.getString(5));
                cliente.setRg(resultSet.getString(6));
                cliente.setLogradouro(resultSet.getString(7));
                cliente.setNumero(resultSet.getInt(8));
                cliente.setBairro(resultSet.getString(9));
                cliente.setCidade(resultSet.getString(10));
                cliente.setEstado(resultSet.getString(11));
                cliente.setCep(resultSet.getInt(12));
                cliente.setStatusCliente(resultSet.getInt(13));
                cliente.setDataCadastro(resultSet.getString(14));
                cliente.setDataAtualizacao(resultSet.getString(15));
                cliente.setObservacao(resultSet.getString(16));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            DatabaseConnection.disconnect();
        }

        return cliente;
    }

    @Override
    public int loadMaxClientId() throws SQLException {
        String sql = "SELECT MAX(COD_CLIENTE) AS clientID FROM TB_CLIENTE";

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            PreparedStatement stmt = connection.prepareStatement(sql);
            resultSet = stmt.executeQuery();
            if (resultSet.next())
                return resultSet.getInt(1);
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            DatabaseConnection.disconnect();
        }

        return -1;
    }

    @Override
    public int save(ClienteDao client) throws SQLException {
        String sql = "INSERT INTO TB_CLIENTE (NOME, TELEFONE, EMAIL, CPF, RG, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP, DATA_CADASTRO, OBSERVACAO) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)";

        try {
            DatabaseConnection.connect();
            connection = DatabaseConnection.connection;

            PreparedStatement stmt = connection.prepareStatement(sql);
            stmt.setString(1, client.getNome());
            stmt.setString(2, client.getTelefone());
            stmt.setString(3, client.getEmail());
            stmt.setString(4, client.getCpf());
            stmt.setString(5, client.getRg());
            stmt.setString(6, client.getLogradouro());
            stmt.setInt(7, client.getNumero());
            stmt.setString(8, client.getBairro());
            stmt.setString(9, client.getCidade());
            stmt.setString(10, client.getEstado());
            stmt.setInt(11, client.getCep());
            stmt.setString(12, client.getDataCadastro());
            stmt.setString(13, client.getObservacao());
            int resultInsert = stmt.executeUpdate();
            if (resultInsert > 0) {
                int maxClientId = loadMaxClientId();
                if (maxClientId > 0) {
                    return maxClientId;
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            DatabaseConnection.disconnect();
        }

        return -1;
    }
}
