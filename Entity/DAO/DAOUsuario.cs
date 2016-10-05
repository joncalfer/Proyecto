using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Entity;


namespace DAO
{
    public class DaoUsuario
    {
        public List<Usuario> listar()
        {
            try
            {
                using (EntityEntities conexion = new EntityEntities())
                {
                    List<Usuario> consulta = (from usuarios in conexion.Usuario
                        select usuarios).ToList();
                    //se puede también solo con lo de abajo
                    // return conexion.Usuario.ToList();
                    return consulta;
                }
            }
            catch (Exception ex)
            {

                throw ;
            }


        }

        public Usuario obtener(Usuario usuario)
        {
            try
            {
                using (EntityEntities conexion = new EntityEntities())
                {
                    return conexion.Usuario.SingleOrDefault<Usuario>(usu => usu.id == usuario.id);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Usuario obtenerPorNombreUsuario(Usuario usuario)
        {
            try
            {
                using (EntityEntities conexion = new EntityEntities())
                {
                    return conexion.Usuario.SingleOrDefault<Usuario>(usu => usu.nombreUsuario == usuario.nombreUsuario);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool agregar(Usuario usuario)
        {
            try
            {
                using (EntityEntities conexion = new EntityEntities())
                {
                    
                    conexion.Usuario.Add(usuario);
                    
                    return conexion.SaveChanges() > 0;
                }
                }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool eliminar(Usuario usuario)
        {
            try
            {
                using (EntityEntities conexion = new EntityEntities())
                {


                    conexion.Usuario.Attach(usuario);
                    conexion.Usuario.Remove(usuario);

                    return conexion.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool actualizar(Usuario usuario)
        {
            try
            {
                using (EntityEntities conexion = new EntityEntities())
                {
                    Usuario usu = new Usuario();
                    usu.id = usuario.id;
                    conexion.Usuario.Attach(usu);
                    usu.activo = usuario.activo;
                    usu.apellidos = usuario.apellidos;
                    usu.contrasena = usuario.contrasena;
                    usu.email = usuario.email;
                    usu.nombre = usuario.nombre;
                    usu.nombreUsuario = usuario.nombreUsuario;
                    usu.roles = usuario.roles;
                    usu.ultimoCambioContrasena = usuario.ultimoCambioContrasena;
                    return conexion.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Consulta> usuariosActivos()
        {
            try
            {
                using (EntityEntities conexion = new EntityEntities())
                {

                    return conexion.Database.SqlQuery<Consulta>("consultarUsuariosActivos ").ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}