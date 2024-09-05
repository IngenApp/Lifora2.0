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
        public string fecha;
        public string habilitado;
        public void CrearPost()
        {
            string sql = $"insert into post (id_cuenta, texto_post, fecha) values(@id_cuenta, @texto_post, @fecha)";
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
            this.Comando.Parameters.AddWithValue("@texto_post", post);
            this.Comando.Parameters.AddWithValue("@fecha", fecha);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }



        public void ModificarPostBackOffice()
        {
            string sql = $"update post set texto_post = '{this.post}' where id_post ='{this.idPost}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarIdPostBackOffice()
        {
            string sql = $"update post set id_post = '{this.idPost}' where id_post ='{this.idPost}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarIdCuentaBackOffice()
        {
            string sql = $"update post set id_cuenta = '{this.idCuenta}' where id_post ='{this.idPost}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarFechaBackOffice()
        {
            string sql = $"update post set fecha = '{this.fecha}' where id_post ='{this.idPost}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarLikeBackOffice()
        {
            string sql = $"update post set contador_comentario = '{this.comentarios}' where id_post ='{this.idPost}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarPostUsuarioBackoffice()
        {
            string sql = $"update post set texto_post = @texto_post, id_cuenta = @id_cuenta,  fecha = @fecha, contador_like = @contador_like where id_post = @id_post";
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
            string sql = $"UPDATE post SET habilitado = false WHERE id_post = '{this.idPost}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarPost()
        {
            string sql = $"UPDATE post SET habilitado = true WHERE id_post = '{this.idPost}'";
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
    }
}

