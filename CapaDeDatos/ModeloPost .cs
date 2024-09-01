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
        public int idUsuario;
        public int idCuenta;
        public string post;
        public int like;
        public int comentarios;
        public string habilitado;

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

