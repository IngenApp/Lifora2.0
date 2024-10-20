using System;
using System.Collections.Generic;
using System.Data;
using Modelo;

namespace Controladores
{
    public class ControladorPost 
    {
        public static void CrearPost(int idPerfil, string descripcion)
        {
            ModeloPost CreaPost = new ModeloPost();
            CreaPost.idPerfil = idPerfil;
            CreaPost.descripcion = descripcion;
            CreaPost.CrearPost();
        }
        public static void ModificarPost(string idPost, string descripcion)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(idPost);
            ModPostBO.descripcion = descripcion;
            ModPostBO.ModificarPost();
        }
        public static void DarLike(int idPost, int idPerfil)
        {
            ModeloPost modeloPost = new ModeloPost();
            modeloPost.idPost = idPost;
            modeloPost.DarLike(idPerfil, idPost);
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
            foreach (ModeloPost p in ListarComentarios.ObtenerComentarios(idPost))
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

    }
}

