package com.WSR.Model;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "usuarios")
public class Usuario {

	
	@Id
    private Integer id;
	
	private String nombreUsuario;
	private String contrasena;
	private String Authorities;
	
	
	public Usuario(Integer id, String nombreUsuario, String contrasena, String Authorities) {
		super();
		this.id = id;
		this.nombreUsuario = nombreUsuario;
		this.contrasena = contrasena;
		this.Authorities = Authorities;
	}


	public Integer getId() {
		return id;
	}


	public void setId(Integer id) {
		this.id = id;
	}


	public String getNombreUsuario() {
		return nombreUsuario;
	}


	public void setNombreUsuario(String nombreUsuario) {
		this.nombreUsuario = nombreUsuario;
	}


	public String getContrasena() {
		return contrasena;
	}


	public void setContrasena(String contrasena) {
		this.contrasena = contrasena;
	}


	public String getAuthorities() {
		return Authorities;
	}


	public void setAuthorities(String authorities) {
		Authorities = authorities;
	}
	
	
	
	
}
