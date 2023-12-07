package imprime.model;

import com.fasterxml.jackson.annotation.JsonInclude;

import java.util.List;

public class PedidoDelivery {
    private int id;

    private String codPedido;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    private String referencia;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    private String referenciaCurta;
    private String dataPedido;
    private String statusPedido;
    private boolean agendado;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    private String dataEntrega;
    private String tipo;
    private ClienteDelivery cliente;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    private PagamentoDelivery pagamento;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    private List<PedidoItemDelivery> itens;
    private double vrTotal;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    private double vrAdicional;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    private double vrTroco;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    private double vrDesconto;
    private String observacao;
    private String origem;

    @JsonInclude(JsonInclude.Include.NON_NULL)
    private String codPedidoIntegracao;

    public PedidoDelivery() {
    }

    public String getCodPedido() {
        return codPedido;
    }

    public void setCodPedido(String codPedido) {
        this.codPedido = codPedido;
    }

    public String getReferencia() {
        return referencia;
    }

    public void setReferencia(String referencia) {
        this.referencia = referencia;
    }

    public String getReferenciaCurta() {
        return referenciaCurta;
    }

    public void setReferenciaCurta(String referenciaCurta) {
        this.referenciaCurta = referenciaCurta;
    }

    public String getDataPedido() {
        return dataPedido;
    }

    public void setDataPedido(String dataCriacao) {
        this.dataPedido = dataCriacao;
    }

    public boolean isAgendado() {
        return agendado;
    }

    public void setAgendado(boolean agendado) {
        this.agendado = agendado;
    }

    public String getDataEntrega() {
        return dataEntrega;
    }

    public void setDataEntrega(String dataEntrega) {
        this.dataEntrega = dataEntrega;
    }

    public String getTipo() {
        return tipo;
    }

    public void setTipo(String tipo) {
        this.tipo = tipo;
    }

    public ClienteDelivery getCliente() {
        return cliente;
    }

    public void setCliente(ClienteDelivery cliente) {
        this.cliente = cliente;
    }

    public PagamentoDelivery getPagamento() {
        return pagamento;
    }

    public void setPagamento(PagamentoDelivery pagamento) {
        this.pagamento = pagamento;
    }

    public List<PedidoItemDelivery> getItens() {
        return itens;
    }

    public void setItens(List<PedidoItemDelivery> itens) {
        this.itens = itens;
    }

    public double getVrTotal() {
        return vrTotal;
    }

    public void setVrTotal(double vrTotal) {
        this.vrTotal = vrTotal;
    }

    public double getVrAdicional() {
        return vrAdicional;
    }

    public void setVrAdicional(double vrAdicional) {
        this.vrAdicional = vrAdicional;
    }

    public double getVrDesconto() {
        return vrDesconto;
    }

    public void setVrDesconto(double vrDesconto) {
        this.vrDesconto = vrDesconto;
    }

    public String getObservacao() {
        return observacao;
    }

    public void setObservacao(String observacao) {
        this.observacao = observacao;
    }

    public String getOrigem() {
        return origem;
    }

    public void setOrigem(String origem) {
        this.origem = origem;
    }

    public String getCodPedidoIntegracao() {
        return codPedidoIntegracao;
    }

    public void setCodPedidoIntegracao(String codPedidoIntegracao) {
        this.codPedidoIntegracao = codPedidoIntegracao;
    }

    public void setStatusPedido(String statusPedido) {
        this.statusPedido = statusPedido;
    }

    public String getStatusPedido() {
        return statusPedido;
    }

    public double getVrTroco() {
        return vrTroco;
    }

    public void setVrTroco(double vrTroco) {
        this.vrTroco = vrTroco;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
}
