using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class ModeloEventos : Modelo
    {
        public int idEvento, idPerfil;
        public string nombreEvento, informacion, lugar, fechaEvento, idFotoEvento;
        public bool habilitado;
 
        public void CrearEvento()
        {
            string sql = $"INSERT INTO eventos (nombre_evento, informacion, lugar, fecha_evento, id_foto_evento, id_perfil, fecha_hora) VALUES(@nombre_evento, @informacion, @lugar, @fecha_evento, @id_foto_evento, @id_perfil, now());";
            this.Comando.Parameters.AddWithValue("@nombre_evento", nombreEvento);
            this.Comando.Parameters.AddWithValue("@informacion", informacion);
            this.Comando.Parameters.AddWithValue("@lugar", lugar);
            this.Comando.Parameters.AddWithValue("@fecha_evento", fechaEvento);
            this.Comando.Parameters.AddWithValue("@id_foto_evento", idFotoEvento);
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
            this.Comando.CommandText = "COMMIT;";
            this.Comando.ExecuteNonQuery();
        }
        public void DeshabilitarEvento()
        {
            string sql = $"update eventos set habilitado = false where id_eventos = @id_eventos;";
            this.Comando.Parameters.AddWithValue("@id_eventos", idEvento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
            this.Comando.CommandText = "COMMIT;";
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarEvento()
        {
            string sql = $"update eventos set habilitado = true where id_eventos = @id_eventos";
            this.Comando.Parameters.AddWithValue("@id_eventos", idEvento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
            this.Comando.CommandText = "COMMIT;";
            this.Comando.ExecuteNonQuery();
        }

        public void ModificarEvento()
        {
            string sql = $"update eventos set nombre_evento = @nombre_evento, informacion = @informacion, lugar = @lugar, fecha_evento = @fecha_evento, id_foto_evento=@id_foto_Evento where id_eventos = @id_eventos;";
            this.Comando.Parameters.AddWithValue("@nombre_evento", nombreEvento);
            this.Comando.Parameters.AddWithValue("@informacion", informacion);
            this.Comando.Parameters.AddWithValue("@lugar", lugar);
            this.Comando.Parameters.AddWithValue("@fecha_evento", fechaEvento);
            this.Comando.Parameters.AddWithValue("@id_foto_evento", idFotoEvento);
            this.Comando.Parameters.AddWithValue("@id_eventos", idEvento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
            this.Comando.CommandText = "COMMIT;";
            this.Comando.ExecuteNonQuery();
        }
        public Dictionary<string, string> ObtenerEventoPorNombreEvento()
        {
            string sql = "SELECT * FROM eventos WHERE nombre_evento = @nombre_evento AND habilitado = true";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@nombre_evento", nombreEvento);
            this.Comando.Prepare();

            Dictionary<string, string> datosEvento = new Dictionary<string, string>();

            using (MySqlDataReader reader = this.Comando.ExecuteReader())
            {
                if (reader.Read())
                {
                    datosEvento.Add("id_evento", reader["id_eventos"].ToString());
                    datosEvento.Add("nombre_evento", reader["nombre_evento"].ToString());
                    datosEvento.Add("informacion", reader["informacion"].ToString());
                    datosEvento.Add("lugar", reader["lugar"].ToString());
                    datosEvento.Add("fecha_evento", reader["fecha_evento"].ToString());
                    datosEvento.Add("id_perfil", reader["id_perfil"].ToString());
                    datosEvento.Add("habilitado", reader["habilitado"].ToString());
                    datosEvento.Add("id_foto_perfil", reader["id_foto_perfil"].ToString());
                    datosEvento.Add("resultado", "true");
                }
                else
                {
                    datosEvento.Add("resultado", "false");
                }
            }

            return datosEvento;
        }


        public List<ModeloEventos> ObtenerEventos()
        {
            List<ModeloEventos> ListaEventos = new List<ModeloEventos>();

            string sql = $"SELECT * FROM eventos";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            while (this.Lector.Read())
            {
                ModeloEventos me = new ModeloEventos();
                me.idEvento = Int32.Parse(this.Lector["id_eventos"].ToString());
                me.nombreEvento = this.Lector["nombre_evento"].ToString();
                me.informacion = this.Lector["informacion"].ToString();
                me.lugar = this.Lector["lugar"].ToString();
                me.idFotoEvento = this.Lector["id_foto_evento"].ToString();
                me.fechaEvento = this.Lector["fecha_evento"].ToString();
                me.habilitado = Convert.ToBoolean( this.Lector["habilitado"]);
                me.idPerfil = Int32.Parse(this.Lector["id_perfil"].ToString());

                ListaEventos.Add(me);
            }
            return ListaEventos;

        }


    }
}
