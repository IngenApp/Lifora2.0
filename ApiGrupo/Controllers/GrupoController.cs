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
                    ModeloApiGrupo mag = new ModeloApiGrupo
                    {
                        IdGrupo = grupos["ID_Grupo"] != DBNull.Value ? Convert.ToInt32(grupos["ID_Grupo"]) : 0,
                        Nombre = grupos["Nombre_Grupo"].ToString(),
                        Informacion = grupos["Informacion"].ToString(),
                        Fecha = grupos["Fecha"].ToString(),
                        IdPerfil = grupos["ID_Perfil"] != DBNull.Value ? Convert.ToInt32(grupos["ID_Perfil"]) : 0
                    };

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
                if (grupo.IdPerfil <= 0 ||
                    string.IsNullOrWhiteSpace(grupo.Nombre) ||
                    string.IsNullOrWhiteSpace(grupo.Informacion))
                {
                    return BadRequest("Complete todos los campos.");
                }
                ControladorGrupos.CrearGrupo(grupo.IdPerfil, grupo.Nombre, grupo.Informacion);

                return Ok(new { mensaje = "Grupo creado exitosamente" });
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
                if (unirseGrupo.IdGrupo <= 0 || unirseGrupo.IdPerfil <= 0)
                {
                    return BadRequest("El ID de grupo y el ID de perfil deben ser mayores a cero.");
                }
                ControladorGrupos.UnirseAGrupo(unirseGrupo.IdGrupo, unirseGrupo.IdPerfil, unirseGrupo.silenciar); 

                return Ok(new { mensaje = "Te has unido al grupo exitosamente" });
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
                return Ok(new { cantidad });
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
                if (salirDeGrupo.IdGrupo <= 0 || salirDeGrupo.IdPerfil <= 0)
                {
                    return BadRequest("El ID de grupo y el ID de perfil deben ser mayores a cero.");
                }
                ControladorGrupos.SalirDeGrupo(salirDeGrupo.IdGrupo, salirDeGrupo.IdPerfil);

                return Ok(new { mensaje = "Has salido del grupo exitosamente" });
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
                if (silenciarGrupo.IdGrupo <= 0 || silenciarGrupo.IdPerfil <= 0)
                {
                    return BadRequest("El ID de grupo y el ID de perfil deben ser mayores a cero.");
                }
                ControladorGrupos.SilenciarGrupo(silenciarGrupo.IdGrupo, silenciarGrupo.IdPerfil, silenciarGrupo.dFotoGrupo == "true");

                return Ok(new { mensaje = silenciarGrupo.dFotoGrupo == "true" ? "Grupo silenciado exitosamente" : "Grupo des-silenciado exitosamente" });
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
                return InternalServerError(new Exception($"Error al buscar el grupo por ID: {ex.Message}", ex));
            }
        }

        [Route("api/Grupo/ModificarGrupo/{id:int}")]
        [HttpPut]
        public IHttpActionResult ModificarGrupo(int id, ModeloApiGrupo grupo)
        {
            try
            {
                if (string.IsNullOrEmpty(grupo.IdGrupo.ToString()) ||
                    string.IsNullOrEmpty(grupo.Nombre) ||
                    string.IsNullOrEmpty(grupo.Informacion) ||
                    string.IsNullOrEmpty(grupo.dFotoGrupo))
                {
                    return BadRequest("Complete todos los campos.");
                }
                ControladorGrupos.ModificarGrupo(grupo.IdGrupo, grupo.Nombre, grupo.Informacion, grupo.dFotoGrupo);
                return Ok(new { mensaje = "Grupo modificado exitosamente" });
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
            try
            {
                ControladorGrupos.BloquearGrupo(id);
                return Ok(new { mensaje = "Grupo bloqueado exitosamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al bloquear el grupo.", ex));
            }
        }

        [Route("api/Grupo/DesbloquearGrupo/{id:int}")]
        [HttpDelete]
        public IHttpActionResult DesbloquearGrupo(int id)
        {
            try
            {
                ControladorGrupos.HabilitarGrupo(id);
                return Ok(new { mensaje = "Grupo desbloqueado exitosamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al desbloquear el grupo.", ex));
            }
        }

    }
}