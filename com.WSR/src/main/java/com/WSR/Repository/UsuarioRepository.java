package com.WSR.Repository;



import com.WSR.Model.Usuario;

public interface UsuarioRepository  {
	
	Usuario loadUserByUsername(String username);
	
	int post(Usuario appUser);

	Usuario get(int id);

	Usuario patch(Usuario appUser);

    boolean delete(int id);

}
