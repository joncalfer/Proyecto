package com.WSR.Repository;

import com.WSR.Model.Usuario;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;

public class UsuarioRepoImpl implements UsuarioRepository{

	
	@Autowired
	private SessionFactory sessionFactory;
	 
	 
	@Override
	public Usuario loadUserByUsername(String username) {
		return (Usuario)sessionFactory.getCurrentSession()
                .createCriteria(Usuario.class)
                .add(Restrictions.eq("nombreUsuario", username))
                .uniqueResult();
	}

	

}
