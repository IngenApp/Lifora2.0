using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloPersonas : Modelo
    {
        public int idCuenta, idUsuario;
        public string nombre, apellido, fechaNacimiento, email, telefono, contrasena, apodo, idioma;
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

            this.Comando.ExecuteNonQuery()
        }
        public void DeshabilitarCuentaUsuario()
        {
            string sql = $"update cuenta_lifora set habilitacion = false where id_cuenta = '{this.idCuenta}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void HabilitarCuentaUsuario()
        {
            string sql = $"update cuenta_lifora set habilitacion = true where id_cuenta = '{this.idCuenta}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        
       
        public void ModificarContrasenaUsuario()
        {
            string sql = $"update cuenta_lifora set contrasena = '{this.contrasena}' where id_cuenta ='{this.idCuenta}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
       
        public void ModificarCuentaUsuario()
        {
            string sql = $"update cuenta_ set email = '{this.email}', telefono = '{this.telefono}', nombre = '{this.nombre}', apellido = '{this.apellido}', fecha_nacimiento = '{this.fechaNacimiento}' where id_cuenta = '{this.idCuenta}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public bool Autenticar()
        {
            string sql = $"SELECT COUNT(*) FROM cuenta_lifora WHERE email = @email AND contrasenia = @contrasenia";
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
            this.Comando.Parameters.AddWithValue("@id", this.idCuenta);
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
        /*public List<ModeloPersonas> ObtenerTodos()
        {
            List<ModeloPersonas> bd = new List<ModeloPersonas>();

            string sql = $"SELECT * FROM cuenta_usuario";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            while (this.Lector.Read())
            {
                ModeloPersonas mp = new ModeloPersonas();
                mp.id_cuenta = Int32.Parse(this.Lector["id_cuenta"].ToString());
                mp.nombre = this.Lector["nombre"].ToString();
                mp.apellido = this.Lector["apellido"].ToString();
                mp.email = this.Lector["email"].ToString();
                mp.telefono = Int32.Parse(this.Lector["telefono"].ToString());
                mp.fecha_nac = this.Lector["fecha_nacimiento"].ToString();
                mp.habilitacion = this.Lector["habilitacion"].ToString();
                bd.Add(mp);
            }
            return bd;

        }*/
    }
}
