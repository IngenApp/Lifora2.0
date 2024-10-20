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
        public int idGrupo, idPerfil, idFotoGrupo;
        public string nombre, informacion, fecha;
        public bool habilitado;

        public void CrearGrupo()
        {
            string sql = "INSERT INTO grupos (id_perfil, nombre_grupo, informacion, fecha_hora) VALUES (@id_perfil, @nombre_grupo, @informacion, now()); commit;";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Parameters.AddWithValue("@nombre_grupo", nombre);
            this.Comando.Parameters.AddWithValue("@informacion", informacion);
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery(); 
        }

        public void ModificarGrupo()
        {
            string sql = "UPDATE grupos SET nombre_grupo = @nombre_grupo, id_foto_grupo = @id_foto_grupo, informacion = @informacion WHERE id_grupos = @id_grupos; commit;";
            this.Comando.Parameters.Clear(); 
            this.Comando.Parameters.AddWithValue("@nombre_grupo", nombre);
            this.Comando.Parameters.AddWithValue("@informacion", informacion);
            this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);
            this.Comando.Parameters.AddWithValue("@id_foto_grupo", idFotoGrupo);
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery(); 
        }


        public void BloquearGrupo()
        {
            string sql = "UPDATE grupos SET habilitado = 0 WHERE id_grupos = @id_grupos; commit;";
            this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void HabilitarGrupo()
        {
            string sql = "UPDATE grupos SET habilitado = 1 WHERE id_grupos = @id_grupos; commit";
            this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public Dictionary<string, string> ObtenerDatosPorId()
        {
            string sql = "SELECT id_grupos, nombre_grupo, informacion, habilitado FROM grupos WHERE id_grupos = @id_grupos";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);
            this.Lector = this.Comando.ExecuteReader();
            Dictionary<string, string> datosGrupo = new Dictionary<string, string>();
            if (this.Lector.Read())
            {
                datosGrupo["id_grupos"] = this.Lector["id_grupos"].ToString();
                datosGrupo["nombre_grupo"] = this.Lector["nombre_grupo"].ToString();
                datosGrupo["informacion"] = this.Lector["informacion"].ToString();
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
            string sql = "SELECT * FROM grupos";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();
            while (this.Lector.Read())
            {
                ModeloGrupos mg = new ModeloGrupos();
                mg.idGrupo = Int32.Parse(this.Lector["id_grupos"].ToString());
                mg.nombre = this.Lector["nombre_grupo"].ToString();
                mg.informacion = this.Lector["informacion"].ToString();
                mg.habilitado = Convert.ToBoolean(this.Lector["habilitado"]);
                mg.idPerfil = Int32.Parse(this.Lector["id_perfil"].ToString());   
                bd.Add(mg);
            }
            this.Lector.Close();
            return bd;
        }

    }
}
