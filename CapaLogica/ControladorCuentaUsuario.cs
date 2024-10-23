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


        public static bool LoginBackoffice(string email, string contrasena)
        {
            ModeloPersonas lb = new ModeloPersonas();
            lb.email = email;
            lb.contrasena = contrasena;
            return lb.AutenticarBackoffice();
        }


        public static void DeshabilitaCuentaUsuario(int idUsuario)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idUsuario = idUsuario;
            CuentaUsuario.DeshabilitarCuentaUsuario();
        }


        public static void HabilitaCuentaUsuario(int idUsuario)
        {
            ModeloPersonas CuentaUsuario = new ModeloPersonas();
            CuentaUsuario.idUsuario = idUsuario;
            CuentaUsuario.HabilitarCuentaUsuario();
        }

        
        public static void ModificarCuenta(string email, string emailNuevo, string nombre, string apellido, string telefono)
        {
            ModeloPersonas ModCuenta = new ModeloPersonas();
            ModCuenta.email = email;
            ModCuenta.emailNuevo = emailNuevo;
            ModCuenta.nombre = nombre;
            ModCuenta.apellido = apellido;
            ModCuenta.telefono = telefono;
            ModCuenta.ModificarCuentaUsuario();
        }

        public static void ModificarPerfil(string email, string apodo, int idFotoPerfil, string idioma, string atributo1, string atributo2, string contrasena)
        {
            ModeloPersonas ModPerf = new ModeloPersonas();
            ModPerf.email = email;
            ModPerf.apodo = apodo;
            ModPerf.idFotoPerfil = idFotoPerfil;
            ModPerf.idioma = idioma;
            ModPerf.atributo1 = atributo1;
            ModPerf.atributo2 = atributo2;
            ModPerf.contrasena = contrasena;
            ModPerf.ModificarPerfilUsuario();

        }

        public static DataTable Listar()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("ID perfil", typeof(int));
            tabla.Columns.Add("apodo", typeof(string));
            tabla.Columns.Add("Email", typeof(string));
            tabla.Columns.Add("Telefono", typeof(string));
            tabla.Columns.Add("Habilitado", typeof(bool));
            tabla.Columns.Add("ID usuario", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Apellido", typeof(string));
            tabla.Columns.Add("Contrasena", typeof(string));
            tabla.Columns.Add("Fecha Nacimiento", typeof(DateTime));
            tabla.Columns.Add("Idioma", typeof(string));
            tabla.Columns.Add("Atributo1", typeof(string));
            tabla.Columns.Add("Atributo2", typeof(string));

            ModeloPersonas ListarPersonas = new ModeloPersonas();

            foreach (ModeloPersonas p in ListarPersonas.ObtenerTodos())
            {
                DataRow fila = tabla.NewRow();
                fila["ID perfil"] = p.idPerfil;
                fila["apodo"] = p.apodo;
                fila["Email"] = p.email;
                fila["Telefono"] = p.telefono;
                fila["Habilitado"] = p.habilitacion;
                fila["ID usuario"] = p.idUsuario;
                fila["Nombre"] = p.nombre;
                fila["Apellido"] = p.apellido;
                fila["Contrasena"] = p.contrasena;
                fila["Fecha Nacimiento"] = p.fechaNacimiento;
                fila["Idioma"] = p.idioma;
                fila["Atributo1"] = p.atributo1;
                fila["Atributo2"] = p.atributo2;

                tabla.Rows.Add(fila);
            }

            return tabla;
        }
    }
}


