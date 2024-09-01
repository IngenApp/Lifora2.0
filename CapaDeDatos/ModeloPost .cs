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
        public bool habilitado;

        public void DeshabilitarPost()
        {
            try
            {
                string sql = $"UPDATE post SET habilitado = false WHERE id_post = '{this.idPost}'";
                this.Comando.CommandText = sql;
                this.Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deshabilitar el post: {ex.Message}");
            }
        }

        public void HabilitarPost()
        {
            try
            {
                string sql = $"UPDATE post SET habilitado = true WHERE id_post = '{this.idPost}'";
                this.Comando.CommandText = sql;
                this.Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al habilitar el post: {ex.Message}");
            }
        }
        public List<ModeloPost> ObtenerPostUsuario(int idUsuario)
        {
            List<ModeloPost> bd = new List<ModeloPost>();

            try
            {
                string sql = $"SELECT * FROM post WHERE id_usuario = {idUsuario}";
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
                    mp.habilitado = Convert.ToBoolean(this.Lector["habilitado"]);
                    bd.Add(mp);
                }
                this.Lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los posts del usuario: " + ex.Message);
                if (this.Lector != null && !this.Lector.IsClosed)
                {
                    this.Lector.Close();
                }
            }

            return bd;
        }

    }
}



