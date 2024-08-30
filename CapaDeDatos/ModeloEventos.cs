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
        public int id_evento;
        public string nombre_evento;
        public string informacion;
        public string lugar;
        public string fecha_evento;
        public int id_cuenta;

        public void CrearEvento()
        {
            string sql = $"insert into eventos (nombre_evento, informacion, lugar, fecha_evento, id_cuenta) values(@nombre_evento, @informacion, @lugar, @fecha_evento, @id_cuenta)";
            this.Comando.Parameters.AddWithValue("@nombre_evento", nombre_evento);
            this.Comando.Parameters.AddWithValue("@informacion", informacion);
            this.Comando.Parameters.AddWithValue("@lugar", lugar);
            this.Comando.Parameters.AddWithValue("@fecha_evento", fecha_evento);
            this.Comando.Parameters.AddWithValue("@id_cuenta", id_cuenta);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void DeshabilitarEvento()
        {
            string sql = $"update eventos set habilitado = false where id_eventos = @id_eventos";
            this.Comando.Parameters.AddWithValue("@id_eventos", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarEvento()
        {
            string sql = $"update eventos set habilitado = true where id_eventos = @id_eventos";
            this.Comando.Parameters.AddWithValue("@id_eventos", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarNombreEvento()
        {
            string sql = $"update eventos set nombre_evento = @nombre_evento where id_eventos = @id_eventos";
            this.Comando.Parameters.AddWithValue("@nombre_evento", nombre_evento);
            this.Comando.Parameters.AddWithValue("@id_eventos", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarLugarEvento()
        {
            string sql = $"update eventos set lugar = @lugar where id_eventos = @id_eventos";
            this.Comando.Parameters.AddWithValue("@lugar", lugar);
            this.Comando.Parameters.AddWithValue("@id_eventos", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarInformacionEvento()
        {
            string sql = $"update eventos set informacion = @informacion where id_eventos = @id_eventos";
            this.Comando.Parameters.AddWithValue("@informacion", informacion);
            this.Comando.Parameters.AddWithValue("@id_eventos", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarFechaEvento()
        {
            string sql = $"update eventos set fecha_evento = @fecha_evento where id_eventos = @id_eventos";
            this.Comando.Parameters.AddWithValue("@fecha_evento", fecha_evento);
            this.Comando.Parameters.AddWithValue("@id_eventos", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public int ObtenerIdEvento()
        {
            string sql = $"select * from eventos where nombre_evento = @nombre_evento";
            this.Comando.Parameters.AddWithValue("@nombre_evento", nombre_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            using (MySqlDataReader reader = this.Comando.ExecuteReader())
            {
                if (reader.Read()) // Verifica si hay filas en el resultado
                {
                    int id_evento = Int32.Parse(reader["id_eventos"].ToString());
                    return id_evento;
                }
                else
                {
                    return 0;
                }
            }
        }


    }
}
