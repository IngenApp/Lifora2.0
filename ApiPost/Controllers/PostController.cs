using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Controladores;
using System.Data;
using System;
using ApiPost.Models;

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
                    ModeloApiPost p = new ModeloApiPost
                    {
                        IdPost = Int32.Parse(post["id_post"].ToString()),
                        Descripcion = post["descripcion"].ToString(),
                        Fecha = post["fecha"].ToString(),
                        Habilitado = bool.Parse(post["habilitado"].ToString()),
                        Apodo = post["apodo"].ToString(),
                        IdPerfil = Int32.Parse(post["id_perfil"].ToString())
                    };

                    listaPosts.Add(p);
                }

                return Ok(listaPosts);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al listar los posts.", ex));
            }
        }

        [Route("api/Post/ObtenerTexto/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult ObtenerTextoPost(int idPerfil)
        {
            List<ModeloApiPost> listaPosts = new List<ModeloApiPost>();
            try
            {
                DataTable posts = ControladorPost.ObtenerTextoPost(idPerfil);
                foreach (DataRow post in posts.Rows)
                {
                    ModeloApiPost p = new ModeloApiPost
                    {
                        IdPost = Int32.Parse(post["id_post"].ToString()),
                        Descripcion = post["descripcion"].ToString(),
                        Fecha = post["fecha"].ToString(),
                        Apodo = post["apodo"].ToString(),
                        IdPerfil = Int32.Parse(post["id_perfil"].ToString())
                    };

                    listaPosts.Add(p);
                }

                return Ok(listaPosts);
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al listar los posts.", ex));
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

        [Route("api/Post/DarLike")]
        [HttpPost]
        public IHttpActionResult DarLike(ModeloApiPost like)
        {
            if (like == null || like.IdPost <= 0 || like.IdPerfil <= 0)
            {
                return BadRequest("Datos inválidos para dar like.");
            }
            try
            {
                ControladorPost.DarLike(like.IdPost, like.IdPerfil);
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
            if (like == null || like.IdPost <= 0 || like.IdPerfil <= 0)
            {
                return BadRequest("Datos inválidos para eliminar el like.");
            }
            try
            {
                ControladorPost.EliminarLike(like.IdPost, like.IdPerfil);
                return Ok(new { mensaje = "Like eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al eliminar el like.", ex));
            }
        }

        [Route("api/Post/VerificarSiDioLike")]
        [HttpPost]
        public IHttpActionResult VerificarSiDioLike(ModeloApiPost like)
        {
            if (like == null || like.IdPost <= 0 || like.IdPerfil <= 0)
            {
                return BadRequest("Datos inválidos para verificar el like.");
            }

            try
            {
                bool yaDioLike = ControladorPost.VerificarSiDioLike(like.IdPost, like.IdPerfil);
                return Ok(new { yaDioLike });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al verificar si dio like.", ex));
            }
        }

        [Route("api/Post/ComentarPost")]
        [HttpPost]
        public IHttpActionResult ComentarPost(ModeloApiPost comentario)
        {
            if (comentario == null || string.IsNullOrEmpty(comentario.Comentario) || comentario.IdPost <= 0 || comentario.IdPerfil <= 0)
            {
                return BadRequest("Datos inválidos para comentar.");
            }
            try
            {
                ControladorPost.ComentarPost(comentario.IdPost.ToString(), comentario.IdPerfil.ToString(), comentario.Comentario);
                return Ok(new { mensaje = "Comentario agregado exitosamente" });
            }
            catch (Exception ex)
            {
                return InternalServerError(new Exception("Error al comentar el post.", ex));
            }
        }

        [Route("api/Post/CrearPostTexto")]
        [HttpPost]
        public IHttpActionResult CrearPostTexto(ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.Descripcion)) // Propiedad con auto-property
            {
                return BadRequest("El contenido del post es requerido.");
            }

            try
            {
                ControladorPost.CrearPostTexto(post.IdPerfil, post.Descripcion);

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

        [Route("api/Post/ModificarPost/{id:int}")]
        [HttpPut]
        public IHttpActionResult ModificarPost(int id, ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.Descripcion)) 
            {
                return BadRequest("El contenido del post es requerido.");
            }
            try
            {
                ControladorPost.ModificarPost(id.ToString(), post.Descripcion);
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

        [Route("api/Post/CrearPostImagen")]
        [HttpPost]
        public IHttpActionResult CrearPostImagen(ModeloApiPost post)
        {
            if (post == null || string.IsNullOrEmpty(post.Descripcion) || string.IsNullOrEmpty(post.IdImagen)) 
            {
                return BadRequest("El contenido del post y la imagen son requeridos.");
            }
            try
            {
                ControladorPost.CrearPostImagen(post.IdPerfil, post.Descripcion, post.IdImagen);

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
            if (post == null || string.IsNullOrEmpty(post.Descripcion) || string.IsNullOrEmpty(post.IdVideo)) 
            {
                return BadRequest("El contenido del post y el video son requeridos.");
            }
            try
            {
                ControladorPost.CrearPostVideo(post.IdPerfil, post.Descripcion, post.IdVideo);

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
            if (post == null || string.IsNullOrEmpty(post.Descripcion) || string.IsNullOrEmpty(post.IdAudio)) 
            {
                return BadRequest("El contenido del post y el audio son requeridos.");
            }
            try
            {
                ControladorPost.CrearPostAudio(post.IdPerfil, post.Descripcion, post.IdAudio);

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
            if (comentario == null || string.IsNullOrEmpty(comentario.Comentario) || comentario.IdComentario <= 0)
            {
                return BadRequest("Datos inválidos para modificar el comentario.");
            }
            try
            {
                ControladorPost.ModificarComentario(comentario.IdComentario.ToString(), comentario.Comentario);
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











        [Route("api/Post/ObtenerImagen/{idPerfil:int}")]
        [HttpGet]
        public IHttpActionResult ObtenerPostImagen(int idPerfil)
        {
            try
            {
                var posts = ControladorPost.ObtenerPostImagen(idPerfil);
                return Ok(posts);              }
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
