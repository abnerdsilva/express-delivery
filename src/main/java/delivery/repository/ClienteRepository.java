package delivery.repository;

import db.DatabaseConnection;
import delivery.model.dao.ClienteDao;
import delivery.repository.interfaces.IClienteRepository;
import log.LoggerInFile;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class ClienteRepository implements IClienteRepository {
    /**
     * consulta todos os cliente cadastrados na tabela cliente
     *
     * @return - retorna lista com todos os clientes cadastrados
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
    @Override
    public List<ClienteDao> loadAll() throws SQLException {
        String sql = "SELECT * FROM TB_CLIENTE";

        List<ClienteDao> clientes = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery(sql);
            while (bd.rs.next()) {
                ClienteDao cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getInt("cod_cliente"));
                cliente.setNome(bd.rs.getString("nome"));
                cliente.setTelefone(bd.rs.getString("telefone"));
                cliente.setEmail(bd.rs.getString("email"));
                cliente.setCpf(bd.rs.getString("cpf"));
                cliente.setRg(bd.rs.getString("rg"));
                cliente.setLogradouro(bd.rs.getString("logradouro"));
                cliente.setNumero(bd.rs.getInt("numero"));
                cliente.setBairro(bd.rs.getString("bairro"));
                cliente.setCidade(bd.rs.getString("cidade"));
                cliente.setEstado(bd.rs.getString("estado"));
                cliente.setCep(bd.rs.getInt("cep"));
                cliente.setStatusCliente(bd.rs.getInt("status_cliente"));
                cliente.setDataCadastro(bd.rs.getString("data_cadastro"));
                cliente.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                cliente.setObservacao(bd.rs.getString("observacao"));

                clientes.add(cliente);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return clientes;
    }

    /**
     * busca cliente através do id informado
     *
     * @param idClient - id do cliente que será consultado
     * @return - retorna dados do cliente com modelo ClienteDao
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
    @Override
    public ClienteDao loadById(int idClient) throws SQLException {
        String sql = "SELECT * FROM TB_CLIENTE WHERE COD_CLIENTE=?";

        ClienteDao cliente = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setInt(1, idClient);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                cliente = new ClienteDao();
                cliente.setCodCliente(bd.rs.getInt(1));
                cliente.setNome(bd.rs.getString(2));
                cliente.setTelefone(bd.rs.getString(3));
                cliente.setEmail(bd.rs.getString(4));
                cliente.setCpf(bd.rs.getString(5));
                cliente.setRg(bd.rs.getString(6));
                cliente.setLogradouro(bd.rs.getString(7));
                cliente.setNumero(bd.rs.getInt(8));
                cliente.setBairro(bd.rs.getString(9));
                cliente.setCidade(bd.rs.getString(10));
                cliente.setEstado(bd.rs.getString(11));
                cliente.setCep(bd.rs.getInt(12));
                cliente.setStatusCliente(bd.rs.getInt(13));
                cliente.setDataCadastro(bd.rs.getString(14));
                cliente.setDataAtualizacao(bd.rs.getString(15));
                cliente.setObservacao(bd.rs.getString(16));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return cliente;
    }

    /**
     * busca id do ultimo cliente cadastrado na tabela cliente
     *
     * @return - retorna id do ultimo cliente
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
    @Override
    public int loadMaxClientId() throws SQLException {
        String sql = "SELECT MAX(COD_CLIENTE) AS clientID FROM TB_CLIENTE";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next())
                return bd.rs.getInt(1);
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }

    /**
     * salva cliente no banco de dados
     *
     * @param client - informações do cliente
     * @return - retorna id do cliente cadastrado ou -1 quando ocorre erro
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
    @Override
    public int save(ClienteDao client) throws SQLException {
        String sql = "INSERT INTO TB_CLIENTE (NOME, TELEFONE, EMAIL, CPF, RG, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP, DATA_CADASTRO, OBSERVACAO) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?)";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, client.getNome());
            bd.st.setString(2, client.getTelefone());
            bd.st.setString(3, client.getEmail());
            bd.st.setString(4, client.getCpf());
            bd.st.setString(5, client.getRg());
            bd.st.setString(6, client.getLogradouro());
            bd.st.setInt(7, client.getNumero());
            bd.st.setString(8, client.getBairro());
            bd.st.setString(9, client.getCidade());
            bd.st.setString(10, client.getEstado());
            bd.st.setInt(11, client.getCep());
            bd.st.setString(12, client.getDataCadastro());
            bd.st.setString(13, client.getObservacao());
            int resultInsert = bd.st.executeUpdate();
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
            bd.close();
        }

        return -1;
    }
}
