using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Controladores;
using System.Data;
using ApiEventos.Models;
using System;

namespace ApiEventos.Controllers
{
    public class EventoController : ApiController
    {
        [Route("api/Evento/ListarEventos")]
        [HttpGet]
        public IHttpActionResult ListarEventos()
        {
            List<ModeloApiEventos> listaEventos = new List<ModeloApiEventos>();
            try
            {
                DataTable evento = ControladorEventos.ListarEventos();

                foreach (DataRow eventos in evento.Rows)
                {
                    ModeloApiEventos me = new ModeloApiEventos();
                    me.idEvento = Int32.Parse(eventos["id_eventos"].ToString());
                    me.nombreEvento = eventos["nombre_evento"].ToString();
                    me.informacion = eventos["informacion"].ToString();
                    me.lugar = eventos["lugar"].ToString();
                    me.fechaEvento = eventos["fecha_evento"].ToString();
                    listaEventos.Add(me);
                }

                return Ok(listaEventos);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al listar los eventos.", ex));
            }
        }

        [Route("api/Evento/CrearEventos")]
        [HttpPost]
        public IHttpActionResult CrearEventos(ModeloApiEventos evento)
        {
            if (evento == null || string.IsNullOrEmpty(evento.informacion))
            {
                return BadRequest("El contenido del post es requerido.");
            }
            try
            {
                ControladorEventos.CrearEvento(evento.idPerfil, evento.nombreEvento, evento.informacion, evento.lugar, evento.fechaEvento);
                Dictionary<string, string> resultado = new Dictionary<string, string>
                {
                    { "mensaje", "Evento creado exitosamente" }
                };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al crear el evento.", ex));
            }
        }

        [Route("api/Evento/ModificarEvento/{id:int}")]
        [HttpPut]
        public IHttpActionResult ModificarEvento(int id, ModeloApiEventos evento)
        {
            if (evento == null || string.IsNullOrEmpty(evento.informacion))
            {
                return BadRequest("El contenido del evento es requerido.");
            }
            try
            {
                ControladorEventos.ModificarEvento(id.ToString(), evento.nombreEvento, evento.informacion, evento.lugar, evento.fechaEvento);
                Dictionary<string, string> resultado = new Dictionary<string, string>
            {
                { "mensaje", "Evento modificado exitosamente" }
            };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al modificar el evento.", ex));
            }
        }


        [Route("api/Evento/DesabilitarEvento{id:int}")]
        [HttpDelete]
        public IHttpActionResult DesabilitarEvento(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            try
            {
                ControladorEventos.DeshabilitarEvento(id);
                resultado.Add("mensaje", "Evento deshabilitado exitosamente");
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al deshabilitar el evento.", ex));
            }
        }

        [Route("api/Evento/HabilitarEvento{id:int}")]
        [HttpDelete]
        public IHttpActionResult HabilitarEvento(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();

            try
            {
                ControladorEventos.HabilitarEvento(id);
                resultado.Add("mensaje", "Evento habilitado exitosamente");
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al habilitar el evento.", ex));
            }
        }

        [Route("api/Evento/BuscarEvento/{id:int}")]
        [HttpGet]
        public IHttpActionResult BuscarEvento(int id)
        {
            ModeloApiEventos evento = new ModeloApiEventos();
            Dictionary<string, string> datosEvento = ControladorEventos.BuscarEventoPorId(id);

            if (datosEvento != null && datosEvento["resultado"] == "true")
            {
                evento.idEvento = Int32.Parse(datosEvento["id_evento"]);
                evento.idPerfil = Int32.Parse(datosEvento["id_cuenta"]);
                evento.nombreEvento = datosEvento["nombre_evento"];
                evento.lugar = datosEvento["lugar"];
                evento.informacion = datosEvento["informacion"];
                evento.fechaEvento = datosEvento["fecha_evento"];
                if (datosEvento.ContainsKey("habilitado"))
                {
                    evento.habilitado = Boolean.Parse(datosEvento["habilitado"]);
                }
                return Ok(evento);
            }
            return NotFound();
        }


    }
}