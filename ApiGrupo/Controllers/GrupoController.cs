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
        public List<ModeloApiGrupo> Get()
        {
            DataTable grupo = ControladorGrupos.ListarGrupos();
            List<ModeloApiGrupo> listarGrupos = new List<ModeloApiGrupo>();
          
            foreach (DataRow grupos in grupo.Rows)
            {
                ModeloApiGrupo mag = new ModeloApiGrupo();
                mag.idGrupo = Int32.Parse(grupos["idGrupo"].ToString());
                mag.nombre = grupos["nombre"].ToString();
                mag.descripcion = grupos["descripcion"].ToString();
                mag.fecha = grupos["fecha"].ToString();
                mag.habilitado = bool.Parse(grupos["habilitado"].ToString());
                listarGrupos.Add(mag);
            }
            return listarGrupos;
        }
    }
}