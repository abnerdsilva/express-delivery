package delivery.model;

import java.util.List;

public class PedidoDelivery {
    private int codPedido;
    private String referencia;
    private String referenciaCurta;
    private String dataCriacao;
    private boolean agendado;
    private String dataEntrega;
    private String tipo;
    private ClienteDelivery cliente;
    private PagamentoDelivery pagamento;
    private List<PedidoItemDelivery> itens;
    private double vrTotal;
    private double vrAdicional;
    private double vrDesconto;
    private String observacao;
    private String origem;
    private String codPedidoIntegracao;

    public PedidoDelivery() {
    }

    public int getCodPedido() {
        return codPedido;
    }

    public void setCodPedido(int codPedido) {
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

    public String getDataCriacao() {
        return dataCriacao;
    }

    public void setDataCriacao(String dataCriacao) {
        this.dataCriacao = dataCriacao;
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
}
