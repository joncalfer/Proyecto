package com.WSR.Repository;

import com.WSR.Model.Usuario;
import org.hibernate.SessionFactory;
import org.hibernate.criterion.Restrictions;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;


@Service(value = "appUserService")
public class UsuarioRepoImpl implements UsuarioRepository{

	
	@Autowired
	private SessionFactory sessionFactory;
	 
	 
	@Override
	@Transactional
	public Usuario loadUserByUsername(String username) {
		return (Usuario)sessionFactory.getCurrentSession()
                .createCriteria(Usuario.class)
                .add(Restrictions.eq("nombreUsuario", username))
                .uniqueResult();
	}

	@Transactional
	@Override
	public int post(Usuario appUser) {
		return	(int) sessionFactory.getCurrentSession().save(appUser);
		
	}

	@Transactional
	@Override
	public Usuario get(int id) {
		return sessionFactory.getCurrentSession().get(Usuario.class, id);
	}

	@Transactional
	@Override
	public Usuario patch(Usuario appUser) {
		sessionFactory.getCurrentSession().update(appUser);
        return get(appUser.getId());
	}

	@Transactional
	@Override
	public boolean delete(int id) {
		sessionFactory.getCurrentSession().delete(get(id));
        return true;
	}

	

}
