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
        public List<ModeloApiEventos> Get()
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
        public IHttpActionResult Post(ModeloApiEventos evento)
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
        public IHttpActionResult Put(int id, ModeloApiEventos evento)
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
        public IHttpActionResult Delete(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorEventos.DeshabilitarEvento(id);
            resultado.Add("mensaje", "Evento deshabilitado exitosamente");
            return Ok(resultado);
        }




        /*
        [Route("api/Eventos/BuscarPost/{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ModeloApiEventos post = new ModeloApiEventos();
            Dictionary<string, string> datosPost = ControladorEventos.BuscarPostPorId(id);

            if (datosPost != null && datosPost["resultado"] == "true")
            {
                post.idPost = Int32.Parse(datosPost["id_post"]);
                post.idCuenta = Int32.Parse(datosPost["id_cuenta"]);
                post.post = datosPost["texto_post"];
                post.like = Int32.Parse(datosPost["contador_like"]);
                post.comentarios = Int32.Parse(datosPost["contador_comentarios"]);
                post.fecha = datosPost["fecha"];
                if (datosPost.ContainsKey("habilitado"))
                {
                    post.habilitado = Boolean.Parse(datosPost["habilitado"]);
                }
                return Ok(post);
            }
            return NotFound();
        }
        */
    }
}