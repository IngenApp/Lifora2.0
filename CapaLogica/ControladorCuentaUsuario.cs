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
        public static void AltaCuentaUsuario(string nombre, string apellido, string fechaNacimiento, string email, string telefono, string contrasena)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.nombre = nombre;
            CuentaUsuario.apellido = apellido;
            CuentaUsuario.fechaNacimiento = fechaNacimiento;
            CuentaUsuario.email = email;
            CuentaUsuario.telefono = telefono;
            CuentaUsuario.contrasena = contrasena;
            CuentaUsuario.GuardarCuentaUsuario();
            
           
        }
        public static void CrearPerfil(string apodo, string email, string idioma)
        {
            ModeloPersonas crearPerfil = new ModeloPersonas();
            crearPerfil.apodo = apodo;
            crearPerfil.email = email;
            crearPerfil.idioma = idioma;

            
                crearPerfil.CrearPerfil();
            
            
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
            CuentaUsuario.idCuenta = id;
            CuentaUsuario.DeshabilitarCuentaUsuario();
        }
        public static void HabilitaCuentaUsuario(int id)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idCuenta = id;
            CuentaUsuario.HabilitarCuentaUsuario();
        }
        public static void ModificarNombreUsuario(string id, string nombre)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idCuenta = Int32.Parse(id);
            CuentaUsuario.nombre = nombre;
            
        }
        public static void ModificarApellidoUsuario(string id, string apellido)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idCuenta = Int32.Parse(id);
            CuentaUsuario.apellido = apellido;
           
        }
        public static void ModificarContrasenaUsuario(string id, string contrasena)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idCuenta = Int32.Parse(id);
            CuentaUsuario.contrasena = contrasena;
            CuentaUsuario.ModificarContrasenaUsuario();
        }
        public static void ModificarFechaNacimientoUsuario(string id, string fech_nac)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idCuenta = Int32.Parse(id);
            CuentaUsuario.fechaNacimiento= fech_nac;
            
        }
        public static void ModificarCuentaDesdeBackoffice(string id, string nombre, string apellido, string email, string telefono, string fecha_nac)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idCuenta = Int32.Parse(id);
            CuentaUsuario.telefono = telefono;
            CuentaUsuario.nombre = nombre;
            CuentaUsuario.apellido = apellido;
            CuentaUsuario.email = email;
            CuentaUsuario.fechaNacimiento = fecha_nac;
        
        }
        public static Dictionary<string, string> BuscarPorId(int id)
        {
            ModeloPersonas cuentaUsuario = new ModeloPersonas();
            cuentaUsuario.idCuenta = id;
            return cuentaUsuario.ObtenerDatosPorId();
        }
        /*public static DataTable Listar()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido", typeof(string));
            tabla.Columns.Add("Telefono", typeof(int));
            tabla.Columns.Add("Mail", typeof(string));
            tabla.Columns.Add("Fec Nac", typeof(string));
            tabla.Columns.Add("Habilitado", typeof(Boolean));
            ModeloPersonas ListarPersonas = new ModeloPersonas();
            foreach (ModeloPersonas p in ListarPersonas.ObtenerTodos())
            {
                DataRow fila = tabla.NewRow();
                fila["ID"] = p.id_cuenta;
                fila["Nombre"] = p.nombre;
                fila["Apellido"] = p.apellido;
                fila["Telefono"] = p.telefono;
                fila["Mail"] = p.email;
                fila["Fec Nac"] = p.fecha_nac; 
                fila["Habilitado"] = p.habilitacion;
                tabla.Rows.Add(fila);
            }
            return tabla;
        }*/
    }
}


