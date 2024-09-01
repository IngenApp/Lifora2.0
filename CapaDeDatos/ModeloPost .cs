using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class ModeloPost : Modelo
    {
        public int idPost;
        public int idUsuario;
        public int idCuenta;
        public string post;
        public int like;
        public int comentarios;
        public string habilitado;

        public void DeshabilitarPost()
        {
            string sql = "UPDATE post SET texto_post = CONCAT(texto_post, ' [BLOQUEADO]') WHERE id_post = @id_post";

            using (MySqlCommand comando = new MySqlCommand(sql, this.Conexion))
            {
                comando.Parameters.AddWithValue("@id_post", this.idPost);
                comando.ExecuteNonQuery();
            }
        }

        public void HabilitarPost()
        {
            string sql = "UPDATE post SET texto_post = TRIM(REPLACE(texto_post, ' [BLOQUEADO]', '')) WHERE id_post = @id_post";

            using (MySqlCommand comando = new MySqlCommand(sql, this.Conexion))
            {
                comando.Parameters.AddWithValue("@id_post", this.idPost);
                comando.ExecuteNonQuery();
            }
        }

        public List<ModeloPost> ObtenerPostUsuario(int idUsuario)
        {
            List<ModeloPost> bd = new List<ModeloPost>();

            string sql = "SELECT * FROM post WHERE id_usuario = @idUsuario AND habilitado = 'true'";

            using (MySqlCommand command = new MySqlCommand(sql, this.Conexion))
            {
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    using (MySqlDataReader lector = command.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            ModeloPost mp = new ModeloPost
                            {
                                post = lector["texto_post"].ToString(),
                                like = Convert.ToInt32(lector["contador_like"]),
                                idPost = Convert.ToInt32(lector["id_post"]),
                                idUsuario = Convert.ToInt32(lector["id_usuario"]),
                                idCuenta = Convert.ToInt32(lector["id_cuenta"]),
                                habilitado = lector["habilitado"].ToString()
                            };
                            bd.Add(mp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener los posts del usuario: " + ex.Message);
                }
            }

            return bd;
        }

    }
}




