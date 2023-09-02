package delivery.service;

import delivery.model.dao.UsuarioDao;
import delivery.repository.UsuarioRepository;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class AuthorizationService implements UserDetailsService {

    UsuarioRepository repository;

    AuthorizationService() {
        repository = new UsuarioRepository();
    }

    @Override
    public UsuarioDao loadUserByUsername(String username) throws UsernameNotFoundException {
        return repository.findByLogin(username);
    }
}
