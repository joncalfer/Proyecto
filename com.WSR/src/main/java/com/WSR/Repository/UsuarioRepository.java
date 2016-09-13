package com.WSR.Repository;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;

import com.WSR.Model.Usuario;

public interface UsuarioRepository  {
	
	Usuario loadUserByUsername(String username);

}
