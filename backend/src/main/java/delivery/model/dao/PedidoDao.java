package delivery.model.dao;

public class PedidoDao {
    private int id;
    private String codPedido;
    private String codCliente;
    private ClienteDao cliente;
    private String statusPedido;
    private String dataPedido;
    private String dataEntrega;
    private double vrTotal;
    private double vrTaxa;
    private double vrTroco;
    private double vrDesconto;
    private String logradouro;
    private int numero;
    private String bairro;
    private String cidade;
    private String estado;
    private String cep;
    private String tipoPedido;
    private String origem;
    private String observacao;
    private String dataAtualizacao;
    private String formaPagamento;
    private String codPedidoIntegracao;
    private String codUsuario;

    public PedidoDao() {
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getCodUsuario() {
        return codUsuario;
    }

    public void setCodUsuario(String codUsuario) {
        this.codUsuario = codUsuario;
    }

    public ClienteDao getCliente() {
        return cliente;
    }

    public void setCliente(ClienteDao cliente) {
        this.cliente = cliente;
    }

    public String getCodPedido() {
        return codPedido;
    }

    public void setCodPedido(String codPedido) {
        this.codPedido = codPedido;
    }

    public String getCodCliente() {
        return codCliente;
    }

    public void setCodCliente(String codCliente) {
        this.codCliente = codCliente;
    }

    public String getStatusPedido() {
        return statusPedido;
    }

    public void setStatusPedido(String statusPedido) {
        this.statusPedido = statusPedido;
    }

    public String getDataPedido() {
        return dataPedido;
    }

    public void setDataPedido(String dataPedido) {
        this.dataPedido = dataPedido;
    }

    public String getDataEntrega() {
        return dataEntrega;
    }

    public void setDataEntrega(String dataEntrega) {
        this.dataEntrega = dataEntrega;
    }

    public double getVrTotal() {
        return vrTotal;
    }

    public void setVrTotal(double vrTotal) {
        this.vrTotal = vrTotal;
    }

    public double getVrTaxa() {
        return vrTaxa;
    }

    public void setVrTaxa(double vrTaxa) {
        this.vrTaxa = vrTaxa;
    }

    public double getVrTroco() {
        return vrTroco;
    }

    public void setVrTroco(double vrTroco) {
        this.vrTroco = vrTroco;
    }

    public double getVrDesconto() {
        return vrDesconto;
    }

    public void setVrDesconto(double vrDesconto) {
        this.vrDesconto = vrDesconto;
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

    public String getCep() {
        return cep;
    }

    public void setCep(String cep) {
        this.cep = cep;
    }

    public String getTipoPedido() {
        return tipoPedido;
    }

    public void setTipoPedido(String tipoPedido) {
        this.tipoPedido = tipoPedido;
    }

    public String getOrigem() {
        return origem;
    }

    public void setOrigem(String origem) {
        this.origem = origem;
    }

    public String getObservacao() {
        return observacao;
    }

    public void setObservacao(String observacao) {
        this.observacao = observacao;
    }

    public String getDataAtualizacao() {
        return dataAtualizacao;
    }

    public void setDataAtualizacao(String dataAtualizacao) {
        this.dataAtualizacao = dataAtualizacao;
    }

    public String getFormaPagamento() {
        return formaPagamento;
    }

    public void setFormaPagamento(String formaPagamento) {
        this.formaPagamento = formaPagamento;
    }

    public String getCodPedidoIntegracao() {
        return codPedidoIntegracao;
    }

    public void setCodPedidoIntegracao(String codPedidoIntegracao) {
        this.codPedidoIntegracao = codPedidoIntegracao;
    }
}
