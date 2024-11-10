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

        [Route("api/Post/ModificarPost/{id:int}")]
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

        [Route("api/Post/DeshabilitarPost/{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeshabilitarPost(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            try
            {
                ControladorPost.DeshabilitarPost(id);
                resultado.Add("mensaje", "Post deshabilitado exitosamente");
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                resultado.Add("error", ex.Message);
                return InternalServerError(new Exception("Error al deshabilitar el post.", ex));
            }
        }

        [Route("api/Post/HabilitarPost/{id:int}")]
        [HttpPut] 
        public IHttpActionResult HabilitarPost(int id)
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();
            try
            {
                ControladorPost.HabilitarPost(id);

                resultado.Add("mensaje", "Post habilitado exitosamente");
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                resultado.Add("error", ex.Message);  
                return InternalServerError(new Exception("Error al habilitar el post.", ex));
            }
        }



        [Route("api/Post/CrearPostTexto")]
        [HttpPost]
        public IHttpActionResult CrearPostTexto(ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.descripcion))
            {
                return BadRequest("El contenido del post es requerido.");
            }

            try
            {
                ControladorPost.CrearPostTexto(post.idPerfil, post.descripcion);

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

        [Route("api/Post/CrearPostImagen")]
        [HttpPost]
        public IHttpActionResult CrearPostImagen(ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.descripcion) || string.IsNullOrEmpty(post.idImagen))
            {
                return BadRequest("El contenido del post y la imagen son requeridos.");
            }
            try
            {
                ControladorPost.CrearPostImagen(post.idPerfil, post.descripcion, post.idImagen);

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

        [Route("api/Post/CrearPostVideo")]
        [HttpPost]
        public IHttpActionResult CrearPostVideo(ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.descripcion) || string.IsNullOrEmpty(post.idVideo))
            {
                return BadRequest("El contenido del post y el video son requeridos.");
            }
            try
            {
                ControladorPost.CrearPostVideo(post.idPerfil, post.descripcion, post.idVideo);

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

        [Route("api/Post/CrearPostAudio")]
        [HttpPost]
        public IHttpActionResult CrearPostAudio(ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.descripcion) || string.IsNullOrEmpty(post.idAudio))
            {
                return BadRequest("El contenido del post y el audio son requeridos.");
            }
            try
            {
                ControladorPost.CrearPostAudio(post.idPerfil, post.descripcion, post.idAudio);

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

       
        
        
        [Route("api/Post/DarLike")]
        [HttpPost]
        public IHttpActionResult DarLike(ModeloApiPost like)
        {
            if (like == null || like.idPost <= 0 || like.idPerfil <= 0)
            {
                return BadRequest("Datos inválidos para dar like.");
            }
            try
            {
                ControladorPost.DarLike(like.idPost, like.idPerfil);
                return Ok(new { mensaje = "Like registrado correctamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al registrar el like.", ex));
            }
        }

        [Route("api/Post/EliminarLike")]
        [HttpPost]
        public IHttpActionResult EliminarLike(ModeloApiPost like)
        {
            if (like == null || like.idPost <= 0 || like.idPerfil <= 0)
            {
                return BadRequest("Datos inválidos para eliminar el like.");
            }
            try
            {
                ControladorPost.EliminarLike(like.idPost, like.idPerfil);
                return Ok(new { mensaje = "Like eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al eliminar el like.", ex));
            }
        }

        [Route("api/Post/ContarLikes/{id:int}")]
        [HttpGet]
        public IHttpActionResult ContarLikes(int id)
        {
            try
            {
                int cantidad = ControladorPost.ContarLikes(id);
                return Ok(new { cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al contar los likes.", ex));
            }
        }

        [Route("api/Post/ComentarPost")]
        [HttpPost]
        public IHttpActionResult ComentarPost(ModeloApiPost comentario)
        {
            if (comentario == null || string.IsNullOrEmpty(comentario.comentario) || comentario.idPost <= 0 || comentario.idPerfil <= 0)
            {
                return BadRequest("Datos inválidos para comentar.");
            }
            try
            {
                ControladorPost.ComentarPost(comentario.idPost.ToString(), comentario.idPerfil.ToString(), comentario.comentario);
                return Ok(new { mensaje = "Comentario agregado exitosamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al comentar el post.", ex));
            }
        }



        [Route("api/Post/ContarComentarios/{id:int}")]
        [HttpGet]
        public IHttpActionResult ContarComentarios(int id)
        {
            try
            {
                int cantidad = ControladorPost.ContarComentarios(id);
                return Ok(new { cantidad });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al contar los comentarios.", ex));
            }
        }

        [Route("api/Post/DeshabilitarComentario/{id:int}")]
        [HttpPut]
        public IHttpActionResult DeshabilitarComentario(int id)
        {
            try
            {
                ControladorPost.DeshabilitarComentario(id);
                return Ok(new { mensaje = "Comentario deshabilitado exitosamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al deshabilitar el comentario.", ex));
            }
        }

        [Route("api/Post/HabilitarComentario/{id:int}")]
        [HttpPut]
        public IHttpActionResult HabilitarComentario(int id)
        {
            try
            {
                ControladorPost.HabilitarComentario(id);
                return Ok(new { mensaje = "Comentario habilitado exitosamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al habilitar el comentario.", ex));
            }
        }

        [Route("api/Post/ModificarComentario")]
        [HttpPut]
        public IHttpActionResult ModificarComentario(ModeloApiPost comentario)
        {
            if (comentario == null || string.IsNullOrEmpty(comentario.comentario) || comentario.idComentario <= 0)
            {
                return BadRequest("Datos inválidos para modificar el comentario.");
            }
            try
            {
                ControladorPost.ModificarComentario(comentario.idComentario.ToString(), comentario.comentario);
                return Ok(new { mensaje = "Comentario modificado exitosamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al modificar el comentario.", ex));
            }
        }
                
        [Route("api/Post/CompartirPost/{idPost:int}/{idPerfil:int}")]
        [HttpPost]
        public IHttpActionResult CompartirPost(int idPost, int idPerfil)
        {
            if (idPost <= 0 || idPerfil <= 0)
            {
                return BadRequest("Datos inválidos para compartir el post.");
            }
            try
            {
                ControladorPost.CompartirPost(idPost, idPerfil);
                return Ok(new { mensaje = "Post compartido con éxito" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al compartir el post: {ex.Message}", ex));
            }
        }


      
        
        
        [Route("api/Post/ObtenerTexto/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult ObtenerPostTexto(int idPerfil)
        {
            try
            {
                var posts = ControladorPost.ObtenerPostTexto(idPerfil);
                return Ok(posts); 
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al obtener publicaciones de texto: {ex.Message}", ex));
            }
        }

        [Route("api/Post/ObtenerImagen/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult ObtenerPostImagen(int idPerfil)
        {
            try
            {
                var posts = ControladorPost.ObtenerPostImagen(idPerfil);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al obtener publicaciones con imágenes: {ex.Message}", ex));
            }
        }

        [Route("api/Post/ObtenerVideo/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult ObtenerPostVideo(int idPerfil)
        {
            try
            {
                var posts = ControladorPost.ObtenerPostVideo(idPerfil);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al obtener publicaciones con video: {ex.Message}", ex));
            }
        }

        [Route("api/Post/ObtenerAudio/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult ObtenerPostAudio(int idPerfil)
        {
            try
            {
                var posts = ControladorPost.ObtenerPostAudio(idPerfil);
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception($"Error al obtener publicaciones con audio: {ex.Message}", ex));
            }
        }





    }
}
