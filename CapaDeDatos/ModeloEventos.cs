﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelo
{
    public class ModeloEventos : Modelo
    {
        public int id_evento;
        public string nombre_evento;
        public string informacion;
        public string lugar;
        public string fecha;

        public void CrearEvento()
        {
            string sql = $"insert into eventos (nombre_evento, informacion, lugar) values(@nombre_evento, @informacion, @lugar)";
            this.Comando.Parameters.AddWithValue("@nombre_evento", nombre_evento);
            this.Comando.Parameters.AddWithValue("@informacion", informacion);
            this.Comando.Parameters.AddWithValue("@lugar", lugar);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void DeshabilitarEvento()
        {
            string sql = $"update eventos set habilitado = false where id_cuenta = @id_evento";
            this.Comando.Parameters.AddWithValue("@id_evento", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarEvento()
        {
            string sql = $"update eventos set habilitado = true where id_cuenta = @id_evento";
            this.Comando.Parameters.AddWithValue("@id_evento", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarNombreEvento()
        {
            string sql = $"update eventos set nombre = @nombre_evento where id_cuenta = @id_evento";
            this.Comando.Parameters.AddWithValue("@nombre_evento", nombre_evento);
            this.Comando.Parameters.AddWithValue("@id_evento", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarLugarEvento()
        {
            string sql = $"update eventos set nombre = @lugar where id_cuenta = @id_evento";
            this.Comando.Parameters.AddWithValue("@lugar", lugar);
            this.Comando.Parameters.AddWithValue("@id_evento", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarInformacionEvento()
        {
            string sql = $"update eventos set nombre = @informacion where id_cuenta = @id_evento";
            this.Comando.Parameters.AddWithValue("@informacion", nombre_evento);
            this.Comando.Parameters.AddWithValue("@id_evento", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarFechaEvento()
        {
            string sql = $"update eventos set nombre = @fecha where id_cuenta = @id_evento";
            this.Comando.Parameters.AddWithValue("@fecha", fecha);
            this.Comando.Parameters.AddWithValue("@id_evento", id_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public int ObtenerIdEvento()
        {
            string sql = $"select * from cuenta_usuario where nombre_evento = @nombre_evento";
            this.Comando.Parameters.AddWithValue("@nombre_evento", nombre_evento);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            ModeloEventos me = new ModeloEventos();
            me.id_evento = Int32.Parse(this.Lector["id_evento"].ToString());

            return id_evento;
        }


    }
}
