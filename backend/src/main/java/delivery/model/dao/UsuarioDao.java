package delivery.model.dao;

import delivery.model.UsuarioDelivery;

public class UsuarioDao {
    private int id;
    private String usuario;
    private String tipoUsuario;
    private byte statusUsuario;

    public UsuarioDao() {
    }

    public UsuarioDao(int id, String usuario, String tipoUsuario, byte statusUsuario) {
        this.id = id;
        this.usuario = usuario;
        this.tipoUsuario = tipoUsuario;
        this.statusUsuario = statusUsuario;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getTipoUsuario() {
        return tipoUsuario;
    }

    public void setTipoUsuario(String tipoUsuario) {
        this.tipoUsuario = tipoUsuario;
    }

    public byte getStatusUsuario() {
        return statusUsuario;
    }

    public void setStatusUsuario(byte statusUsuario) {
        this.statusUsuario = statusUsuario;
    }

    public UsuarioDelivery usuarioDaoToDelivery() {
        String status = "ATIVO";
        if (this.getStatusUsuario() == 0) {
            status = "INATIVO";
        }
        return new UsuarioDelivery(this.getId(), this.getUsuario(), this.getTipoUsuario(), status);
    }
}
