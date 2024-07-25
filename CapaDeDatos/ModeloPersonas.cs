using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloPersonas : Modelo
    {
        public int id_cuenta;
        public int telefono;
        public string nombre;
        public string apellido;
        public string email;
        public string fecha_nac;
        public string contrasena;
        public string habilitacion;

        public void GuardarCuentaUsuario()
        {
            string sql = $"insert into cuenta_usuario (telefono, nombre, apellido, fecha_nacimiento, contrasena) values('{this.telefono}','{this.nombre}','{this.apellido}','{this.fecha_nac}','{this.contrasena}')";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void DeshabilitarCuentaUsuario()
        {
            string sql = $"update cuenta_usuario set habilitacion = false where id_cuenta = '{this.id_cuenta}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }

        public void ModificarNombreUsuario()
        {
            string sql = $"update cuenta_usuario set nombre = '{this.nombre}' where id_cuenta ='{this.id_cuenta}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarApellidoUsuario()
        {
            string sql = $"update cuenta_usuario set apellido = '{this.apellido}' where id_cuenta ='{this.id_cuenta}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public void ModificarContrasenaUsuario()
        {
            string sql = $"update cuenta_usuario set contrasena = '{this.contrasena}' where id_cuenta ='{this.id_cuenta}'";
            this.Comando.CommandText = sql;
            this.Comando.ExecuteNonQuery();
        }
        public int ObtenerIdUsuario()
        {
            string sql = $"select * from cuenta_usuario where email = '{this.email}'";
            this.Comando.CommandText = sql;
            this.Lector = this.Comando.ExecuteReader();

            ModeloPersonas mp = new ModeloPersonas();
            mp.id_cuenta = Int32.Parse(this.Lector["id_cuenta"].ToString());

            return id_cuenta;
        }
        public List<ModeloPersonas> ObtenerTodos()
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

        }

    }
}
