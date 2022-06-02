package delivery.model;

public class PedidoItemDelivery {
    String nome;
    int quantidade;
    double vrUnit;
    double vrTotal;
    double vrDesconto;
    double vrAdicional;
    String codExterno;
    String observacao;

    public PedidoItemDelivery() {
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public int getQuantidade() {
        return quantidade;
    }

    public void setQuantidade(int quantidade) {
        this.quantidade = quantidade;
    }

    public double getVrUnit() {
        return vrUnit;
    }

    public void setVrUnit(double vrUnit) {
        this.vrUnit = vrUnit;
    }

    public double getVrTotal() {
        return vrTotal;
    }

    public void setVrTotal(double vrTotal) {
        this.vrTotal = vrTotal;
    }

    public double getVrDesconto() {
        return vrDesconto;
    }

    public void setVrDesconto(double vrDesconto) {
        this.vrDesconto = vrDesconto;
    }

    public double getVrAdicional() {
        return vrAdicional;
    }

    public void setVrAdicional(double vrAdicional) {
        this.vrAdicional = vrAdicional;
    }

    public String getCodExterno() {
        return codExterno;
    }

    public void setCodExterno(String codExterno) {
        this.codExterno = codExterno;
    }

    public String getObservacao() {
        return observacao;
    }

    public void setObservacao(String observacao) {
        this.observacao = observacao;
    }
}
