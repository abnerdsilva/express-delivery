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

        List<ClienteDao> clients = new ArrayList<>();

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery(sql);
            while (bd.rs.next()) {
                ClienteDao client = new ClienteDao();
                client.setCodCliente(bd.rs.getString("cod_cliente"));
                client.setNome(bd.rs.getString("nome"));
                client.setTelefone(bd.rs.getString("telefone"));
                client.setEmail(bd.rs.getString("email"));
                client.setCpf(bd.rs.getString("cpf"));
                client.setRg(bd.rs.getString("rg"));
                client.setLogradouro(bd.rs.getString("logradouro"));
                client.setNumero(bd.rs.getInt("numero"));
                client.setBairro(bd.rs.getString("bairro"));
                client.setCidade(bd.rs.getString("cidade"));
                client.setEstado(bd.rs.getString("estado"));
                client.setCep(bd.rs.getInt("cep"));
                client.setStatusCliente(bd.rs.getInt("status_cliente"));
                client.setDataCadastro(bd.rs.getString("data_cadastro"));
                client.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                client.setObservacao(bd.rs.getString("observacao"));

                clients.add(client);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return clients;
    }

    /**
     * busca cliente através do id informado
     *
     * @param code - id do cliente que será consultado
     * @return - retorna dados do cliente com modelo ClienteDao
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
    @Override
    public ClienteDao loadByCode(String code) throws SQLException {
        String sql = "SELECT * FROM TB_CLIENTE WHERE COD_CLIENTE=?";

        ClienteDao client = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, code);
            bd.rs = bd.st.executeQuery();

            if (bd.rs.next()) {
                client = new ClienteDao();
                client.setCodCliente(bd.rs.getString("cod_cliente"));
                client.setNome(bd.rs.getString("nome"));
                client.setTelefone(bd.rs.getString("telefone"));
                client.setEmail(bd.rs.getString("email"));
                client.setCpf(bd.rs.getString("cpf"));
                client.setRg(bd.rs.getString("rg"));
                client.setLogradouro(bd.rs.getString("logradouro"));
                client.setNumero(bd.rs.getInt("numero"));
                client.setBairro(bd.rs.getString("bairro"));
                client.setCidade(bd.rs.getString("cidade"));
                client.setEstado(bd.rs.getString("estado"));
                client.setCep(bd.rs.getInt("cep"));
                client.setStatusCliente(bd.rs.getInt("status_cliente"));
                client.setDataCadastro(bd.rs.getString("data_cadastro"));
                client.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                client.setObservacao(bd.rs.getString("observacao"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return client;
    }

    @Override
    public ClienteDao loadByPhone(String phone) throws SQLException {
        String sql = "SELECT * FROM TB_CLIENTE WHERE TELEFONE=?";

        ClienteDao client = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, phone);
            bd.rs = bd.st.executeQuery();

            if (bd.rs.next()) {
                client = new ClienteDao();
                client.setCodCliente(bd.rs.getString("cod_cliente"));
                client.setNome(bd.rs.getString("nome"));
                client.setTelefone(bd.rs.getString("telefone"));
                client.setEmail(bd.rs.getString("email"));
                client.setCpf(bd.rs.getString("cpf"));
                client.setRg(bd.rs.getString("rg"));
                client.setLogradouro(bd.rs.getString("logradouro"));
                client.setNumero(bd.rs.getInt("numero"));
                client.setBairro(bd.rs.getString("bairro"));
                client.setCidade(bd.rs.getString("cidade"));
                client.setEstado(bd.rs.getString("estado"));
                client.setCep(bd.rs.getInt("cep"));
                client.setStatusCliente(bd.rs.getInt("status_cliente"));
                client.setDataCadastro(bd.rs.getString("data_cadastro"));
                client.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                client.setObservacao(bd.rs.getString("observacao"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return client;
    }

    @Override
    public ClienteDao loadById(int id) throws SQLException {
        String sql = "SELECT * FROM TB_CLIENTE WHERE ID=?";

        ClienteDao client = null;

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setInt(1, id);
            bd.rs = bd.st.executeQuery();

            if (bd.rs.next()) {
                client = new ClienteDao();
                client.setCodCliente(bd.rs.getString("cod_cliente"));
                client.setNome(bd.rs.getString("nome"));
                client.setTelefone(bd.rs.getString("telefone"));
                client.setEmail(bd.rs.getString("email"));
                client.setCpf(bd.rs.getString("cpf"));
                client.setRg(bd.rs.getString("rg"));
                client.setLogradouro(bd.rs.getString("logradouro"));
                client.setNumero(bd.rs.getInt("numero"));
                client.setBairro(bd.rs.getString("bairro"));
                client.setCidade(bd.rs.getString("cidade"));
                client.setEstado(bd.rs.getString("estado"));
                client.setCep(bd.rs.getInt("cep"));
                client.setStatusCliente(bd.rs.getInt("status_cliente"));
                client.setDataCadastro(bd.rs.getString("data_cadastro"));
                client.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                client.setObservacao(bd.rs.getString("observacao"));
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return client;
    }

    @Override
    public List<ClienteDao> loadClientsByPhone(String phone) {
        List<ClienteDao> clients = new ArrayList<>();

        String sql = "SELECT * FROM TB_CLIENTE WHERE TELEFONE=?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, phone);
            bd.rs = bd.st.executeQuery();

            while (bd.rs.next()) {
                var client = new ClienteDao();
                client.setCodCliente(bd.rs.getString("cod_cliente"));
                client.setNome(bd.rs.getString("nome"));
                client.setTelefone(bd.rs.getString("telefone"));
                client.setEmail(bd.rs.getString("email"));
                client.setCpf(bd.rs.getString("cpf"));
                client.setRg(bd.rs.getString("rg"));
                client.setLogradouro(bd.rs.getString("logradouro"));
                client.setNumero(bd.rs.getInt("numero"));
                client.setBairro(bd.rs.getString("bairro"));
                client.setCidade(bd.rs.getString("cidade"));
                client.setEstado(bd.rs.getString("estado"));
                client.setCep(bd.rs.getInt("cep"));
                client.setStatusCliente(bd.rs.getInt("status_cliente"));
                client.setDataCadastro(bd.rs.getString("data_cadastro"));
                client.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                client.setObservacao(bd.rs.getString("observacao"));

                clients.add(client);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return clients;
    }

    @Override
    public List<ClienteDao> loadClientsByName(String name) {
        List<ClienteDao> clients = new ArrayList<>();

        String sql = "SELECT * FROM TB_CLIENTE WHERE NOME like '%" + name + "%'";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.rs = bd.st.executeQuery();

            while (bd.rs.next()) {
                var client = new ClienteDao();
                client.setCodCliente(bd.rs.getString("cod_cliente"));
                client.setNome(bd.rs.getString("nome"));
                client.setTelefone(bd.rs.getString("telefone"));
                client.setEmail(bd.rs.getString("email"));
                client.setCpf(bd.rs.getString("cpf"));
                client.setRg(bd.rs.getString("rg"));
                client.setLogradouro(bd.rs.getString("logradouro"));
                client.setNumero(bd.rs.getInt("numero"));
                client.setBairro(bd.rs.getString("bairro"));
                client.setCidade(bd.rs.getString("cidade"));
                client.setEstado(bd.rs.getString("estado"));
                client.setCep(bd.rs.getInt("cep"));
                client.setStatusCliente(bd.rs.getInt("status_cliente"));
                client.setDataCadastro(bd.rs.getString("data_cadastro"));
                client.setDataAtualizacao(bd.rs.getString("data_atualizacao"));
                client.setObservacao(bd.rs.getString("observacao"));

                clients.add(client);
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return clients;
    }

    /**
     * busca id do ultimo cliente cadastrado na tabela cliente
     *
     * @return - retorna id do ultimo cliente
     * @throws SQLException - retorna exceção quando ocorre erro de SQL
     */
    @Override
    public int loadMaxClientId() throws SQLException {
        String sql = "SELECT MAX(ID) AS clientID FROM TB_CLIENTE";

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
    public int create(ClienteDao client) throws SQLException {
        String sql = "INSERT INTO TB_CLIENTE (COD_CLIENTE, NOME, TELEFONE, EMAIL, CPF, RG, LOGRADOURO, NUMERO," +
                " BAIRRO, CIDADE, ESTADO, CEP, DATA_CADASTRO, OBSERVACAO) VALUES (uuid(),?,?,?,?,?,?,?,?,?,?,?,now(),?)";

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
            bd.st.setString(12, client.getObservacao());
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

    @Override
    public int update(ClienteDao client) {
        String sql = "UPDATE TB_CLIENTE SET NOME=?, TELEFONE=?, EMAIL=?," +
                " CPF=?, RG=?, OBSERVACAO=?, STATUS_CLIENTE=?, LOGRADOURO=?, NUMERO=?," +
                " BAIRRO=?, CIDADE=?, ESTADO=?, CEP=?, DATA_ATUALIZACAO=now() WHERE COD_CLIENTE = ?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, client.getNome());
            bd.st.setString(2, client.getTelefone());
            bd.st.setString(3, client.getEmail());
            bd.st.setString(4, client.getCpf());
            bd.st.setString(5, client.getRg());
            bd.st.setString(6, client.getObservacao());
            bd.st.setInt(7, client.getStatusCliente());
            bd.st.setString(8, client.getLogradouro());
            bd.st.setDouble(9, client.getNumero());
            bd.st.setString(10, client.getBairro());
            bd.st.setString(11, client.getCidade());
            bd.st.setString(12, client.getEstado());
            bd.st.setInt(13, client.getCep());
            bd.st.setString(14, client.getCodCliente());

            return bd.st.executeUpdate();
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return -1;
    }

    public String hasClient(String code, String phone) throws SQLException {
        String sql = "SELECT COD_CLIENTE FROM TB_CLIENTE WHERE COD_CLIENTE=? OR TELEFONE=?";

        DatabaseConnection bd = new DatabaseConnection();
        bd.getConnection();

        try {
            bd.st = bd.connection.prepareStatement(sql);
            bd.st.setString(1, code);
            bd.st.setString(2, phone);
            bd.rs = bd.st.executeQuery();
            if (bd.rs.next()) {
                return bd.rs.getString("COD_CLIENTE");
            }
        } catch (Exception e) {
            e.printStackTrace();
            LoggerInFile.printError(e.getMessage());
        } finally {
            bd.close();
        }

        return "-1";
    }
}
