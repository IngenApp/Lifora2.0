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
        public int idGrupo, idPerfil;
        public string nombre, informacion, fecha, idFotoGrupo;
        public bool habilitado, silenciar;
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
        public void UnirseAGrupo(int idGrupos, int idPerfil, bool silenciar)
        {
            string sql = "INSERT INTO se_une_grupos (id_grupos, id_perfil, silenciar, fecha_hora) VALUES (@id_grupos, @id_perfil, @silenciar, NOW());";
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_grupos", idGrupos);
            this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
            this.Comando.Parameters.AddWithValue("@silenciar", silenciar ? 1 : 0);
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void SalirDelGrupo(int idGrupos, int idPerfil)
        {
            string sql = "DELETE FROM se_une_grupos WHERE id_grupos = @id_grupos AND id_perfil = @id_perfil;";

            try
            {
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@id_grupos", idGrupos);
                this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
                this.Comando.CommandText = sql;
                this.Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al salir del grupo: {ex.Message}");
            }
        }
        public void SilenciarGrupo(int idGrupos, int idPerfil, bool silenciar)
        {
            string sql = "UPDATE se_une_grupos SET silenciar = @silenciar WHERE id_grupos = @id_grupos AND id_perfil = @id_perfil;";

            try
            {
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@id_grupos", idGrupos);
                this.Comando.Parameters.AddWithValue("@id_perfil", idPerfil);
                this.Comando.Parameters.AddWithValue("@silenciar", silenciar ? 1 : 0);
                this.Comando.CommandText = sql;
                this.Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al silenciar el grupo: {ex.Message}");
            }
        }
        public ModeloGrupos BuscarGrupoPorNombre(string nombreGrupo)
        {
            string sql = @"SELECT id_grupos, nombre_grupo, informacion, id_foto_grupo, fecha_hora, id_perfil, habilitado FROM grupos WHERE nombre_grupo = @nombre_grupo";

            try
            {
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@nombre_grupo", nombreGrupo);

                using (this.Lector = this.Comando.ExecuteReader())
                {
                    if (this.Lector.Read())
                    {
                        this.idGrupo = Convert.ToInt32(this.Lector["id_grupos"]);
                        this.nombre = this.Lector["nombre_grupo"].ToString();
                        this.informacion = this.Lector["informacion"].ToString();
                        this.idFotoGrupo = this.Lector["id_foto_grupo"] != DBNull.Value ? this.Lector["id_foto_grupo"].ToString() : null;
                        this.fecha = this.Lector["fecha_hora"].ToString();
                        this.idPerfil = Convert.ToInt32(this.Lector["id_perfil"]);
                        this.habilitado = Convert.ToBoolean(this.Lector["habilitado"]);

                        return this;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }
        public int ObtenerCantidadDeIntegrantes(int idGrupo)
        {
            string sql = @"SELECT COUNT(*) FROM se_une_grupos WHERE id_grupos = @id_grupos";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);

            try
            {
                int cantidad = Convert.ToInt32(this.Comando.ExecuteScalar());
                return cantidad;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la cantidad de integrantes: {ex.Message}");
                return 0;
            }
        }
        public List<string> ObtenerApodoDeIntegrantes(int idGrupo)
        {
            List<string> apodos = new List<string>();
            string sql = @"SELECT p.apodo FROM se_une_grupos su INNER JOIN perfil p ON su.id_perfil = p.id_perfil WHERE su.id_grupos = @id_grupos";

            try
            {
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);

                this.Lector = this.Comando.ExecuteReader();

                while (this.Lector.Read())
                {
                    string apodo = this.Lector["apodo"].ToString();  
                    apodos.Add(apodo);
                }

                this.Lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los apodos de los integrantes: {ex.Message}");
            }

            return apodos;
        }
/*  
        public void AsociarPostAGrupo(int idGrupo, int idPost)
        {
            string sql = @"INSERT INTO grupo_post (id_grupos, id_post) VALUES (@id_grupos, @id_post);";

            try
            {
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);
                this.Comando.Parameters.AddWithValue("@id_post", idPost);
                this.Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al asociar el post al grupo: {ex.Message}");
            }
        }
   
        public void EliminarPostDeGrupo(int idGrupo, int idPost)
        {
            string sql = @"DELETE gp, p 
                   FROM grupo_post gp 
                   JOIN post p ON gp.id_post = p.id_post 
                   WHERE gp.id_post = @id_post;";
            try
            {
                using (var transaction = this.Comando.Connection.BeginTransaction())
                {
                    this.Comando.Transaction = transaction;
                    this.Comando.CommandText = sql;
                    this.Comando.Parameters.Clear();
                    this.Comando.Parameters.AddWithValue("@id_post", idPost);
                    this.Comando.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el post y su relación con el grupo: {ex.Message}");
                transaction.Rollback();
            }
        }
        public List<int> ObtenerPostsDeGrupo(int idGrupo)
        {
            List<int> posts = new List<int>();
            string sql = @"SELECT id_post FROM grupo_post WHERE id_grupos = @id_grupos;";

            try
            {
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);
                this.Lector = this.Comando.ExecuteReader();
                while (this.Lector.Read())
                {
                    int idPost = Convert.ToInt32(this.Lector["id_post"]);
                    posts.Add(idPost);
                }

                this.Lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los posts del grupo: {ex.Message}");
            }

            return posts;
        }

        public bool EsPostDeGrupo(int idGrupo, int idPost)
        {
            string sql = @"SELECT COUNT(*) FROM grupo_post WHERE id_grupos = @id_grupos AND id_post = @id_post;";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);
            this.Comando.Parameters.AddWithValue("@id_post", idPost);

            try
            {
                int count = Convert.ToInt32(this.Comando.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar si el post pertenece al grupo: {ex.Message}");
                return false;
            }
        }
*/

        public ModeloGrupos BuscarGrupoPorId(int idGrupo)
        {
            string sql = @"SELECT id_grupos, nombre_grupo, informacion, id_foto_grupo, fecha_hora, id_perfil, habilitado FROM grupos WHERE id_grupos = @id_grupos";

            try
            {
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@id_grupos", idGrupo);

                using (this.Lector = this.Comando.ExecuteReader())
                {
                    if (this.Lector.Read())
                    {
                        return new ModeloGrupos()
                        {
                            idGrupo = Convert.ToInt32(this.Lector["id_grupos"]),
                            nombre = this.Lector["nombre_grupo"].ToString(),
                            informacion = this.Lector["informacion"].ToString(),
                            idFotoGrupo = this.Lector["id_foto_grupo"] != DBNull.Value ? this.Lector["id_foto_grupo"].ToString() : null,
                            fecha = this.Lector["fecha_hora"].ToString(),
                            idPerfil = Convert.ToInt32(this.Lector["id_perfil"]),
                            habilitado = Convert.ToBoolean(this.Lector["habilitado"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
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
