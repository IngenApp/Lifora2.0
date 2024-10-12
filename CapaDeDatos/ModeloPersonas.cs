using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;

namespace Modelo
{
    public class ModeloPersonas : Modelo
    {
        public int idPerfil, idUsuario, idCuenta, id_foto_perfil;
        public string nombre, apellido, fechaNacimiento, email, telefono, contrasena, apodo, idioma, atributo1, atributo2;
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
            string sql = $"CALL actualizar_usuario_cuenta(@email, @nombre, @apellido, @fecha_nacimiento, @telefono, @contrasenia);";
            this.Comando.Parameters.AddWithValue("@email", email);
            this.Comando.Parameters.AddWithValue("@nombre", nombre);
            this.Comando.Parameters.AddWithValue("@apellido", apellido);
            this.Comando.Parameters.AddWithValue("@fecha_nacimiento", fechaNacimiento);
            this.Comando.Parameters.AddWithValue("@telefono", telefono);
            this.Comando.Parameters.AddWithValue("@contrasenia", contrasena);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarPerfil()
        {
            string sql = $"CALL actualizar_perfil(@apodo, @email, @idioma, @id_foto_perfil, @atributo1, @atributo2);";
            this.Comando.Parameters.AddWithValue("@apodo", apodo);
            this.Comando.Parameters.AddWithValue("@email", email);
            this.Comando.Parameters.AddWithValue("@idioma", idioma);
            this.Comando.Parameters.AddWithValue("@id_foto_perfil", id_foto_perfil);
            this.Comando.Parameters.AddWithValue("@atributo1", atributo1);
            this.Comando.Parameters.AddWithValue("@atributo2", atributo2);
            this.Comando.Prepare();
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public bool Autenticar()
        {
            string sql = $"SELECT COUNT(*) FROM cuenta_lifora WHERE email = @email AND contrasenia = @contrasenia AND habilitado = 1;";
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

            string sql = @"SELECT p.id_perfil, 
                          p.apodo, 
                          p.email AS perfil_email, 
                          u.telefono AS cuenta_telefono, 
                          c.habilitado, 
                          c.id_usuario 
                   FROM perfil p 
                   JOIN cuenta_usuario u ON p.email = u.email 
                   JOIN cuenta_lifora c ON u.email = c.email 
                   ORDER BY c.id_usuario;";

            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            while (this.Lector.Read())
            {
                ModeloPersonas mp = new ModeloPersonas
                {
                    idPerfil = Convert.ToInt32(this.Lector["id_perfil"]),
                    apodo = this.Lector["apodo"].ToString(),
                    email = this.Lector["perfil_email"].ToString(), // Usando el alias
                    telefono = this.Lector["cuenta_telefono"].ToString(), // Usando el alias
                    habilitacion = this.Lector["habilitado"] != DBNull.Value && Convert.ToBoolean(this.Lector["habilitado"]),
                    idUsuario = Convert.ToInt32(this.Lector["id_usuario"])
                };
                bd.Add(mp);
            }
            this.Lector.Close(); // Asegúrate de cerrar el lector al final
            return bd;
        }
    }
}
