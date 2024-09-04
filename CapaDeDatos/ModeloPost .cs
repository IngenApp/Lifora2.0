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
            string sql = $"update post set id_cuenta = @id_cuenta, texto_post = @texto_post, fecha = @fecha where id_post = @id_post";
            this.Comando.Parameters.AddWithValue("@id_post", idPost);
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
            this.Comando.Parameters.AddWithValue("@texto_post", post);
            this.Comando.Parameters.AddWithValue("@fecha", fecha);
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
                    mp.idPost = Int32.Parse(this.Lector["id_post"].ToString());
                    mp.post = this.Lector["texto_post"].ToString();
                    mp.like = Int32.Parse(this.Lector["contador_like"].ToString());            
                    mp.habilitado = this.Lector["habilitado"].ToString(); 
                    mp.idCuenta = Int32.Parse(this.Lector["id_cuenta"].ToString());
                    ListaPost.Add(mp);
                }
                return ListaPost;
        }
    }
}

