using System;
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
    }
}
