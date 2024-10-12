using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class ModeloPersonas : Modelo
    {
        public int idPerfil, idUsuario, idCuenta, idFotoPerfil;
        public string nombre, apellido, fechaNacimiento, email, telefono, contrasena, apodo, idioma, atributo1, atributo2, emailNuevo;
        public bool habilitacion;


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
            string sql = $"update cuenta_lifora set habilitado = false where id_usuario = '{this.idUsuario}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarCuentaUsuario()
        {
            string sql = $"update cuenta_lifora set habilitado = true where id_usuario = '{this.idUsuario}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
  
        public void ModificarCuentaUsuario()
        {
            this.Comando.Parameters.Clear();
            string sql = "CALL actualizar_usuario_cuenta(@p_email_antiguo, @p_email_nuevo, @p_nombre, @p_apellido, @p_telefono);";

            this.Comando.Parameters.AddWithValue("@p_email_antiguo", email);
            this.Comando.Parameters.AddWithValue("@p_email_nuevo", emailNuevo);
            this.Comando.Parameters.AddWithValue("@p_nombre", nombre);
            this.Comando.Parameters.AddWithValue("@p_apellido", apellido);
            this.Comando.Parameters.AddWithValue("@p_telefono", telefono);

            this.Comando.CommandText = sql;
            this.Comando.Prepare();
            this.Comando.ExecuteNonQuery();

        }

        public void ModificarPerfilUsuario()
        {
            this.Comando.Parameters.Clear();
            string sql = "CALL actualizar_perfil_usuario(@p_email, @p_apodo, @p_id_foto_perfil, @p_idioma, @p_atributo1, @p_atributo2, @p_contrasena);";

            this.Comando.Parameters.AddWithValue("@p_email", email);
            this.Comando.Parameters.AddWithValue("@p_apodo", apodo);
            this.Comando.Parameters.AddWithValue("@p_id_foto_perfil", idFotoPerfil);
            this.Comando.Parameters.AddWithValue("@p_idioma", idioma);
            this.Comando.Parameters.AddWithValue("@p_atributo1", atributo1);
            this.Comando.Parameters.AddWithValue("@p_atributo2", atributo2);
            this.Comando.Parameters.AddWithValue("@p_contrasena", contrasena);

            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
         
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


        public Dictionary<string, string> ObtenerDatosPorId()
        {
            string sql = "SELECT id_cuenta, nombre, apellido, telefono, email, fecha_nacimiento, habilitacion FROM cuenta_usuario WHERE id_cuenta = @id";
            this.Comando.CommandText = sql;
            this.Comando.Parameters.Clear();
            this.Comando.Parameters.AddWithValue("@id", this.idUsuario);
            this.Lector = this.Comando.ExecuteReader();
            Dictionary<string, string> datosUsuario = new Dictionary<string, string>();
            if (this.Lector.Read())
            {
                datosUsuario["id_cuenta"] = this.Lector["id_cuenta"].ToString();
                datosUsuario["nombre"] = this.Lector["nombre"].ToString();
                datosUsuario["apellido"] = this.Lector["apellido"].ToString();
                datosUsuario["telefono"] = this.Lector["telefono"].ToString();
                datosUsuario["email"] = this.Lector["email"].ToString();
                datosUsuario["fecha_nacimiento"] = this.Lector["fecha_nacimiento"].ToString();
                datosUsuario["habilitacion"] = this.Lector["habilitacion"].ToString();
                datosUsuario["resultado"] = "true";
            }
            else
            {
                datosUsuario["resultado"] = "false";
            }
            this.Lector.Close();
            return datosUsuario;
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
    }
}
