using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Modelo

{
   public class ModeloGrupos : Modelo
    {
        public int idGrupo;
        public int idCuenta;
        public string nombre;
        public string descripcion;
        public string fecha;
        public bool habilitado;

        public void CrearGrupo()
        {
            string sql = "INSERT INTO grupo (id_cuenta, nombre, descripcion, fecha) VALUES (@id_cuenta, @nombre, @descripcion, now())";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_cuenta", idCuenta);
            this.Comando.Parameters.AddWithValue("@nombre", nombre);
            this.Comando.Parameters.AddWithValue("@descripcion", descripcion);
            this.Comando.CommandText = sql;
        }

        public void ModificarGrupo()
        {
            string sql = "UPDATE grupo SET nombre = @nombre, descripcion = @descripcion WHERE id_grupo = @id_grupo";
            this.Comando.Parameters.AddWithValue("@nombre", nombre);
            this.Comando.Parameters.AddWithValue("@descripcion", descripcion);
            this.Comando.Parameters.AddWithValue("@id_grupo", idGrupo);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void BloquearGrupo()
        {
            string sql = "UPDATE grupo SET habilitado = 0 WHERE id_grupo = @id_grupo";
            this.Comando.Parameters.AddWithValue("@id_grupo", idGrupo);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void HabilitarGrupo()
        {
            string sql = "UPDATE grupo SET habilitado = 1 WHERE id_grupo = @id_grupo";
            this.Comando.Parameters.AddWithValue("@id_grupo", idGrupo);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public Dictionary<string, string> ObtenerDatosPorId()
        {
            string sql = "SELECT id_grupo, nombre, descripcion, habilitado FROM grupo WHERE id_grupo = @id_grupo";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_grupo", idGrupo);
            this.Lector = this.Comando.ExecuteReader();
            Dictionary<string, string> datosGrupo = new Dictionary<string, string>();
            if (this.Lector.Read())
            {
                datosGrupo["id_grupo"] = this.Lector["id_grupo"].ToString();
                datosGrupo["nombre"] = this.Lector["nombre"].ToString();
                datosGrupo["descripcion"] = this.Lector["descripcion"].ToString();
                datosGrupo["habilitado"] = this.Lector["habilitado"].ToString();
                datosGrupo["resultado"] = "true";
            }
            else
            {
                datosGrupo["resultado"] = "false";
            }
            this.Lector.Close();
            return datosGrupo;
        }

        public List<ModeloGrupos> ObtenerTodos()
        {
            List<ModeloGrupos> bd = new List<ModeloGrupos>();

            string sql = "SELECT * FROM grupo";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            while (this.Lector.Read())
            {
                ModeloGrupos mg = new ModeloGrupos();
                mg.idGrupo = Int32.Parse(this.Lector["id_grupo"].ToString());
                mg.nombre = this.Lector["nombre"].ToString();
                mg.descripcion = this.Lector["descripcion"].ToString();
                mg.habilitado = Convert.ToBoolean(this.Lector["habilitado"]);
                bd.Add(mg);
            }
            return bd;
        }
    }
}
