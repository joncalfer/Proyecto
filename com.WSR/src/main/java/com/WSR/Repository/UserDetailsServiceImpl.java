package com.WSR.Repository;



import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import com.WSR.Model.SpringSecurityUser;
import com.WSR.Model.Usuario;

@Service(value = "userDetailsService")
public class UserDetailsServiceImpl implements UserDetailsService {

    @Autowired
    private UsuarioRepository appUserService;

    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        Usuario appUser = this.appUserService.loadUserByUsername(username);

        if (appUser == null) {
            throw new UsernameNotFoundException(String.format("No appUser found with username '%s'.", username));
        } else {
            return new SpringSecurityUser(
                    appUser.getId(),
                    appUser.getNombreUsuario(),
                    appUser.getContrasena(),
                    null,
                    null,
                    AuthorityUtils.commaSeparatedStringToAuthorityList(appUser.getAuthorities())
            );
        }
    }

}
