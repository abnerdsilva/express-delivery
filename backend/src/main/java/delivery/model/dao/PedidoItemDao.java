package delivery.model.dao;

import delivery.model.PedidoItemDelivery;

public class PedidoItemDao {
    private String codPedidoItem;
    private String codPedido;
    private String codProduto;
    private String codExterno;
    private int quantidade;
    private double vrUnitario;
    private double vrTotal;
    private String observacao;
    private String nome;

    public PedidoItemDao() {
    }

    public String getCodPedidoItem() {
        return codPedidoItem;
    }

    public void setCodPedidoItem(String codPedidoItem) {
        this.codPedidoItem = codPedidoItem;
    }

    public String getCodPedido() {
        return codPedido;
    }

    public void setCodPedido(String codPedido) {
        this.codPedido = codPedido;
    }

    public String getCodProduto() {
        return codProduto;
    }

    public void setCodProduto(String codProduto) {
        this.codProduto = codProduto;
    }

    public int getQuantidade() {
        return quantidade;
    }

    public void setQuantidade(int quantidade) {
        this.quantidade = quantidade;
    }

    public double getVrUnitario() {
        return vrUnitario;
    }

    public void setVrUnitario(double vrUnitario) {
        this.vrUnitario = vrUnitario;
    }

    public double getVrTotal() {
        return vrTotal;
    }

    public void setVrTotal(double vrTotal) {
        this.vrTotal = vrTotal;
    }

    public String getObservacao() {
        return observacao;
    }

    public void setObservacao(String observacao) {
        this.observacao = observacao;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getNome() {
        return nome;
    }

    public void setCodExterno(String codigo) {
        this.codExterno = nome;
    }

    public String getCodExterno() {
        return codExterno;
    }

    public PedidoItemDelivery itemDaoToItemDelivery() {
        PedidoItemDelivery itemDelivery = new PedidoItemDelivery();
        itemDelivery.setId(this.getCodProduto());
        itemDelivery.setVrUnit(this.getVrUnitario());
        itemDelivery.setQuantidade(this.getQuantidade());
        itemDelivery.setObservacao(this.getObservacao());
        itemDelivery.setVrTotal(this.getVrTotal());
        itemDelivery.setNome(this.getNome());

        return itemDelivery;
    }
}
