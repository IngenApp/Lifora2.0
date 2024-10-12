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
        public static void ModificarIdPost(string id, string IdPost)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(id);
            ModPostBO.idPost = Int32.Parse(IdPost);
            ModPostBO.ModificarIdPost();
        }
        public static void ModificarIdCuenta(string idPost, string IdCuenta)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(idPost);
            ModPostBO.idPerfil = Int32.Parse(IdCuenta);
            ModPostBO.ModificarIdCuenta();
        }
        public static void ModificarFecha(string idPost, string fecha)
        {
            ModeloPost ModPostBO = new ModeloPost();
            ModPostBO.idPost = Int32.Parse(idPost);
            ModPostBO.fecha = fecha;
            ModPostBO.ModificarFecha();
        }
        public static void DarLike(int idPost, int idCuenta)
        {
            ModeloPost modeloPost = new ModeloPost();
            modeloPost.idPost = idPost;
            modeloPost.DarLike(idCuenta);
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
        public static void ComentarPost(int idPost, int idCuenta, string comentar)
        {
            ModeloPost ComentarPost = new ModeloPost();
            ComentarPost.idPost = idPost;
            ComentarPost.idPerfil = idCuenta;
            //ComentarPost.textoComentarios = comentar;
            ComentarPost.ComentarPost();
        }
        public static Dictionary<string, string> BuscarPostPorId(int id)
        {
            ModeloPost post = new ModeloPost();
            post.idPost = id;
            return post.ObtenerDatosPostPorId();
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
            tabla.Columns.Add("ID", typeof(int));
            tabla.Columns.Add("Usuario", typeof(string));
            tabla.Columns.Add("Comentario", typeof(string));
            tabla.Columns.Add("Fecha", typeof(string));
            tabla.Columns.Add("Post", typeof(string));
            tabla.Columns.Add("Like", typeof(int));
            tabla.Columns.Add("Habilitado", typeof(bool));
            //ModeloPost ListarComentarios = new ModeloPost();
            //foreach (ModeloPost p in ListarComentarios.ObtenerComentarios(idPost))
            {
                //DataRow fila = tabla.NewRow();
               // fila["ID"] = p.comentarios;
               // fila["Usuario"] = p.nombre;
               // fila["Comentario"] = p.textoComentarios;
                //fila["Fecha"] = p.fecha;
               // fila["Post"] = p.post;
               // fila["Like"] = p.contadorLike;
                //fila["Habilitado"] = p.habilitado;

                //tabla.Rows.Add(fila);
            }
            return tabla;
        }
        public static void DeshabilitarComentario(int comentarios)
        {
            ModeloPost DeshabilitarComentario = new ModeloPost();
            //DeshabilitarComentario.comentarios = comentarios;
            DeshabilitarComentario.DeshabilitarComentario();
        }
        public static void HabilitarComentario(int comentarios)
        {
            ModeloPost HabilitarComentario = new ModeloPost();
           // HabilitarComentario.comentarios = comentarios;
            HabilitarComentario.HabilitarComentario();
        }

    }
}

