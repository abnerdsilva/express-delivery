package delivery.model.dao;

public class BairroDao {
    private String id;
    private String nome;
    private double vrTaxa;

    private int status;

    public int getStatus() {
        return status;
    }

    public void setStatus(int status) {
        this.status = status;
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

    public double getVrTaxa() {
        return vrTaxa;
    }

    public void setVrTaxa(double vrTaxa) {
        this.vrTaxa = vrTaxa;
    }
}
