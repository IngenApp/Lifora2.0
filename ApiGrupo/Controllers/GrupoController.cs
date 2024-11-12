using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Controladores;
using System.Data;
using System.Web.Routing;
using ApiGrupo.Models;
using ApiPost.Models;

namespace ApiGrupo.Controllers
{
    public class GrupoController : ApiController
    {
        [Route("api/Grupo/ListarGrupos")]
        [HttpGet]
        public IHttpActionResult ListarGrupos()
        {
            try
            {
                DataTable grupo = ControladorGrupos.ListarGrupos();
                List<ModeloApiGrupo> listarGrupos = new List<ModeloApiGrupo>();

                foreach (DataRow grupos in grupo.Rows)
                {
                    ModeloApiGrupo mag = new ModeloApiGrupo();
                    mag.idGrupo = Int32.Parse(grupos["ID_Grupo"].ToString());
                    mag.nombre = grupos["Nombre_Grupo"].ToString();
                    mag.informacion = grupos["Informacion"].ToString();
                    mag.fecha = grupos["Fecha"].ToString();
                    mag.habilitado = bool.Parse(grupos["Habilitado"].ToString());
                    mag.idPerfil = Int32.Parse(grupos["ID_Perfil"].ToString());
                    listarGrupos.Add(mag);
                }

                return Ok(listarGrupos);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Ocurrió un error al listar los grupos.", ex));
            }
        }

        [Route("api/Grupo/CrearGrupo")]
        [HttpPost]
        public IHttpActionResult CrearGrupo(ModeloApiGrupo grupo)
        {
            try
            {
                if (grupo.idPerfil <= 0 ||
                    string.IsNullOrWhiteSpace(grupo.nombre) ||
                    string.IsNullOrWhiteSpace(grupo.informacion))
                {
                    return BadRequest("Complete todos los campos.");
                }
                ControladorGrupos.CrearGrupo(grupo.idPerfil, grupo.nombre, grupo.informacion);
                var resultado = new Dictionary<string, string>
        {
            { "mensaje", "Grupo creado exitosamente" }
        };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al crear el grupo: {ex.Message}", ex));
            }
        }


        [Route("api/Grupo/UnirseAGrupo")]
        [HttpPost]
        public IHttpActionResult UnirseAGrupo(ModeloApiGrupo unirseGrupo)
        {
            try
            {
                if (unirseGrupo.idGrupo <= 0 || unirseGrupo.idPerfil <= 0)
                {
                    return BadRequest("El ID de grupo y el ID de perfil deben ser mayores a cero.");
                }
                ControladorGrupos.UnirseAGrupo(unirseGrupo.idGrupo, unirseGrupo.idPerfil, unirseGrupo.silenciar);

                var resultado = new Dictionary<string, string>
        {
            { "mensaje", "Te has unido al grupo exitosamente" }
        };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al unirse al grupo: {ex.Message}", ex));
            }
        }

        [Route("api/Grupo/ObtenerCantidadDeIntegrantes/{idGrupo}")]
        [HttpGet]
        public IHttpActionResult ObtenerCantidadDeIntegrantes(int idGrupo)
        {
            try
            {
                int cantidad = ControladorGrupos.ObtenerCantidadDeIntegrantes(idGrupo);
                return Ok(new { cantidad = cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al obtener la cantidad de integrantes: {ex.Message}", ex));
            }
        }

        [Route("api/Grupo/ObtenerApodoDeIntegrantes/{idGrupo}")]
        [HttpGet]
        public IHttpActionResult ObtenerApodoDeIntegrantes(int idGrupo)
        {
            try
            {
                List<string> nombres = ControladorGrupos.ObtenerApodoDeIntegrantes(idGrupo);

                if (nombres == null || !nombres.Any())
                {
                    return NotFound();
                }

                return Ok(nombres);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al obtener los nombres de los integrantes: {ex.Message}", ex));
            }
        }

        [Route("api/Grupo/SalirDeGrupo")]
        [HttpPost]
        public IHttpActionResult SalirDeGrupo(ModeloApiGrupo salirDeGrupo)
        {
            try
            {
                if (salirDeGrupo.idGrupo <= 0 || salirDeGrupo.idPerfil <= 0)
                {
                    return BadRequest("El ID de grupo y el ID de perfil deben ser mayores a cero.");
                }
                ControladorGrupos.SalirDeGrupo(salirDeGrupo.idGrupo, salirDeGrupo.idPerfil);

                var resultado = new Dictionary<string, string>
        {
            { "mensaje", "Has salido del grupo exitosamente" }
        };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al salir del grupo: {ex.Message}", ex));
            }
        }

        [Route("api/Grupo/SilenciarGrupo")]
        [HttpPost]
        public IHttpActionResult SilenciarGrupo(ModeloApiGrupo silenciarGrupo)
        {
            try
            {
                if (silenciarGrupo.idGrupo <= 0 || silenciarGrupo.idPerfil <= 0)
                {
                    return BadRequest("El ID de grupo y el ID de perfil deben ser mayores a cero.");
                }
                ControladorGrupos.SilenciarGrupo(silenciarGrupo.idGrupo, silenciarGrupo.idPerfil, silenciarGrupo.silenciar);

                var resultado = new Dictionary<string, string>
        {
            { "mensaje", silenciarGrupo.silenciar ? "Grupo silenciado exitosamente" : "Grupo des-silenciado exitosamente" }
        };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al silenciar el grupo: {ex.Message}", ex));
            }
        }

        [Route("api/Grupo/BuscarGrupoPorNombre/{nombre}")]
        [HttpGet]
        public IHttpActionResult BuscarGrupoPorNombre(string nombre)
        {
            try
            {
                Dictionary<string, string> grupo = ControladorGrupos.BuscarGrupoPorNombre(nombre);
                if (grupo == null || !grupo.Any())
                    return NotFound();

                return Ok(grupo);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al buscar el grupo por nombre: {ex.Message}", ex));
            }
        }

        [Route("api/Grupo/BuscarGrupoPorId/{id:int}")]
        [HttpGet]
        public IHttpActionResult BuscarGrupoPorId(int id)
        {
            try
            {
                    Dictionary<string, string> grupo = ControladorGrupos.BuscarGrupoPorId(id);
                    if (grupo == null || !grupo.Any())
                        return NotFound();

                    return Ok(grupo);
                }
                catch (Exception ex)
                {
                    return InternalServerError(new Exception($"Error al buscar el grupo por nombre: {ex.Message}", ex));
                }
            }


/*
        [Route("api/Post/AsociarPostAGrupo")]
        [HttpPost]
        public IHttpActionResult AsociarPostAGrupo(ModeloApiPost post)
        {
            ModeloApiGrupo modeloApiGrupo = new ModeloApiGrupo();
            try
            {
                if (modeloApiGrupo.idGrupo <= 0 || post.idPost <= 0)
                {
                    return BadRequest("El ID del grupo y el ID del post deben ser mayores a cero.");
                }

                ControladorGrupos.AsociarPostAGrupo(modeloApiGrupo.idGrupo, post.idPost);

                var resultado = new Dictionary<string, string>
                {
                    { "mensaje", "El post ha sido asociado al grupo exitosamente." }
                };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al asociar el post al grupo: {ex.Message}", ex));
            }
        }

        [Route("api/Post/EliminarPostDeGrupo")]
        [HttpPost]
        public IHttpActionResult EliminarPostDeGrupo(ModeloApiPost post)
        {
            ModeloApiGrupo modeloApiGrupo = new ModeloApiGrupo();
            try
            {
                if (modeloApiGrupo.idGrupo <= 0 || post.idPost <= 0)
                {
                    return BadRequest("El ID del grupo y el ID del post deben ser mayores a cero.");
                }

                ControladorGrupos.EliminarPostDeGrupo(modeloApiGrupo.idGrupo, post.idPost);

                var resultado = new Dictionary<string, string>
                {
                    { "mensaje", "El post ha sido eliminado del grupo exitosamente." }
                };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al eliminar el post del grupo: {ex.Message}", ex));
            }
        }

        [Route("api/Post/ObtenerPostsDeGrupo/{idGrupo}")]
        [HttpGet]
        public IHttpActionResult ObtenerPostsDeGrupo(int idGrupo)
        {
            try
            {
                List<int> posts = ControladorGrupos.ObtenerPostsDeGrupo(idGrupo);

                if (posts == null || !posts.Any())
                {
                    return NotFound();
                }

                return Ok(posts);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al obtener los posts del grupo: {ex.Message}", ex));
            }
        }

        [Route("api/Post/EsPostDeGrupo")]
        [HttpGet]
        public IHttpActionResult EsPostDeGrupo(int idGrupo, int idPost)
        {
            try
            {
                bool esPost = ControladorGrupos.EsPostDeGrupo(idGrupo, idPost);
                return Ok(new { esPost = esPost });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al verificar si el post pertenece al grupo: {ex.Message}", ex));
            }
        }
*/



        [Route("api/Grupo/ModificarGrupo/{id:int}")]
        [HttpPut]
        public IHttpActionResult ModificarGrupo(int id, ModeloApiGrupo grupo)
        {
            try
            {
                if (
                    string.IsNullOrEmpty(grupo.idGrupo.ToString()) ||
                    string.IsNullOrEmpty(grupo.nombre) ||
                    string.IsNullOrEmpty(grupo.informacion) ||
                    string.IsNullOrEmpty(grupo.idFotoGrupo.ToString()))
                {
                    return BadRequest("Complete todos los campos.");
                }
                ControladorGrupos.ModificarGrupo(grupo.idGrupo, grupo.nombre, grupo.informacion, grupo.idFotoGrupo);
                Dictionary<string, string> resultado = new Dictionary<string, string>
    {
        { "mensaje", "Grupo modificado exitosamente" }
    };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al modificar el grupo: {ex.Message}", ex));
            }
        }


        [Route("api/Grupo/BloquearGrupo/{id:int}")]
        [HttpDelete]
        public IHttpActionResult BloquearGrupo(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            try
            {
                ControladorGrupos.BloquearGrupo(id);
                resultado.Add("mensaje", "Grupo bloquear exitosamente");
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al bloquar el grupo.", ex));
            }

        }

        [Route("api/Grupo/DesbloquearGrupo{id:int}")]
        [HttpDelete]
        public IHttpActionResult DesbloquearGrupo(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            try
            {
                ControladorGrupos.HabilitarGrupo(id);
                resultado.Add("mensaje", "Grupo Desbloqueado exitosamente");
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al Desbloquear el grupo.", ex));
            }
        }

    }
}