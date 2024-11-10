using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class ModeloPersonas : Modelo
    {
        public int idPerfil, idUsuario, idCuenta;
        public string nombre, apellido, fechaNacimiento, email, telefono, contrasena, apodo, idioma, atributo1, atributo2, emailNuevo, idFotoPerfil;
        public bool habilitacion;

        public List<string> ObtenerSeguidores(int idPerfil)
        {
            var seguidores = new List<string>();

            try
            {
                string sql = @"SELECT perfil.apodo FROM sigue  JOIN perfil ON sigue.id_perfil_1 = perfil.id_perfil 
            WHERE sigue.id_perfil_2 = @idPerfil";
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@idPerfil", idPerfil);

                using (this.Lector = this.Comando.ExecuteReader())
                {
                    while (this.Lector.Read())
                    {
                        seguidores.Add(this.Lector.GetString("apodo"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return seguidores;
        }

        public int ObtenerCantidadSeguidores(int idPerfil)
        {
            int cantidadSeguidores = 0;

            try
            {
                string sql = @"SELECT COUNT(*) FROM sigue 
                       WHERE id_perfil_2 = @idPerfil";
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@idPerfil", idPerfil);

                object result = this.Comando.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    cantidadSeguidores = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return cantidadSeguidores;
        }


        public List<string> ObtenerSeguidos(int idPerfil)
        {
            var seguidos = new List<string>();

            try
            {
                string sql = @"SELECT perfil.apodo FROM sigue 
                       JOIN perfil ON sigue.id_perfil_2 = perfil.id_perfil 
                       WHERE sigue.id_perfil_1 = @idPerfil";
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@idPerfil", idPerfil);

                using (this.Lector = this.Comando.ExecuteReader())
                {
                    while (this.Lector.Read())
                    {
                        seguidos.Add(this.Lector.GetString("apodo"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return seguidos;
        }

        public int ObtenerCantidadSeguidos(int idPerfil)
        {
            int cantidadSeguidos = 0;

            try
            {
                string sql = @"SELECT COUNT(*) FROM sigue 
                       WHERE id_perfil_1 = @idPerfil";
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@idPerfil", idPerfil);

                object result = this.Comando.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    cantidadSeguidos = Convert.ToInt32(result);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de MySQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return cantidadSeguidos;
        }

        public void GuardarCuentaUsuario()
        {
            string sql = $"CALL crear_usuario_cuenta(@nombre, @apellido, @fecha_nacimiento, @email, @telefono, @contrasenia);";
            this.Comando.Parameters.AddWithValue("@nombre", nombre);
            this.Comando.Parameters.AddWithValue("@apellido", apellido);
            this.Comando.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento);
            this.Comando.Parameters.AddWithValue("@email", email);
            this.Comando.Parameters.AddWithValue("@telefono", telefono);
            this.Comando.Parameters.AddWithValue("@contrasenia", contrasena);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();

        }
        public void CrearPerfil()
        {
            string sql = $"CALL crear_perfil(@apodo, @email, @idioma);";
            this.Comando.Parameters.AddWithValue("@apodo", apodo);
            this.Comando.Parameters.AddWithValue("@email", email);
            this.Comando.Parameters.AddWithValue("@idioma", idioma);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void DeshabilitarCuentaUsuario()
        {
            string sql = $"update cuenta_lifora set habilitado = false where id_usuario = '{this.idUsuario}'; commit;";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarCuentaUsuario()
        {
            string sql = $"update cuenta_lifora set habilitado = true where id_usuario = '{this.idUsuario}'; commit;";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }



        public void ModificarCuentaUsuario()
        {
            try
            {
                this.Comando.Parameters.Clear();
                string sql = "CALL actualizar_usuario_cuenta(@p_email_antiguo, @p_email_nuevo, @p_nombre, @p_apellido, @p_telefono);";

                this.Comando.Parameters.AddWithValue("@p_email_antiguo", email);
                this.Comando.Parameters.AddWithValue("@p_email_nuevo", emailNuevo);
                this.Comando.Parameters.AddWithValue("@p_nombre", nombre);
                this.Comando.Parameters.AddWithValue("@p_apellido", apellido);
                this.Comando.Parameters.AddWithValue("@p_telefono", telefono);

                this.Comando.CommandText = sql;
                this.Comando.CommandType = CommandType.Text;
                this.Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar la cuenta del usuario: " + ex.Message);
                throw;
            }
        }
        public void ModificarPerfilUsuario()
        {
            try
            {
                this.Comando.Parameters.Clear();

                string sql = "CALL actualizar_perfil_usuario(@p_email, @p_apodo, @p_id_foto_perfil, @p_idioma, @p_atributo1, @p_atributo2, @p_contrasena);";

                this.Comando.Parameters.AddWithValue("p_email", email);
                this.Comando.Parameters.AddWithValue("p_apodo", apodo);
                this.Comando.Parameters.AddWithValue("p_id_foto_perfil", idFotoPerfil);
                this.Comando.Parameters.AddWithValue("p_idioma", idioma);
                this.Comando.Parameters.AddWithValue("p_atributo1", atributo1);
                this.Comando.Parameters.AddWithValue("p_atributo2", atributo2);
                this.Comando.Parameters.AddWithValue("p_contrasena", contrasena);

                this.Comando.CommandText = sql;
                this.Comando.CommandType = CommandType.Text;

                this.Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar el perfil del usuario: " + ex.Message);
                throw;
            }
        }





        public bool Autenticar()
        {
            string sql = $"SELECT COUNT(*) FROM cuenta_lifora c JOIN cuenta_usuario u ON c.email = u.email WHERE c.email = @email AND c.contrasenia = @contrasenia AND c.habilitado = 1;";
            this.Comando.Parameters.AddWithValue("@email", this.email);
            this.Comando.Parameters.AddWithValue("@contrasenia", this.contrasena);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
            string resultado = this.Comando.ExecuteScalar().ToString();
            if (resultado == "0")
                return false;
            return true;
        }
        public bool AutenticarBackoffice()
        {
            string sql = $"SELECT COUNT(*) FROM cuenta_lifora c JOIN backoffice b ON c.email = b.email WHERE c.email = @email AND c.contrasenia = @contrasenia AND c.habilitado = 1;";
            this.Comando.Parameters.AddWithValue("@email", this.email);
            this.Comando.Parameters.AddWithValue("@contrasenia", this.contrasena);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
            string resultado = this.Comando.ExecuteScalar().ToString();
            if (resultado == "0")
                return false;
            return true;
        }

        public List<ModeloPersonas> ObtenerTodos()
        {
            List<ModeloPersonas> bd = new List<ModeloPersonas>();

            string sql = @"SELECT p.id_perfil, p.apodo, p.email AS perfil_email, u.telefono AS cuenta_telefono, c.habilitado, c.id_usuario, usr.nombre, usr.apellido, usr.fecha_nacimiento, c.contrasenia, p.idioma, p.atributo1, p.atributo2
                        FROM perfil p JOIN cuenta_usuario u ON p.email = u.email JOIN cuenta_lifora c ON u.email = c.email 
                        JOIN usuario usr ON c.id_usuario = usr.id_usuario ORDER BY c.id_usuario;";

            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            while (this.Lector.Read())
            {
                ModeloPersonas mp = new ModeloPersonas
                {
                    idPerfil = Convert.ToInt32(this.Lector["id_perfil"]),
                    apodo = this.Lector["apodo"].ToString(),
                    email = this.Lector["perfil_email"].ToString(),
                    telefono = this.Lector["cuenta_telefono"].ToString(),
                    habilitacion = Convert.ToBoolean(this.Lector["habilitado"]),
                    idUsuario = Convert.ToInt32(this.Lector["id_usuario"]),
                    nombre = this.Lector["nombre"].ToString(),
                    apellido = this.Lector["apellido"].ToString(),
                    fechaNacimiento = this.Lector["fecha_nacimiento"].ToString(),
                    contrasena = this.Lector["contrasenia"].ToString(),
                    idioma = this.Lector["idioma"].ToString(),
                    atributo1 = this.Lector["atributo1"].ToString(),
                    atributo2 = this.Lector["atributo2"].ToString()
                };
                bd.Add(mp);
            }
            this.Lector.Close();
            return bd;
        }

        public void ObtenerIdPerfilPorApodo(string apodo)
        {

            string sql = @"SELECT u.nombre, u.apellido, u.fecha_nacimiento, p.email, cl.telefono, p.id_perfil, p.apodo, p.id_foto_perfil, p.idioma, p.atributo1, p.atributo2 FROM perfil p JOIN cuenta_usuario cu ON p.email = cu.email JOIN cuenta_lifora cl ON cu.email = cl.email JOIN usuario u ON cl.id_usuario = u.id_usuario WHERE p.apodo = @apodo; ";
            try
            {
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@apodo", apodo);

                using (this.Lector = this.Comando.ExecuteReader())
                {
                    if (this.Lector.Read())
                    {
                        this.idPerfil = Convert.ToInt32(Lector["id_perfil"]);
                        this.nombre = Lector["nombre"].ToString();
                        this.apellido = Lector["apellido"].ToString();
                        this.fechaNacimiento = Convert.ToString(Lector["fecha_nacimiento"]);
                        this.email = Lector["email"].ToString();
                        this.telefono = Lector["telefono"].ToString();
                        this.apodo = Lector["apodo"].ToString();
                        this.idFotoPerfil = Lector["id_foto_perfil"].ToString();
                        this.idioma = Lector["idioma"].ToString();
                        this.atributo1 = Lector["atributo1"].ToString();
                        this.atributo2 = Lector["atributo2"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }

        }
        public void ObtenerIdPerfilPorEmail(string email)
        {

            string sql = @"SELECT u.nombre, u.apellido, u.fecha_nacimiento, p.email, cl.telefono, p.id_perfil, p.apodo, p.id_foto_perfil, p.idioma, p.atributo1, p.atributo2 FROM perfil p JOIN cuenta_usuario cu ON p.email = cu.email JOIN cuenta_lifora cl ON cu.email = cl.email JOIN usuario u ON cl.id_usuario = u.id_usuario WHERE p.email = @email; ";
            try
            {
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@email", email);

                using (this.Lector = this.Comando.ExecuteReader())
                {
                    if (this.Lector.Read())
                    {
                        this.idPerfil = Convert.ToInt32(Lector["id_perfil"]);
                        this.nombre = Lector["nombre"].ToString();
                        this.apellido = Lector["apellido"].ToString();
                        this.fechaNacimiento = Convert.ToString(Lector["fecha_nacimiento"]);
                        this.email = Lector["email"].ToString();
                        this.telefono = Lector["telefono"].ToString();
                        this.apodo = Lector["apodo"].ToString();
                        this.idFotoPerfil = Lector["id_foto_perfil"].ToString(); ;
                        this.idioma = Lector["idioma"].ToString();
                        this.atributo1 = Lector["atributo1"].ToString();
                        this.atributo2 = Lector["atributo2"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        public bool ObtenerPerfilPorEmail(string email)
        {
            string sql = @"SELECT u.nombre, u.apellido, u.fecha_nacimiento, p.email, cl.telefono, 
                          p.id_perfil, p.apodo, p.id_foto_perfil, p.idioma, p.atributo1, 
                          p.atributo2, cl.contrasenia 
                   FROM perfil p 
                   JOIN cuenta_usuario cu ON p.email = cu.email 
                   JOIN cuenta_lifora cl ON cu.email = cl.email 
                   JOIN usuario u ON cl.id_usuario = u.id_usuario 
                   WHERE p.email = @email;";

            try
            {
                this.Comando.CommandText = sql;
                this.Comando.Parameters.Clear();
                this.Comando.Parameters.AddWithValue("@email", email);

                using (this.Lector = this.Comando.ExecuteReader())
                {
                    if (this.Lector.Read())
                    {
                        this.idPerfil = Convert.ToInt32(Lector["id_perfil"]);
                        this.nombre = Lector["nombre"].ToString();
                        this.apellido = Lector["apellido"].ToString();
                        this.fechaNacimiento = Convert.ToString(Lector["fecha_nacimiento"]);
                        this.email = Lector["email"].ToString();
                        this.contrasena = Lector["contrasenia"].ToString();
                        this.telefono = Lector["telefono"].ToString();
                        this.apodo = Lector["apodo"].ToString();

                        if (!string.IsNullOrEmpty(Lector["id_foto_perfil"].ToString()))
                            this.idFotoPerfil = Lector["id_foto_perfil"].ToString();

                        this.idioma = Lector["idioma"].ToString();
                        this.atributo1 = Lector["atributo1"].ToString();
                        this.atributo2 = Lector["atributo2"].ToString();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return false;
        }




        /*
                public bool ObtenerPerfilPorEmail(string email)
                {
                    string sql = @"SELECT u.nombre, u.apellido, u.fecha_nacimiento, p.email, cl.telefono, 
                                  p.id_perfil, p.apodo, p.id_foto_perfil, p.idioma, 
                                  p.atributo1, p.atributo2, cu.contrasena 
                           FROM perfil p 
                           JOIN cuenta_usuario cu ON p.email = cu.email 
                           JOIN cuenta_lifora cl ON cu.email = cl.email 
                           JOIN usuario u ON cl.id_usuario = u.id_usuario 
                           WHERE p.email = @email;";

                    try
                    {
                        this.Comando.CommandText = sql;
                        this.Comando.Parameters.Clear();
                        this.Comando.Parameters.AddWithValue("@email", email);

                        using (this.Lector = this.Comando.ExecuteReader())
                        {
                            if (this.Lector.Read())
                            {
                                this.idPerfil = Convert.ToInt32(Lector["id_perfil"]);
                                this.nombre = Lector["nombre"].ToString();
                                this.apellido = Lector["apellido"].ToString();
                                this.fechaNacimiento = Convert.ToString(Lector["fecha_nacimiento"]);
                                this.email = Lector["email"].ToString();
                                this.contrasena = Lector["contrasena"].ToString();
                                this.telefono = Lector["telefono"].ToString();
                                this.apodo = Lector["apodo"].ToString();
                                this.idFotoPerfil = Lector["id_foto_perfil"].ToString();
                                this.idioma = Lector["idioma"].ToString();
                                this.atributo1 = Lector["atributo1"].ToString();
                                this.atributo2 = Lector["atributo2"].ToString();

                                return true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    return false;
                }
                */

    }
}