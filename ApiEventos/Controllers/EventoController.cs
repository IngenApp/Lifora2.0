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
        [Route("api/Lifora/ListarPost")]
        [HttpGet]
        public List<ModeloApiEventos> Get()
        {
            DataTable posts = ControladorEventos.ListarEventos();
            List<ModeloApiEventos> listaPosts = new List<ModeloApiEventos>();

            foreach (DataRow post in posts.Rows)
            {
                ModeloApiEventos p = new ModeloApiEventos();
                p.idPost = Int32.Parse(post["id"].ToString());
                p.idCuenta = Int32.Parse(post["cuenta"].ToString());
                p.post = post["post"].ToString();
                p.fecha = post["fecha"].ToString();
                p.like = Int32.Parse(post["like"].ToString());
                p.habilitado = Boolean.Parse(post["habilitado"].ToString());

                listaPosts.Add(p);
            }
            return listaPosts;
        }

        [Route("api/Lifora/CrearPost")]
        [HttpPost]
        public IHttpActionResult Post(ModeloApiEventos post)
        {
            if (post == null || string.IsNullOrEmpty(post.post))
            {
                return BadRequest("El contenido del post es requerido.");
            }

            ControladorEventos.CrearPost(post.idCuenta, post.post);
            var resultado = new Dictionary<string, string>
            {
                { "mensaje", "Post creado exitosamente" }
            };
            return Ok(resultado);
        }

        [Route("api/Lifora/ModificarPost{id:int}")]
        [HttpPut]
        public IHttpActionResult Put(int id, ModeloApiEventos post)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorEventos.ModificarPost(id.ToString(), post.post);
            ControladorEventos.ModificarIdCuenta(id.ToString(), post.idCuenta.ToString());
            ControladorEventos.ModificarFecha(id.ToString(), post.fecha);
            resultado.Add("mensaje", "Post modificado exitosamente");
            return Ok(resultado);
        }

        [Route("api/Lifora/DesabilitarPost{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorEventos.DeshabilitarPost(id);
            resultado.Add("mensaje", "Post deshabilitado exitosamente");
            return Ok(resultado);
        }

        [Route("api/Lifora/BuscarPost/{id:int}")]
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
    }
}