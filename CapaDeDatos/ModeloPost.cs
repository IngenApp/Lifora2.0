using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo

{
    class ModeloPost : Modelo
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
            string sql = $"update post set habilitado = false where id_post = '{this.idPost}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarPost()
        {
            string sql = $"update post set habilitado = true where id_post = '{this.idPost}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public int ObtenerIdPost()
        {
            string sql = $"select * from post where id_post = '{this.idPost}'";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            ModeloPost mp = new ModeloPost();
            mp.idPost = Int32.Parse(this.Lector["id_post"].ToString());

            return idCuenta;
        }
        public List<ModeloPost> ObtenerPostUsuario()
        {
            List<ModeloPost> bd = new List<ModeloPost>();

            string sql = $"SELECT * FROM post";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            while (this.Lector.Read())
            {
                ModeloPost mp = new ModeloPost();
                mp.post = this.Lector["texto_post"].ToString();
                mp.like = Int32.Parse(this.Lector["contador_like"].ToString());
                mp.idPost = Int32.Parse(this.Lector["id_post"].ToString());
                mp.idUsuario = Int32.Parse(this.Lector["id_usuario"].ToString());
                mp.idCuenta = Int32.Parse(this.Lector["id_cuenta"].ToString());
                mp.habilitado = this.Lector["habilitado"].ToString();
                bd.Add(mp);
            }
            return bd;
        }
    }
}
