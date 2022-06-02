package delivery.model;

public class PagamentoDelivery {
    String nome;
    double valor;
    String tipo;
    double troco;
    boolean prePago;

    public PagamentoDelivery() {
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public double getValor() {
        return valor;
    }

    public void setValor(double valor) {
        this.valor = valor;
    }

    public String getTipo() {
        return tipo;
    }

    public void setTipo(String tipo) {
        this.tipo = tipo;
    }

    public double getTroco() {
        return troco;
    }

    public void setTroco(double troco) {
        this.troco = troco;
    }

    public boolean isPrePago() {
        return prePago;
    }

    public void setPrePago(boolean prePago) {
        this.prePago = prePago;
    }
}
