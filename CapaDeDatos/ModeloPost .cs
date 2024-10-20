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

        public string post, descripcion, apodo, fecha, comentario;
        public bool habilitado;

        public void CrearPost()
        {
            string sql = $"insert into post (id_perfil, descripcion, fecha_hora) values(@id_perfil, @descripcion, now()); commit;";
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Parameters.AddWithValue("@descripcion", descripcion);
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

 
        public void DarLike(int idCuenta)
        {
            string sqlCheck = "SELECT COUNT(*) FROM like_post WHERE id_post = @id_post AND id_cuenta = @id_cuenta";
            this.Comando.CommandText = sqlCheck;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
            int likeExists = Convert.ToInt32(this.Comando.ExecuteScalar());
            if (likeExists > 0)
            {
                string sqlDelete = "DELETE FROM like_post WHERE id_post = @id_post AND id_cuenta = @id_cuenta";
                this.Comando.CommandText = sqlDelete;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@id_post", idPost);
                this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
                this.Comando.ExecuteNonQuery();

                string sqlUpdate = "UPDATE post SET contador_like = contador_like - 1 WHERE id_post = @id_post";
                this.Comando.CommandText = sqlUpdate;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@id_post", idPost);
                this.Comando.ExecuteNonQuery();
                return;
            }
            string sqlInsert = "INSERT INTO like_post (id_post, id_cuenta, fecha) VALUES (@id_post, @id_cuenta, NOW())";
            this.Comando.CommandText = sqlInsert;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
            this.Comando.ExecuteNonQuery();

            string sqlUpdateAdd = "UPDATE post SET contador_like = contador_like + 1 WHERE id_post = @id_post";
            this.Comando.CommandText = sqlUpdateAdd;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.ExecuteNonQuery();
        }

        public void DeshabilitarPost()
        {
            string sql = "UPDATE post SET habilitado = false WHERE id_post = @id_post; commit;";
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

        public List<ModeloPost> ObtenerComentarios(string idPost)
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

        public void ModificarComentario()
        {
            string sql = $"UPDATE comentario SET comentario = @comentario WHERE id_comentario = @id_comentario; commit;";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_comentario", idComentario);
            this.Comando.Parameters.AddWithValue("@comentario", comentario);
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

    }
}

