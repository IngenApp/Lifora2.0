using System;
using System.Collections.Generic;
using System.Data;
using Modelo;

namespace Controladores
{
    public class ControladorPost
    {
        public static void DeshabilitarPost(int id)
        {
            try
            {
                ModeloPost post = new ModeloPost { idPost = id };
                post.DeshabilitarPost();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deshabilitar el post: {ex.Message}");
            }
        }

        public static void HabilitarPost(int id)
        {
            try
            {
                ModeloPost post = new ModeloPost { idPost = id };
                post.HabilitarPost();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al habilitar el post: {ex.Message}");
            }
        }

        public static DataTable ListarPost(int idCuenta)
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_post", typeof(int));
            tabla.Columns.Add("texto_post", typeof(string));
            tabla.Columns.Add("contador_like", typeof(int));
            tabla.Columns.Add("habilitado", typeof(bool));

            try
            {
                ModeloPost modeloPost = new ModeloPost();
                List<ModeloPost> posts = modeloPost.ObtenerPostUsuario(idCuenta);

                foreach (ModeloPost p in posts)
                {
                    DataRow fila = tabla.NewRow();
                    fila["id_post"] = p.idPost;
                    fila["texto_post"] = p.post;
                    fila["contador_like"] = p.like;
                    fila["habilitado"] = p.habilitado;
                    tabla.Rows.Add(fila);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar los posts: {ex.Message}");
            }

            return tabla;
        }

    }
}

