using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entity;
using Newtonsoft.Json;

namespace BL
{
    public class BlUsuario
    {

        public Response<List<Usuario>> GetUsuarios()
        {
            var response = new Response<List<Usuario>>();
            
            var daoUsuario = new DaoUsuario();

            try
            {
                List<Usuario> lista = daoUsuario.listar();
                if (lista != null && lista.Count > 0)
                {
                    response.Status= "200";
                    response.Message = "Usuarios Encontrados: " + lista.Count;
                    response.Data = lista;

                }
                else
                {
                    response.Status= "404";
                     response.Message = "No hay usuarios registrados";
                     response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.Status = "500";
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }

        public Response<Usuario> agregarUsuario(Usuario usuario)
        {
            var response = new Response<Usuario>();

            var daoUsuario = new DaoUsuario();
            usuario.ultimoCambioContrasena = DateTime.Now;
            usuario.activo = true;
            try
            {
                bool resultado = daoUsuario.agregar(usuario);
                if (resultado)
                {
                    response.Status = "200";
                    response.Message = "Usuario agregado correctamente";
                    response.Data = usuario;

                }
                else
                {
                    response.Status = "404";
                    response.Message = "No se pudo guardar el usuario";
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.Status = "500";
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }

        public Response<Usuario> editarUsuario(Usuario usuario)
        {
            var response = new Response<Usuario>();

            var daoUsuario = new DaoUsuario();
            if (!String.IsNullOrEmpty(usuario.contrasena))
            {
                usuario.ultimoCambioContrasena = DateTime.Now;
            }
            
            
            try
            {
                bool resultado = daoUsuario.actualizar(usuario);
                if (resultado)
                {
                    response.Status = "200";
                    response.Message = "Usuario actualizado correctamente";
                    response.Data = usuario;

                }
                else
                {
                    response.Status = "404";
                    response.Message = "No se pudo actualizar el usuario";
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.Status = "500";
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }

        public Response<Usuario> eliminarUsuario(Usuario usuario)
        {
            var response = new Response<Usuario>();

            var daoUsuario = new DaoUsuario();
          
            try
            {
                bool resultado = daoUsuario.eliminar(usuario);
                if (resultado)
                {
                    response.Status = "200";
                    response.Message = "Usuario eliminado correctamente";
                    response.Data = usuario;

                }
                else
                {
                    response.Status = "404";
                    response.Message = "No se pudo eliminar el usuario";
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.Status = "500";
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }

        public Response<List<Consulta>> consultarActivos()
        {
            var response = new Response<List<Consulta>>();

            var daoUsuario = new DaoUsuario();

            try
            {
                List<Consulta> lista = daoUsuario.usuariosActivos();
                if (lista != null && lista.Count > 0)
                {
                    response.Status = "200";
                    response.Message = "Usuarios Encontrados: " + lista.Count;
                    response.Data = lista;

                }
                else
                {
                    response.Status = "404";
                    response.Message = "No hay usuarios activos";
                    response.Data = null;
                }
            }
            catch (Exception ex)
            {
                response.Status = "500";
                response.Message = ex.Message;
                response.Data = null;
            }
            return response;
        }
    }
}
