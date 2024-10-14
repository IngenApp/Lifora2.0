using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Controladores;
using ApiLifora.Models;
using System.Data;


namespace ApiLifora.Controllers
{
    public class UsuarioController : ApiController
    {
        [Route("api/Usuario/ListarUsuarios")]
        [HttpGet]
        public List<ModeloApiUsuario> Get()
        {
            DataTable usuarios = ControladorCuentaUsuario.Listar();
            List<ModeloApiUsuario> listaUsuarios = new List<ModeloApiUsuario>();

            foreach (DataRow usuario in usuarios.Rows)
            {
                ModeloApiUsuario u = new ModeloApiUsuario();
                u.idPerfil = Int32.Parse(usuario ["ID perfil"].ToString());
                u.email = usuario["Email"].ToString();
                u.telefono = usuario["Telefono"].ToString();
                u.habilitacion = bool.Parse(usuario["Habilitado"].ToString());
                u.idUsuario = Int32.Parse(usuario["ID usuario"].ToString());
                u.nombre = usuario["Nombre"].ToString();
                u.apellido = usuario["Apellido"].ToString();
                u.fechaNacimiento = usuario["Fecha Nacimiento"].ToString();
                u.idioma = usuario["Idioma"].ToString();
                u.atributo1 = usuario["Atributo1"].ToString();
                u.atributo2 = usuario["Atributo2"].ToString();

                listaUsuarios.Add(u);
            }
            return listaUsuarios;
        }

 /*       [Route("api/Usuario/CrearUsuario")]
        [HttpPost]
        public IHttpActionResult Post(ModeloApiUsuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.mail))
            {
                return BadRequest("El campo 'email' es requerido.");
            }
            ControladorCuentaUsuario.AltaCuentaUsuario(usuario.nombre, usuario.apellido, usuario.telefono, usuario.mail, usuario.fechaNacimiento, usuario.contrasenia);
            Dictionary<string, string> resultado = new Dictionary<string, string>
    {
        { "mensaje", "Usuario creado exitosamente" }
    };
            return Ok(resultado);
        }

        [Route("api/Usuario/ModificarUsuario{id:int}")]
        [HttpPut]
        public IHttpActionResult Put(int id, ModeloApiUsuario usuario)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            
           
            resultado.Add("mensaje", "Usuario modificado exitosamente");
            return Ok(resultado);
        }

        [Route("api/Usuario/DesabilitarUsuario{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorCuentaUsuario.DeshabilitaCuentaUsuario(id);
            resultado.Add("mensaje", "Usuario deshabilitado exitosamente");
            return Ok(resultado);
        }

        [Route("api/Usuario/BuscarUsuario/{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ModeloApiUsuario usuario = new ModeloApiUsuario();
            Dictionary<string, string> datosUsuario = ControladorCuentaUsuario.BuscarPorId(id);

            if (datosUsuario != null && datosUsuario["resultado"] == "true")
            {
                usuario.id = Int32.Parse(datosUsuario["id_cuenta"]);
                usuario.nombre = datosUsuario["nombre"];
                usuario.apellido = datosUsuario["apellido"];
                usuario.telefono = Int32.Parse(datosUsuario["telefono"]);
                usuario.mail = datosUsuario["email"];
                usuario.fechaNacimiento = datosUsuario["fecha_nacimiento"];
                if (datosUsuario.ContainsKey("habilitado"))
                {
                    usuario.habilitado = Boolean.Parse(datosUsuario["habilitado"]);
                }
                return Ok(usuario);
            }
            return NotFound();
        }
        */

    }
}
