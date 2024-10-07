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
        public IHttpActionResult Get()
        {
            try
            {
                DataTable usuarios = ControladorCuentaUsuario.Listar();
                List<ModeloApiUsuario> listaUsuarios = new List<ModeloApiUsuario>();

                foreach (DataRow usuario in usuarios.Rows)
                {
                    ModeloApiUsuario u = new ModeloApiUsuario
                    {
                        id = Int32.Parse(usuario["id_cuenta"].ToString()),
                        nombre = usuario["nombre"].ToString(),
                        apellido = usuario["apellido"].ToString(),
                        telefono = Int32.Parse(usuario["telefono"].ToString()),
                        mail = usuario["email"].ToString(),
                        fechaNacimiento = usuario["fecha_nacimiento"].ToString(),
                        habilitado = Boolean.Parse(usuario["habilitado"].ToString())
                    };

                    listaUsuarios.Add(u);
                }
                return Ok(listaUsuarios);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al listar los usuarios: " + ex.Message));
            }
        }

        [Route("api/Usuario/CrearUsuario")]
        [HttpPost]
        public IHttpActionResult Post(ModeloApiUsuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.mail))
            {
                return BadRequest("El campo 'email' es requerido.");
            }

            try
            {
                ControladorCuentaUsuario.AltaCuentaUsuario(usuario.nombre, usuario.apellido, usuario.telefono, usuario.mail, usuario.fechaNacimiento, usuario.contrasenia);
                Dictionary<string, string> resultado = new Dictionary<string, string>
                {
                    { "mensaje", "Usuario creado exitosamente" }
                };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al crear el usuario: " + ex.Message));
            }
        }

        [Route("api/Usuario/ModificarUsuario{id:int}")]
        [HttpPut]
        public IHttpActionResult Put(int id, ModeloApiUsuario usuario)
        {
            try
            {
                ControladorCuentaUsuario.ModificarCuentaDesdeBackoffice(id.ToString(), usuario.nombre, usuario.apellido, usuario.mail, usuario.telefono, usuario.fechaNacimiento);
                Dictionary<string, string> resultado = new Dictionary<string, string>
                {
                    { "mensaje", "Usuario modificado exitosamente" }
                };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al modificar el usuario: " + ex.Message));
            }
        }

        [Route("api/Usuario/DesabilitarUsuario{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                ControladorCuentaUsuario.DeshabilitaCuentaUsuario(id);
                Dictionary<string, string> resultado = new Dictionary<string, string>
                {
                    { "mensaje", "Usuario deshabilitado exitosamente" }
                };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al deshabilitar el usuario: " + ex.Message));
            }
        }

        [Route("api/Usuario/BuscarUsuario/{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
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
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al buscar el usuario: " + ex.Message));
            }
        }


    }
}
