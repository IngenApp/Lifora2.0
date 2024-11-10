using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Controladores;
using ApiLifora.Models;
using System.Data;


namespace ApiLifora.Controllers
{
    public class UsuarioController : ApiController
    {


        [Route("api/Usuario/{email}/")]
        [HttpGet]
        public IHttpActionResult ObtenerPerfilPorMail(string email)
        {
            Dictionary<string, string> perfil = ControladorCuentaUsuario.ObtenerPerfilPorMail(email);

            if (perfil == null || !perfil.Any())
                return NotFound();

            return Ok(perfil);

        }


        [Route("api/Usuario/MeSiguen/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult MeSiguen(int idPerfil)
        {
            try
            {
                List<string> seguidores = ControladorCuentaUsuario.ObtenerSeguidores(idPerfil);

                if (seguidores == null || seguidores.Count == 0)
                    return NotFound();

                return Ok(seguidores);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Ocurrió un error al obtener los seguidores: {ex.Message}", ex));
            }
        }


        [Route("api/Usuario/CantidadSeguidores/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult ObtenerCantidadSeguidores(int idPerfil)
        {
            try
            {
                int cantidadSeguidores = ControladorCuentaUsuario.ObtenerCantidadSeguidores(idPerfil);

                if (cantidadSeguidores < 0)
                    return NotFound();

                return Ok(new { cantidadSeguidores });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Ocurrió un error al obtener la cantidad de seguidores: {ex.Message}", ex));
            }
        }

        [Route("api/Usuario/Sigo/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult Seguidos(int idPerfil)
        {
            try
            {
                List<string> seguidos = ControladorCuentaUsuario.ObtenerSeguidos(idPerfil);
                if (seguidos == null || seguidos.Count == 0)
                    return NotFound();

                return Ok(seguidos);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Ocurrio un error al obtener los seguidos: {ex.Message}", ex));
            }
        }

        [Route("api/Usuario/CantidadSeguidos/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult ObtenerCantidadSeguidos(int idPerfil)
        {
            try
            {
                int cantidadSeguidos = ControladorCuentaUsuario.ObtenerCantidadSeguidos(idPerfil);

                if (cantidadSeguidos < 0)
                    return NotFound();

                return Ok(new { cantidadSeguidos });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Ocurrió un error al obtener la cantidad de seguidos: {ex.Message}", ex));
            }
        }










        [Route("api/Usuario/ModificarPerfil/{email}")]
        [HttpPut]
        public IHttpActionResult ModificarUsuario(string email, ModeloApiUsuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.apodo))
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


        [Route("api/Usuario/ModificarCuenta/{id:int}")]
        [HttpPut]
        public IHttpActionResult ModificarCuenta(int id, ModeloApiUsuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.email))
                {
                    return BadRequest("El campo 'email' es obligatorio.");
                }
                usuario.emailNuevo = string.IsNullOrEmpty(usuario.emailNuevo) ? usuario.email : usuario.email;

                ControladorCuentaUsuario.ModificarCuenta(
                    usuario.email, usuario.emailNuevo, usuario.nombre, usuario.apellido, usuario.telefono
                    );
                Dictionary<string, string> resultado = new Dictionary<string, string>
        {
            { "mensaje", "Cuenta modificada exitosamente" }
        };

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al modificar la cuenta: {ex.Message}", ex));
            }
        }






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






        /*    [Route("api/Usuario/ModificarUsuario/{id:int}/")]
            [HttpPut]
            public IHttpActionResult ModificarPerfil(string email, ModeloApiUsuario usuario)
            {
                try
                {
                    if (string.IsNullOrEmpty(usuario.apodo))
                    {
                        return BadRequest("Complete todos los campos obligatorios: email, nombre, apellido, apodo y contrasena.");
                    }
                    if (string.IsNullOrEmpty(usuario.idioma))
                    {
                        usuario.idioma = "espanol"; 
                    }
                    ControladorCuentaUsuario.ModificarPerfil(
                        usuario.email,
                        usuario.apodo,
                        usuario.idFotoPerfil,
                        usuario.idioma,
                        usuario.atributo1,
                        usuario.atributo2,
                        usuario.contrasena
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
        */



        [Route("api/Usuario/DeshabilitarUsuario/{id:int}")]
        [HttpPut]
        public IHttpActionResult DeshabilitaCuentaUsuario(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorCuentaUsuario.DeshabilitaCuentaUsuario(id);
            resultado.Add("mensaje", "Usuario deshabilitado exitosamente");
            return Ok(resultado);
        }


        [Route("api/Usuario/HabilitarUsuario{id:int}")]
        [HttpPut]
        public IHttpActionResult HabilitarCuentaUsuario(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorCuentaUsuario.HabilitaCuentaUsuario(id);
            resultado.Add("mensaje", "Usuario habilitado exitosamente");
            return Ok(resultado);
        }





    }
}
