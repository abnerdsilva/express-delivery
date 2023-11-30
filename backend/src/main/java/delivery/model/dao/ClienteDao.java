package delivery.model.dao;

import delivery.model.ClienteDelivery;

public class ClienteDao {
    private String codCliente;
    private String nome;
    private String telefone;
    private String email;
    private String cpf;
    private String rg;
    private String logradouro;
    private int numero;
    private String bairro;
    private String cidade;
    private String estado;
    private int cep;
    private int statusCliente;
    private String dataCadastro;
    private String dataAtualizacao;
    private String observacao;

    public String getCodCliente() {
        return codCliente;
    }

    public void setCodCliente(String codCliente) {
        this.codCliente = codCliente;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getTelefone() {
        return telefone;
    }

    public void setTelefone(String telefone) {
        this.telefone = telefone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getCpf() {
        return cpf;
    }

    public void setCpf(String cpf) {
        this.cpf = cpf;
    }

    public String getRg() {
        return rg;
    }

    public void setRg(String rg) {
        this.rg = rg;
    }

    public String getLogradouro() {
        return logradouro;
    }

    public void setLogradouro(String logradouro) {
        this.logradouro = logradouro;
    }

    public int getNumero() {
        return numero;
    }

    public void setNumero(int numero) {
        this.numero = numero;
    }

    public String getBairro() {
        return bairro;
    }

    public void setBairro(String bairro) {
        this.bairro = bairro;
    }

    public String getCidade() {
        return cidade;
    }

    public void setCidade(String cidade) {
        this.cidade = cidade;
    }

    public String getEstado() {
        return estado;
    }

    public void setEstado(String estado) {
        this.estado = estado;
    }

    public int getCep() {
        return cep;
    }

    public void setCep(int cep) {
        this.cep = cep;
    }

    public int getStatusCliente() {
        return statusCliente;
    }

    public void setStatusCliente(int statusCliente) {
        this.statusCliente = statusCliente;
    }

    public String getDataCadastro() {
        return dataCadastro;
    }

    public void setDataCadastro(String dataCadastro) {
        this.dataCadastro = dataCadastro;
    }

    public String getDataAtualizacao() {
        return dataAtualizacao;
    }

    public void setDataAtualizacao(String dataAtualizacao) {
        this.dataAtualizacao = dataAtualizacao;
    }

    public String getObservacao() {
        return observacao;
    }

    public void setObservacao(String observacao) {
        this.observacao = observacao;
    }

    public ClienteDelivery clientDaoToClienteDelivery() {
        ClienteDelivery clienteDelivery = new ClienteDelivery();
        clienteDelivery.setCodCliente(this.getCodCliente());
        clienteDelivery.setDocumento(this.getCpf());
        clienteDelivery.setTelefone(this.getTelefone());
        clienteDelivery.setBairro(this.getBairro());
        clienteDelivery.setLogradouro(this.getLogradouro());
        clienteDelivery.setEstado(this.getEstado());
        clienteDelivery.setCep(this.getCep());
        clienteDelivery.setCidade(this.getCidade());
        clienteDelivery.setEmail(this.getEmail());
        clienteDelivery.setNumero(this.getNumero());
        clienteDelivery.setNome(this.getNome());
        clienteDelivery.setObservacao(this.getObservacao());

        return clienteDelivery;
    }
}
