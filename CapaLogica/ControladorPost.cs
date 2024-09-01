using System;
using System.Collections.Generic;
using System.Data;
using Modelo;

namespace Controladores
{
    public class ControladorPost
    {
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

            tabla.Columns.Add("id_post", typeof(int));
            tabla.Columns.Add("texto_post", typeof(string));
            tabla.Columns.Add("contador_like", typeof(int));
            tabla.Columns.Add("habilitado", typeof(bool));
            tabla.Columns.Add("id_cuenta", typeof(string));

            ModeloPost ListarPost = new ModeloPost();
            foreach (ModeloPost p in ListarPost.ObtenerPost())
            {
                DataRow fila = tabla.NewRow();

                fila["id_post"] = p.idPost;
                fila["texto_post"] = p.post;
                fila["contador_like"] = p.like;
                fila["habilitado"] = p.habilitado;
                fila["id_cuenta"] = p.idCuenta;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }

    }
}

