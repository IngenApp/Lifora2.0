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
        public int idPost, idPerfil;

        public string post, descripcion, apodo, fecha;
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

        public void ModificarIdPost()
        {
            string sql = $"update post set id_post = @id_post where id_post = @id_post";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void ModificarIdCuenta()
        {
            string sql = "update post set id_cuenta = @id_cuenta where id_post = @id_post";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_cuenta", idPerfil);
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void ModificarFecha()
        {
            string sql = $"update post set fecha = @fecha where id_post = @id_post";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@fecha", fecha);
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

        public Dictionary<string, string> ObtenerDatosPostPorId()
        {
            string sql = "";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@pf.id_perfil", this.idPost);
            this.Lector = this.Comando.ExecuteReader();

            Dictionary<string, string> datosPost = new Dictionary<string, string>();
            if (this.Lector.Read())
            {
                datosPost["id_post"] = this.Lector["id_post"].ToString();
                datosPost["id_cuenta"] = this.Lector["id_cuenta"].ToString();
                datosPost["texto_post"] = this.Lector["texto_post"].ToString();
                datosPost["contador_like"] = this.Lector["contador_like"].ToString();
                datosPost["contador_comentarios"] = this.Lector["contador_comentarios"].ToString();
                datosPost["habilitado"] = this.Lector["habilitado"].ToString();
                datosPost["fecha"] = this.Lector["fecha"].ToString();
                datosPost["resultado"] = "true";
            }
            else
            {
                datosPost["resultado"] = "false";
            }
            this.Lector.Close();
            return datosPost;
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
            string sql = $"insert into comentario (id_post , id_cuenta, texto_comentario, fecha) values(@id_post, @id_cuenta, @texto_comentario, now())";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_cuenta", idPerfil);
          //  this.Comando.Parameters.AddWithValue("@texto_comentario", textoComentarios);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void DeshabilitarComentario()
        {
            string sql = "UPDATE comentario SET habilitado = false WHERE id_comentario = @id_comentario";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
          //  this.Comando.Parameters.AddWithValue("@id_comentario", comentarios);
            this.Comando.ExecuteNonQuery();
        }

        public void HabilitarComentario()
        {
            string sql = "UPDATE comentario SET habilitado = true WHERE id_comentario = @id_comentario";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
          //  this.Comando.Parameters.AddWithValue("@id_comentario", comentarios);
            this.Comando.ExecuteNonQuery();
        }

   

    }
}

