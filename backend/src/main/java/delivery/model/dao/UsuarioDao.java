package delivery.model.dao;

import delivery.model.UsuarioDelivery;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import java.util.ArrayList;
import java.util.Collection;

public class UsuarioDao implements UserDetails {
    private String id;
    private String usuario;
    private String tipoUsuario;
    private int statusUsuario;
    private String senha;

    public UsuarioDao() {
    }

    public UsuarioDao(String id, String usuario, String tipoUsuario, int statusUsuario) {
        this.id = id;
        this.usuario = usuario;
        this.tipoUsuario = tipoUsuario;
        this.statusUsuario = statusUsuario;
    }

    public UsuarioDao(String id, String usuario, String senha, String tipoUsuario, int statusUsuario) {
        this.id = id;
        this.usuario = usuario;
        this.senha = senha;
        this.tipoUsuario = tipoUsuario;
        this.statusUsuario = statusUsuario;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
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

    public int getStatusUsuario() {
        return statusUsuario;
    }

    public void setStatusUsuario(int statusUsuario) {
        this.statusUsuario = statusUsuario;
    }

    public void setSenha(String password) {
        this.senha = password;
    }

    public String getSenha() {
        return senha;
    }

    public UsuarioDelivery usuarioDaoToDelivery() {
        String status = "ATIVO";
        if (this.getStatusUsuario() == 0) {
            status = "INATIVO";
        }
        return new UsuarioDelivery(this.getId(), this.getUsuario(), this.getTipoUsuario(), status);
    }

    @Override
    public Collection<? extends GrantedAuthority> getAuthorities() {
        return new ArrayList<>();
    }

    @Override
    public String getPassword() {
        return this.getSenha();
//        return new BCryptPasswordEncoder().encode(this.getSenha());
    }

    @Override
    public String getUsername() {
        return null;
    }

    @Override
    public boolean isAccountNonExpired() {
        return true;
    }

    @Override
    public boolean isAccountNonLocked() {
        return true;
    }

    @Override
    public boolean isCredentialsNonExpired() {
        return true;
    }

    @Override
    public boolean isEnabled() {
        return true;
    }
}
