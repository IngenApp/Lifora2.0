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
        public int idPost;
        public int idCuenta;
        public string post;
        public int like;
        public int comentarios;
        public string textoComentarios;
        public int contadorLike;
        public string fecha;
        public string habilitado;
        public string nombre;

        public void CrearPost()
        {
            string sql = $"insert into post (id_cuenta, texto_post, fecha) values(@id_cuenta, @texto_post, now())";
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
            this.Comando.Parameters.AddWithValue("@texto_post", post);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void ModificarPost()
        {
            string sql = "update post set texto_post = @texto_post where id_post = @id_post";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@texto_post", post);
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
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta); 
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

        public void ModificarPostUsuarioBackoffice()
        {
            string sql = $"update post set texto_post = @texto_post, id_cuenta = @id_cuenta,  fecha = @fecha, contador_like = @contador_like where id_post = @id_post";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@texto_post", post);
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
            this.Comando.Parameters.AddWithValue("@fecha", fecha);
            this.Comando.Parameters.AddWithValue("@contador_like", like);
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void DeshabilitarPost()
        {
            string sql = "UPDATE post SET habilitado = false WHERE id_post = @id_post";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear(); 
            this.Comando.Parameters.AddWithValue("@id_post", idPost); 
            this.Comando.ExecuteNonQuery();
        }

        public void HabilitarPost()
        {
            string sql = $"update post set habilitado = true where id_post = @id_post";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.ExecuteNonQuery();
        }

        public Dictionary<string, string> ObtenerDatosPostPorId()
        {
            string sql = "SELECT id_post, id_cuenta, texto_post, contador_like, contador_comentarios, habilitado, fecha " +
                         "FROM post WHERE id_post = @id";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id", this.idPost);
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
            string sql = $"SELECT * FROM post";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();
            while (this.Lector.Read())
            {
                ModeloPost mp = new ModeloPost();
                mp.post = this.Lector["texto_post"].ToString();
                mp.idPost = Int32.Parse(this.Lector["id_post"].ToString());
                mp.idCuenta = Int32.Parse(this.Lector["id_cuenta"].ToString());
                mp.fecha = this.Lector["fecha"].ToString();
                mp.like = Int32.Parse(this.Lector["contador_like"].ToString());
                mp.habilitado = this.Lector["habilitado"].ToString();
                ListaPost.Add(mp);
            }
            return ListaPost;
        }

        public bool CompartirPost(int idCuentaCompartir, int idPost)
        {
            bool operacionExitosa = false;

            string sqlSelect = "SELECT texto_post, fecha FROM post WHERE id_post = @id_post AND habilitado = 1";
            this.Comando.CommandText = sqlSelect;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Lector = this.Comando.ExecuteReader();

            if (!this.Lector.Read())
            {
                this.Lector.Close();
                return false;
            }
            string textoOriginal = this.Lector["texto_post"].ToString();
            string fechaOriginal = this.Lector["fecha"].ToString();
            this.Lector.Close();
            string sqlInsert = @"INSERT INTO post (id_cuenta, texto_post, texto_post_original, fecha, contador_like, contador_comentarios, habilitado) 
                         VALUES (@id_cuenta, @texto_post, @texto_post_original, NOW(), 0, 0, 1)";
            this.Comando.CommandText = sqlInsert;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuentaCompartir);
            this.Comando.Parameters.AddWithValue("@texto_post", "[COMPARTIDO] " + textoOriginal);
            this.Comando.Parameters.AddWithValue("@texto_post_original", textoOriginal);

            int filasAfectadas = this.Comando.ExecuteNonQuery();
            operacionExitosa = filasAfectadas > 0;

            return operacionExitosa;
        }

        public void ComentarPost()
        {
            string sql = $"insert into comentario (id_post , id_cuenta, texto_comentario, fecha) values(@id_post, @id_cuenta, @texto_comentario, now())";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
            this.Comando.Parameters.AddWithValue("@texto_comentario", textoComentarios);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void DeshabilitarComentario()
        {
            string sql = "UPDATE comentario SET habilitado = false WHERE id_comentario = @id_comentario";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_comentario", comentarios);
            this.Comando.ExecuteNonQuery();
        }

        public void HabilitarComentario()
        {
            string sql = "UPDATE comentario SET habilitado = true WHERE id_comentario = @id_comentario";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_comentario", comentarios);
            this.Comando.ExecuteNonQuery();
        }

        public List<ModeloPost> ObtenerComentarios(int idPost)
        {
            List<ModeloPost> ListaComentarios = new List<ModeloPost>();
            string sql = "SELECT c.id_comentario, c.texto_comentario, c.fecha, c.habilitado, cu.nombre, cu.id_cuenta, p.texto_post, " +
                         "IFNULL((SELECT COUNT(*) FROM like_comentario lc WHERE lc.id_comentario = c.id_comentario), 0) AS contador_like " +
                         "FROM comentario c " +
                         "JOIN post p ON c.id_post = p.id_post " +
                         "JOIN cuenta_usuario cu ON c.id_cuenta = cu.id_cuenta " +
                         "WHERE c.id_post = @id_post;";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Lector = this.Comando.ExecuteReader();
            while (this.Lector.Read())
            {
                ModeloPost mc = new ModeloPost();
                mc.comentarios = Convert.ToInt32(this.Lector["id_comentario"]);
                mc.textoComentarios = this.Lector["texto_comentario"].ToString();
                mc.fecha = this.Lector["fecha"].ToString();
                mc.nombre = this.Lector["id_cuenta"].ToString();
                mc.post = this.Lector["texto_post"].ToString();
                mc.habilitado= this.Lector["habilitado"].ToString();

                ListaComentarios.Add(mc);
            }
            this.Lector.Close();
            return ListaComentarios;
        }

    }
}

