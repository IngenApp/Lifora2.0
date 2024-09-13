using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Controladores;
using System.Data;
using ApiPost.Models;
using System;

namespace ApiPost.Controllers
{
    public class PostController : ApiController
    {
        [Route("api/Lifora/ListarPost")]
        [HttpGet]
        public List<ModeloApiPost> Get()
        {
            DataTable posts = ControladorPost.ListarPost();
            List<ModeloApiPost> listaPosts = new List<ModeloApiPost>();

            foreach (DataRow post in posts.Rows)
            {
                ModeloApiPost p = new ModeloApiPost();
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
        public IHttpActionResult Post(ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.post))
            {
                return BadRequest("El contenido del post es requerido.");
            }

            ControladorPost.CrearPost(post.idCuenta, post.post);

            var resultado = new Dictionary<string, string>
            {
                { "mensaje", "Post creado exitosamente" }
            };

            return Ok(resultado);
        }


        [Route("api/Lifora/ModificarUsuario{id:int}")]
        [HttpPut]
        public IHttpActionResult Put(int id, ModeloApiPost post)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorPost.ModificarPost(id.ToString(), post.post);
            ControladorPost.ModificarIdCuenta(id.ToString(), post.idCuenta.ToString());
            ControladorPost.ModificarFecha(id.ToString(), post.fecha);

            resultado.Add("mensaje", "Usuario modificado exitosamente");
            return Ok(resultado);
        }




    }
}
