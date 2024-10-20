using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiGrupo.Models;
using System.Web.Http;
using Controladores;
using System.Data;
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