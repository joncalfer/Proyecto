using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;
using Entity;
using BL;  

namespace WSS
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WssUsuario
    {
        [OperationContract]
        [WebInvoke(Method = "GET", 
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json, 
            UriTemplate = "listarUsuario")]
        public Response<List<Usuario>> listarUsuarios()
        {
            BlUsuario blUsuario = new BlUsuario();
            return blUsuario.GetUsuarios();
        }


        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "agregarUsuario")]
        public Response<Usuario> agregarUsuario(Usuario usuario)
        {
            
            BlUsuario blUsuario = new BlUsuario();
            return blUsuario.agregarUsuario(usuario);
        }

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "editarUsuario")]
        public Response<Usuario> editarUsuario(Usuario usuario)
        {

            BlUsuario blUsuario = new BlUsuario();
            
            return blUsuario.editarUsuario(usuario);
        }

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "")]
        public Response<Usuario> eliminarUsuario(Usuario usuario)
        {

            BlUsuario blUsuario = new BlUsuario();

            return blUsuario.eliminarUsuario(usuario);
        }

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "activos")]
        public Response<List<Consulta>> usuariosActivos()
        {

            BlUsuario blUsuario = new BlUsuario();

            return blUsuario.consultarActivos();
        }
    }
}
