using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Modelo;
using System.Data;

namespace Controladores
{
    public class ControladorCuentaUsuario
    {
        public static void AltaCuentaUsuario(String nombre, string apellido, int telefono, string email, string fecha_nac, string contrasena)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.nombre = nombre;
            CuentaUsuario.apellido = apellido;
            CuentaUsuario.telefono = telefono;
            CuentaUsuario.email = email;
            CuentaUsuario.fecha_nac = fecha_nac;
            CuentaUsuario.contrasena = contrasena;

            CuentaUsuario.GuardarCuentaUsuario();
        }
        public static bool Login(string email, string contrasena)
        {
            ModeloPersonas mp = new ModeloPersonas();
            mp.email = email;
            mp.contrasena = contrasena;
            return mp.Autenticar();
        }
        public static void DeshabilitaCuentaUsuario(int id)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = id;
            CuentaUsuario.DeshabilitarCuentaUsuario();
        }
        public static void HabilitaCuentaUsuario(int id)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = id;
            CuentaUsuario.HabilitarCuentaUsuario();
        }
        public static void ModificarNombreUsuario(string id, string nombre)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.nombre = nombre;
            CuentaUsuario.ModificarNombreUsuario();
        }
        public static void ModificarApellidoUsuario(string id, string apellido)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.apellido = apellido;
            CuentaUsuario.ModificarApellidoUsuario();
        }
        public static void ModificarContrasenaUsuario(string id, string contrasena)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.contrasena = contrasena;
            CuentaUsuario.ModificarContrasenaUsuario();
        }
        public static void ModificarFechaNacimientoUsuario(string id, string fech_nac)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.fecha_nac = fech_nac;
            CuentaUsuario.ModificarFechaNacimientoUsuario();
        }
        public static void ModificarCuentaDesdeBackoffice(string id, string nombre, string apellido, string email, int telefono, string fecha_nac)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.id_cuenta = Int32.Parse(id);
            CuentaUsuario.telefono = telefono;
            CuentaUsuario.nombre = nombre;
            CuentaUsuario.apellido = apellido;
            CuentaUsuario.email = email;
            CuentaUsuario.fecha_nac = fecha_nac;
            CuentaUsuario.ModificarCuentaUsuarioBackoffice();
        }
        public static Dictionary<string, string> BuscarPorId(int id)
        {
            ModeloPersonas cuentaUsuario = new ModeloPersonas();
            cuentaUsuario.id_cuenta = id;
            return cuentaUsuario.ObtenerDatosPorId();
        }
        public static DataTable Listar()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id_cuenta", typeof(int));
            tabla.Columns.Add("nombre", typeof(string));
            tabla.Columns.Add("apellido", typeof(string));
            tabla.Columns.Add("telefono", typeof(int));
            tabla.Columns.Add("email", typeof(string));
            tabla.Columns.Add("fecha_nacimiento", typeof(string));
            tabla.Columns.Add("habilitado", typeof(Boolean));
            ModeloPersonas ListarPersonas = new ModeloPersonas();
            foreach (ModeloPersonas p in ListarPersonas.ObtenerTodos())
            {
                DataRow fila = tabla.NewRow();
                fila["id_cuenta"] = p.id_cuenta;
                fila["nombre"] = p.nombre;
                fila["apellido"] = p.apellido;
                fila["telefono"] = p.telefono;
                fila["email"] = p.email;
                fila["fecha_nacimiento"] = p.fecha_nac; 
                fila["habilitado"] = p.habilitacion;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }
    }
}


