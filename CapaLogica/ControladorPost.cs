using System;
using System.Collections.Generic;
using System.Data;
using Modelo;

namespace Controladores
{
    public class ControladorPost
    {
        public static void CrearPost(int idCuenta, string postear)
        {
            ModeloPost CreaPost = new ModeloPost();
            CreaPost.idCuenta = idCuenta;
            CreaPost.post = postear;
            CreaPost.CrearPost();
        }
        public static void ModificarPostBackoffice(string idPost, string post)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(idPost);
            ModPostBO.post = post;
            ModPostBO.ModificarPostBackOffice();
        }
        public static void ModificarIdPostBackoffice(string id, string IdPost)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(id);
            ModPostBO.idPost = Int32.Parse(IdPost);
            ModPostBO.ModificarPostBackOffice();
        }
        public static void ModificarIdCuentaBackoffice(string idPost, string IdCuenta)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(idPost);
            ModPostBO.idCuenta = Int32.Parse(IdCuenta);
            ModPostBO.ModificarPostBackOffice();
        }
        public static void ModificarFechaBackoffice(string idPost, string fecha)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(idPost);
            ModPostBO.fecha = fecha;
            ModPostBO.ModificarPostBackOffice();
        }
        public static void ModificarLikeBackoffice(string idPost, string like)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(idPost);
            ModPostBO.like = Int32.Parse(like);
            ModPostBO.ModificarPostBackOffice();
        }
        public static void ModificarPostBackoffice(string post, string idPost, string idCuenta, string fecha, string like)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.post = post;
            ModPostBO.idPost = Int32.Parse(idPost);
            ModPostBO.idCuenta = Int32.Parse(idCuenta);
            ModPostBO.fecha = fecha;
            ModPostBO.like = Int32.Parse(like);
            ModPostBO.ModificarPostUsuarioBackoffice();
        }
        public static void DeshabilitarPost(int idPost)
        {
            ModeloPost DeshabilitarPost = new ModeloPost();
            DeshabilitarPost.idPost = idPost;
            DeshabilitarPost.DeshabilitarPost();
        }
        public static void HabilitarPost(int idPost)
        {
            ModeloPost HabilitarPost = new ModeloPost ();
            HabilitarPost.idPost = idPost;
            HabilitarPost.HabilitarPost();
        }
        public static DataTable ListarPost()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("id", typeof(int));
            tabla.Columns.Add("cuenta", typeof(string));
            tabla.Columns.Add("post", typeof(string));
            tabla.Columns.Add("fecha", typeof(string));
            tabla.Columns.Add("like", typeof(int));
            tabla.Columns.Add("habilitado", typeof(bool));

            ModeloPost ListarPost = new ModeloPost();
            foreach (ModeloPost p in ListarPost.ObtenerPost())
            {
                DataRow fila = tabla.NewRow();

                fila["id"] = p.idPost;
                fila["cuenta"] = p.idCuenta;
                fila["post"] = p.post;
                fila["fecha"] = p.fecha;
                fila["like"] = p.like;
                fila["habilitado"] = p.habilitado;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
        public static void ComentarPost(int idPost, int idCuenta, string comentar)
        {
            ModeloPost ComentarPost = new ModeloPost();
            ComentarPost.idPost = idPost;
            ComentarPost.idCuenta = idCuenta;
            ComentarPost.textoComentarios = comentar;
            ComentarPost.ComentarPost();
        }
        public static DataTable ListarComentarios(int idPost)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("IdComentarios", typeof(int));
            tabla.Columns.Add("Usuario", typeof(string));
            tabla.Columns.Add("Comentario", typeof(string));
            tabla.Columns.Add("fecha", typeof(string));
            tabla.Columns.Add("post", typeof(string));
            ModeloPost modelo = new ModeloPost();
            foreach (ModeloPost p in modelo.ObtenerComentarios(idPost))
            {
                DataRow fila = tabla.NewRow();
                fila["IdComentarios"] = p.comentarios;
                fila["Usuario"] = p.nombre;
                fila["Comentario"] = p.textoComentarios;
                fila["fecha"] = p.fecha;
                fila["post"] = p.post;

                tabla.Rows.Add(fila);
            }
            return tabla;
        }



    }
}

