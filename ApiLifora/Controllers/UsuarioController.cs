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
        public IHttpActionResult ListarUsuarios()
    {
        try
        {
            DataTable usuarios = ControladorCuentaUsuario.Listar();
            List<ModeloApiUsuario> listaUsuarios = new List<ModeloApiUsuario>();
            foreach (DataRow usuario in usuarios.Rows)
            {
                    ModeloApiUsuario u = new ModeloApiUsuario
                    {
                    idPerfil = Int32.Parse(usuario["ID perfil"].ToString()),
                    apodo = usuario["apodo"].ToString(),
                    email = usuario["Email"].ToString(),
                    telefono = usuario["Telefono"].ToString(),
                    habilitacion = bool.Parse(usuario["Habilitado"].ToString()),
                    idUsuario = Int32.Parse(usuario["ID usuario"].ToString()),
                    nombre = usuario["Nombre"].ToString(),
                    apellido = usuario["Apellido"].ToString(),
                    contrasena = usuario["contrasena"].ToString(),
                    fechaNacimiento = usuario["Fecha Nacimiento"].ToString(),
                    idioma = usuario["Idioma"].ToString(),
                    atributo1 = usuario["Atributo1"].ToString(),
                    atributo2 = usuario["Atributo2"].ToString()

                };
                listaUsuarios.Add(u);
            }
            return Ok(listaUsuarios);
        }
        catch (Exception ex)
        {
            return InternalServerError(new Exception($"Error al listar los usuarios: {ex.Message}", ex));
        }
    }

        [Route("api/Usuario/CrearUsuario")]
        [HttpPost]
        public IHttpActionResult CrearUsuario(ModeloApiUsuario usuario)
    {
        try
        {
            if (string.IsNullOrEmpty(usuario.email) ||
                string.IsNullOrEmpty(usuario.nombre) ||
                string.IsNullOrEmpty(usuario.apellido) ||
                string.IsNullOrEmpty(usuario.telefono) ||
                string.IsNullOrEmpty(usuario.contrasena) ||
                string.IsNullOrEmpty(usuario.fechaNacimiento) ||
                string.IsNullOrEmpty(usuario.apodo))
            {
                return BadRequest("Complete todos los campos.");
            }
            if (string.IsNullOrEmpty(usuario.idioma))
            {
                usuario.idioma = "espanol";
            }
            ControladorCuentaUsuario.AltaCuentaUsuario(
                usuario.nombre, usuario.apellido, usuario.fechaNacimiento,
                usuario.email, usuario.telefono, usuario.contrasena
            );

            ControladorCuentaUsuario.CrearPerfil(usuario.apodo, usuario.email, usuario.idioma);

            Dictionary<string, string> resultado = new Dictionary<string, string>
    {
        { "mensaje", "Usuario creado exitosamente" }
    };
            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return InternalServerError(new Exception($"Error al crear el usuario o el perfil: {ex.Message}", ex));
        }
    }

        [Route("api/Usuario/Login")]
        [HttpPost]
        public IHttpActionResult Login(ModeloApiUsuario login)
    {
        try
        {
                if (ControladorCuentaUsuario.Login(login.email, login.contrasena) == false)
                {
                    return NotFound();
                }
                return Ok(new { mensaje = "Inicio de sesión exitoso" });
            }
        catch (Exception ex)
        {
            return InternalServerError(new Exception($"Ocurrió un error durante el inicio de sesión.: {ex.Message}", ex));
        }
    }

        [Route("api/Usuario/ModificarUsuario/{id:int}")]
        [HttpPut]
        public IHttpActionResult ModificarUsuario(int id, ModeloApiUsuario usuario)
    {
        try
        {
            if (
                string.IsNullOrEmpty(usuario.email) ||
                string.IsNullOrEmpty(usuario.apodo) ||
                string.IsNullOrEmpty(usuario.atributo1) ||
                string.IsNullOrEmpty(usuario.atributo2) ||
                string.IsNullOrEmpty(usuario.contrasena))
            {
                return BadRequest("Complete todos los campos.");
            }
            if (string.IsNullOrEmpty(usuario.idioma))
            {
                usuario.idioma = "espanol";
            }
            ControladorCuentaUsuario.ModificarPerfil(
                usuario.email, usuario.apodo, usuario.idFotoPerfil, usuario.idioma, usuario.atributo1, usuario.atributo2, usuario.contrasena
            );
            Dictionary<string, string> resultado = new Dictionary<string, string>
    {
        { "mensaje", "Usuario modificado exitosamente" }
    };

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return InternalServerError(new Exception($"Error al modificar el usuario: {ex.Message}", ex));
        }
    }

        [Route("api/Usuario/DeshabilitarUsuario/{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeshabilitaCuentaUsuario(int id)
        {  
                Dictionary<string, string> resultado = new Dictionary<string, string>();
                ControladorCuentaUsuario.DeshabilitaCuentaUsuario(id);
                resultado.Add("mensaje", "Usuario deshabilitado exitosamente");
                return Ok(resultado);
        }

        [Route("api/Usuario/HabilitarUsuario{id:int}")]
        [HttpDelete]
        public IHttpActionResult HabilitarCuentaUsuario(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorCuentaUsuario.HabilitaCuentaUsuario(id);
            resultado.Add("mensaje", "Usuario habilitado exitosamente");
            return Ok(resultado);
        }

        /*[Route("api/Usuario/BuscarUsuario/{id:int}")]
        [HttpGet]
        public IHttpActionResult BuscarUsuarioPorId(int id)
        {
            Dictionary<string, string> datosUsuario = ControladorCuentaUsuario.BuscarPorId(id);
            if (datosUsuario != null && datosUsuario.ContainsKey("resultado") && datosUsuario["resultado"] == "true")
            {
                ModeloApiUsuario usuario = new ModeloApiUsuario();
                usuario.idUsuario = Int32.Parse(datosUsuario["id_usuario"]);
                usuario.nombre = datosUsuario["nombre"];
                usuario.apellido = datosUsuario["apellido"];
                usuario.telefono = datosUsuario["telefono"];
                usuario.email = datosUsuario["email"];
                usuario.fechaNacimiento = datosUsuario["fecha_nacimiento"];
                if (datosUsuario.ContainsKey("habilitado"))
                {
                    usuario.habilitacion = Boolean.Parse(datosUsuario["habilitado"]);
                }
                return Ok(usuario);
            }
            return NotFound();
        }*/
    }
}
