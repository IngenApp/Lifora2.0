using System;
using System.Collections.Generic;
using System.Data;
using Modelo;

namespace Controladores
{

    public class ControladorPost
    {

        public static void CompartirPost(int idPost, int idPerfil)
        {
            try
            {
                ModeloPost modeloPost = new ModeloPost();
                modeloPost.CompartirPost(idPost, idPerfil);
                Console.WriteLine("El post ha sido compartido correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al compartir el post: {ex.Message}");
            }
        }

        public static List<ModeloPost> ObtenerPostTexto(int idPerfil)
        {
            try
            {
                ModeloPost modelo = new ModeloPost();
                return modelo.ObtenerPostTexto(idPerfil); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener publicaciones de texto: " + ex.Message);
                return new List<ModeloPost>(); 
            }
        }


        public static List<ModeloPost> ObtenerPostImagen(int idPerfil)
        {
            try
            {
                ModeloPost modelo = new ModeloPost();
                modelo.idPerfil = idPerfil;  
                return modelo.ObtenerPostImagen();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener publicaciones con imágenes: " + ex.Message);
                return new List<ModeloPost>();  
            }
        }

        public static List<ModeloPost> ObtenerPostVideo(int idPerfil)
        {
            try
            {
                ModeloPost modelo = new ModeloPost();
                modelo.idPerfil = idPerfil;  
                return modelo.ObtenerPostVideo();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener publicaciones con video: " + ex.Message);
                return new List<ModeloPost>(); 
            }
        }

        public static List<ModeloPost> ObtenerPostAudio(int idPerfil)
        {
            try
            {
                ModeloPost modelo = new ModeloPost();
                modelo.idPerfil = idPerfil; 
                return modelo.ObtenerPostAudio();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener publicaciones con audio: " + ex.Message);
                return new List<ModeloPost>();  
            }
        }


        public static void CrearPostTexto(int idPerfil, string descripcion)
        {
            ModeloPost CreaPost = new ModeloPost();
            CreaPost.idPerfil = idPerfil;
            CreaPost.descripcion = descripcion;
            CreaPost.CrearPostTexto();
        }
        public static void CrearPostImagen(int idPerfil, string descripcion, string idImagen)
        {
            ModeloPost CreaPost = new ModeloPost();
            CreaPost.idPerfil = idPerfil;
            CreaPost.descripcion = descripcion;
            CreaPost.idImagen = idImagen;
            CreaPost.CrearPostImagen();
        }
        public static void CrearPostVideo(int idPerfil, string descripcion, string idVideo)
        {
            ModeloPost CreaPost = new ModeloPost();
            CreaPost.idPerfil = idPerfil;
            CreaPost.descripcion = descripcion;
            CreaPost.idVideo = idVideo;
            CreaPost.CrearPostVideo();
        }
        public static void CrearPostAudio(int idPerfil, string descripcion, string idAudio)
        {
            ModeloPost CreaPost = new ModeloPost();
            CreaPost.idPerfil = idPerfil;
            CreaPost.descripcion = descripcion;
            CreaPost.idAudio = idAudio;
            CreaPost.CrearPostAudio();
        }

        public static void ModificarPost(string idPost, string nuevaDescripcion)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(idPost);
            ModPostBO.descripcion = nuevaDescripcion;
            ModPostBO.ModificarPost();
        }
        public static void DeshabilitarPost(int idPost)
        {
            ModeloPost DeshabilitarPost = new ModeloPost();
            DeshabilitarPost.idPost = idPost;
            DeshabilitarPost.DeshabilitarPost();
        }
        public static void HabilitarPost(int idPost)
        {
            ModeloPost HabilitarPost = new ModeloPost();
            HabilitarPost.idPost = idPost;
            HabilitarPost.HabilitarPost();
        }

        public static void DarLike(int idPost, int idPerfil)
        {
            ModeloPost modeloPost = new ModeloPost();
            try
            {
                modeloPost.DarLike(idPost, idPerfil);
                Console.WriteLine("Like registrado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el like: {ex.Message}");
            }
        }

        public static void EliminarLike(int idPost, int idPerfil)
        {
            ModeloPost modeloPost = new ModeloPost();
            try
            {
                modeloPost.EliminarLike(idPost, idPerfil);
                Console.WriteLine("Like eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el like: {ex.Message}");
            }
        }

        public static int ContarLikes(int idPost)
        {   
            ModeloPost modeloPost = new ModeloPost();
            modeloPost.idPost = idPost;
            return  modeloPost.ContarLikes();    
        }

        public static void ComentarPost(string idPost, string idPerfil, string comentario)
        {
            ModeloPost ComentarPost = new ModeloPost();
            int postID, perfilID;
            if (!Int32.TryParse(idPost, out postID))
            {
                throw new Exception("El ID del post no es válido.");
            }

            if (!Int32.TryParse(idPerfil, out perfilID))
            {
                throw new Exception("El ID del perfil no es válido.");
            }
            ComentarPost.idPost = postID;
            ComentarPost.idPerfil = perfilID;
            ComentarPost.comentario = comentario;
            ComentarPost.ComentarPost();
        }
        public static int ContarComentarios(int idPost)
        {
            ModeloPost modeloPost = new ModeloPost();
            modeloPost.idPost = idPost;
            return modeloPost.ContarComentarios();
        }
        public static void DeshabilitarComentario(int idComentario)
        {
            ModeloPost DeshabilitarComentario = new ModeloPost();
            DeshabilitarComentario.idComentario = idComentario;
            DeshabilitarComentario.DeshabilitarComentario();
        }
        public static void HabilitarComentario(int idComentario)
        {
            ModeloPost HabilitarComentario = new ModeloPost();
            HabilitarComentario.idComentario = idComentario;
            HabilitarComentario.HabilitarComentario();
        }
        public static void ModificarComentario(string idComentario, string comentario)
        {
            ModeloPost ModificarComentario = new ModeloPost();
            ModificarComentario.idComentario = Int32.Parse(idComentario);
            ModificarComentario.comentario = comentario;
            ModificarComentario.ModificarComentario();
        }


        public static DataTable ListarPost()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID_Post", typeof(string));
            tabla.Columns.Add("Descripcion", typeof(string));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Habilitado", typeof(bool));
            tabla.Columns.Add("Apodo", typeof(string));
            tabla.Columns.Add("ID_Perfil", typeof(int));

            ModeloPost ListarPost = new ModeloPost();

            foreach (ModeloPost p in ListarPost.ObtenerPost())
            {
                DataRow fila = tabla.NewRow();
                fila["ID_Post"] = p.idPost;
                fila["Apodo"] = p.apodo;
                fila["ID_Perfil"] = p.idPerfil;
                fila["Descripcion"] = p.descripcion;
                fila["Habilitado"] = p.habilitado;
                fila["Fecha"] = p.fecha;
                tabla.Rows.Add(fila);
            }

            return tabla;
        }
        // ANDRES
        //realizar metodo para tomar los datos de los post texto, video, imagen y audio necesarios para mostrar en pantalla por API

   

        public static DataTable ListarComentarios(string idPost)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID_Comentario", typeof(string));
            tabla.Columns.Add("Comentario", typeof(string));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Habilitado", typeof(bool));
            tabla.Columns.Add("Apodo", typeof(string));
            tabla.Columns.Add("ID_perfil", typeof(string));

            ModeloPost ListarComentarios = new ModeloPost();
            ListarComentarios.idPost = Int32.Parse(idPost);
            foreach (ModeloPost p in ListarComentarios.ObtenerComentarios())
            {
                DataRow fila = tabla.NewRow();
                fila["ID_Comentario"] = p.idComentario;
                fila["Comentario"] = p.comentario;
                fila["Fecha"] = p.fecha;
                fila["Habilitado"] = p.habilitado;
                fila["Apodo"] = p.apodo;
                fila["ID_Perfil"] = p.idPerfil;
               

                tabla.Rows.Add(fila);
            }
            return tabla;
        }

    }
}

