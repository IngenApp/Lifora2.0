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
        [Route("api/Eventos/ListarEventos")]
        [HttpGet]
        public List<ModeloApiEventos> ListarEventos()
        {
            DataTable evento = ControladorEventos.ListarEventos();
            List<ModeloApiEventos> listaEventos = new List<ModeloApiEventos>();

            foreach (DataRow eventos in evento.Rows)
            {
                ModeloApiEventos me = new ModeloApiEventos();
                me.id_evento = Int32.Parse(eventos["id_eventos"].ToString());
                me.nombre_evento = eventos["nombre_evento"].ToString();
                me.informacion = eventos["informacion"].ToString();
                me.lugar = eventos["lugar"].ToString();
                me.fecha_evento = eventos["fecha_evento"].ToString();
                listaEventos.Add(me);
            }
            return listaEventos;
        }

        [Route("api/Eventos/CrearEventos")]
        [HttpPost]
        public IHttpActionResult CrearEventos(ModeloApiEventos evento)
        {
            if (evento == null || string.IsNullOrEmpty(evento.informacion))
            {
                return BadRequest("El contenido del post es requerido.");
            }

            ControladorEventos.CrearEvento(evento.id_cuenta, evento.nombre_evento, evento.informacion, evento.lugar, evento.fecha_evento);
            Dictionary<string,string> resultado = new Dictionary<string, string>
            {
                { "mensaje", "Evento creado exitosamente" }
            };
            return Ok(resultado);
        }

        [Route("api/Eventos/ModificarEvento{id:int}")]
        [HttpPut]
        public IHttpActionResult ModificarEvento(int id, ModeloApiEventos evento)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorEventos.ModificarNombreEvento(id, evento.nombre_evento);
            ControladorEventos.ModificarInformacionEvento(id, evento.informacion);
            ControladorEventos.ModificarLugarEvento(id, evento.lugar.ToString());
            ControladorEventos.ModificarFechaEvento(id, evento.fecha_evento);
            resultado.Add("mensaje", "Evento modificado exitosamente");
            return Ok(resultado);
        }
       
        [Route("api/Eventos/DesabilitarEvento{id:int}")]
        [HttpDelete]
        public IHttpActionResult DesabilitarEvento(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorEventos.DeshabilitarEvento(id);
            resultado.Add("mensaje", "Evento deshabilitado exitosamente");
            return Ok(resultado);
        }
       
        [Route("api/Eventos/BuscarEvento/{id:int}")]
        [HttpGet]
        public IHttpActionResult BuscarEvento(int id)
        {
            ModeloApiEventos evento = new ModeloApiEventos(); 
            Dictionary<string, string> datosEvento = ControladorEventos.BuscarEventoPorId(id);

            if (datosEvento != null && datosEvento["resultado"] == "true")
            {
                evento.id_evento = Int32.Parse(datosEvento["id_evento"]);
                evento.id_cuenta = Int32.Parse(datosEvento["id_cuenta"]);
                evento.nombre_evento = datosEvento["nombre_evento"];
                evento.lugar = datosEvento["lugar"];
                evento.informacion = datosEvento["informacion"];
                evento.fecha_evento = datosEvento["fecha_evento"];
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