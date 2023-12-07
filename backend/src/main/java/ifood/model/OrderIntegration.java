package ifood.model;

import java.sql.Timestamp;

public class OrderIntegration {
    private String idPedido;
    private String id;
    private String codPedidoIntegracao;
    private Timestamp dataCriacao;
    private String statusIntegracao;
    private String codStatusIntegracao;
    private int nrPedido;

    public String getIdPedido() {
        return idPedido;
    }

    public void setIdPedido(String idPedido) {
        this.idPedido = idPedido;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getCodPedidoIntegracao() {
        return codPedidoIntegracao;
    }

    public void setCodPedidoIntegracao(String codPedidoIntegracao) {
        this.codPedidoIntegracao = codPedidoIntegracao;
    }

    public Timestamp getDataCriacao() {
        return dataCriacao;
    }

    public void setDataCriacao(Timestamp dataCriacao) {
        this.dataCriacao = dataCriacao;
    }

    public String getStatusIntegracao() {
        return statusIntegracao;
    }

    public void setStatusIntegracao(String statusIntegracao) {
        this.statusIntegracao = statusIntegracao;
    }

    public String getCodStatusIntegracao() {
        return codStatusIntegracao;
    }

    public void setCodStatusIntegracao(String codStatusIntegracao) {
        this.codStatusIntegracao = codStatusIntegracao;
    }

    public int getNrPedido() {
        return nrPedido;
    }

    public void setNrPedido(int nrPedido) {
        this.nrPedido = nrPedido;
    }

    @Override
    public String toString() {
        return "OrderIntegration{" +
                "idPedido=" + idPedido +
                ", id='" + id + '\'' +
                ", codPedidoIntegracao='" + codPedidoIntegracao + '\'' +
                ", dataCriacao=" + dataCriacao +
                ", statusIntegracao='" + statusIntegracao + '\'' +
                ", codStatusIntegracao='" + codStatusIntegracao + '\'' +
                ", nrPedido=" + nrPedido +
                '}';
    }
}
