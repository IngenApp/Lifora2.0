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
        public void ModificarPostBackOffice()
        {
            string sql = "update post set texto_post = @texto_post where id_post = @id_post";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@texto_post", post);
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarIdPostBackOffice()
        {
            string sql = $"update post set id_post = @id_post where id_post = @id_post";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_post", idPost); 
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery(); 
        }
        public void ModificarIdCuentaBackOffice()
        {
            string sql = $"update post set id_cuenta = @id_duenta where id_post = @id_post";
            this.Comando.Parameters.Clear();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarFechaBackOffice()
        {
            string sql = $"update post set fecha = @fecha where id_post = @id_post";
            this.Comando.Parameters.Clear();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void DarLike(int idCuenta)
        {
            string sqlCheck = "SELECT COUNT(*) FROM like_post WHERE id_post = @id_post AND id_cuenta = @id_cuenta";
            this.Comando.CommandText = sqlCheck;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", this.idPost);
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);

            int likeExists = Convert.ToInt32(this.Comando.ExecuteScalar());
            if (likeExists > 0)
             return;
            
            string sqlInsert = "INSERT INTO like_post (id_post, id_cuenta, fecha) VALUES (@id_post, @id_cuenta, NOW())";
            this.Comando.CommandText = sqlInsert;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", this.idPost);
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
            this.Comando.ExecuteNonQuery();

            string sqlUpdate = "UPDATE post SET contador_like = contador_like + 1 WHERE id_post = @id_post";
            this.Comando.CommandText = sqlUpdate;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_post", this.idPost);
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
            string sql = $"update post set habilitado = false where id_post = @id_post";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarPost()
        {
            string sql = $"update post set habilitado = true where id_post = @id_post";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
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
        public List<ModeloPost> ObtenerComentarios(int idPost)
        {
            List<ModeloPost> ListaComentarios = new List<ModeloPost>();
            string sql = "SELECT c.id_comentario, c.texto_comentario, c.fecha, cu.nombre, p.texto_post " +
                         "FROM comentario c " +
                         "JOIN post p ON c.id_post = p.id_post " +
                         "JOIN cuenta_usuario cu ON c.id_cuenta = cu.id_cuenta " +
                         "WHERE c.id_post = @id_post;";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Lector = this.Comando.ExecuteReader();

            while (this.Lector.Read())
            {
                ModeloPost mc = new ModeloPost();
                mc.comentarios = Int32.Parse(this.Lector["id_comentario"].ToString());
                mc.textoComentarios = this.Lector["texto_comentario"].ToString();
                mc.fecha = this.Lector["fecha"].ToString();
                mc.nombre = this.Lector["nombre"].ToString();
                mc.post = this.Lector["texto_post"].ToString();

                ListaComentarios.Add(mc);
            }

            this.Lector.Close();
            return ListaComentarios;
        }


    }
}

