package delivery.model;

public class PedidoItemDelivery {
    private String id;
    private String nome;
    private int quantidade;
    private double vrUnit;
    private double vrTotal;
    private double vrDesconto;
    private double vrAdicional;
    private String codExterno;
    private String observacao;

    public PedidoItemDelivery() {
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
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
