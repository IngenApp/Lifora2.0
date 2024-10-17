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
        [Route("api/Post/ListarPost")]
        [HttpGet]
        public IHttpActionResult ListarPost()
        {
            List<ModeloApiPost> listaPosts = new List<ModeloApiPost>();
            try
            {
                DataTable posts = ControladorPost.ListarPost();
                foreach (DataRow post in posts.Rows)
                {
                    ModeloApiPost p = new ModeloApiPost();
                    p.idPost = Int32.Parse(post["id_post"].ToString());
                    p.descripcion = post["descripcion"].ToString();
                    p.fecha = post["fecha"].ToString();
                    p.habilitado = bool.Parse(post["habilitado"].ToString());
                    p.apodo = post["apodo"].ToString();
                    p.idPerfil = Int32.Parse(post["id_perfil"].ToString());

                    listaPosts.Add(p);
                }

                return Ok(listaPosts);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al listar los posts.", ex));
            }
        }

        [Route("api/Post/CrearPost")]
        [HttpPost]
        public IHttpActionResult CrearPost(ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.descripcion))
            {
                return BadRequest("El contenido del post es requerido.");
            }
            try
            {
                ControladorPost.CrearPost(post.idPerfil, post.descripcion);
                Dictionary<string, string> resultado = new Dictionary<string, string>
        {
            { "mensaje", "Post creado exitosamente" }
        };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al crear el post.", ex));
            }
        }

        [Route("api/Post/ModificarPost{id:int}")]
        [HttpPut]
        public IHttpActionResult ModificarPost(int id, ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.descripcion))
            {
                return BadRequest("El contenido del post es requerido.");
            }
            try
            {
                ControladorPost.ModificarPost(id.ToString(), post.descripcion);
                Dictionary<string, string> resultado = new Dictionary<string, string>
        {
            { "mensaje", "Post modificado exitosamente" }
        };
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al modificar el post.", ex));
            }
        }


        /*[Route("api/Post/DesabilitarPost{id:int}")]
        [HttpDelete]
        public IHttpActionResult DesabilitarPost(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            ControladorPost.DeshabilitarPost(id);
            resultado.Add("mensaje", "Post deshabilitado exitosamente");
            return Ok(resultado);
        }

        [Route("api/Post/BuscarPost/{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ModeloApiPost post = new ModeloApiPost();
            Dictionary<string, string> datosPost = ControladorPost.BuscarPostPorId(id);

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
