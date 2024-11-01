using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class ModeloPost : Modelo
    {
        public int idPost, idPerfil, idComentario;
        public string post, descripcion, apodo, fecha, comentario, idImagen, idVideo, idAudio;
        public bool habilitado, comparteHabilitado;
        public DateTime fechaHora, fechaComparte;


        public void CrearPostTexto()
        {
            string sql = $"insert into post (id_perfil, descripcion, fecha_hora) values(@id_perfil, @descripcion, now()); insert into texto (id_post) values (last_insert_id()); commit;";
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Parameters.AddWithValue("@descripcion", descripcion);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void CrearPostImagen()
        {
            string sql = $"insert into post (id_perfil, descripcion, fecha_hora) values(@id_perfil, @descripcion, now()); insert into multimedia (id_post) values (last_insert_id()); insert into imagen (id_post, id_imagen) values (last_insert_id(), @id_imagen)); commit;";
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Parameters.AddWithValue("@descripcion", descripcion);
            this.Comando.Parameters.AddWithValue("@id_imagen", idImagen);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void CrearPostVideo()
        {
            string sql = $"insert into post (id_perfil, descripcion, fecha_hora) values(@id_perfil, @descripcion, now()); insert into multimedia (id_post) values (last_insert_id()); insert into video (id_post, id_video) values (last_insert_id(), @id_video)); commit;";
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Parameters.AddWithValue("@descripcion", descripcion);
            this.Comando.Parameters.AddWithValue("@id_video", idVideo);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void CrearPostAudio()
        {
            string sql = $"insert into post (id_perfil, descripcion, fecha_hora) values(@id_perfil, @descripcion, now()); insert into multimedia (id_post) values (last_insert_id()); insert into audio (id_post, id_audio) values (last_insert_id(), @id_audio)); commit;";
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Parameters.AddWithValue("@descripcion", descripcion);
            this.Comando.Parameters.AddWithValue("@id_audio", idAudio);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }


        public void ModificarPost()
        {
            string sql = $"UPDATE post SET descripcion = @descripcion WHERE id_post = @id_post; commit;";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@descripcion", descripcion);
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void DeshabilitarPost()
        {
            string sql = $"UPDATE post SET habilitado = false WHERE id_post = @id_post; commit;";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarPost()
        {
            string sql = $"update post set habilitado = true where id_post = @id_post; commit;";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.ExecuteNonQuery();
        }


        public void DarLike()
        {
           
            string sqlInsert = $"INSERT INTO likes (id_post, id_perfil, fecha) VALUES (@id_post, @id_perfil, NOW()); commit;";
            this.Comando.CommandText = sqlInsert;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.ExecuteNonQuery();

        }
        public void EliminarLike()
        {
            string sql = "DELETE FROM likes WHERE id_post = @id_post AND id_perfil = @id_perfil; commit;";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.ExecuteNonQuery();
        }
        public int ContarLikes()
        {
            string sql = "SELECT COUNT(*) FROM likes WHERE id_post = @id_post;";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            int contadorLikes = Convert.ToInt32(this.Comando.ExecuteScalar());
            return contadorLikes;
        }
        //mostrar likes

 

        public List<ModeloPost> ObtenerPost()
        {
            List<ModeloPost> ListaPost = new List<ModeloPost>();

            string sql = "SELECT p.id_post, p.descripcion, p.fecha_hora, p.habilitado, pf.apodo, pf.id_perfil FROM post p LEFT JOIN perfil pf ON p.id_perfil = pf.id_perfil";

            this.Comando.CommandText = sql;
            using (this.Lector = this.Comando.ExecuteReader())
            {
                while (this.Lector.Read())
                {
                    ModeloPost mp = new ModeloPost
                    {
                        idPost = Convert.ToInt32(this.Lector["id_post"]),
                        descripcion = this.Lector["descripcion"].ToString(),
                        fecha = this.Lector["fecha_hora"].ToString(),
                        habilitado = Convert.ToBoolean(this.Lector["habilitado"]),
                        apodo = this.Lector["apodo"].ToString(),
                        idPerfil = Convert.ToInt32(this.Lector["id_perfil"])
                    };

                    ListaPost.Add(mp);
                }
            } 

            return ListaPost;

        }
        public List<ModeloPost> ObtenerPostTexto()
        {
            List<ModeloPost> ListaPost = new List<ModeloPost>();

            string sql = @"
        SELECT 
            p.id_post, 
            p.descripcion, 
            p.fecha_hora, 
            p.habilitado, 
            pf.apodo, 
            pf.id_perfil 
        FROM 
            post p 
        JOIN 
            texto t ON p.id_post = t.id_post 
        LEFT JOIN 
            perfil pf ON p.id_perfil = pf.id_perfil 
        WHERE 
            p.habilitado = TRUE AND p.id_perfil= @id_perfil;";

            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            using (this.Lector = this.Comando.ExecuteReader())
            {
                while (this.Lector.Read())
                {
                    ModeloPost mp = new ModeloPost
                    {
                        idPost = Convert.ToInt32(this.Lector["id_post"]),
                        descripcion = this.Lector["descripcion"].ToString(),
                        fecha = this.Lector["fecha_hora"].ToString(),
                        habilitado = Convert.ToBoolean(this.Lector["habilitado"]),
                        apodo = this.Lector["apodo"] != DBNull.Value ? this.Lector["apodo"].ToString() : string.Empty, 
                        idPerfil = Convert.ToInt32(this.Lector["id_perfil"])
                    };

                    ListaPost.Add(mp);
                }
            }
            return ListaPost;
        }
        public List<ModeloPost> ObtenerPostImagen()
        {
            List<ModeloPost> ListaPost = new List<ModeloPost>();

            string sql = @"
        SELECT 
            p.id_post,
            p.descripcion,
            p.habilitado,
            p.fecha_hora,
            m.id_imagen,
            c.habilitado AS comparte_habilitado,
            c.fecha_hora AS fecha_comparte
        FROM post p
        LEFT JOIN imagen m ON p.id_post = m.id_post
        LEFT JOIN comparte c ON p.id_post = c.id_post AND c.id_perfil = p.id_perfil
        WHERE p.habilitado = TRUE AND p.id_perfil = @id_perfil order by p.fecha_hora and fecha_comparte;";

            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);

            using (this.Lector = this.Comando.ExecuteReader())
            {
                while (this.Lector.Read())
                {
                    ModeloPost mp = new ModeloPost
                    {
                        idPost = Convert.ToInt32(this.Lector["id_post"]),
                        descripcion = this.Lector["descripcion"].ToString(),
                        habilitado = Convert.ToBoolean(this.Lector["habilitado"]),
                        fechaHora = Convert.ToDateTime(this.Lector["fecha_hora"]),
                        idImagen = this.Lector["id_imagen"] != DBNull.Value ? this.Lector["id_imagen"].ToString() : null,
                        comparteHabilitado = this.Lector["comparte_habilitado"] != DBNull.Value ? Convert.ToBoolean(this.Lector["comparte_habilitado"]) : false,
                        fechaComparte = Convert.ToDateTime(this.Lector["fecha_comparte"]),
                    };

                    ListaPost.Add(mp);
                }
            }

            return ListaPost;
        }
        public List<ModeloPost> ObtenerPostVideo()
        {
            List<ModeloPost> listaPost = new List<ModeloPost>();

            string sql = @"
        SELECT 
            p.id_post,
            p.descripcion,
            p.habilitado,
            p.fecha_hora,
            v.id_video,
            c.habilitado AS comparte_habilitado,
            c.fecha_hora AS fecha_comparte
        FROM post p
        LEFT JOIN video v ON p.id_post = v.id_post
        LEFT JOIN comparte c ON p.id_post = c.id_post AND c.id_perfil = p.id_perfil
        WHERE p.habilitado = TRUE AND p.id_perfil = @id_perfil order by p.fecha_hora and fecha_comparte;";

            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);

            using (this.Lector = this.Comando.ExecuteReader())
            {
                while (this.Lector.Read())
                {
                    ModeloPost mp = new ModeloPost
                    {
                        idPost = Convert.ToInt32(this.Lector["id_post"]),
                        descripcion = this.Lector["descripcion"].ToString(),
                        habilitado = Convert.ToBoolean(this.Lector["habilitado"]),
                        fechaHora = Convert.ToDateTime(this.Lector["fecha_hora"]),
                        idVideo = this.Lector["id_video"] != DBNull.Value ? this.Lector["id_video"].ToString() : null,
                        comparteHabilitado = this.Lector["comparte_habilitado"] != DBNull.Value ? Convert.ToBoolean(this.Lector["comparte_habilitado"]) : false,
                        fechaComparte = Convert.ToDateTime(this.Lector["fecha_comparte"]),
                    };

                    listaPost.Add(mp);
                }
            }

            return listaPost;
        }
        public List<ModeloPost> ObtenerPostAudio()
        {
            List<ModeloPost> listaPost = new List<ModeloPost>();

            string sql = @"
        SELECT 
            p.id_post,
            p.descripcion,
            p.habilitado,
            p.fecha_hora,
            a.id_audio,
            c.habilitado AS comparte_habilitado,
            c.fecha_hora AS fecha_comparte
        FROM post p
        LEFT JOIN audio a ON p.id_post = a.id_post
        LEFT JOIN comparte c ON p.id_post = c.id_post AND c.id_perfil = p.id_perfil
        WHERE p.habilitado = TRUE AND p.id_perfil = @id_perfil order by p.fecha_hora and fecha_comparte;";

            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);

            using (this.Lector = this.Comando.ExecuteReader())
            {
                while (this.Lector.Read())
                {
                    ModeloPost mp = new ModeloPost
                    {
                        idPost = Convert.ToInt32(this.Lector["id_post"]),
                        descripcion = this.Lector["descripcion"].ToString(),
                        habilitado = Convert.ToBoolean(this.Lector["habilitado"]),
                        fechaHora = Convert.ToDateTime(this.Lector["fecha_hora"]),
                        idAudio = this.Lector["id_audio"] != DBNull.Value ? this.Lector["id_audio"].ToString() : null,
                        comparteHabilitado = this.Lector["comparte_habilitado"] != DBNull.Value ? Convert.ToBoolean(this.Lector["comparte_habilitado"]) : false,
                        fechaComparte = Convert.ToDateTime(this.Lector["fecha_comparte"]),
                    };

                    listaPost.Add(mp);
                }
            }

            return listaPost;
        }


        public List<ModeloPost> ObtenerComentarios()
        {
            List<ModeloPost> Listacomentarios = new List<ModeloPost>();

            string sql = "SELECT p.id_comentario, p.comentario, p.fecha_hora, p.habilitado, pf.apodo, pf.id_perfil FROM comentario p LEFT JOIN perfil pf ON p.id_perfil = pf.id_perfil WHERE p.id_post = @id_post";
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.CommandText = sql;
            using (this.Lector = this.Comando.ExecuteReader())
            {
                while (this.Lector.Read())
                {
                    ModeloPost mp = new ModeloPost
                    {
                        idComentario = Convert.ToInt32(this.Lector["id_comentario"]),
                        comentario = this.Lector["comentario"].ToString(),
                        fecha = this.Lector["fecha_hora"].ToString(),
                        habilitado = Convert.ToBoolean(this.Lector["habilitado"]),
                        apodo = this.Lector["apodo"].ToString(),
                        idPerfil = Convert.ToInt32(this.Lector["id_perfil"])
                    };

                    Listacomentarios.Add(mp);
                }
            }

            return Listacomentarios;

        }

        public void ComentarPost()
        {
            string sql = $"insert into comentario (id_post , id_perfil, comentario, fecha_hora) values(@id_post, @id_perfil, @comentario, now()); commit;";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Parameters.AddWithValue("@comentario", comentario);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void DeshabilitarComentario()
        {
            string sql = "UPDATE comentario SET habilitado = false WHERE id_comentario = @id_comentario; commit;";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_comentario", idComentario);
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarComentario()
        {
            string sql = "UPDATE comentario SET habilitado = true WHERE id_comentario = @id_comentario; commit;";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_comentario", idComentario);
            this.Comando.ExecuteNonQuery();
        } 
        public void ModificarComentario()
        {
            string sql = $"UPDATE comentario SET comentario = @comentario WHERE id_comentario = @id_comentario; commit;";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_comentario", idComentario);
            this.Comando.Parameters.AddWithValue("@comentario", comentario);
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public int ContarComentarios()
        {
            string sql = "SELECT COUNT(*) FROM comentarios WHERE id_post = @id_post; commit";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            int contadorComentarios = Convert.ToInt32(this.Comando.ExecuteScalar());
            return contadorComentarios;
        }



        public void CompartirPost()
        {
            string sql = $"INSERT INTO comparte (id_perfil, id_post, fecha_hora) VALUES (@id_perfil, @id_post, NOW()); commit;";

            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.ExecuteNonQuery();
        }
        public void DeshabilitarComparte()
        {
            string sql = $"UPDATE comparte SET habilitado = FALSE WHERE id_post = @id_post; commit";

            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.ExecuteNonQuery();
        }

    }
}

